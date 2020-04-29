Imports AATM.Accounts.My.Resources
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Forms

    Public Class ChartEntryTv
        Implements IChartView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Chart_View"
            TvMainFieldName = "AccountName"
            TvSecondaryFieldName = "AccountCode"
            SortOrderKey = "SortKey"
            ParentFieldName = "ParentIdNo"
            FirstControl = txtAccountCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New ChartPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

            'CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("ActiveSelection", GetType(ActiveSelection))
            'ResourceEnumConverter.MakeResource("AccountGroupSelection", GetType(AccountGroupSelection))
            'ResourceEnumConverter.MakeResource("DebitCreditSelection", GetType(DebitCreditSelection))
            'ResourceEnumConverter.MakeResource("PayeeTypeSelection", GetType(PayeeTypeSelection))
        End Sub

        Public Property AccountCode As String Implements IChartView.AccountCode
            Get
                Return txtAccountCode.Text
            End Get
            Set
                txtAccountCode.Text = Value
            End Set
        End Property

        Public Property AccountGroup As String Implements IChartView.AccountGroup
            Get
                Return cboAccountGroup.GetValue()
            End Get
            Set
                cboAccountGroup.SetValue(Value)
            End Set
        End Property

        Public Property AccountName As String Implements IChartView.AccountName
            Get
                Return txtAccountName.Text
            End Get
            Set
                txtAccountName.Text = Value
            End Set
        End Property

        Public Property AccountNameAra As String Implements IChartView.AccountNameAra
            Get
                Return txtAccountNameAra.Text
            End Get
            Set
                txtAccountNameAra.Text = Value
            End Set
        End Property

        Public Property Active As Boolean Implements IChartView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property DetailAccount As Boolean Implements IChartView.DetailAccount
            Get
                Return chkDetailAccount.Checked
            End Get
            Set
                chkDetailAccount.Checked = Value
            End Set
        End Property

        Public Property IdNo As Int32 Implements IChartView.IdNo
            Get
                If txtIdNo.Text <> "" Then
                    Return Convert.ToInt32(txtIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property LevelNumber As Int16 Implements IChartView.LevelNumber
            Get
                If (txtLevelNumber.Text) Is Nothing Or txtLevelNumber.Text = "" Then
                    Return 0
                End If
                Return Convert.ToInt16(txtLevelNumber.Text)
            End Get
            Set
                txtLevelNumber.Text = Value
            End Set
        End Property

        Public Property NormalBalance As String Implements IChartView.NormalBalance
            Get
                Return cboNormalBalance.GetValue()
            End Get
            Set
                cboNormalBalance.SetValue(Value)
            End Set
        End Property

        Public Property Notes As String Implements IChartView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property ParentIdNo As Int32? Implements IChartView.ParentIdNo
            Get
                Return CType(cboParentIdNo.GetValue(), Integer?)
            End Get
            Set
                cboParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PayeeType As String Implements IChartView.PayeeType
            Get
                Return cboPayeeType.GetValue()
            End Get
            Set
                cboPayeeType.SetValue(Value)
            End Set
        End Property

        Public Property SortKey As String Implements IChartView.SortKey
            Get
                Return txtSortKey.Text
            End Get
            Set
                txtSortKey.Text = Value
            End Set
        End Property

        Public Property WithReconciliation As Boolean Implements IChartView.WithReconciliation
            Get
                Return chkWithReconciliation.Checked
            End Get
            Set
                chkWithReconciliation.Checked = Value
            End Set
        End Property

        Public Property SpecialAccount As String Implements IChartView.SpecialAccount
            Get
                Return cboSpecialAccount.GetValue()
            End Get
            Set
                cboSpecialAccount.SetValue(Value)
            End Set
        End Property

        Public Sub CheckIfEditable() Handles MyBase.BeforeEdit
            If String.IsNullOrEmpty(txtLevelNumber.Text) OrElse CInt(txtLevelNumber.Text) = 0 Then
                _MBMainAccountNotEditable.Show(Me)
                PresenterObj.CancelEdit = True
            End If
        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("ChartTypeSelection", GetType(ChartTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

        Public Sub OnAfterSave() Handles MyBase.AfterSave
            cboParentIdNo.DataSource = PresenterObj.GetChartList("AccountName")
            cboParentIdNo.Refresh()
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If PresenterObj.EditMode And ParentIdNo = IDNo Then
                Messaging.Show(True, "MsgMemberCannotBeAParentToItself", "Sorry a member cannot be a parent to itself.", "Invalid Parent")
                PresenterObj.CancelSave = True
                Exit Sub
            End If
            If PresenterObj.EditMode And chkDetailAccount.Checked Then
                Dim acctName = PresenterObj.GetAccountNameOfChild(IDNo)
                If Not (acctName Is Nothing Or acctName = "") Then
                    Dim foundAccount = " (" & acctName & ")"
                    MessageBox.Show(Me,
                                    AccountStrings.ChartEntryTv_OnBeforeSave_Child_Account_Found_Message & foundAccount,
                                    AccountStrings.ChartEntryTv_OnBeforeSave_Child_Account_Found, MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    PresenterObj.CancelSave = True
                End If
            End If
            'If PresenterObj.EditMode then
            '    Dim cOldParentId As String = PresenterObj.GetOriginalValue(cacParentIdNo)
            '    If cOldParentId <> cacParentIdNo.Text Then
            '        ' ParentID is changed by the user so
            '        ' check for records which have this record as parent.
            '        ' check for matching children entries
            '        If CommonDaoOld.CountRecordWithKey(TxtIDNo.Text, MainTableName, "ParentIdNo") > 0 Then
            '            _MBParentWithChildrenChangedDisallowed.Show(Me)
            '            CancelSave = True
            '            Exit Sub
            '        End If
            '    End If
            'End If
        End Sub

        Protected Overrides Sub CreateDataSources()
            cboParentIdNo.DataSource = PresenterObj.GetChartList()
            cboAccountGroup.DataSource = PresenterObj.MakeEnumComboList(Of AccountGroupSelection)
            cboPayeeType.DataSource = PresenterObj.MakeEnumComboList(Of PayeeTypeSelection)
            cboNormalBalance.DataSource = PresenterObj.MakeEnumComboList(Of DebitCreditSelection)
            cboSpecialAccount.DataSource = PresenterObj.MakeEnumComboList(Of SpecialAccountSelection)
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                    {
                    {"AccountCode", txtAccountCode},
                    {"AccountGroup", cboAccountGroup},
                    {"AccountName", txtAccountName},
                    {"AccountNameAra", txtAccountNameAra},
                    {"Active", chkActive},
                    {"DetailAccount", chkDetailAccount},
                    {"IDNo", txtIdNo},
                    {"LevelNumber", txtLevelNumber},
                    {"NormalBalance", cboNormalBalance},
                    {"Notes", txtNotes},
                    {"ParentIdNo", cboParentIdNo},
                    {"PayeeType", cboPayeeType},
                    {"SortKey", txtSortKey},
                    {"SpecialAccount", cboSpecialAccount},
                    {"WithReconciliation", chkWithReconciliation}
                    }
        End Sub

        'Private Sub UpdateParentIdComboListData()
        '    Dim chartsList = PresenterObj.GetChartList("AccountName")
        '    ' need to change to blank because of error in selection using arrow keys.
        '    'cacParentIdNo.ValueMember = ""
        '    'cacParentIdNo.DisplayMember = ""
        '    cacParentIdNo.ValueMember = "IDNo"
        '    cacParentIdNo.DisplayMember = "Name"
        '    cacParentIdNo.DataSource = PresenterObj.GetChartList("AccountName")

        'End Sub
        'Public Sub CheckIfDeletable() Handles MyBase.BeforeDelete
        '    If CInt(txtLevelNumber.Text) = 0 Then
        '        _MBMainAccountNotEditable.Show(Me)
        '        CancelDelete = True
        '    End If
        'End Sub

        'Private Sub ParentIdNoTextChanged(sender As Object, e As EventArgs) Handles cacParentIdNo.TextChanged
        '    'If (value Is Nothing And cacParentIdNo.Text Is Nothing) Or value <> CInt(cacParentIdNo.Text) Then
        '    Dim x = PresenterObj.GetRecordFieldWithKey(cacParentIdNo.Text, "Chart", "IdNo", "LevelNumber")
        '    Dim y = PresenterObj.GetRecordFieldWithKey(cacParentIdNo.Text, "Chart", "IdNo", "AccountGroup")
        '    txtLevelNumber.Text = (CInt(x) + 1).ToString()
        '    cacAccountGroup.Text = AccountGroupToEnum(y)
        '    If cacParentIdNo.Text Is Nothing Or cacParentIdNo.Text = "" Then
        '        Select Case cacAccountGroup.Text
        '            Case AccountGroupSelection.Assets
        '                cacParentIdNo.Text = DebitCreditSelection.Debit
        '            Case AccountGroupSelection.Liabilities
        '                cacParentIdNo.Text = DebitCreditSelection.Credit
        '            Case AccountGroupSelection.Equity
        '                cacParentIdNo.Text = DebitCreditSelection.Credit
        '            Case AccountGroupSelection.Revenue
        '                cacParentIdNo.Text = DebitCreditSelection.Credit
        '            Case AccountGroupSelection.CostOfGoodsSold
        '                cacParentIdNo.Text = DebitCreditSelection.Debit
        '            Case AccountGroupSelection.Expenses
        '                cacParentIdNo.Text = DebitCreditSelection.Debit
        '        End Select
        '    End If
        'End Sub

    End Class

End Namespace