Imports System.Drawing

Public Class dlgTimeColors

    Private Sub TimeColorsUIEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadColors()

    End Sub

    Private Sub LoadColors()
        With gTimePickerColors.TimeColors
            ccbClockFaceOuter.SelectedIndex = ccbClockFaceOuter.FindStringExact(.FaceOuter.Name)
            ccbClockFaceInner.SelectedIndex = ccbClockFaceInner.FindStringExact(.FaceInner.Name)
            ccbClockFrameOuter.SelectedIndex = ccbClockFrameOuter.FindStringExact(.FrameOuter.Name)
            ccbClockFrameInner.SelectedIndex = ccbClockFrameInner.FindStringExact(.FrameInner.Name)
            ccbHourHand.SelectedIndex = ccbHourHand.FindStringExact(.HourHand.Name)
            ccbHourNum.SelectedIndex = ccbHourNum.FindStringExact(.Hour.Name)
            ccbMinuteHand.SelectedIndex = ccbMinuteHand.FindStringExact(.MinuteHand.Name)
            ccbMinuteNum.SelectedIndex = ccbMinuteNum.FindStringExact(.Minute.Name)
            ccbMinutePlus.SelectedIndex = ccbMinutePlus.FindStringExact(.MinutePlus.Name)
            ccbBox.SelectedIndex = ccbBox.FindStringExact(.Box.Name)
            ccbDisplayTime.SelectedIndex = ccbDisplayTime.FindStringExact(.DisplayTime.Name)
            ccbTimeAMPMOn.SelectedIndex = ccbTimeAMPMOn.FindStringExact(.TimeAMPM_ON.Name)
            ccbTimeAMPMOff.SelectedIndex = ccbTimeAMPMOff.FindStringExact(.TimeAMPM_OFF.Name)
            ccbBackColor.SelectedIndex = ccbBackColor.FindStringExact(.BackGround.Name)

        End With
    End Sub

    Private Sub ccbMinuteNum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ccbMinuteNum.SelectedIndexChanged

        gTimePickerColors.TimeColors.Minute = Color.FromName(ccbMinuteNum.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub ccbBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ccbBox.SelectedIndexChanged

        gTimePickerColors.TimeColors.Box = Color.FromName(ccbBox.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub ccbHourHand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ccbHourHand.SelectedIndexChanged

        gTimePickerColors.TimeColors.HourHand = Color.FromName(ccbHourHand.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub ccbClockFaceInner_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ccbClockFaceInner.SelectedIndexChanged

        gTimePickerColors.TimeColors.FaceInner = Color.FromName(ccbClockFaceInner.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub ccbDisplayTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ccbDisplayTime.SelectedIndexChanged

        gTimePickerColors.TimeColors.DisplayTime = Color.FromName(ccbDisplayTime.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub ccbHourNum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ccbHourNum.SelectedIndexChanged

        gTimePickerColors.TimeColors.Hour = Color.FromName(ccbHourNum.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub ccbTimeAMPMOn_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ccbTimeAMPMOn.SelectedIndexChanged

        gTimePickerColors.TimeColors.TimeAMPM_ON = Color.FromName(ccbTimeAMPMOn.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub ccbMinuteHand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ccbMinuteHand.SelectedIndexChanged

        gTimePickerColors.TimeColors.MinuteHand = Color.FromName(ccbMinuteHand.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub ccbMinutePlus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ccbMinutePlus.SelectedIndexChanged

        gTimePickerColors.TimeColors.MinutePlus = Color.FromName(ccbMinutePlus.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub ccbClockFrameInner_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ccbClockFrameInner.SelectedIndexChanged

        gTimePickerColors.TimeColors.FrameInner = Color.FromName(ccbClockFrameInner.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub ccbTimeAMPMOff_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ccbTimeAMPMOff.SelectedIndexChanged

        gTimePickerColors.TimeColors.TimeAMPM_OFF = Color.FromName(ccbTimeAMPMOff.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub ccbClockFaceOuter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ccbClockFaceOuter.SelectedIndexChanged

        gTimePickerColors.TimeColors.FaceOuter = Color.FromName(ccbClockFaceOuter.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub ccbClockFrameOuter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ccbClockFrameOuter.SelectedIndexChanged

        gTimePickerColors.TimeColors.FrameOuter = Color.FromName(ccbClockFrameOuter.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub ccbBackColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ccbBackColor.SelectedIndexChanged

        Panel1.BackColor = Color.FromName(ccbBackColor.Text)
        gTimePickerColors.TimeColors.BackGround = Color.FromName(ccbBackColor.Text)
        gTimePickerColors.Refresh()

    End Sub

    Private Sub cboColorTheme_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboColorTheme.SelectedIndexChanged
        Select Case cboColorTheme.Text
            Case "Default"
                gTimePickerColors.TimeColors = New TimeColors
            Case "Blue"
                gTimePickerColors.TimeColors = gTimePickerColors.cBlue
            Case "Red"
                gTimePickerColors.TimeColors = gTimePickerColors.cRed
            Case "Green"
                gTimePickerColors.TimeColors = gTimePickerColors.cGreen
            Case "Yellow"
                gTimePickerColors.TimeColors = gTimePickerColors.cYellow
        End Select
        LoadColors()
    End Sub

    Private Sub butExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Close()
    End Sub

End Class