Public Class Form4
    Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea
        dim number As Double
        number = CTextBox1.Text
        CLabel1.Text = AATM.Libraries.GlobalFuncNSub.DecimalToFraction(number,32)
        CLabel2.Text = AATM.Libraries.GlobalFuncNSub.RealToFraction(number,0.0001)
        CLabel3.Text = AATM.Libraries.GlobalFuncNSub.GetDecimalToFraction(number,32,"U")

    End Sub
End Class