Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Views.Interfaces

Public Class UserSecurityEntryTv
    Implements IUserSecurityView

    Private WithEvents _dgvSecurityGroup As CtDataGridView
    Private _UserAccesses As List(Of UserAccessView)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FirstControl = UserSecurityView.txtUserName
        _dgvSecurityGroup = UserSecurityView.DataGridViewUserAccesses

    End Sub

#Region "UserSecurityFields"

    Public Property IdNo As Short Implements IUserSecurityView.IdNo
        Get
            Return GlobalFunctions.NumParser(Of Short)(UserSecurityView.TxtIdNo.Text)
        End Get
        Set
            UserSecurityView.TxtIdNo.Text = Convert.ToString(Value)
        End Set
    End Property

    Private Sub BindUserAccess()
        SuspendLayout()
        UserSecurityView.bsUserAccesses.DataSource = UserAccesses
        UserSecurityView.bsUserAccesses.AllowNew = False
        With UserSecurityView.DataGridViewUserAccesses
            Call .Refresh()
            .AutoGenerateColumns = False
            .DataSource = UserSecurityView.bsUserAccesses
            Invoker.SetProperty(UserSecurityView.DataGridViewUserAccesses.Columns("DGVSecurityObjectName"), "DisplayOnly", {True})
            Call .AutoResizeColumns()
            Call .Refresh()
        End With
        ResumeLayout()
    End Sub

#End Region

    Public Event CheckAllEvent(propertyName As String) Implements IUserSecurityView.CheckAllEvent

    Public Event UncheckAllEvent(propertyName As String) Implements IUserSecurityView.UncheckAllEvent

    Private Sub OnBtnCheckAllVisible() Handles btnCheckAllVisible.ClickButtonArea
        RaiseEvent CheckAllEvent("Visible")
        UserSecurityView.bsUserAccesses.ResetBindings(False)
    End Sub

    Private Sub OnBtnCheckAllEditable() Handles btnCheckAllEditable.ClickButtonArea
        RaiseEvent CheckAllEvent("Editable")
        UserSecurityView.bsUserAccesses.ResetBindings(False)
    End Sub

    Private Sub OnBtnUncheckAllVisible() Handles btnUncheckAllVisible.ClickButtonArea
        RaiseEvent UncheckAllEvent("Visible")
        UserSecurityView.bsUserAccesses.ResetBindings(False)
    End Sub

    Private Sub OnBtnUncheckAllEditable() Handles btnUncheckAllEditable.ClickButtonArea
        RaiseEvent UncheckAllEvent("Editable")
        UserSecurityView.bsUserAccesses.ResetBindings(False)
    End Sub
    Public Property UserAccesses As List(Of UserAccessView) Implements IUserSecurityView.UserAccesses
        Get
            Return _UserAccesses
        End Get
        Set(value As List(Of UserAccessView))
            _UserAccesses = value
            'BindUserAccess()
        End Set
    End Property

    Public Property UserName As String Implements IUserSecurityView.UserName
        Get
            Return UserSecurityView.txtUserName.Text
        End Get
        Set(value As String)
            UserSecurityView.txtUserName.Text = value
        End Set
    End Property

    Private Property IUserSecurityView_Active As Boolean Implements IUserSecurityView.Active
    Private Property IUserSecurityView_EmployeeIdNo As Integer? Implements IUserSecurityView.EmployeeIdNo
    Private Property IUserSecurityView_Password As String Implements IUserSecurityView.Password
    Private Property IUserSecurityView_SecurityLevel As Short Implements IUserSecurityView.SecurityLevel
    Private Property IUserSecurityView_SecurityGroupIdNo As Short Implements IUserSecurityView.SecurityGroupIdNo
    Protected Overrides Sub CreateMainFieldsDictionary()
        With UserSecurityView
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                    {
                    {"IdNo", .TxtIdNo},
                    {"UserName", .txtUserName}
                    }
        End With
    End Sub

    Protected Sub OnInputsTurnedOff() Handles MyBase.InputsTurnedOff
        btnCheckAllEditable.Enabled = False
        btnCheckAllVisible.Enabled = False
        btnUncheckAllEditable.Enabled = False
        btnUncheckAllVisible.Enabled = False
    End Sub

    Protected Sub OnInputsTurnedOn() Handles MyBase.InputsTurnedOn
        btnCheckAllEditable.Enabled = True
        btnCheckAllVisible.Enabled = True
        btnUncheckAllEditable.Enabled = True
        btnUncheckAllVisible.Enabled = True
    End Sub

    Private Sub gridCategories_CellMouseUp(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles _dgvSecurityGroup.CellMouseUp
        ' needs this because after clicking a cell the CellEndEdit doesn't trigger for checkbox unless focus moves to another control
        ' so this sub will trigger the CellEndEdit for checkBoxes DgvVisible and DgvEditable
        If e.ColumnIndex = _dgvSecurityGroup.Columns("DgvVisible").Index Or e.ColumnIndex = _dgvSecurityGroup.Columns("DgvEditable").Index Then
            ' endEdit to trigger checkbox change
            _dgvSecurityGroup.EndEdit()
        End If
    End Sub

    Private Sub DgvUserAccess_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles _dgvSecurityGroup.CellEndEdit
        Dim firstDisplayedRow = _dgvSecurityGroup.FirstDisplayedScrollingRowIndex
        ProcessCellEndEdit(_dgvSecurityGroup, UserSecurityView.bsUserAccesses)
        'UserSecurityView.bsUserAccesses.ResetBindings(False)
        UserSecurityView.DataGridViewUserAccesses.FirstDisplayedScrollingRowIndex = firstDisplayedRow
    End Sub

    Protected Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
        UserSecurityView.bsUserAccesses.ResetBindings(False)
    End Sub

    Private Sub UserSecurityEntryTv_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        BindUserAccess()
    End Sub

End Class