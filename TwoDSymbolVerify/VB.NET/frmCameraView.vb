Public Class frmCameraView
    Dim WithEvents camera As New uEye.Camera()
    Dim DisplayHandle As IntPtr
    Dim bLive As Boolean
    Dim valExposure As Double

    Private Sub frmCameraView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Location = New Point(0, 0)
        DisplayHandle = DisplayWindow.Handle

        CameraInit()

        camera.Timing.Exposure.Get(valExposure)
        TrackBar1.Maximum = Int(valExposure)
        TrackBar1.Value = Int(valExposure)
        txtExposure.Text = Int(valExposure)
    End Sub

    Private Sub EventHandler() Handles camera.EventFrame

        'Event
        Dim s32MemID As Int32
        camera.Memory.GetActive(s32MemID)
        camera.Display.Render(s32MemID, DisplayHandle, uEye.Defines.DisplayRenderMode.FitToWindow)

    End Sub


    Private Sub CameraInit()

        Dim s32MemID As Int32
        Dim statusRet As uEye.Defines.Status
        'Open Camera
        statusRet = camera.Init()
        camera.PixelFormat.Set(uEye.Defines.ColorMode.Mono8)

        If (statusRet <> uEye.Defines.Status.Success) Then

            MessageBox.Show("Camera initializing failed")

        End If

        'Allocate Memory
        statusRet = camera.Memory.Allocate(s32MemID, True)
        If (statusRet <> uEye.Defines.Status.Success) Then

            MessageBox.Show("Allocate Memory failed")

        End If

        'Start Live
        statusRet = camera.Acquisition.Capture()
        If (statusRet <> uEye.Defines.Status.Success) Then

            MessageBox.Show("Start Live Video failed")

        Else

            bLive = True

        End If
        camera.Device.Feature.ImageEffect.Set(uEye.Defines.ImageEffectMode.Crosshair)



        ' CB_Auto_Gain_Balance.Enabled = camera.AutoFeatures.Software.Gain.Supported
        ' CB_Auto_White_Balance.Enabled = camera.AutoFeatures.Software.WhiteBalance.Supported

    End Sub

    Private Sub CB_Auto_White_Balance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Auto_White_Balance.CheckedChanged

        'CheckBox Auto White Balance
        camera.AutoFeatures.Software.WhiteBalance.SetEnable(CB_Auto_White_Balance.Checked)

    End Sub


    Private Sub CB_Auto_Gain_Balance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Auto_Gain_Balance.CheckedChanged

        'CheckBox Auto Gain Balance
        camera.AutoFeatures.Software.Gain.SetEnable(CB_Auto_Gain_Balance.Checked)

    End Sub

    Private Sub btnCaptureImage_Click(sender As Object, e As EventArgs)
    End Sub

    Public Sub CaptureImage()

        Const strFileName As String = "/Images/test2.bmp"
        Dim strBaseDir As String
        strBaseDir = Environ("VPRO_ROOT")
        'Stop Live Video
        ' If (camera.Acquisition.Stop() = uEye.Defines.Status.Success) Then

        ' bLive = False

        camera.Image.Save(strBaseDir & strFileName, System.Drawing.Imaging.ImageFormat.Bmp)

        ' End If
    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click

    End Sub

    Private Sub StartLiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartLiveToolStripMenuItem.Click

        'Start Live Video
        If (camera.Acquisition.Capture() = uEye.Defines.Status.Success) Then

            bLive = True

        End If
    End Sub

    Private Sub StopLiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopLiveToolStripMenuItem.Click
        'Stop Live Video
        If (camera.Acquisition.Stop() = uEye.Defines.Status.Success) Then

            bLive = False

        End If

    End Sub

    Private Sub CaptureImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CaptureImageToolStripMenuItem.Click
        CaptureImage()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        'Load Parameters
        camera.Acquisition.Stop()
        camera.Parameter.Load("")

        If (bLive = True) Then

            If (camera.Acquisition.Capture() = uEye.Defines.Status.Success) Then

                bLive = True

            End If

        End If

    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click

        'Close the Camera
        camera.Exit()

        'Program Exit
        Close()

    End Sub

    Private Sub btnSetPara_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtExposure_TextChanged(sender As Object, e As EventArgs) Handles txtExposure.TextChanged
        valExposure = Int(txtExposure.Text)
        camera.Timing.Exposure.Set(valExposure)
        bLive = True
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        valExposure = Int(TrackBar1.Value)
        camera.Timing.Exposure.Set(valExposure)
        bLive = True
        txtExposure.Text = Int(valExposure)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class