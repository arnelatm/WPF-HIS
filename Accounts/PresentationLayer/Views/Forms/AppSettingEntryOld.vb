Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class AppSettingEntry
        Implements IAppSettingView

        Private _lockGroup As Boolean = False
        Private _groupIdNo As Int16

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboAppSettingGroupSelector
            LockGroup = False
            btnLockGroup.Enabled = True
        End Sub

        Public Sub New(appSettingGroupIdNo As Int16)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboAppSettingGroupSelector
            LockGroup = False
            btnLockGroup.Enabled = True
            DataFilter = "AppSettingGroupIdNo = " + appSettingGroupIdNo.ToString()
        End Sub

#Region "Fields"

        Public Property IdNo As Int32 Implements IAppSettingView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property AppSettingGroupSelector As Int16 Implements IAppSettingView.AppSettingGroupSelector
            Get
                Return cboAppSettingGroupSelector.GetValue(Of Int16)
            End Get
            Set
                cboAppSettingGroupSelector.SetValue(Value)
                'If Not btnEdit.Enabled Then
                '    If Value <> 0 Then
                '        btnLockGroup.Enabled = True
                '    Else
                '        btnLockGroup.Enabled = True
                '    End If
                'End If
            End Set
        End Property

        Public Property Selector1IdNo1 As Int32 Implements IAppSettingView.Selector1IdNo
            Get
                Return cboSelector1IdNo.GetValue(Of Int32)
            End Get
            Set
                cboSelector1IdNo.SetValue(Value)
            End Set
        End Property


        Public Property Selector1IdNo2 As Int32 Implements IAppSettingView.Selector2IdNo
            Get
                Return cboSelector2IdNo.GetValue(Of Int32)
            End Get
            Set
                cboSelector2IdNo.SetValue(Value)
            End Set
        End Property

        Public Property AppSettingGroupIdNo As Int16 Implements IAppSettingView.AppSettingGroupIdNo
            Get
                Return txtAppSettingGroupIdNo.GetValue(Of Int16)
            End Get
            Set
                txtAppSettingGroupIdNo.SetValue(Value)
            End Set
        End Property



        Public Property LockGroup As Boolean Implements IAppSettingView.LockGroup
            Get
                Return _lockGroup
            End Get
            Set(value As Boolean)
                _lockGroup = value
                If value Then
                    btnLockGroup.BackgroundImage = My.Resources.Unlock
                    cboAppSettingGroupSelector.EditingMode = False
                Else
                    btnLockGroup.BackgroundImage = My.Resources.Lock
                    cboAppSettingGroupSelector.EditingMode = True
                End If
            End Set
        End Property

        Public Property SavedGroupIdNo As Short Implements IAppSettingView.SavedGroupIdNo
        Public Event LockGroupClicked() Implements IAppSettingView.LockGroupClicked
        Public Event FilterRecords() Implements IAppSettingView.FilterRecords

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AppSettingGroupIdNo", txtAppSettingGroupIdNo},
                {"IdNo", TxtIdNo},
                {"AppSettingGroupSelector", cboAppSettingGroupSelector},
                {"Selector1IdNo", cboSelector1IdNo},
                {"Selector2IdNo", cboSelector2IdNo}
                }
        End Sub



        Private Sub OnFormLoad() Handles MyBase.Load
            DataFilter = "AppSettingGroupIdNo = 0"
            RaiseEvent FilterRecords()
            cboAppSettingGroupSelector.SelectedValue = 0
            cboAppSettingGroupSelector.DisplayOnly = False
            cboAppSettingGroupSelector.EditingMode = True
        End Sub

        'Protected Overrides Sub BeforeEdit()
        '    cboAppSettingCodeSelector.Enabled = False
        'End Sub

        Protected Overrides Sub AfterEdit()
            EnableSelector1Selection()
        End Sub

        Protected Sub AppSettingAfterUpdateView() Handles MyBase.AfterUpdateView
            EnableSelector1Selection()
        End Sub

        Private Sub EnableSelector1Selection()
            cboAppSettingGroupSelector.EditingMode = True
            'cboAppSettingCodeSelector.DisplayOnly = False
        End Sub

        Protected Overrides Sub BeforeAdd()
            _groupIdNo = AppSettingGroupIdNo
            MyBase.BeforeAdd()
            'Selector1 = _groupIdNo
        End Sub

        Protected Overrides Sub AfterAdd()
            MyBase.AfterAdd()
            AppSettingGroupIdNo = _groupIdNo
            'If Selector1 <> 0 Then
            '    cboAppSettingCodeSelector.EditingMode = True
            'Else
            '    cboAppSettingCodeSelector.EditingMode = False
            'End If
        End Sub

        Private Sub AppSettingEntryTv_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            FormShown = True
        End Sub

        Private Sub cboSelector1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAppSettingGroupSelector.SelectionChangeCommitted
            If FormShown Then
                DataFilter = "Selector1 = " & cboAppSettingGroupSelector.SelectedValue.ToString()
                AppSettingGroupIdNo = cboAppSettingGroupSelector.SelectedValue
                SavedGroupIdNo = AppSettingGroupIdNo
                RaiseEvent FilterRecords()
            End If
        End Sub

        'Private Sub AddNewRecord() Handles btnNew.Click
        '    btnNew.PerformClick()
        '    If LockGroup Then
        '        cboAppSettingCodeSelector.EditingMode = False
        '    Else
        '        cboAppSettingCodeSelector.EditingMode = True
        '    End If
        'End Sub

        'Private Sub EditRecord() Handles btnEdit.Click
        '    btnEdit.PerformClick()
        '    If LockGroup Then
        '        cboAppSettingCodeSelector.EditingMode = False
        '    Else
        '        cboAppSettingCodeSelector.EditingMode = True
        '    End If
        'End Sub

        Private Sub OnAfterChangeRecord() Handles MyBase.AfterChangeRecord
            If LockGroup Then
                cboAppSettingGroupSelector.EditingMode = False
            Else
                cboAppSettingGroupSelector.EditingMode = True
            End If
        End Sub


        'Private Sub btnLockGroup_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnLockGroup.ClickButtonArea
        '    If LockGroup Then
        '        cboAppSettingCodeSelector.EditingMode = True
        '    Else
        '        cboAppSettingCodeSelector.EditingMode = False
        '    End If
        'End Sub

        Private Sub btnLockGroup_Click(sender As Object, e As EventArgs) Handles btnLockGroup.Click
            LockGroup = Not LockGroup
            If cboAppSettingGroupSelector.SelectedValue <> 0 Then
                If Not LockGroup Then
                    'LockGroup = True

                    'cboAppSettingCodeSelector.Enabled = False
                    'RaiseEvent LockGroupClicked()
                    cboAppSettingGroupSelector.EditingMode = True
                Else
                    'RaiseEvent LockGroupClicked()
                    SavedGroupIdNo = AppSettingGroupIdNo
                    cboAppSettingGroupSelector.EditingMode = False
                End If
            Else
                cboAppSettingGroupSelector.EditingMode = True
            End If
            cboAppSettingGroupSelector.Refresh()
            'RaiseEvent LockGroupClicked()
        End Sub


        Public Overloads Sub Inputs(onOff As Boolean)
            ' need to override because default method is to set 'EditingMode' to desired value
            ' but in this case cboAppSettingCodeSelector is not databound but just a selector
            ' and we always need to set its 'EditingMode' based on 'LockGroup' Value
            MyBase.Inputs(onOff)
            If LockGroup Then
                cboAppSettingGroupSelector.EditingMode = False
            Else
                cboAppSettingGroupSelector.EditingMode = True
            End If
        End Sub

        'Private Sub FormTreeView_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles FormTreeView.AfterSelect
        '    cboAppSettingGroupSelector.EditingMode = Not LockGroup
        'End Sub
    End Class

End Namespace