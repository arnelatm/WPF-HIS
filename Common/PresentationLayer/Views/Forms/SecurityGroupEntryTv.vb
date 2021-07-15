Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views.Forms

    Public Class SecurityGroupEntryTv
        Implements ISecurityGroupView

        Private WithEvents _dgvSecurityGroup As CDataGridView
        Private _groupAccesses As List(Of GroupAccessView)

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            ParentFieldName = "ParentIdNo"
            FirstControl = SecurityGroupView.txtSecurityGroupCode
            _dgvSecurityGroup = SecurityGroupView.DataGridViewGroupAccesses

        End Sub

#Region "SecurityGroupFields"

        Public Property IdNo As Int16 Implements ISecurityGroupView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int16)(SecurityGroupView.TxtIdNo.Text)
            End Get
            Set
                SecurityGroupView.TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property Notes As String Implements ISecurityGroupView.Notes
            Get
                Return SecurityGroupView.txtNotes.Text
            End Get
            Set
                SecurityGroupView.txtNotes.Text = Value
            End Set
        End Property

        Public Property ParentIdNo As Int16? Implements ISecurityGroupView.ParentIdNo
            Get
                Return SecurityGroupView.cacParentIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                SecurityGroupView.cacParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property SecurityGroupCode As String Implements ISecurityGroupView.SecurityGroupCode
            Get
                Return SecurityGroupView.txtSecurityGroupCode.Text
            End Get
            Set
                SecurityGroupView.txtSecurityGroupCode.Text = Value
            End Set
        End Property

        Public Property SecurityGroupName As String Implements ISecurityGroupView.SecurityGroupName
            Get
                Return SecurityGroupView.txtSecurityGroupName.Text
            End Get
            Set
                SecurityGroupView.txtSecurityGroupName.Text = Value
            End Set
        End Property

        Public Property SecurityGroupNameAra As String Implements ISecurityGroupView.SecurityGroupNameAra
            Get
                Return SecurityGroupView.txtSecurityGroupNameAra.Text
            End Get
            Set
                SecurityGroupView.txtSecurityGroupNameAra.Text = Value
            End Set
        End Property

        Private Sub BindGroupAccess()
            SuspendLayout()
            SecurityGroupView.bsGroupAccesses.DataSource = GroupAccesses
            SecurityGroupView.bsGroupAccesses.AllowNew = False
            With SecurityGroupView.DataGridViewGroupAccesses
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = SecurityGroupView.bsGroupAccesses
                LateBinding.SetProperty(SecurityGroupView.DataGridViewGroupAccesses.Columns("DGVSecurityObjectName"), "DisplayOnly", {True})
                .AutoResizeColumns()
                .Refresh()
            End With
            ResumeLayout()
        End Sub

#End Region

        Public Event CheckAllEvent(propertyName As String) Implements ISecurityGroupView.CheckAllEvent

        Public Event UncheckAllEvent(propertyName As String) Implements ISecurityGroupView.UncheckAllEvent

        Private Sub OnBtnCheckAllVisible() Handles btnCheckAllVisible.ClickButtonArea
            RaiseEvent CheckAllEvent("Visible")
            SecurityGroupView.bsGroupAccesses.ResetBindings(False)
        End Sub

        Private Sub OnBtnCheckAllEditable() Handles btnCheckAllEditable.ClickButtonArea
            RaiseEvent CheckAllEvent("Editable")
            SecurityGroupView.bsGroupAccesses.ResetBindings(False)
        End Sub

        Private Sub OnBtnUncheckAllVisible() Handles btnUncheckAllVisible.ClickButtonArea
            RaiseEvent UncheckAllEvent("Visible")
            SecurityGroupView.bsGroupAccesses.ResetBindings(False)
        End Sub

        Private Sub OnBtnUncheckAllEditable() Handles btnUncheckAllEditable.ClickButtonArea
            RaiseEvent UncheckAllEvent("Editable")
            SecurityGroupView.bsGroupAccesses.ResetBindings(False)
        End Sub

        Public Property GroupAccesses As List(Of GroupAccessView) Implements ISecurityGroupView.GroupAccesses
            Get
                Return _groupAccesses
            End Get
            Set(value As List(Of GroupAccessView))
                _groupAccesses = value
                BindGroupAccess()
            End Set
        End Property

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("SecurityGroup", SecurityGroupView.cacParentIdNo)
            SecurityGroupView.cacParentIdNo.Refresh()
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            With SecurityGroupView
                MainFieldsDictionary = New Dictionary(Of String, Object) From
                    {
                    {"IdNo", .TxtIdNo},
                    {"Notes", .txtNotes},
                    {"ParentId", .TxtIdNo},
                    {"ParentIdNo", .cacParentIdNo},
                    {"SecurityGroupCode", .txtSecurityGroupCode},
                    {"SecurityGroupName", .txtSecurityGroupName},
                    {"SecurityGroupNameAra", .txtSecurityGroupNameAra}
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

        Private Sub DgvGroupAccess_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles _dgvSecurityGroup.CellEndEdit
            Dim firstDisplayedRow = _dgvSecurityGroup.FirstDisplayedScrollingRowIndex
            ProcessCellEndEdit(_dgvSecurityGroup, SecurityGroupView.bsGroupAccesses)
            SecurityGroupView.bsGroupAccesses.ResetBindings(False)
            SecurityGroupView.DataGridViewGroupAccesses.FirstDisplayedScrollingRowIndex = firstDisplayedRow
        End Sub

    End Class

End Namespace