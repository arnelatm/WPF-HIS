Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeLeaveCreditView
        Implements IEmployeeLeaveCreditView

        'Public Property MainTableName As String = "EmployeeLeaveCredit"

        Public Property IdNo As Int16 Implements IEmployeeLeaveCreditView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property LeaveAllowed As Int16 Implements IEmployeeLeaveCreditView.LeaveAllowed
            Get
                Return txtEmployeeLeaveCreditAllowed.Text
            End Get
            Set
                txtEmployeeLeaveCreditAllowed.Text = Value
            End Set
        End Property

        Public Property PaidPercent As Decimal Implements IEmployeeLeaveCreditView.PaidPercent
            Get
                If txtPaidPercent.Text <> "" Then
                    Return Convert.ToDecimal(txtPaidPercent.Text)
                Else
                    Return 0D
                End If
            End Get
            Set
                txtPaidPercent.Text = Value
            End Set
        End Property

        Public Property Cumulative As Boolean Implements IEmployeeLeaveCreditView.Cumulative
            Get
                Return chkCumulative.Checked
            End Get
            Set
                chkCumulative.Checked = Value
            End Set
        End Property

        Public Property MaxCarryOver As Short Implements IEmployeeLeaveCreditView.MaxCarryOver
            Get
                Return txtMaxCarryOver.Text
            End Get
            Set
                txtMaxCarryOver.Text = Value
            End Set
        End Property

        Public Property MaxLimit As Short Implements IEmployeeLeaveCreditView.MaxLimit
            Get
                Return txtMaxLimit.Text
            End Get
            Set
                txtMaxLimit.Text = Value
            End Set
        End Property

        Public Property Errors As List(Of String) Implements IView.Errors

        Public Property EmployeeIdNo As Integer Implements IEmployeeLeaveCreditView.EmployeeIdNo
            Get
                Return GlobalFunctions.NumParser(Of Int16)(TxtEmployeeIdNo.Text)
            End Get
            Set
                TxtEmployeeIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property LeaveIdNo As Short Implements IEmployeeLeaveCreditView.LeaveIdNo
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Short)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property AccumulatedLeaves As Short Implements IEmployeeLeaveCreditView.AccumulatedLeaves
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Short)
                Throw New NotImplementedException()
            End Set
        End Property
    End Class

End Namespace