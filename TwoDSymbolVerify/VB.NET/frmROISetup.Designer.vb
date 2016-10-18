<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmROISetup
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
        Me.x_ROI = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.y_ROI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.width_ROI = New System.Windows.Forms.TextBox()
        Me.height_ROI = New System.Windows.Forms.TextBox()
        Me.btn_ROI_Setup = New System.Windows.Forms.Button()
        Me.btn_ROI_Reset = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'x_ROI
        '
        Me.x_ROI.Location = New System.Drawing.Point(93, 32)
        Me.x_ROI.Name = "x_ROI"
        Me.x_ROI.Size = New System.Drawing.Size(100, 20)
        Me.x_ROI.TabIndex = 5
        Me.x_ROI.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Origin:"
        '
        'y_ROI
        '
        Me.y_ROI.Location = New System.Drawing.Point(221, 32)
        Me.y_ROI.Name = "y_ROI"
        Me.y_ROI.Size = New System.Drawing.Size(100, 20)
        Me.y_ROI.TabIndex = 7
        Me.y_ROI.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Size:"
        '
        'width_ROI
        '
        Me.width_ROI.Location = New System.Drawing.Point(93, 81)
        Me.width_ROI.Name = "width_ROI"
        Me.width_ROI.Size = New System.Drawing.Size(100, 20)
        Me.width_ROI.TabIndex = 9
        Me.width_ROI.Text = "1280"
        '
        'height_ROI
        '
        Me.height_ROI.Location = New System.Drawing.Point(221, 81)
        Me.height_ROI.Name = "height_ROI"
        Me.height_ROI.Size = New System.Drawing.Size(100, 20)
        Me.height_ROI.TabIndex = 10
        Me.height_ROI.Text = "1024"
        '
        'btn_ROI_Setup
        '
        Me.btn_ROI_Setup.Location = New System.Drawing.Point(93, 124)
        Me.btn_ROI_Setup.Name = "btn_ROI_Setup"
        Me.btn_ROI_Setup.Size = New System.Drawing.Size(75, 23)
        Me.btn_ROI_Setup.TabIndex = 11
        Me.btn_ROI_Setup.Text = "Apply ROI"
        Me.btn_ROI_Setup.UseVisualStyleBackColor = True
        '
        'btn_ROI_Reset
        '
        Me.btn_ROI_Reset.Location = New System.Drawing.Point(221, 124)
        Me.btn_ROI_Reset.Name = "btn_ROI_Reset"
        Me.btn_ROI_Reset.Size = New System.Drawing.Size(75, 23)
        Me.btn_ROI_Reset.TabIndex = 12
        Me.btn_ROI_Reset.Text = "Reset ROI"
        Me.btn_ROI_Reset.UseVisualStyleBackColor = True
        '
        'frmROISetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 177)
        Me.Controls.Add(Me.btn_ROI_Reset)
        Me.Controls.Add(Me.btn_ROI_Setup)
        Me.Controls.Add(Me.height_ROI)
        Me.Controls.Add(Me.width_ROI)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.y_ROI)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.x_ROI)
        Me.Name = "frmROISetup"
        Me.Text = "frmROISetup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents x_ROI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents y_ROI As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents width_ROI As System.Windows.Forms.TextBox
    Friend WithEvents height_ROI As System.Windows.Forms.TextBox
    Friend WithEvents btn_ROI_Setup As System.Windows.Forms.Button
    Friend WithEvents btn_ROI_Reset As System.Windows.Forms.Button
End Class
