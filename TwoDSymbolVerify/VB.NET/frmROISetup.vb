Public Class frmROISetup

    Private Sub btn_ROI_Setup_Click(sender As Object, e As EventArgs) Handles btn_ROI_Setup.Click

        frmTwoDSymbolVerify.DisplaySearchRegion(x_ROI.Text, y_ROI.Text, width_ROI.Text, height_ROI.Text)

    End Sub

    Private Sub btn_ROI_Reset_Click(sender As Object, e As EventArgs) Handles btn_ROI_Reset.Click

    End Sub

    Private Sub frmROISetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 500)

    End Sub
End Class