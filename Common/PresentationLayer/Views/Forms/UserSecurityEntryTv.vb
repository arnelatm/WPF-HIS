Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views.Forms

    Public Class UserSecurityEntryTv
        Implements IUserSecurityView

        Private WithEvents _dgvUserSecurity As CtDataGridView
        Private _userAccesses As List(Of UserAccessView)

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            FirstControl = UserSecurityView.txtUserName
            _dgvUserSecurity = UserSecurityView.DataGridViewUserAccesses

        End Sub

#Region "UserSecurityFields"

        Public Property IdNo As Int16 Implements IUserSecurityView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int16)(UserSecurityView.TxtIdNo.Text)
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
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = UserSecurityView.bsUserAccesses
                Invoker.SetProperty(UserSecurityView.DataGridViewUserAccesses.Columns("DGVSecurityObjectName"), "DisplayOnly", {True})
                .AutoResizeColumns()
                .Refresh()
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
                Return _userAccesses
            End Get
            Set(value As List(Of UserAccessView))
                _userAccesses = value
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

        Private Sub gridCategories_CellMouseUp(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles _dgvUserSecurity.CellMouseUp
            ' needs this because after clicking a cell the CellEndEdit doesn't trigger for checkbox unless focus moves to another control
            ' so this sub will trigger the CellEndEdit for checkBoxes DgvVisible and DgvEditable
            If e.ColumnIndex = _dgvUserSecurity.Columns("DgvVisible").Index Or e.ColumnIndex = _dgvUserSecurity.Columns("DgvEditable").Index Then
                ' endEdit to trigger checkbox change
                _dgvUserSecurity.EndEdit()
            End If
        End Sub

        Private Sub DgvUserAccess_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles _dgvUserSecurity.CellEndEdit
            Dim firstDisplayedRow = _dgvUserSecurity.FirstDisplayedScrollingRowIndex
            ProcessCellEndEdit(_dgvUserSecurity, UserSecurityView.bsUserAccesses)
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

End Namespace
