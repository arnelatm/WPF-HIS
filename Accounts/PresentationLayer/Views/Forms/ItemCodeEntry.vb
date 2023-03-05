Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class ItemCodeEntryTv
        Implements IItemCodeView

        Private _lockGroup As Boolean = False

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtItemCodeName
            LockGroup = False
            btnLockGroup.Enabled = False
        End Sub

#Region "Fields"

        Public Property IdNo As Int32 Implements IItemCodeView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ItemCodeCode As String Implements IItemCodeView.ItemCodeCode
            Get
                Return txtItemCodeCode.Text
            End Get
            Set
                txtItemCodeCode.Text = Value
            End Set
        End Property

        Public Property ItemCodeName As String Implements IItemCodeView.ItemCodeName
            Get
                Return txtItemCodeName.Text
            End Get
            Set
                txtItemCodeName.Text = Value
            End Set
        End Property

        Public Property ItemCodeNameAra As String Implements IItemCodeView.ItemCodeNameAra
            Get
                Return txtItemCodeNameAra.Text
            End Get
            Set
                txtItemCodeNameAra.Text = Value
            End Set
        End Property

        Public Property CodeGroupIdNo As Int16 Implements IItemCodeView.CodeGroupIdNo
            Get
                Return cboCodeGroupIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboCodeGroupIdNo.SetValue(Value)
                If Value <> 0 Then
                    btnLockGroup.Enabled = True
                    'LockGroup = True
                Else
                    btnLockGroup.Enabled = False
                    'LockGroup = False
                End If
            End Set
        End Property

        Public Property Note As String Implements IItemCodeView.Note
            Get
                Return txtNote.Text
            End Get
            Set
                txtNote.Text = Value
            End Set
        End Property

        Public Property LockGroup As Boolean Implements IItemCodeView.LockGroup
            Get
                Return _lockGroup
            End Get
            Set(value As Boolean)
                _lockGroup = value
                If value Then
                    btnLockGroup.BackgroundImage = My.Resources.Resources.Lock
                Else
                    btnLockGroup.BackgroundImage = My.Resources.Resources.Unlock
                End If
            End Set
        End Property

        Public Event LockGroupClicked() Implements IItemCodeView.LockGroupClicked

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"ItemCodeCode", txtItemCodeCode},
                {"ItemCodeName", txtItemCodeName},
                {"ItemCodeNameAra", txtItemCodeNameAra},
                {"IdNo", TxtIdNo},
                {"CodeGroupIdNo", cboCodeGroupIdNo},
                {"Note", txtNote}
                }
        End Sub

        Private Sub BtnLockGroup_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnLockGroup.ClickButtonArea
            If CodeGroupIdNo <> 0 Then
                If Not LockGroup Then
                    LockGroup = True
                    RaiseEvent LockGroupClicked()
                Else
                    LockGroup = False
                    RaiseEvent LockGroupClicked()
                End If
            Else
                LockGroup = False
            End If
            RaiseEvent LockGroupClicked()
        End Sub

    End Class

End Namespace