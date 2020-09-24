Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class LeaveView
        Implements ILeaveView

        Public Property IdNo As Int16 Implements ILeaveView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property LeaveCode As String Implements ILeaveView.LeaveCode
            Get
                Return txtLeaveCode.Text
            End Get
            Set
                txtLeaveCode.Text = Value
            End Set
        End Property

        Public Property LeaveName As String Implements ILeaveView.LeaveName
            Get
                Return txtLeaveName.Text
            End Get
            Set
                txtLeaveName.Text = Value
            End Set
        End Property

        Public Property LeaveNameAra As String Implements ILeaveView.LeaveNameAra
            Get
                Return txtLeaveNameAra.Text
            End Get
            Set
                txtLeaveNameAra.Text = Value
            End Set
        End Property

        Public Property LeaveAllowed As Int16 Implements ILeaveView.LeaveAllowed
            Get
                Return txtLeaveNameAra.Text
            End Get
            Set
                txtLeaveNameAra.Text = Value
            End Set
        End Property

        Public Property PaidPercent As Decimal Implements ILeaveView.PaidPercent
            Get
                If txtPaidPercent.Text <> "" Then
                    Return Convert.ToByte(txtPaidPercent.Text)
                Else
                    Return 0D
                End If
            End Get
            Set
                txtPaidPercent.Text = Value
            End Set
        End Property

        Public Property Cumulative As Boolean Implements ILeaveView.Cumulative
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Boolean)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MaxCarryOver As Short Implements ILeaveView.MaxCarryOver
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Short)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MaxLimit As Short Implements ILeaveView.MaxLimit
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Short)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Notes As String Implements ILeaveView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

End Namespace