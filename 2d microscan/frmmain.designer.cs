namespace LoadAndRun
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.cmbDevices = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsMain_LoadAVP = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsMain_Start = new System.Windows.Forms.ToolStripButton();
			this.tsMain_Stop = new System.Windows.Forms.ToolStripButton();
			this.splitMain = new System.Windows.Forms.SplitContainer();
			this.ctlBufView = new Visionscape.Display.Image.BufferView();
			this.grdReport = new System.Windows.Forms.DataGridView();
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsMain.SuspendLayout();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.Panel2.SuspendLayout();
			this.splitMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdReport)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.AutoSize = false;
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
			// 
			// tsMain
			// 
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.cmbDevices,
            toolStripSeparator2,
            this.toolStripSeparator3,
            this.tsMain_LoadAVP,
            this.toolStripSeparator4,
            this.toolStripSeparator1,
            this.tsMain_Start,
            this.tsMain_Stop});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Padding = new System.Windows.Forms.Padding(0);
			this.tsMain.Size = new System.Drawing.Size(649, 35);
			this.tsMain.TabIndex = 0;
			this.tsMain.Text = "toolStrip1";
			// 
			// toolStripTextBox1
			// 
			this.toolStripTextBox1.AutoSize = false;
			this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.Size = new System.Drawing.Size(60, 35);
			this.toolStripTextBox1.Text = "DEVICES:";
			// 
			// cmbDevices
			// 
			this.cmbDevices.Name = "cmbDevices";
			this.cmbDevices.Size = new System.Drawing.Size(121, 35);
			this.cmbDevices.SelectedIndexChanged += new System.EventHandler(this.cmbDevices_SelectedIndexChanged);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
			// 
			// tsMain_LoadAVP
			// 
			this.tsMain_LoadAVP.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsMain_LoadAVP.Name = "tsMain_LoadAVP";
			this.tsMain_LoadAVP.Size = new System.Drawing.Size(62, 32);
			this.tsMain_LoadAVP.Text = "Load AVP";
			this.tsMain_LoadAVP.Click += new System.EventHandler(this.tsMain_LoadAVP_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 35);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
			// 
			// tsMain_Start
			// 
			this.tsMain_Start.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsMain_Start.Margin = new System.Windows.Forms.Padding(10, 1, 2, 1);
			this.tsMain_Start.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.tsMain_Start.Name = "tsMain_Start";
			this.tsMain_Start.Size = new System.Drawing.Size(98, 33);
			this.tsMain_Start.Text = "Start Inspections";
			this.tsMain_Start.Click += new System.EventHandler(this.tsMain_Start_Click);
			// 
			// tsMain_Stop
			// 
			this.tsMain_Stop.Checked = true;
			this.tsMain_Stop.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tsMain_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsMain_Stop.Margin = new System.Windows.Forms.Padding(1, 1, 2, 1);
			this.tsMain_Stop.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.tsMain_Stop.Name = "tsMain_Stop";
			this.tsMain_Stop.Size = new System.Drawing.Size(98, 33);
			this.tsMain_Stop.Text = "Stop Inspections";
			this.tsMain_Stop.Click += new System.EventHandler(this.tsMain_Stop_Click);
			// 
			// splitMain
			// 
			this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitMain.Location = new System.Drawing.Point(0, 35);
			this.splitMain.Name = "splitMain";
			// 
			// splitMain.Panel1
			// 
			this.splitMain.Panel1.Controls.Add(this.ctlBufView);
			// 
			// splitMain.Panel2
			// 
			this.splitMain.Panel2.Controls.Add(this.grdReport);
			this.splitMain.Size = new System.Drawing.Size(649, 446);
			this.splitMain.SplitterDistance = 350;
			this.splitMain.TabIndex = 1;
			// 
			// ctlBufView
			// 
			this.ctlBufView.AutoZoom = true;
			this.ctlBufView.Buffer = null;
			this.ctlBufView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlBufView.Location = new System.Drawing.Point(0, 0);
			this.ctlBufView.Name = "ctlBufView";
			this.ctlBufView.ScrollPositionX = 0;
			this.ctlBufView.ScrollPositionY = 0;
			this.ctlBufView.ShowStatusBar = true;
			this.ctlBufView.Size = new System.Drawing.Size(350, 446);
			this.ctlBufView.TabIndex = 0;
			this.ctlBufView.ZoomFactor = 1D;
			// 
			// grdReport
			// 
			this.grdReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdReport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdReport.Location = new System.Drawing.Point(0, 0);
			this.grdReport.Name = "grdReport";
			this.grdReport.Size = new System.Drawing.Size(295, 446);
			this.grdReport.TabIndex = 2;
			// 
			// dlgOpenFile
			// 
			this.dlgOpenFile.FileName = "openFileDialog1";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(649, 481);
			this.Controls.Add(this.splitMain);
			this.Controls.Add(this.tsMain);
			this.Name = "frmMain";
			this.Text = "Load and Run Sample";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.Panel2.ResumeLayout(false);
			this.splitMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdReport)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.ToolStripButton tsMain_LoadAVP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsMain_Start;
        private System.Windows.Forms.ToolStripButton tsMain_Stop;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripComboBox cmbDevices;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private Visionscape.Display.Image.BufferView ctlBufView;
        private System.Windows.Forms.DataGridView grdReport;

    }
}

