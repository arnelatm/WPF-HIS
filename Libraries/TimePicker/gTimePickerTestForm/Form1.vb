Public Class Form1

#Disable Warning BC30590 ' Event 'TimePicked' cannot be found.
    Private Sub GTimePicker2_TimePicked(ByVal sender As System.Object) Handles GTimePicker2.TimePicked
#Enable Warning BC30590 ' Event 'TimePicked' cannot be found.
        TextBox1.Text = GTimePicker2.ToStringAMPM
    End Sub

#Disable Warning BC30590 ' Event 'TimePicked' cannot be found.
    Private Sub GTimePicker1_TimePicked(ByVal sender As System.Object) Handles GTimePicker1.TimePicked
#Enable Warning BC30590 ' Event 'TimePicked' cannot be found.
        Label1.Text = "You picked " & GTimePicker1.Time
    End Sub

#Disable Warning BC30590 ' Event 'ValueOrNullChanged' cannot be found.
    Private Sub GDateTimePicker2_ValueOrNullChanged(ByVal sender As System.Object) Handles GDateTimePicker2.ValueOrNullChanged
#Enable Warning BC30590 ' Event 'ValueOrNullChanged' cannot be found.
        UpdateDateTime()
    End Sub

    Sub UpdateDateTime()
        TextBox2.Text = String.Concat(GDateTimePicker2.ValueToString(DateTimePickerFormat.Long), " ", GTimePicker4.ToStringAMPM)
    End Sub

#Disable Warning BC30590 ' Event 'TimePicked' cannot be found.
    Private Sub GTimePicker4_TimePicked(ByVal sender As System.Object) Handles GTimePicker4.TimePicked
#Enable Warning BC30590 ' Event 'TimePicked' cannot be found.
        UpdateDateTime()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GDateTimePicker1.gValue = Nothing
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GDateTimePicker1.gValue = Today
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        GDateTimePicker1.gFormat = DateTimePickerFormat.Short
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        GDateTimePicker1.gFormat = DateTimePickerFormat.Long
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        GDateTimePicker1.gFormat = DateTimePickerFormat.Custom
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        GDateTimePicker1.gFormatString = TextBox4.Text
    End Sub

#Disable Warning BC30590 ' Event 'ValueOrNullChanged' cannot be found.
    Private Sub GDateTimePicker1_ValueOrNullChanged(ByVal sender As Object) Handles GDateTimePicker1.ValueOrNullChanged
#Enable Warning BC30590 ' Event 'ValueOrNullChanged' cannot be found.
        TextBox3.Text = GDateTimePicker1.ValueToString(OutputString)
    End Sub

    Dim OutputString As DateTimePickerFormat = DateTimePickerFormat.Long

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        OutputString = DateTimePickerFormat.Short
        TextBox3.Text = GDateTimePicker1.ValueToString(OutputString)
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        OutputString = DateTimePickerFormat.Long
        TextBox3.Text = GDateTimePicker1.ValueToString(OutputString)
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        OutputString = DateTimePickerFormat.Custom
        TextBox3.Text = GDateTimePicker1.ValueToString(OutputString)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form2.ShowDialog()

    End Sub

    Private tTime As String
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblNowTime.Text = Now.ToLongTimeString

        If CheckBox1.Checked Then
            Dim nTime As String = String.Format("{0}:{1} {2}", _
                                      Now.Hour, _
                                      Now.Minute, _
                                      IIf(Now.Hour < 12, "AM", "PM"))
            If GTimePickerCntrl1.Time <> String.Empty _
              AndAlso tTime <> nTime Then
                GTimePickerCntrl1.Time = Now.ToShortTimeString
                tTime = nTime
            End If
        End If
    End Sub

#Disable Warning BC30590 ' Event 'TimePicked' cannot be found.
    Private Sub GTimePickerCntrl1_TimePicked(ByVal sender As System.Object) Handles GTimePickerCntrl1.TimePicked
#Enable Warning BC30590 ' Event 'TimePicked' cannot be found.
        tTime = String.Format("{0:0#}:{1:0#} {2}", _
                    GTimePickerCntrl1.Hour, _
                    GTimePickerCntrl1.Minute, _
                    GTimePickerCntrl1.TimeAMPM.ToString)
        Label3.Text = GTimePickerCntrl1.Time
        Label4.Text = tTime
        Label5.Text = GTimePickerCntrl1.ToStringAMPM
        Label6.Text = GTimePickerCntrl1.TimeAMPM.ToString
        Label7.Text = GTimePickerCntrl1.Hour
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Timer1.Start()
    End Sub

    Private Sub chkMidMins_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMidMins.CheckedChanged
        GTimePickerCntrl1.ShowMidMins = chkMidMins.Checked
    End Sub

    Private Sub chkTrueHour_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTrueHour.CheckedChanged
        GTimePickerCntrl1.TrueHour = chkTrueHour.Checked
    End Sub

    Private Sub chk24Hour_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk24Hour.CheckedChanged
        GTimePickerCntrl1.Hr24 = chk24Hour.Checked

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        GTimePickerCntrl1.Time = TextBox5.Text
    End Sub
End Class
