Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class HolidayPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IHolidayView, TM)

        Private ReadOnly _payrollService As New AccountsService("Payroll")
        Private ReadOnly _payrollIdNo As Int16 = 0
        Private ReadOnly _payrollEndDate As Date
        Private ReadOnly _payrollStartDate As Date
        Private ReadOnly _payrollName As String
        Private ReadOnly _payrollNameAra As String
        Private ReadOnly _payrollCode As String

        Public Sub New(itemView As IHolidayView)
            MyBase.New(itemView)
            Service = New AccountsService("Holiday")
            TableName = "Holiday"
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
            _payrollStartDate = payroll.StartDate
            _payrollEndDate = payroll.EndDate
            SetPayroll()
            DataFilter = "PayrollIdNo = " & _payrollIdNo.ToString()
        End Sub

        Protected Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            SetPayroll()
        End Sub

        Private Sub SetPayroll()
            View.PayrollIdNo = _payrollIdNo
            View.PayrollCode = _payrollCode
            If GlobalVariables.RightToLeftLayout Then
                View.PayrollName = _payrollNameAra
            Else
                View.PayrollName = _payrollName
            End If
            View.PayrollStartDate = _payrollStartDate
            View.PayrollEndDate = _payrollEndDate
            View.PayrollCode = _payrollCode
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = True
            If MyBase.IsBizDataValid() Then
                If View.DateStart < View.PayrollStartDate Or View.DateEnd > View.PayrollEndDate Then
                    Dim fieldName As String = Messaging.TranslateCaption("Start Date")
                    Messaging.ShowParametrizedMessage(True, "MsgInvalidRange", {"fieldName", fieldName, "minimumValue", View.PayrollStartDate.ToShortDateString, "maximumValue", View.PayrollEndDate.ToShortDateString})
                    retValue = False
                End If
            End If
            Return retValue
        End Function

    End Class

End Namespace