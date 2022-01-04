Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class ReportSelectorPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IReportSelectorView, TM)

        'Private ReadOnly _journalItemService
        'Private ReadOnly _ReportIdsService

        Public Sub New(view As IReportSelectorView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("Report")
            TableName = "Report"
            SortOrderKey = "ReportName"
            AskBeforeSave = True
            DisableSaveMemento = True

        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim reportList As List(Of ReportModel) = Service.ortList()
            GlobalVariables.Mapper.Map(reportList, View.ReportList)
        End Sub

        'Private Sub OnReportIdCheckedEvent(sender As Object)
        '    sender.Print = Not sender.Print
        'End Sub

        Public Overrides Sub GoPrintRecord()
            'Dim transactionNumber As Int32
            'transactionNumber = Service.GetNextSeries("ReportSelectorSeries")
            Dim dtIdPrinting As New DataTable
            CreateDataTable(dtIdPrinting, {{"ReportIdNo", GetType(Int32)},
                                           {"TransactionNumber", GetType(Int32)}
                                           })
            'For Each Report As IReportView In View.ReportIdList
            '    Dim workRow As DataRow
            '    workRow = dtIdPrinting.NewRow()
            '    workRow("ReportIdNo") = Report.IdNo
            '    workRow("TransactionNumber") = transactionNumber
            '    dtIdPrinting.Rows.Add(workRow)
            'Next
            'Dim retVal = Service.ExecuteTvpSp("InsertReportSelectorTvp", dtIdPrinting)
            Dim cForm
            cForm = New ReportForm(View.ReportFileName)
            cForm.Show()
        End Sub

    End Class

End Namespace