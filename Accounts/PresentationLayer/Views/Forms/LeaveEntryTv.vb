Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class LeaveEntryTv
        Implements ILeaveView

        Public Sub New()

            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtLeaveCode
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements ILeaveView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
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
                Return txtLeaveAllowed.Text
            End Get
            Set
                txtLeaveAllowed.Text = Value
            End Set
        End Property

        Public Property PaidPercent As Decimal Implements ILeaveView.PaidPercent
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

        Public Property Cumulative As Boolean Implements ILeaveView.Cumulative
            Get
                Return chkCumulative.Checked
            End Get
            Set
                chkCumulative.Checked = Value
            End Set
        End Property

        Public Property MaxCarryOver As Short Implements ILeaveView.MaxCarryOver
            Get
                Return txtMaxCarryOver.Text
            End Get
            Set
                txtMaxCarryOver.Text = Value
            End Set
        End Property

        Public Property MaxLimit As Short Implements ILeaveView.MaxLimit
            Get
                Return txtMaxLimit.Text
            End Get
            Set
                txtMaxLimit.Text = Value
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

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"LeaveCode", txtLeaveCode},
                {"LeaveName", txtLeaveName},
                {"LeaveNameAra", txtLeaveNameAra},
                {"LeaveAllowed", txtLeaveAllowed},
                {"PaidPercent", txtPaidPercent},
                {"Cumulative", chkCumulative},
                {"MaxCarryOver", txtMaxCarryOver},
                {"MaxLimit", txtMaxLimit},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace