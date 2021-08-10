Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class EmployeeAbsencePresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IEmployeeAbsenceView, TM)

        Private ReadOnly _payrollService As New AccountsService("Payroll")
        Private ReadOnly _payrollIdNo As Int16 = 0
        Private ReadOnly _endDate As Date
        Private ReadOnly _startDate As Date
        Private ReadOnly _payrollName As String
        Private ReadOnly _payrollNameAra As String
        Private ReadOnly _payrollCode As String

        Public Sub New(itemView As IEmployeeAbsenceView)
            MyBase.New(itemView)
            Service = New AccountsService("EmployeeAbsence")
            TableName = "EmployeeAbsence"
            SortOrderKey = "IdNo"
            WithTreeView = False
            If _payrollIdNo = 0 Then
                _payrollIdNo = Service.GetFieldOnMaxField("PayrollIdNo", "PayrollDetail", "PayrollIdNo")
            End If
            Dim payroll As PayrollModel
            payroll = _payrollService.GetRecordByIdNo(Of PayrollModel)(_payrollIdNo)
            _payrollCode = payroll.PayrollCode
            _payrollNameAra = payroll.PayrollNameAra
            _payrollName = payroll.PayrollName
            _startDate = payroll.StartDate
            _endDate = payroll.EndDate
            SetPayroll()
            DataFilter = "PayrollIdNo = " & _payrollIdNo.ToString()
            AddHandler View.AddedByUserChanged, AddressOf OnAddedByUserChanged
        End Sub

        Protected Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            SetPayroll()
            View.AddedByUser = GlobalVariables.UserIdNo
            View.UserName = Service.GetFieldWithIdNo(GlobalVariables.UserIdNo, "User", "UserName")
        End Sub

        Private Sub SetPayroll()
            View.PayrollIdNo = _payrollIdNo
            View.PayrollCode = _payrollCode
            If GlobalVariables.RightToLeftLayout Then
                View.PayrollName = _payrollNameAra
            Else
                View.PayrollName = _payrollName
            End If
            View.StartDate = _startDate
            View.EndDate = _endDate
            View.PayrollCode = _payrollCode
        End Sub

        Protected Sub OnAddedByUserChanged()

        End Sub

    End Class

End Namespace