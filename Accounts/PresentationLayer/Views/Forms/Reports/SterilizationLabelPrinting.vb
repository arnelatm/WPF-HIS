Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class SterilizationLabelPrinter

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            'MainTableName = "ApJournal"
            'SortOrderKey = "IdNo"
            Presenter = New ReportPresenter(Me)
            Dim currentDate = Now()
            currentDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, currentDate.Month, currentDate.Day)
            ' returns previous month last day
            dtpExpiryDate.Value = currentDate.AddDays(-1)
            dtpProductionDate.Value = dtpExpiryDate.Value
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpProductionDate.Value <= dtpExpiryDate.Value Then
                Dim productionDate As Date?
                Dim expiryDate As Date?
                productionDate = dtpProductionDate.Value
                expiryDate = dtpExpiryDate.Value
                Dim parameter As New ArrayList
                parameter.Add({"ProductionDate", productionDate})
                parameter.Add({"ExpiryDate", expiryDate})
                'parameter.Add({"Copies", txtCopies.Text})
                Dim cForm As New ReportFormNew($"Expiry Label.Rpt", "Myreport", CultureInfo.CurrentCulture, productionDate, "ProductionDate", expiryDate, "ExpiryDate")
                cForm.Show()
            Else
                Messaging.ShowPmMessage(True, "MsgObj1MustBeLessThanObj2", {"name1", "production date", "name2", "expiry date"})
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace