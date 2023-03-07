Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class ItemCodeEntryTv
        Implements IItemCodeView

        Private _lockGroup As Boolean = False
        Private _groupIdNo As Int16

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtItemCodeName
            LockGroup = False
            btnLockGroup.Enabled = True
        End Sub

        Public Sub New(codeGroupIdNo As Int16)
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtItemCodeName
            LockGroup = False
            btnLockGroup.Enabled = True
            DataFilter = "CodeGroupIdNo = " + codeGroupIdNo.ToString()
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
                If Not btnEdit.Enabled Then
                    If Value <> 0 Then
                        btnLockGroup.Enabled = True
                    Else
                        btnLockGroup.Enabled = True
                    End If
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
                    btnLockGroup.BackgroundImage = My.Resources.Lock
                Else
                    btnLockGroup.BackgroundImage = My.Resources.Unlock
                End If
            End Set
        End Property

        Public Property SavedGroupIdNo As Short Implements IItemCodeView.SavedGroupIdNo

        Public Event LockGroupClicked() Implements IItemCodeView.LockGroupClicked
        Public Event FilterRecords() Implements IItemCodeView.FilterRecords

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

        'Private Sub BtnLockGroup_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnLockGroup.ClickButtonArea
        '    If CodeGroupIdNo <> 0 Then
        '        If Not LockGroup Then
        '            LockGroup = True
        '            SavedGroupIdNo = CodeGroupIdNo
        '            cboCodeGroupIdNo.Enabled = False
        '            RaiseEvent LockGroupClicked()
        '        Else
        '            cboCodeGroupIdNo.Enabled = True
        '            LockGroup = False
        '            RaiseEvent LockGroupClicked()
        '        End If
        '    Else
        '        LockGroup = False
        '        cboCodeGroupIdNo.Enabled = True
        '    End If
        '    RaiseEvent LockGroupClicked()
        'End Sub

        Private Sub OnFormLoad() Handles MyBase.Load
            DataFilter = "CodeGroupIdNo = 0"
            RaiseEvent FilterRecords()
            cboCodeGroupIdNo.Enabled = True
            cboCodeGroupIdNo.DisplayOnly = False
        End Sub

        Private Sub cboCodeGroupIdNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCodeGroupIdNo.SelectedIndexChanged
            DataFilter = "CodeGroupIdNo = " & CodeGroupIdNo.ToString()
            SavedGroupIdNo = CodeGroupIdNo
            RaiseEvent FilterRecords()
        End Sub

        Protected Overrides Sub BeforeEdit()
            cboCodeGroupIdNo.Enabled = False
        End Sub

        Protected Overrides Sub AfterEdit()
            EnableCodeGroupIdNoSelection()
        End Sub

        Protected Sub ItemCodeAfterUpdateView() Handles MyBase.AfterUpdateView
            EnableCodeGroupIdNoSelection()
        End Sub

        Private Sub EnableCodeGroupIdNoSelection()
            cboCodeGroupIdNo.Enabled = True
            cboCodeGroupIdNo.DisplayOnly = False
        End Sub

        Protected Overrides Sub BeforeAdd()
            _groupIdNo = CodeGroupIdNo
            MyBase.BeforeAdd()
            'CodeGroupIdNo = _groupIdNo
        End Sub

        Protected Overrides Sub AfterAdd()
            MyBase.AfterAdd()
            CodeGroupIdNo = _groupIdNo
            If CodeGroupIdNo <> 0 Then
                cboCodeGroupIdNo.Enabled = False
                cboCodeGroupIdNo.DisplayOnly = True
            End If
        End Sub


    End Class

End Namespace