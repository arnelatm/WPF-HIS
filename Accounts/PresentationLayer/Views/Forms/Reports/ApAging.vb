Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Libraries.MessagingLibrary

Public Class ApAging
    Public Sub New(ByVal currentCulture As CultureInfo)
        Dim reportTitle = Messaging.TranslateCaption("Aging of Accounts Payable")
        Dim cForm As New ReportFormNew("Aging of Accounts Payable.Rpt", reportTitle, currentCulture)
        cForm.Show()
    End Sub
End Class
