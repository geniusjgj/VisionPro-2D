using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Visionscape.Devices;
using Visionscape.Steps;
using Visionscape.Communications;

namespace LoadAndRun
{
    public partial class frmMain : Form
    {
        //Constants
        const int RESULTS_ROW = 6;

        //member variables
        VsCoordinator _coord; //the coordinator object tells us what hardware is available
        VsDevice _device;   //a reference to our chosen Visionscape Device
        JobStep _job; //reference to the loaded avp
        VisionSystemStep _vsStep; //the VisionSystem step
        ReportConnection _reportConnection; //We will use this object to receive images and results from the inspection
        InspectionReport _report; //reference to the most recently uploaded inspection report
        LoadAndRun.Settings _appSettings;
        private bool _bStartingUp = false;

#region frmMain_events

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {    
            //instantiate our components
            _coord = new VsCoordinator();
            _job = new JobStep();

            //Load the combo box with a list of all available Devices
            LoadDeviceCombo();

            //wire up our event handlers to notify us of...
            ///  ...newly discovered devices
            _coord.OnDeviceDiscovered += _coord_OnDeviceDiscovered;
            //   .. when a Device receives Focus
            _coord.OnDeviceFocus += new _IVsCoordinatorEvents_OnDeviceFocusEventHandler(_coord_OnDeviceFocus);

            //init the data grid we will use to display results
            InitResultGrid();

            //did we select a device the last time we ran?
            _appSettings = new LoadAndRun.Settings();
            if (_appSettings.LastDevice != "")
            { //Yes.  We now need to wait for this device to be discovered, so we ask the 
                // VsCoordinator object to notify us of it's discovery with the OnDeviceFocus event.
                //  If the device has already been discovered, then the event will fire immediately.
                _coord.DeviceFocusSetOnDiscovery(_appSettings.LastDevice, -1);
                _bStartingUp = true;
            }
            
            UpdateUI();
        }

        /// <summary>
        /// Our startup initialization will continue here, once our selected Device is discovered.
        /// </summary>
        /// <param name="objDevice"></param>
        void _coord_OnDeviceFocus(VsDevice objDevice)
        {
            _device = objDevice;
            
            cmbDevices.SelectedItem = _device.Name;
            //do we have a last loaded Job?
            if (_appSettings.LastAVPFile != "")
                LoadJob(_appSettings.LastAVPFile);

            _bStartingUp = false;
            UpdateUI();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _appSettings.Save();
            CleanUp();
        }
#endregion

        private bool LoadJob(string strJobPath)
        {
            if (_device == null || strJobPath == "")
                return false;
            
            //cleanup from the previous job, if there is one
            CleanUp();

            try
            {   //load the specified job
                _job.Load(strJobPath);

                //download to the device and wait for the download to complete
                TransferStatus xferstat = _device.Download(_job, false);
                if (xferstat == TransferStatus.TransferOK)
                {
                    while (_device.CheckXferStatus(10) == tagXFERSTATUS.XFER_IN_PROGRESS)
                    {
                        //pump messages while we're waiting
                        Application.DoEvents();
                    }
                }

                //connect our ReportConnection
                ConnectReports(_device, 1);

                UpdateUI();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to Load the Specified Job" + strJobPath + "\n" + e.Message,
                    "LoadJob Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                UpdateUI();
                return false;
            }
        }

        private void CleanUp()
        {
            //disconnect our report connection first
            if(_reportConnection != null)
                _reportConnection.Disconnect();

            //stop all inspections
            if (_device != null)
                _device.StopInspection(-1);

            //clear the job from memory
            while (_job.Count > 0)
                _job.Remove(1);
        }

#region report_handling

        private bool ConnectReports(VsDevice dev, int InspectionIndex)
        {
            try
            {
                if (_reportConnection == null)
                {
                    _reportConnection = new ReportConnection();
                    _reportConnection.NewReport += OnNewReportEventHandler;
                }

                if (_reportConnection.IsConnected)
                    _reportConnection.Disconnect();

                //Connect the Report Connection to the specified inspection on the specified device
                _reportConnection.Connect(dev.Name, InspectionIndex);

                //Add the first snapshot buffer to our report
                AddImageToReport(_reportConnection, (Step)_job);

                return _reportConnection.IsConnected;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception thrown in ConnectReports: " + e.Message);
                return false;
            }
        }

        private void AddImageToReport(ReportConnection repcon, Step parentStep)
        {   //find the first snapshot step under the Step "parentStep"
            Step snap = (Step)parentStep.Find("Step.Snapshot", EnumAvpFindOption.FIND_BY_TYPE);
            //Add the output buffer of the snapshot to list of data records being uploaded by the inspection.
            //  you must specify the symbolic name of the step and the datum to be uploaded.
            //    e.g. "Snapshot1.BufOut", where BufOut is the symbolic name of the snapshot's output buffer
            if(snap != null)
                repcon.DataRecordAdd(snap.NameSym + ".BufOut");
            //NOTE: The above logic can also be accomplished by simply calling this method:  repcon.AddSnapBuffers(_job);
        }

        private void OnNewReportEventHandler(object sender, ReportConnectionEventArgs e)
        {
            _report = e.Report; //hold a reference to the most recent report, so our images won't get destroyed
            if (_report.Images.Count > 0)
            {
                BufferDm buf = (BufferDm)_report.Images[0];
                ctlBufView.Buffer = buf;
            }

            UpdateStats(_report);

            UpdateResults(_report);
        }

        private void UpdateStats(InspectionReport  rptObj)
        {
            ReportInspectionStats stats = rptObj.InspectionStats;

            if (stats.Passed)
            {
                grdReport.Rows[0].Cells[1].Style.BackColor = Color.Green;
                grdReport.Rows[0].Cells[1].Value = "Passed";
            }
            else
            {
                grdReport.Rows[0].Cells[1].Style.BackColor = Color.Red;
                grdReport.Rows[0].Cells[1].Value = "Failed";
            }

            grdReport.Rows[1].Cells[1].Value = stats.CycleCount;
            grdReport.Rows[2].Cells[1].Value = stats.PassedCount;
            grdReport.Rows[3].Cells[1].Value = stats.FailedCount;
            grdReport.Rows[4].Cells[1].Value = stats.Snapshot[0].TriggerOverruns + stats.Snapshot[0].ProcessOverruns;
        }

        private void UpdateResults(InspectionReport rptObj)
        {
            ReportResultList results = rptObj.Results;
            
            //do we need to expand the array to hold our results?
            if(results.Count + RESULTS_ROW > grdReport.RowCount)
                grdReport.RowCount = results.Count + RESULTS_ROW;

            int row = RESULTS_ROW;
            foreach (InspectionReportValue result in results)
            {
                Object data = result.AsObject; //get the result data as an object
                string strData = FormatData(data);//format the data into a displayable string
                Console.WriteLine( "Type = " + result.Type);
                grdReport.Rows[row].Cells[0].Value = result.Name;
                grdReport.Rows[row++].Cells[1].Value = strData;
            }
        }
        
        private void InitResultGrid()
        {   //initialize the grid to have enough rows for our stats and one result (to start)
            grdReport.ColumnCount = 2;
            grdReport.RowCount = 7;
            grdReport.RowHeadersVisible = false;
            grdReport.ColumnHeadersVisible = false;

            //set autosizing for the columns
            grdReport.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grdReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //now load the headers
            string[] strHeaders = { "STATS", "Inspected", "Passed", "Rejected", "Overruns", "RESULTS" };

            for (int i = 0; i < strHeaders.Length; ++i)
            {
                grdReport.Rows[i].Cells[0].Value = strHeaders[i];
            }
        }

        private string FormatData(Object data)
        {
			if (data == null) return "";
			
			Type datatype = data.GetType();
            String strResult;

            if (datatype == typeof(Object[,])) //is this a 2D array?
            {
                Object[,] datArray = (Object[,])data;
                StringBuilder strArr = new StringBuilder("");
                int ubound = datArray.GetUpperBound(0);
                int ubound2 = datArray.GetUpperBound(1); //does it have a second dimension?

                    
                for (int r = 0; r <= ubound; ++r)
                {
                    for (int c = 0; c <= ubound2; ++c)
                    {
                        if (strArr.Length > 0)
                            strArr.Append(", ");//separate elements with a comma
                                                
                        strArr.Append(FormatScalar(datArray[r,c]));
                    }
                    strArr.Append("\r\n"); //append carriage return and line feed to the end of each row
                }
                strResult = strArr.ToString();
            }
            else if(datatype == typeof(Object[])) //Is this a 1D array?
            {
                Object[] arrDat = (Object[])data;
                StringBuilder strArr = new StringBuilder("");
                foreach (Object dat in arrDat)
                {
                    if (strArr.Length > 0)
                        strArr.Append(", ");
                        
                    strArr.Append(FormatScalar(dat));                        
                }
                
                strResult = strArr.ToString();
            }
            else //must be scalar
            {

                strResult = FormatScalar(data);
            }

            return strResult;
        }

        private string FormatScalar(Object data)
        {
            Type datatype = data.GetType();
            string strResult;
            if (datatype == typeof(float) || datatype == typeof(double))
            {
                strResult = String.Format("{0:0.####}" ,data);
            }
            else
            {
                strResult = data.ToString();
            }
            return strResult;
        }
#endregion

        private void LoadDeviceCombo()
        {   //loop through all of the devices in the VsCoordinator's
            //  Devices collection, add the name of each to our combo
            foreach(VsDevice dev in _coord.Devices)
            {
                cmbDevices.Items.Add(dev.Name);
            };
        }

        private void UpdateUI()
        {
            bool bHaveJob = _job.Count > 0;
            bool bHaveDevice = (_device != null);
            bool bIsRunning = (_device != null) && _device.IsAnyInspectionRunning;

            tsMain_LoadAVP.Enabled = bHaveDevice && !bIsRunning;
            //start button
            tsMain_Start.Enabled = bHaveDevice && bHaveJob;
            tsMain_Start.Checked = bIsRunning;
            //stop button
            tsMain_Stop.Enabled = tsMain_Start.Enabled;
            tsMain_Stop.Checked = !bIsRunning;

            //update the window caption
            this.Text = "Visionscape .NET Sample: ";
            if (_bStartingUp)
                this.Text += "< Waiting for Device Discovery...>";
            else
            {
                if (_appSettings.LastDevice.Length == 0)
                {
                    this.Text += "<No Device Selected>";
                }
                else if (_appSettings.LastAVPFile == "")
                    this.Text += "< no job loaded >";
                else
                    this.Text += _appSettings.LastAVPFile;
            }
        }

        void _coord_OnDeviceDiscovered(VsDevice newDevice)
        {
            cmbDevices.Items.Add(newDevice.Name);
        }

        private void tsMain_Start_Click(object sender, EventArgs e)
        {
            if (_device != null)
                _device.StartAll();// start all inspections

            UpdateUI();
        }

        private void tsMain_Stop_Click(object sender, EventArgs e)
        {
            if (_device != null)
                _device.StopAll(); // stop all inspections
            UpdateUI();
        }

        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            VsDevice newDevice = _coord.FindDeviceByName(cmbDevices.SelectedItem.ToString());
            if (newDevice != null && newDevice != _device)
            {
                CleanUp();
                _appSettings.LastAVPFile = "";
                _device = newDevice;
                _appSettings.LastDevice = _device.Name;
            }

            UpdateUI();
        }

        private void tsMain_LoadAVP_Click(object sender, EventArgs e)
        {
            //Configure our Open File Dialog
            dlgOpenFile.DefaultExt = "*.AVP";
            dlgOpenFile.Title = "Load an AVP file";

            //ask the user to select the AVP file
            dlgOpenFile.ShowDialog();

            //did they choose a file?
            if (dlgOpenFile.FileName != "")
            {   //load it
                bool bResult = LoadJob(dlgOpenFile.FileName);
                //if the job was successfully loaded, save the 
                //  file name to our app settings object
                if (bResult)
                    _appSettings.LastAVPFile = dlgOpenFile.FileName;
            }
            UpdateUI();
        }
        
    }
}
