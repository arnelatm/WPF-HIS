Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class ItemCodeEntryTv
        Implements IItemCodeView

        Private _lockGroup As Boolean = False
        Private _groupIdNo As Int16

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtItemCodeName
            LockGroup = False
            btnLockGroup.Enabled = True
        End Sub

        Public Sub New(codeGroupIdNo As Int16)
            MyBase.New()
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

        Public Property CodeGroupSelector As Int16 Implements IItemCodeView.CodeGroupSelector
            Get
                Return cboCodeGroupSelector.GetValue(Of Int16)
            End Get
            Set
                cboCodeGroupSelector.SetValue(Value)
                'If Not btnEdit.Enabled Then
                '    If Value <> 0 Then
                '        btnLockGroup.Enabled = True
                '    Else
                '        btnLockGroup.Enabled = True
                '    End If
                'End If
            End Set
        End Property

        Public Property CodeGroupIdNo As Int16 Implements IItemCodeView.CodeGroupIdNo
            Get
                Return txtCodeGroupIdNo.GetValue(Of Int16)
            End Get
            Set
                txtCodeGroupIdNo.SetValue(Value)
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
                    btnLockGroup.BackgroundImage = My.Resources.Unlock
                    cboCodeGroupSelector.EditingMode = False
                Else
                    btnLockGroup.BackgroundImage = My.Resources.Lock
                    cboCodeGroupSelector.EditingMode = True
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
                {"CodeGroupSelector", cboCodeGroupSelector},
                {"CodeGroupIdNo", txtCodeGroupIdNo},
                {"Note", txtNote}
                }
        End Sub



        Private Sub OnFormLoad() Handles MyBase.Load
            DataFilter = "CodeGroupIdNo = 0"
            RaiseEvent FilterRecords()
            cboCodeGroupSelector.SelectedValue = 0
            cboCodeGroupSelector.DisplayOnly = False
            cboCodeGroupSelector.EditingMode = True
        End Sub

        'Protected Overrides Sub BeforeEdit()
        '    cboCodeGroupSelector.Enabled = False
        'End Sub

        Protected Overrides Sub AfterEdit()
            EnableCodeGroupIdNoSelection()
        End Sub

        Protected Sub ItemCodeAfterUpdateView() Handles MyBase.AfterUpdateView
            EnableCodeGroupIdNoSelection()
        End Sub

        Private Sub EnableCodeGroupIdNoSelection()
            cboCodeGroupSelector.EditingMode = True
            'cboCodeGroupSelector.DisplayOnly = False
        End Sub

        Protected Overrides Sub BeforeAdd()
            _groupIdNo = CodeGroupIdNo
            MyBase.BeforeAdd()
            'CodeGroupIdNo = _groupIdNo
        End Sub

        Protected Overrides Sub AfterAdd()
            MyBase.AfterAdd()
            CodeGroupIdNo = _groupIdNo
            'If CodeGroupIdNo <> 0 Then
            '    cboCodeGroupSelector.EditingMode = True
            'Else
            '    cboCodeGroupSelector.EditingMode = False
            'End If
        End Sub

        Private Sub ItemCodeEntryTv_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            FormShown = True
        End Sub

        Private Sub cboCodeGroupIdNo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCodeGroupSelector.SelectionChangeCommitted
            If FormShown Then
                DataFilter = "CodeGroupIdNo = " & cboCodeGroupSelector.SelectedValue.ToString()
                CodeGroupIdNo = cboCodeGroupSelector.SelectedValue
                SavedGroupIdNo = CodeGroupIdNo
                RaiseEvent FilterRecords()
            End If
        End Sub

        'Private Sub AddNewRecord() Handles btnNew.Click
        '    btnNew.PerformClick()
        '    If LockGroup Then
        '        cboCodeGroupSelector.EditingMode = False
        '    Else
        '        cboCodeGroupSelector.EditingMode = True
        '    End If
        'End Sub

        'Private Sub EditRecord() Handles btnEdit.Click
        '    btnEdit.PerformClick()
        '    If LockGroup Then
        '        cboCodeGroupSelector.EditingMode = False
        '    Else
        '        cboCodeGroupSelector.EditingMode = True
        '    End If
        'End Sub

        Private Sub OnAfterChangeRecord() Handles MyBase.AfterChangeRecord
            If LockGroup Then
                cboCodeGroupSelector.EditingMode = False
            Else
                cboCodeGroupSelector.EditingMode = True
            End If
        End Sub


        'Private Sub btnLockGroup_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnLockGroup.ClickButtonArea
        '    If LockGroup Then
        '        cboCodeGroupSelector.EditingMode = True
        '    Else
        '        cboCodeGroupSelector.EditingMode = False
        '    End If
        'End Sub

        Private Sub btnLockGroup_Click(sender As Object, e As EventArgs) Handles btnLockGroup.Click
            LockGroup = Not LockGroup
            If cboCodeGroupSelector.SelectedValue <> 0 Then
                If Not LockGroup Then
                    'LockGroup = True

                    'cboCodeGroupSelector.Enabled = False
                    'RaiseEvent LockGroupClicked()
                    cboCodeGroupSelector.EditingMode = True
                Else
                    'RaiseEvent LockGroupClicked()
                    SavedGroupIdNo = CodeGroupIdNo
                    cboCodeGroupSelector.EditingMode = False
                End If
            Else
                cboCodeGroupSelector.EditingMode = True
            End If
            cboCodeGroupSelector.Refresh()
            'RaiseEvent LockGroupClicked()
        End Sub


        Public Overloads Sub Inputs(onOff As Boolean)
            ' need to override because default method is to set 'EditingMode' to desired value
            ' but in this case cboCodeGroupSelector is not databound but just a selector
            ' and we always need to set its 'EditingMode' based on 'LockGroup' Value
            MyBase.Inputs(onOff)
            If LockGroup Then
                cboCodeGroupSelector.EditingMode = False
            Else
                cboCodeGroupSelector.EditingMode = True
            End If
        End Sub

        Private Sub FormTreeView_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles FormTreeView.AfterSelect
            cboCodeGroupSelector.EditingMode = Not LockGroup
        End Sub
    End Class

End Namespace