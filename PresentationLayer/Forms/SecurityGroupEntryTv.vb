Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Public Class SecurityGroupEntryTv
    Implements ISecurityGroupView, IGroupAccessesView, ISecurityGroupsView

    Private ReadOnly _securityObjectsPresenter As SecurityObjectsPresenter
    Private ReadOnly _groupAccessPresenter As GroupAccessesPresenter
    Protected DtInsertTable As New DataTable
    Protected DtUpdateTable As New DataTable
    Private _groupAccesses As List(Of GroupAccessModel)

    Public Property SecurityGroups As IList(Of SecurityGroupModel) Implements ISecurityGroupsView.SecurityGroups

    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        MainTableName = "SecurityGroup"
        IdFieldName = "IdNo"
        TvMainFieldName = "SecurityGroupName"
        TvSecondaryFieldName = "SecurityGroupCode"
        SortOrderKey = "SecurityGroupName"
        FirstControl = txtSecurityGroupCode

        ' Add any initialization after the InitializeComponent() call.
        PresenterObj = New SecurityGroupPresenter(Me)
        GroupAccesses = New List(Of GroupAccessModel)
        _groupAccessPresenter = New GroupAccessesPresenter(Me)
        PresenterObj.GroupAccessesPresenter = _groupAccessPresenter

        'BindGroupAccess()

        DtInsertTable.Columns.Add("SecurityGroupIDNo", GetType(Int32))
        DtInsertTable.Columns.Add("SecurityObjectIDNo", GetType(Int32))
        DtInsertTable.Columns.Add("Visible", GetType(Boolean))
        DtInsertTable.Columns.Add("Selectable", GetType(Boolean))
        DtInsertTable.Columns.Add("Viewable", GetType(Boolean))
        DtInsertTable.Columns.Add("Editable", GetType(Boolean))

        DtUpdateTable.Columns.Add("IDNo", GetType(Int32))
        DtUpdateTable.Columns.Add("SecurityGroupIDNo", GetType(Int32))
        DtUpdateTable.Columns.Add("SecurityObjectIDNo", GetType(Int32))
        DtUpdateTable.Columns.Add("Visible", GetType(Boolean))
        DtUpdateTable.Columns.Add("Selectable", GetType(Boolean))
        DtUpdateTable.Columns.Add("Viewable", GetType(Boolean))
        DtUpdateTable.Columns.Add("Editable", GetType(Boolean))

        'CreateEnumResourceFile()
        'ResourceEnumConverter.MakeResource("SecurityGroupTypeSelection", GetType(SecurityGroupTypeSelection))
    End Sub

    Public Sub CreateEnumResourceFile()
        'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
        'ResourceEnumConverter.MakeResource("SecurityGroupTypeSelection", GetType(SecurityGroupTypeSelection))
        'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
    End Sub

#Region "SecurityGroupFields"

    Public Property IDNo As Integer Implements ISecurityGroupView.IdNo
        Get
            Return NumParser(Of Int32)(TxtIDNo.Text)
        End Get
        Set
            TxtIDNo.Text = Convert.ToString(Value)
        End Set
    End Property

    Public Property SecurityGroupCode As String Implements ISecurityGroupView.SecurityGroupCode
        Get
            Return txtSecurityGroupCode.Text
        End Get
        Set
            txtSecurityGroupCode.Text = Value
        End Set
    End Property

    Public Property SecurityGroupName As String Implements ISecurityGroupView.SecurityGroupName
        Get
            Return txtSecurityGroupName.Text
        End Get
        Set
            txtSecurityGroupName.Text = Value
        End Set
    End Property

    Public Property SecurityGroupNameAra As String Implements ISecurityGroupView.SecurityGroupNameAra
        Get
            Return txtSecurityGroupNameAra.Text
        End Get
        Set
            txtSecurityGroupNameAra.Text = Value
        End Set
    End Property

    Public Property Notes As String Implements ISecurityGroupView.Notes
        Get
            Return txtNotes.Text
        End Get
        Set
            txtNotes.Text = Value
        End Set
    End Property

#End Region

    Protected Overrides Sub AddMandatoryFieldCheck()
        'Add controls one by one in error provider.
        MyErrorProvider.Controls.AddMandatory(txtSecurityGroupCode, "SecurityGroup Code")
        MyErrorProvider.Controls.AddMandatory(txtSecurityGroupName, "SecurityGroup Name in English")
        'Set summary error message
        MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
    End Sub

#Region "GroupAccesses"

    Public Property GroupAccesses As IList(Of GroupAccessModel) Implements IGroupAccessesView.GroupAccesses
        Get
            Return _groupAccesses
        End Get
        Set(value As IList(Of GroupAccessModel))
            _groupAccesses = value
        End Set
    End Property

    Protected Overrides Sub DisplayView()
        MyBase.DisplayView()
        _groupAccessPresenter.Display(TargetIdNo, UndoMode)
        DataGridViewGroupAccesses.DataSource = Nothing
        DataGridViewGroupAccesses.DataSource = GroupAccesses
        DataGridViewGroupAccesses.Refresh()
        GroupAccessChanged = False
    End Sub

    Private Sub BindGroupAccess()
        SuspendLayout()
        bsGroupAccesses.DataSource = GroupAccesses
        bsGroupAccesses.AllowNew = False
        With DataGridViewGroupAccesses
            .Refresh()
            .AutoGenerateColumns = False
            .DataSource = bsGroupAccesses
            'CallByName(DataGridViewGroupAccesses.Columns("DGVSecurityObjectName").CellTemplate, "DisplayOnly", CallType.Set, True)
            CallByName(DataGridViewGroupAccesses.Columns("DGVSecurityObjectName"), "DisplayOnly", CallType.Set, True)
            .AutoResizeColumns()
            .Refresh()
        End With
        ResumeLayout()
    End Sub

    Private Sub OnDisplayedRecordChanged() Handles MyBase.DisplayedRecordChanged
        If Not DataGridViewGroupAccesses.DataBindings Is Nothing Then
            UpdateGroupAccessDisplay()
            GroupAccessChanged = False
            DataGridViewGroupAccesses.DataInGridChanged = False
        End If
    End Sub

    Private Sub UpdateGroupAccessDisplay()
        Try
            If TreeViewTableName.SelectedNode.Tag = 0 Then
                Return
            End If
        Catch ex As Exception
            Return
        End Try
        PresenterObj.GroupAccessesPresenter.Display(TargetIdNo)
    End Sub

    Private Sub OnInputsTurnedOn() Handles Me.InputsTurnedOn
        DataGridViewGroupAccesses.StartTrackingChanges = True
    End Sub

    Private Sub OnInputsTurnedOff() Handles Me.InputsTurnedOff
        DataGridViewGroupAccesses.StartTrackingChanges = False
    End Sub

    Public Property GroupAccessChanged As Boolean

#End Region

#Region "Event Handlers"

    Protected Sub OnDataGridChanged() Handles DataGridViewGroupAccesses.ChangesMade
        If DataGridViewGroupAccesses.DataInGridChanged Then
            GroupAccessChanged = True
        Else
            GroupAccessChanged = False
        End If
    End Sub

    Protected Overrides Function ChangesMade()
        If PresenterObj.ChangesMade() Then
            Return True
        End If
        Return GroupAccessChanged 'PresenterObj.GroupAccessesPresenter.ChangesMade()
    End Function

    Public Sub OnParentRecordUpdatedSuccessfully(passedValue As Integer) _
        Handles MyBase.ParentRecordUpdatedSuccessfully
        DtInsertTable.Clear()
        DtUpdateTable.Clear()
        For Each groupAccess In GroupAccesses
            If groupAccess.IdNo <= 0 Then
                If groupAccess.Visible OrElse groupAccess.Editable OrElse groupAccess.Selectable OrElse groupAccess.Editable Then
                    DtInsertTable.Rows.Add(IDNo, groupAccess.SecurityObjectIdNo, groupAccess.Visible, groupAccess.Selectable, groupAccess.Viewable,
                                           groupAccess.Editable)
                End If
            Else
                DtUpdateTable.Rows.Add(groupAccess.IdNo, IDNo, groupAccess.SecurityObjectIdNo,
                                       groupAccess.Visible, groupAccess.Selectable, groupAccess.Viewable, groupAccess.Editable)
            End If
        Next
        PresenterObj.GroupAccessesPresenter.Save(DtInsertTable, DtUpdateTable, IDNo)
    End Sub

#End Region

End Class