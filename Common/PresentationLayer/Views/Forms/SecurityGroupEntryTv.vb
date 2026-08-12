Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Views.Interfaces
Imports System.Drawing
Imports System.Windows.Forms

Namespace PresentationLayer.Views.Forms

    Public Class SecurityGroupEntryTv
        Implements ISecurityGroupView

        Private WithEvents _dgvSecurityGroup As CtDataGridView
        Private _groupAccesses As List(Of GroupAccessView)
        Private ReadOnly _securityGroupOriginalLeftPositions As New Dictionary(Of Control, Integer)
        Private _securityGroupLayoutCaptured As Boolean
        Private _securityGroupLayoutRightToLeft As Boolean

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            ParentFieldName = "ParentIdNo"
            FirstControl = SecurityGroupView.txtSecurityGroupCode
            _dgvSecurityGroup = SecurityGroupView.DataGridViewGroupAccesses

        End Sub

        Protected Overrides Sub ApplyFastLanguageLayout(ByRef allCtrl As List(Of Control))
            MyBase.ApplyFastLanguageLayout(allCtrl)
            ApplySecurityGroupLanguageLayout(GlobalVariables.RightToLeftLayout)
        End Sub

        Private Sub ApplySecurityGroupLanguageLayout(rightToLeftLayout As Boolean)
            If SecurityGroupView Is Nothing Then
                Return
            End If

            CaptureSecurityGroupLayout()
            Dim targetRightToLeft = If(rightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
            Dim labelAlignment = If(rightToLeftLayout,
                                    ContentAlignment.MiddleRight,
                                    ContentAlignment.MiddleLeft)

            SecurityGroupView.SuspendLayout()
            Try
                SecurityGroupView.RightToLeft = targetRightToLeft
                For Each item In _securityGroupOriginalLeftPositions
                    Dim child = item.Key
                    Dim targetLeft = item.Value
                    If rightToLeftLayout Then
                        targetLeft = SecurityGroupView.ClientSize.Width - item.Value - child.Width
                    End If
                    If child.Left <> targetLeft Then
                        child.Left = targetLeft
                    End If

                    Dim label = TryCast(child, Label)
                    If label IsNot Nothing AndAlso label.TextAlign <> labelAlignment Then
                        label.TextAlign = labelAlignment
                    End If
                Next
                _securityGroupLayoutRightToLeft = rightToLeftLayout
            Finally
                SecurityGroupView.ResumeLayout(False)
            End Try
        End Sub

        Private Sub CaptureSecurityGroupLayout()
            If _securityGroupLayoutCaptured Then
                Return
            End If

            For Each child As Control In SecurityGroupView.Controls
                _securityGroupOriginalLeftPositions(child) = child.Left
            Next
            _securityGroupLayoutCaptured = True
        End Sub

        Private Sub SecurityGroupView_SizeChanged(sender As Object, e As EventArgs) Handles SecurityGroupView.SizeChanged
            If _securityGroupLayoutCaptured AndAlso _securityGroupLayoutRightToLeft Then
                ApplySecurityGroupLanguageLayout(True)
            End If
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
                Invoker.SetProperty(SecurityGroupView.DataGridViewGroupAccesses.Columns("DGVSecurityObjectName"), "DisplayOnly", {True})
                .AutoResizeColumns()
                .Refresh()
            End With
            ResumeLayout()
        End Sub

#End Region

        Public Event CheckAllEvent(propertyName As String) Implements ISecurityGroupView.CheckAllEvent

        Public Event UncheckAllEvent(propertyName As String) Implements ISecurityGroupView.UncheckAllEvent

        Public Event GroupAccessChanged(groupAccess As GroupAccessView, propertyName As String, value As Boolean) Implements ISecurityGroupView.GroupAccessChanged

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
                'BindGroupAccess()
            End Set
        End Property

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

        Private Sub DgvGroupAccess_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles _dgvSecurityGroup.CellContentClick
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
                Return
            End If

            Dim propertyName = _dgvSecurityGroup.Columns(e.ColumnIndex).DataPropertyName
            If propertyName <> "Visible" AndAlso propertyName <> "Editable" Then
                Return
            End If

            Dim groupAccess = TryCast(_dgvSecurityGroup.Rows(e.RowIndex).DataBoundItem, GroupAccessView)
            If groupAccess Is Nothing Then
                Return
            End If

            Dim value As Boolean
            Boolean.TryParse(Convert.ToString(_dgvSecurityGroup.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), value)

            Dim firstDisplayedRow = _dgvSecurityGroup.FirstDisplayedScrollingRowIndex
            _dgvSecurityGroup.EndEdit()
            SecurityGroupView.bsGroupAccesses.EndEdit()
            RaiseEvent GroupAccessChanged(groupAccess, propertyName, value)
            SecurityGroupView.bsGroupAccesses.ResetBindings(False)

            If firstDisplayedRow >= 0 AndAlso firstDisplayedRow < _dgvSecurityGroup.Rows.Count Then
                _dgvSecurityGroup.FirstDisplayedScrollingRowIndex = firstDisplayedRow
            End If
        End Sub

        Protected Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            SecurityGroupView.bsGroupAccesses.ResetBindings(False)
        End Sub


        Private Sub SecurityGroupEntryTv_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            BindGroupAccess()
        End Sub

    End Class

End Namespace
