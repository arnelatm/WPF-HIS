Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class EmployeeIdPrintingPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IEmployeeIdListView, TM)

        Private ReadOnly _journalItemService
        Private ReadOnly _EmployeeIdsService

        Public Sub New(view As IEmployeeIdListView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("Employee")
            TableName = "Employee"
            SortOrderKey = "EmployeeName"
            AskBeforeSave = True
            DisableSaveMemento = True
            AddHandler view.ClearAllEmployee, AddressOf OnClearAllEmployeeId
            'AddHandler view.EmployeeIdCheckedEvent, AddressOf OnClearAllEmployeeId

        End Sub

        Public Overrides Sub CreateDataSources()
            Dim employeeIdListModel As List(Of EmployeeIdModel) = Service.GetEmployeeIdList()
            GlobalVariables.Mapper.Map(employeeIdListModel, View.EmployeeIdList)
        End Sub

        'Private Sub OnEmployeeIdCheckedEvent(sender As Object)
        '    If EditMode Or AddMode Then
        '        If sender.PcClosed Then
        '            View.Amount -= sender.Amount
        '        Else
        '            View.Amount += sender.Amount
        '        End If
        '        sender.PcClosed = Not sender.PcClosed
        '    End If
        'End Sub

        Public Overrides Sub GoPrintRecord()
            Dim reportTitle As String
            Dim cForm
            Dim previousDate As Date
            Dim beginningDate As Date
            'beginningDate = GregorianDateSerial(GregorianYear(View.ReconciliationDate), GregorianMonth(View.ReconciliationDate), 1)
            'previousDate = DateAdd(DateInterval.Day, -1, beginningDate)
            'reportTitle = Messaging.TranslateCaption("Account Reconciliation")
            'cForm = New ReportFormNew("Account Reconciliation Report.Rpt", reportTitle, CultureInfo.CurrentCulture, View.IdNo, "ReconciliationNumber", View.AccountIdNo, "AccountIdNo", previousDate, "PreviousDate", beginningDate, "BeginningDate", View.ReconciliationDate, "EndingDate")
            'cForm.Show()
        End Sub

        Private Sub OnClearAllEmployeeId(ByVal bsData As BindingSource, clear As Boolean)
            For Each item In bsData
                item.Print = clear
            Next item
        End Sub

    End Class

End Namespace