Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class EmployeeIdPrintingPresenter(Of TM As New)
        Inherits CommonPresenter(Of IEmployeeIdListView, TM)

        'Private ReadOnly _journalItemService
        'Private ReadOnly _EmployeeIdsService

        Public Sub New(view As IEmployeeIdListView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("Employee")
            TableName = "Employee"
            SortOrderKey = "EmployeeName"
            AskBeforeSave = True
            DisableSaveMemento = True
            AddHandler view.ClearAllEmployee, AddressOf OnClearAllEmployeeId
            'AddHandler view.EmployeeIdCheckedEvent, AddressOf OnEmployeeIdCheckedEvent

        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim employeeIdListModel As List(Of EmployeeIdModel) = Service.GetEmployeeIdList()
            GlobalFUnctions.ManualMap(employeeIdListModel, View.EmployeeIdList)
        End Sub

        'Private Sub OnEmployeeIdCheckedEvent(sender As Object)
        '    sender.Print = Not sender.Print
        'End Sub

        Public Overrides Sub GoPrintRecord()
            Dim transactionNumber As Int32
            transactionNumber = Service.GetNextSeries("EmployeeIdPrintingSeries")
            Dim dtIdPrinting As New DataTable
            CreateDataTable(dtIdPrinting, {{"EmployeeIdNo", GetType(Int32)},
                                           {"TransactionNumber", GetType(Int32)}
                                           })
            For Each employeeId As EmployeeIdView In View.EmployeeIdList
                If employeeId.Print Then
                    Dim workRow As DataRow
                    workRow = dtIdPrinting.NewRow()
                    workRow("EmployeeIdNo") = employeeId.IdNo
                    workRow("TransactionNumber") = transactionNumber
                    dtIdPrinting.Rows.Add(workRow)
                End If
            Next
            Dim retVal = Service.ExecuteTvpSp("InsertEmployeeIdPrintingTvp", dtIdPrinting)
            ShowReportToScreen("HR Id Printing.Rpt", {transactionNumber, "TransactionNumber"})
        End Sub

        Private Sub OnClearAllEmployeeId(ByVal bsData As BindingSource, clear As Boolean)
            For Each item In bsData
                item.Print = clear
            Next item
        End Sub

    End Class

End Namespace