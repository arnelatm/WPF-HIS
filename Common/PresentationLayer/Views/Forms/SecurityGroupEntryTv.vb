Imports AATM.Libraries
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Views.Forms

    Public Class SecurityGroupEntryTv
        Implements ISubscriber(Of DataGridCellChanged)

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "SecurityGroup_View"
            TvMainFieldName = "SecurityGroupName"
            TvSecondaryFieldName = "SecurityGroupCode"
            SortOrderKey = "SecurityGroupName"
            ParentFieldName = "ParentIdNo"
            FirstControl = SecurityGroupView.txtSecurityGroupCode

            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New SecurityGroupPresenter(SecurityGroupView)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
            EaSg = SecurityGroupView.Ea
            EaSg.SubscribeEvent(Me)

        End Sub

        Private Property EaSg As EventAggregator

        Protected Overrides Sub CreateDataSources()
            UpdateParentIdData()
        End Sub

        Private Sub UpdateParentIdData()
            SecurityGroupView.cacParentIdNo.DataSource = PresenterObj.GetLookup("SecurityGroup")
        End Sub

        Protected Overrides Sub RecordSaved(ByRef e As RecordSaved)
            MyBase.RecordSaved(e)
            UpdateParentIdData()
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

        Protected Overrides Sub InputsTurnedOn()
            MyBase.InputsTurnedOn()
            btnCheckAllEditable.Enabled = True
            btnCheckAllVisible.Enabled = True
            btnUncheckAllEditable.Enabled = True
            btnUncheckAllVisible.Enabled = True
        End Sub

        Protected Overrides Sub InputsTurnedOff()
            MyBase.InputsTurnedOff()
            btnCheckAllEditable.Enabled = False
            btnCheckAllVisible.Enabled = False
            btnUncheckAllEditable.Enabled = False
            btnUncheckAllVisible.Enabled = False
        End Sub

        Private Sub btnCheckAllVisible_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCheckAllVisible.ClickButtonArea
            PresenterObj.ProcessRows(SecurityGroupView.GroupAccesses, "Visible", True)
            SecurityGroupView.bsGroupAccesses.ResetBindings(False)
        End Sub

        Private Sub btnCheckAllEditable_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCheckAllEditable.ClickButtonArea
            PresenterObj.ProcessRows(SecurityGroupView.GroupAccesses, "Editable", True)
            SecurityGroupView.bsGroupAccesses.ResetBindings(False)
        End Sub

        Private Sub btnUncheckAllVisible_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnUncheckAllVisible.ClickButtonArea
            PresenterObj.ProcessRows(SecurityGroupView.GroupAccesses, "Visible", False)
            SecurityGroupView.bsGroupAccesses.ResetBindings(False)
        End Sub

        Private Sub btnUncheckAllEditable_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnUncheckAllEditable.ClickButtonArea
            PresenterObj.ProcessRows(SecurityGroupView.GroupAccesses, "Editable", False)
            SecurityGroupView.bsGroupAccesses.ResetBindings(False)
        End Sub

        Public Sub OnEventHandler(ByRef e As DataGridCellChanged) Implements ISubscriber(Of DataGridCellChanged).OnEventHandler
            Dim firstDisplayedRow = SecurityGroupView.DataGridViewGroupAccesses.FirstDisplayedScrollingRowIndex
            If e.ColumnName.ToLower() = $"dgvvisible" Then
                PresenterObj.ProcessChildren(e.Index, True)
            Else
                PresenterObj.ProcessChildren(e.Index, False)
            End If
            SecurityGroupView.bsGroupAccesses.ResetBindings(False)
            'SecurityGroupView.DataGridViewGroupAccesses.CurrentCell = SecurityGroupView.DataGridViewGroupAccesses.Rows(e.Index).Cells(e.ColumnName)
            SecurityGroupView.DataGridViewGroupAccesses.FirstDisplayedScrollingRowIndex = firstDisplayedRow
        End Sub

    End Class

End Namespace