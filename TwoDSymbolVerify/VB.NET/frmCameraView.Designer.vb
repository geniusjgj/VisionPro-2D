<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCameraView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCameraView))
        Me.DisplayWindow = New System.Windows.Forms.PictureBox()
        Me.CB_Auto_White_Balance = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartLiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopLiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CaptureImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtExposure = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CB_Auto_Gain_Balance = New System.Windows.Forms.CheckBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        CType(Me.DisplayWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DisplayWindow
        '
        Me.DisplayWindow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DisplayWindow.Image = CType(resources.GetObject("DisplayWindow.Image"), System.Drawing.Image)
        Me.DisplayWindow.Location = New System.Drawing.Point(12, 77)
        Me.DisplayWindow.Name = "DisplayWindow"
        Me.DisplayWindow.Size = New System.Drawing.Size(416, 347)
        Me.DisplayWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.DisplayWindow.TabIndex = 9
        Me.DisplayWindow.TabStop = False
        '
        'CB_Auto_White_Balance
        '
        Me.CB_Auto_White_Balance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CB_Auto_White_Balance.AutoSize = True
        Me.CB_Auto_White_Balance.Location = New System.Drawing.Point(19, 29)
        Me.CB_Auto_White_Balance.Name = "CB_Auto_White_Balance"
        Me.CB_Auto_White_Balance.Size = New System.Drawing.Size(121, 17)
        Me.CB_Auto_White_Balance.TabIndex = 18
        Me.CB_Auto_White_Balance.Text = "Auto White Balance"
        Me.CB_Auto_White_Balance.UseVisualStyleBackColor = True
        Me.CB_Auto_White_Balance.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(434, 24)
        Me.MenuStrip1.TabIndex = 22
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartLiveToolStripMenuItem, Me.StopLiveToolStripMenuItem, Me.CaptureImageToolStripMenuItem, Me.ExitToolStripMenuItem, Me.ExitToolStripMenuItem1})
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.StartToolStripMenuItem.Text = "Function"
        '
        'StartLiveToolStripMenuItem
        '
        Me.StartLiveToolStripMenuItem.Name = "StartLiveToolStripMenuItem"
        Me.StartLiveToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.StartLiveToolStripMenuItem.Text = "Start Live"
        '
        'StopLiveToolStripMenuItem
        '
        Me.StopLiveToolStripMenuItem.Name = "StopLiveToolStripMenuItem"
        Me.StopLiveToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.StopLiveToolStripMenuItem.Text = "Stop Live"
        '
        'CaptureImageToolStripMenuItem
        '
        Me.CaptureImageToolStripMenuItem.Name = "CaptureImageToolStripMenuItem"
        Me.CaptureImageToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.CaptureImageToolStripMenuItem.Text = "Capture Image"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ExitToolStripMenuItem.Text = "Load Parameter"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'txtExposure
        '
        Me.txtExposure.Location = New System.Drawing.Point(246, 40)
        Me.txtExposure.Name = "txtExposure"
        Me.txtExposure.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtExposure.Size = New System.Drawing.Size(36, 20)
        Me.txtExposure.TabIndex = 23
        Me.txtExposure.Text = "0"
        Me.txtExposure.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Brightness"
        '
        'CB_Auto_Gain_Balance
        '
        Me.CB_Auto_Gain_Balance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CB_Auto_Gain_Balance.AutoSize = True
        Me.CB_Auto_Gain_Balance.Location = New System.Drawing.Point(146, 29)
        Me.CB_Auto_Gain_Balance.Name = "CB_Auto_Gain_Balance"
        Me.CB_Auto_Gain_Balance.Size = New System.Drawing.Size(115, 17)
        Me.CB_Auto_Gain_Balance.TabIndex = 19
        Me.CB_Auto_Gain_Balance.Text = "Auto Gain Balance"
        Me.CB_Auto_Gain_Balance.UseVisualStyleBackColor = True
        Me.CB_Auto_Gain_Balance.Visible = False
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 24)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 438)
        Me.Splitter1.TabIndex = 26
        Me.Splitter1.TabStop = False
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(136, 31)
        Me.TrackBar1.Minimum = 8
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(70, 45)
        Me.TrackBar1.TabIndex = 27
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBar1.Value = 8
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(434, 462)
        Me.ShapeContainer1.TabIndex = 28
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Location = New System.Drawing.Point(0, 0)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(75, 23)
        '
        'frmCameraView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 462)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.CB_Auto_White_Balance)
        Me.Controls.Add(Me.CB_Auto_Gain_Balance)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtExposure)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DisplayWindow)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmCameraView"
        Me.Text = "Camera View"
        CType(Me.DisplayWindow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DisplayWindow As System.Windows.Forms.PictureBox
    Friend WithEvents CB_Auto_White_Balance As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents StartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartLiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopLiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CaptureImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtExposure As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_Auto_Gain_Balance As System.Windows.Forms.CheckBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
End Class
