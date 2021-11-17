Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeaveApprovalPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IEmployeeLeaveApprovalView, TM)

        Private ReadOnly _journalItemService
        Private ReadOnly _EmployeeIdsService

        Public Sub New(view As IEmployeeLeaveApprovalView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("EmployeeLeave")
            TableName = "EmployeeLeave"
            SortOrderKey = "EmployeeName"
            AskBeforeSave = True
            DisableSaveMemento = True
            'AddHandler view.ClearAllEmployee, AddressOf OnClearAllEmployeeId
            'AddHandler view.EmployeeIdCheckedEvent, AddressOf OnEmployeeIdCheckedEvent

        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim employeeLeaveList As List(Of EmployeeLeave) = Service.GetDaoRecords()
            Dim employeeLeaveListModel As New List(Of EmployeeLeaveModel)
            GlobalVariables.Mapper.Map(employeeLeaveList, employeeLeaveListModel)
            GlobalVariables.Mapper.Map(employeeLeaveListModel, View.EmployeeLeaveList)
        End Sub

        'Private Sub OnEmployeeIdCheckedEvent(sender As Object)
        '    sender.Print = Not sender.Print
        'End Sub

        'Private Sub OnClearAllEmployeeId(ByVal bsData As BindingSource, clear As Boolean)
        '    For Each item In bsData
        '        item.Print = clear
        '    Next item
        'End Sub

    End Class

End Namespace