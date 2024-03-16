Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class EmployeeAbsencePresenter(Of TM As New)
        Inherits CommonPresenter(Of IEmployeeAbsenceView, TM)

        Private ReadOnly _payrollService As New AccountsService("Payroll")
        Private ReadOnly _endDate As Date
        Private ReadOnly _startDate As Date
        Private ReadOnly _payrollName As String
        Private ReadOnly _payrollNameAra As String
        Private ReadOnly _payrollCode As String
        Private _payrollIdNo As Int32 = 0

        Public Sub New(itemView As IEmployeeAbsenceView)
            MyBase.New(itemView)
            Service = New AccountsService("EmployeeAbsence")
            TableName = "EmployeeAbsence"
            SortOrderKey = "IdNo"
            WithTreeView = False
            If View.PayrollIdNo = 0 Then
                View.PayrollIdNo = Service.GetFieldOnMaxField("PayrollIdNo", "PayrollDetail", "PayrollIdNo")
                _payrollIdNo = View.PayrollIdNo
            End If
            SetPayroll()
            'AddHandler View.AddedByUserChanged, AddressOf OnAddedByUserChanged
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of AbsenceTypeSelection)("AbsenceType")
            MakeControlDataSources({New Object() {"Employee", "EmployeeIdNo", Nothing, Nothing}})
        End Sub

        Protected Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            'SetPayroll()
            'DataFilter = "PayrollIdNo = " & View.PayrollIdNo.ToString()
            View.PayrollIdNo = _payrollIdNo
            View.AddedByUser = GlobalVariables.UserIdNo
            View.UserName = Service.GetFieldWithIdNo(GlobalVariables.UserIdNo, "User", "UserName")
        End Sub

        Public Sub SetPayroll()
            Dim payroll As PayrollModel
            If View.PayrollIdNo = 0 Then
                View.PayrollIdNo = Service.GetFieldOnMaxField("PayrollIdNo", "PayrollDetail", "PayrollIdNo")
            End If
            payroll = _payrollService.GetRecordByIdNo(Of PayrollModel)(View.PayrollIdNo)
            View.PayrollCode = payroll.PayrollCode
            View.StartDate = payroll.StartDate
            View.EndDate = payroll.EndDate
            If GlobalVariables.RightToLeftLayout Then
                View.PayrollName = payroll.PayrollNameAra
            Else
                View.PayrollName = payroll.PayrollName
            End If
            View.StartDate = payroll.StartDate
            View.EndDate = payroll.EndDate
            View.PayrollCode = payroll.PayrollCode
            DataFilter = "PayrollIdNo = " & View.PayrollIdNo.ToString()
        End Sub

        'Protected Sub OnAddedByUserChanged()

        'End Sub

    End Class

End Namespace