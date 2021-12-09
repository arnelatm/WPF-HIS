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
                'If Value Then
                '    txtMaxLimit.DisplayOnly = False
                '    chkNoMaxLimit.DisplayOnly = False
                '    txtMaxCarryOver.DisplayOnly = False
                'Else
                '    txtMaxLimit.DisplayOnly = True
                '    chkNoMaxLimit.DisplayOnly = True
                '    txtMaxCarryOver.DisplayOnly = True
                'End If
                'chkNoMaxLimit.Refresh()
                'txtMaxCarryOver.Refresh()
            End Set
        End Property

        Public Property MaxCarryOver As Decimal Implements ILeaveView.MaxCarryOver
            Get
                Return txtMaxCarryOver.GetDecimalValue()
            End Get
            Set
                'Dim oldDisplayOnly = txtMaxCarryOver.DisplayOnly
                'txtMaxCarryOver.DisplayOnly = False
                txtMaxCarryOver.Text = Value
                'txtMaxCarryOver.DisplayOnly = oldDisplayOnly
            End Set
        End Property

        Public Property MaxLimit As Decimal Implements ILeaveView.MaxLimit
            Get
                Return txtMaxLimit.GetDecimalValue()
            End Get
            Set
                'Dim oldDisplayOnly As Boolean = txtMaxLimit.DisplayOnly
                'txtMaxLimit.DisplayOnly = False
                txtMaxLimit.Text = Value
                'txtMaxLimit.DisplayOnly = oldDisplayOnly
            End Set
        End Property

        Public Property NoMaxLimit As Boolean Implements ILeaveView.NoMaxLimit
            Get
                Return chkNoMaxLimit.Checked
            End Get
            Set
                'Dim oldDisplayOnly As Boolean = chkNoMaxLimit.DisplayOnly
                'chkNoMaxLimit.DisplayOnly = False
                chkNoMaxLimit.Checked = Value
                'if Not btnEdit.Enabled then
                '    if Value Then
                '        MaxLimit = 0
                '    End If
                'End If
                'chkNoMaxLimit.DisplayOnly = oldDisplayOnly
                'chkNoMaxLimit.Refresh()
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
                If Not btnEdit.Enabled Then
                    MaxLimit = 0
                    txtMaxLimit.Enabled = False
                    'txtMaxCarryOver.Enabled = True
                    'chkNoMaxLimit.Enabled = True
                End If
                'txtMaxLimit.Text = 0
                'if Not btnEdit.Enabled
                '    txtMaxLimit.Enabled = False
                'End If
                'txtMaxLimit.DisplayOnly = False

                'txtMaxLimit.DisplayOnly = True
            Else
                If Not btnEdit.Checked Then
                    txtMaxLimit.Enabled = True
                    If MaxLimit < LeaveAllowed Then
                        MaxLimit = LeaveAllowed
                    End If
                End If
                'txtMaxCarryOver.Enabled = False
                'chkNoMaxLimit.Enabled = False
                'If btnEdit.Enabled Then
                '    txtMaxLimit.DisplayOnly = True
                'Else
                '    txtMaxLimit.DisplayOnly = False
                'End If
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
                If Not btnEdit.Enabled Then
                    'txtMaxCarryOver.DisplayOnly = False
                    NoMaxLimit = True
                    MaxCarryOver = LeaveAllowed
                    MaxLimit = LeaveAllowed
                    chkNoMaxLimit.Enabled = True
                    txtMaxCarryOver.Enabled = True
                    'chkNoMaxLimit.DisplayOnly = False
                    'txtMaxLimit.DisplayOnly = True
                End If
            Else
                MaxCarryOver = 0
                MaxLimit = 0
                'chkNoMaxLimit.DisplayOnly = False
                chkNoMaxLimit.Checked = False
                chkNoMaxLimit.Enabled = False
                txtMaxCarryOver.Enabled = False
                txtMaxLimit.Enabled = False
                'txtMaxCarryOver.DisplayOnly = True
                'txtMaxLimit.DisplayOnly = True
                'chkNoMaxLimit.DisplayOnly = True
            End If
        End Sub

    End Class

End Namespace