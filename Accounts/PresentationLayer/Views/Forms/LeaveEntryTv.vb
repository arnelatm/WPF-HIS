Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
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

        Public Property LeaveCycle As String Implements ILeaveView.LeaveCycle
            Get
                Return cboLeaveCycle.GetValue()
            End Get
            Set(value As String)
                cboLeaveCycle.SetValue(value)
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

        Public Property LeaveAllowed As Decimal Implements ILeaveView.LeaveAllowed
            Get
                Return txtLeaveAllowed.GetDecimalValue()
            End Get
            Set
                txtLeaveAllowed.Text = Value
            End Set
        End Property

        Public Property PaidPercent As Decimal Implements ILeaveView.PaidPercent
            Get
                Return txtPaidPercent.GetDecimalValue()
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

        Public Property MaxCarryOver As Decimal Implements ILeaveView.MaxCarryOver
            Get
                Return txtMaxCarryOver.GetDecimalValue()
            End Get
            Set
                txtMaxCarryOver.Text = Value
            End Set
        End Property

        Public Property MaxLimit As Decimal Implements ILeaveView.MaxLimit
            Get
                Return txtMaxLimit.GetDecimalValue()
            End Get
            Set
                txtMaxLimit.Text = Value
            End Set
        End Property

        Public Property NoMaxLimit As Boolean Implements ILeaveView.NoMaxLimit
            Get
                Return chkNoMaxLimit.Checked
            End Get
            Set
                chkNoMaxLimit.Checked = Value
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

        Public Property Holiday As Boolean Implements ILeaveView.Holiday
            Get
                Return chkHoliday.Checked
            End Get
            Set
                chkHoliday.Checked = Value
            End Set
        End Property

        Public Property Earnable As Boolean Implements ILeaveView.Earnable
            Get
                Return chkEarnable.Checked
            End Get
            Set
                chkEarnable.Checked = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"LeaveCode", txtLeaveCode},
                {"LeaveCycle", cboLeaveCycle},
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

        Private Sub CbNoMaxLimitValueChanged() Handles chkNoMaxLimit.CheckedChanged
            If chkNoMaxLimit.Checked Then
                If Not btnEdit.Enabled Then
                    MaxLimit = 0
                    txtMaxLimit.Enabled = False
                End If
            Else
                If Not btnEdit.Enabled Then
                    txtMaxLimit.Enabled = True
                    If Cumulative AndAlso MaxLimit < LeaveAllowed Then
                        MaxLimit = LeaveAllowed
                    Else
                        MaxLimit = 0
                    End If
                End If
            End If
        End Sub

        Private Sub CbCumulativeValueChanged() Handles chkCumulative.CheckedChanged
            If chkCumulative.Checked Then
                If Not btnEdit.Enabled Then
                    NoMaxLimit = True
                    MaxCarryOver = LeaveAllowed
                    MaxLimit = 0
                    chkNoMaxLimit.Enabled = True
                    txtMaxCarryOver.Enabled = True
                End If
            Else
                MaxCarryOver = 0
                MaxLimit = 0
                chkNoMaxLimit.Checked = False
                chkNoMaxLimit.Enabled = False
                txtMaxCarryOver.Enabled = False
                txtMaxLimit.Enabled = False
            End If
        End Sub

        Private Sub CbLeaveCycleSelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLeaveCycle.SelectedIndexChanged
            If cboLeaveCycle.SelectedValue = EnumToCode(LeaveCycleSelection.OnceOnly) or cboLeaveCycle.SelectedValue = EnumToCode(LeaveCycleSelection.AsNeeded) Then
                If Not btnEdit.Enabled Then
                    chkCumulative.Checked = False
                    NoMaxLimit = False
                    MaxCarryOver = 0
                    MaxLimit = 0
                    chkNoMaxLimit.Enabled = False
                    txtMaxCarryOver.Enabled = False
                    chkCumulative.Enabled = False
                    txtMaxLimit.Enabled = False
                End If
            Else
                If Not btnEdit.Enabled Then
                    'chkNoMaxLimit.Enabled = True
                    'txtMaxCarryOver.Enabled = True
                    chkCumulative.Enabled = True
                End If
            End If
        End Sub

        Private Sub CbCumulativeValueChanged(sender As Object, e As EventArgs) Handles chkCumulative.CheckedChanged

        End Sub
    End Class

End Namespace