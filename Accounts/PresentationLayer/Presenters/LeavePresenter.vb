Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Presenters

    Public Class LeavePresenter(Of TM As New)
        Inherits CommonPresenter(Of ILeaveView, LeaveModel)
        Implements ISubscriber(Of AATM.PresentationLayer.Events.DataChanged)

        Public Sub New(view As ILeaveView)
            MyBase.New(view)

            Service = New AccountsService("Leave")
            TableName = "Leave"
            TreeViewMainField = "LeaveName"
            'TreeViewSecondaryField = "LeaveCode"
            SortOrderKey = "LeaveName"
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int16)(View.IdNo, "EmployeeLeave", "LeaveIdNo") Then
                Return True
            ElseIf CheckDependentRecords(View.IdNo, "EmployeeLeaveCredit", "LeaveIdNo") Then
                Return True
            ElseIf CheckDependentRecords(View.IdNo, "Holiday", "LeaveIdNo") Then
                Return True
            End If
            Return False
        End Function

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of LeaveCycleSelection)("LeaveCycle")
        End Sub

        Public Sub OnLeaveDataChangedEventHandler(ByRef eventType As DataChanged) Implements ISubscriber(Of DataChanged).OnEventHandler
            With eventType.BindingSource
                If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
                    'Select Case eventType.PropertyName
                    '    Case $"Cumulative"
                    '        View.NoMaxLimit = True
                    '        View.MaxCarryOver = View.LeaveAllowed
                    '        View.MaxLimit = 0
                    '    Case $"Rate"
                    '        Dim amount As Decimal
                    '        Dim employeePayElement As EmployeePayElementView = eventType.BindingSource.Current

                    '        Dim earnIdNo = eventType.BindingSource.Current.PayElementIdNo
                    '        Dim calcType = GetFieldWithIdNo(earnIdNo, "PayElement", "CalculationType")
                    '        If calcType = EnumToCode(CalculationTypeSelection.FixedRate) Then
                    '            amount = 0
                    '        ElseIf calcType = EnumToCode(CalculationTypeSelection.FixedAmount) Then
                    '            amount = ComputePayAmount(View.PayFrequency, eventType.EnteredValue, employeePayElement.Unit)
                    '        End If
                    '        employeePayElement.Amount = amount
                    '    Case $"Unit"
                    '        Dim amount As Decimal
                    '        Dim employeePayElement As EmployeePayElementView = eventType.BindingSource.Current
                    '        amount = ComputePayAmount(View.PayFrequency, employeePayElement.Rate, eventType.EnteredValue)
                    '        employeePayElement.Amount = amount
                    '    Case $"Cumulative"
                    '        Dim empLeaveCredit As EmployeeLeaveCreditView = eventType.BindingSource.Current
                    '        If Not empLeaveCredit.Cumulative Then
                    '            empLeaveCredit.MaxCarryOver = 0
                    '            empLeaveCredit.MaxLimit = 0
                    '            empLeaveCredit.NoMaxLimit = False
                    '        Else
                    '            empLeaveCredit.NoMaxLimit = True
                    '            empLeaveCredit.MaxLimit = 0
                    '        End If
                    '    Case $"NoMaxLimit"
                    '        Dim empLeaveCredit As EmployeeLeaveCreditView = eventType.BindingSource.Current
                    '        If Not empLeaveCredit.Cumulative Then
                    '            Beep()
                    '            empLeaveCredit.NoMaxLimit = False
                    '        End If
                    '    Case $"MaxLimit"
                    '        Dim empLeaveCredit As EmployeeLeaveCreditView = eventType.BindingSource.Current
                    '        If Not empLeaveCredit.Cumulative Then
                    '            Beep()
                    '            empLeaveCredit.MaxLimit = 0
                    '        End If
                    '    Case $"MaxCarryOver"
                    '        Dim empLeaveCredit As EmployeeLeaveCreditView = eventType.BindingSource.Current
                    '        If Not empLeaveCredit.Cumulative Then
                    '            Beep()
                    '            empLeaveCredit.MaxCarryOver = 0
                    '        End If
                    '    Case $"AccumulatedLeave"
                    '        Dim empLeaveCredit As EmployeeLeaveCreditView = eventType.BindingSource.Current
                    '        If Not empLeaveCredit.Cumulative Then
                    '            Beep()
                    '            empLeaveCredit.AccumulatedLeave = 0
                    '        End If
                    'End Select
                End If
            End With
        End Sub

    End Class

End Namespace