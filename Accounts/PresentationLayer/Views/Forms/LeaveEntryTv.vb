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

        Private Sub CbNoMaxLimitValueChanged() Handles chkNoMaxLimit.CheckedChanged
            If chkNoMaxLimit.Checked Then
                txtMaxLimit.Text = 0
                txtMaxLimit.DisplayOnly = False
            Else
                If MaxLimit < LeaveAllowed Then
                    MaxLimit = LeaveAllowed
                End If
                If btnEdit.Enabled Then
                    txtMaxLimit.DisplayOnly = True
                Else
                    txtMaxLimit.DisplayOnly = False
                End If
            End If
            'If btnEdit.Enabled Then
            '    txtMaxLimit.DisplayOnly = True
            '    chkNoMaxLimit.DisplayOnly = True
            'Else
            '    If Cumulative Then
            '        chkNoMaxLimit.DisplayOnly = False
            '    Else
            '        chkNoMaxLimit.DisplayOnly = True
            '    End If
            'End If
            'If chkNoMaxLimit.Checked Then
            '    txtMaxLimit.Text = 0
            '    txtMaxLimit.DisplayOnly = False
            'Else
            '    If MaxLimit < LeaveAllowed Then
            '        MaxLimit = LeaveAllowed
            '    End If
            '    If btnEdit.Enabled Then
            '        txtMaxLimit.DisplayOnly = True
            '    Else
            '        txtMaxLimit.DisplayOnly = False
            '    End If
            'End If
            'If btnEdit.Enabled Then
            '    txtMaxLimit.DisplayOnly = True
            '    chkNoMaxLimit.DisplayOnly = True
            'Else
            '    If Cumulative Then
            '        chkNoMaxLimit.DisplayOnly = False
            '    Else
            '        chkNoMaxLimit.DisplayOnly = True
            '    End If
            'End If
        End Sub

        Private Sub CbCumulativeValueChanged() Handles chkCumulative.CheckedChanged
            If chkCumulative.Checked Then
                If btnEdit.Enabled Then
                    txtMaxCarryOver.DisplayOnly = True
                    txtMaxLimit.DisplayOnly = True
                    chkNoMaxLimit.DisplayOnly = True
                Else
                    txtMaxCarryOver.DisplayOnly = False
                    If MaxLimit = 0 Then
                        NoMaxLimit = True
                    End If
                    If NoMaxLimit Then
                        txtMaxLimit.DisplayOnly = True
                    Else
                        txtMaxLimit.DisplayOnly = False
                    End If
                    If MaxCarryOver = 0 Then
                        MaxCarryOver = LeaveAllowed
                    End If
                    chkNoMaxLimit.DisplayOnly = False
                End If
            Else
                MaxCarryOver = 0
                MaxLimit = 0
                chkNoMaxLimit.Checked = False
                txtMaxCarryOver.DisplayOnly = True
                txtMaxLimit.DisplayOnly = True
                chkNoMaxLimit.DisplayOnly = True
            End If
        End Sub

    End Class

End Namespace