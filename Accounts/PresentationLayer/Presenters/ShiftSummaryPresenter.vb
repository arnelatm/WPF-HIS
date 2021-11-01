Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class ShiftSummaryPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IShiftSummaryView, TM)

        Public Sub New(itemView As IShiftSummaryView)
            MyBase.New(itemView)
            Service = New AccountsService("ShiftSummary")
            TableName = "ShiftSummary"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            Dim time = Today
            View.DateStart = time
            View.DateEnd = time
        End Sub

        Public Overrides Sub GoPrintRecord()
            Dim reportTitle = Messaging.TranslateCaption("Shift Summary Report")
            Dim language As String
            Dim curCulture = CultureInfo.CurrentCulture
            Dim establishmentName As String 
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))

            If language <> "ar" Then
                establishmentName = GetRecordField("Establishment", "EstablishmentName")
            Else
                establishmentName = GetRecordField("Establishment", "EstablishmentNameAra")
            End If

            Dim cForm As New ReportForm("Shift Summary Report.Rpt", View.IdNo.ToString(), "TransactionIdNo", reportTitle, "ReportTitle", language, "Language", establishmentName, "EstablishmentName", reportTitle, "ReportTitle") 
            cForm.Show()
        End Sub

    End Class

End Namespace