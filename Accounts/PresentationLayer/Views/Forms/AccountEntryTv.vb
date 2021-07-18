Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class AccountEntryTv
        Implements IAccountView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            ParentFieldName = "ParentIdNo"
            FirstControl = txtAccountCode
            ' Add any initialization after the InitializeComponent() call.
        End Sub



#Region "Fields"
        Public Property AccountCode As String Implements IAccountView.AccountCode
            Get
                Return txtAccountCode.Text
            End Get
            Set
                txtAccountCode.Text = Value
            End Set
        End Property

        Public Property AccountGroup As String Implements IAccountView.AccountGroup
            Get
                Return cboAccountGroup.GetValue()
            End Get
            Set
                cboAccountGroup.SetValue(Value)
            End Set
        End Property

        Public Property AccountName As String Implements IAccountView.AccountName
            Get
                Return txtAccountName.Text
            End Get
            Set
                txtAccountName.Text = Value
            End Set
        End Property

        Public Property AccountNameAra As String Implements IAccountView.AccountNameAra
            Get
                Return txtAccountNameAra.Text
            End Get
            Set
                txtAccountNameAra.Text = Value
            End Set
        End Property

        Public Property Active As Boolean Implements IAccountView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property DetailAccount As Boolean Implements IAccountView.DetailAccount
            Get
                Return chkDetailAccount.Checked
            End Get
            Set
                chkDetailAccount.Checked = Value
            End Set
        End Property

        Public Property IdNo As Int16 Implements IAccountView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int16)(txtIdNo.Text)
            End Get
            Set
                txtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property LevelNumber As Int16 Implements IAccountView.LevelNumber
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

        Public Property NormalBalance As String Implements IAccountView.NormalBalance
            Get
                Return cboNormalBalance.GetValue()
            End Get
            Set
                cboNormalBalance.SetValue(Value)
            End Set
        End Property

        Public Property Notes As String Implements IAccountView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property ParentIdNo As Int16? Implements IAccountView.ParentIdNo
            Get
                Return cboParentIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PayeeType As String Implements IAccountView.PayeeType
            Get
                Return cboPayeeType.GetValue()
            End Get
            Set
                cboPayeeType.SetValue(Value)
            End Set
        End Property

        Public Property SortKey As String Implements IAccountView.SortKey
            Get
                Return txtSortKey.Text
            End Get
            Set
                txtSortKey.Text = Value
            End Set
        End Property

        Public Property WithReconciliation As Boolean Implements IAccountView.WithReconciliation
            Get
                Return chkWithReconciliation.Checked
            End Get
            Set
                chkWithReconciliation.Checked = Value
            End Set
        End Property

        Public Property SpecialAccount As String Implements IAccountView.SpecialAccount
            Get
                Return cboSpecialAccount.GetValue()
            End Get
            Set
                cboSpecialAccount.SetValue(Value)
            End Set
        End Property
#End Region
        Public Event ParentIdUpdated(ByRef accountGroupEditable As Boolean) Implements IAccountView.ParentIdUpdated


        'Public Sub CheckIfEditable() Handles MyBase.BeforeEdit
        '    If String.IsNullOrEmpty(txtLevelNumber.Text) OrElse CInt(txtLevelNumber.Text) = 0 Then
        '        _MBMainAccountNotEditable.Show(Me)
        '        PresenterObj.CancelEdit = True
        '    End If
        'End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("Account", cboParentIdNo)
            CreateEnumDataSource(Of AccountGroupSelection)(cboAccountGroup)
            CreateEnumDataSource(Of PayeeTypeSelection)(cboPayeeType)
            CreateEnumDataSource(Of DebitCreditSelection)(cboNormalBalance)
            CreateEnumDataSource(Of SpecialAccountSelection)(cboSpecialAccount)
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                    {
                    {"AccountCode", txtAccountCode},
                    {"AccountGroup", cboAccountGroup},
                    {"AccountName", txtAccountName},
                    {"AccountNameAra", txtAccountNameAra},
                    {"Active", chkActive},
                    {"DetailAccount", chkDetailAccount},
                    {"IdNo", txtIdNo},
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

        Private Sub OnInputsTurnedOn() Handles MyBase.InputsTurnedOn
            If PresenterObj.AccountHasChildren(IdNo) Then
                cboParentIdNo.DisplayOnly = True
                cboNormalBalance.DisplayOnly = True
            Else
                cboParentIdNo.DisplayOnly = False
            End If
            If PresenterObj.EditableAccountGroup(IdNo, cboParentIdNo.SelectedValue) Then
                cboAccountGroup.DisplayOnly = False
            Else
                cboAccountGroup.DisplayOnly = True
            End If
            If LevelNumber = 0 Then
                cboNormalBalance.DisplayOnly = True
                cboPayeeType.DisplayOnly = True
                cboSpecialAccount.DisplayOnly = True
                chkDetailAccount.DisplayOnly = True
                chkActive.DisplayOnly = True
                chkWithReconciliation.DisplayOnly = True
            Else
                cboNormalBalance.DisplayOnly = False
                cboPayeeType.DisplayOnly = False
                cboSpecialAccount.DisplayOnly = False
                chkDetailAccount.DisplayOnly = False
                chkActive.DisplayOnly = False
                chkWithReconciliation.DisplayOnly = False
            End If
        End Sub

        Private Sub CboParentIdNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboParentIdNo.SelectedIndexChanged
            Dim editable As Boolean
            RaiseEvent ParentIdUpdated(editable)
            If editable Then
                cboAccountGroup.DisplayOnly = False
            Else
                cboAccountGroup.DisplayOnly = True
            End If
        End Sub

    End Class

End Namespace