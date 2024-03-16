Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Views.Interfaces
Imports AATM.ServicesLayer.Services

Public Class SecurityGroupPresenter(Of TM As New)
    Inherits Presenter(Of ISecurityGroupView, TM)
    Implements ISubscriber(Of DgvItemsChanged)

    Protected DtInsertTable As New DataTable
    Protected DtUpdateTable As New DataTable
    Private _groupAccessService
    Private WithEvents _groupAccessDataGrid As CtDataGridView

    Public Sub New(itemView As ISecurityGroupView)
        MyBase.New(itemView)
        Service = New Service("SecurityGroup")
        TableName = "SecurityGroup_View"
        SortOrderKey = "SortKey"
        TreeViewMainField = "SecurityGroupName"
        TreeViewSecondaryField = "SecurityGroupCode"
        ParentFieldName = "ParentIdNo"

        DtInsertTable.Columns.Add("Editable", GetType(Boolean))
        DtInsertTable.Columns.Add("SecurityGroupIdNo", GetType(Int16))
        DtInsertTable.Columns.Add("SecurityObjectIdNo", GetType(Int16))
        DtInsertTable.Columns.Add("Visible", GetType(Boolean))

        DtUpdateTable.Columns.Add("Editable", GetType(Boolean))
        DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
        DtUpdateTable.Columns.Add("SecurityGroupIdNo", GetType(Int16))
        DtUpdateTable.Columns.Add("SecurityObjectIdNo", GetType(Int16))
        DtUpdateTable.Columns.Add("Visible", GetType(Boolean))

        _groupAccessService = New Service("GroupAccess")

        AddHandler View.CheckAllEvent, AddressOf OnCheckAllHandler
        AddHandler View.UncheckAllEvent, AddressOf OnUnCheckAllHandler

    End Sub

    Protected Overrides Sub CreateDataSources()
        MakeControlDataSources({New Object() {"SecurityGroup", "ParentIdNo", Nothing, Nothing}})
        Dim control = GetControlName("ParentIdNo")
        control.Refresh()
    End Sub

    Private Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
        Dim gaModel = Service.GetRecordsWithGroupIdNo(Of GroupAccessModel)(0, "SecurityObjectName")
        Dim gaView = New List(Of GroupAccessView)
        View.GroupAccesses = GlobalVariables.Mapper.Map(gaModel, gaView)
    End Sub

    Private Sub OnBeforeSave() Handles MyBase.BeforeSave
        If Not CancelSave Then
            DtInsertTable.Clear()
            DtUpdateTable.Clear()
            For Each groupAccess In View.GroupAccesses
                If groupAccess.IdNo <= 0 Then
                    If groupAccess.Visible OrElse groupAccess.Editable Then
                        DtInsertTable.Rows.Add(groupAccess.Editable, View.IdNo, groupAccess.SecurityObjectIdNo, groupAccess.Visible)
                    End If
                Else
                    DtUpdateTable.Rows.Add(groupAccess.Editable, groupAccess.IdNo, View.IdNo, groupAccess.SecurityObjectIdNo, groupAccess.Visible)
                End If
            Next
        End If
    End Sub

    Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
        Dim passedValue As Int32 = retVal
        retVal = UpdateChildData(_groupAccessService, DtUpdateTable, DtInsertTable, passedValue, "SecurityGroupIdNo")
    End Sub

    Protected Overrides Function IsBizDataValid() As Boolean
        Dim retValue = False
        If MyBase.IsBizDataValid() Then
            If EditMode And View.ParentIdNo = View.IdNo Then
                Messaging.Show(True, "MsgMemberCannotBeAParentToItself")
            Else
                retValue = True
            End If
        End If
        Return retValue
    End Function

    Public Sub ProcessRows(propertyName As String, value As Boolean)
        For Each groupAccessView In View.GroupAccesses
            Invoker.SetProperty(groupAccessView, propertyName, {value})
        Next
    End Sub

    Public Sub ProcessChildren(index As Integer, visibleColumn As Boolean)
        Dim key = View.GroupAccesses(index).SecurityObjectName
        Dim keyLength = Len(key)
        Dim visible = View.GroupAccesses(index).Visible
        Dim editable = View.GroupAccesses(index).Editable
        For Each groupAccess In View.GroupAccesses
            If Left(groupAccess.SecurityObjectName, keyLength) = key Then
                If visibleColumn Then
                    groupAccess.Visible = visible
                Else
                    groupAccess.Editable = editable
                End If
            End If
        Next
        If (visibleColumn And visible) Or (Not visibleColumn And editable) Then
            ' update parent only when Visible or Editable is True, otherwise don't
            UpdateParent(key, keyLength, visibleColumn, visible, editable)
        End If

    End Sub

    Private Sub UpdateParent(key As String, keyLength As Integer, visibleColumn As Boolean, visible As Boolean, editable As Boolean)
        For Each groupAccess In View.GroupAccesses
            Dim index As Integer = key.LastIndexOf(" > ", StringComparison.Ordinal)
            If index > 0 Then
                Dim parentKey = Left(key, index)
                If Left(groupAccess.SecurityObjectName, keyLength) = parentKey Then
                    If visibleColumn Then
                        groupAccess.Visible = visible
                    Else
                        groupAccess.Editable = editable
                    End If
                    Dim curKey As String = parentKey
                    Dim curKeyLength As Integer = Len(curKey)
                    UpdateParent(curKey, curKeyLength, visibleColumn, visible, editable)
                End If
            End If
        Next
    End Sub

    Private Sub OnCheckAllHandler(propertyName As String)
        ProcessRows(propertyName, True)
    End Sub

    Private Sub OnUnCheckAllHandler(propertyName As String)
        ProcessRows(propertyName, False)
    End Sub

    Public Sub OndgvItemsChangedEventHandler(ByRef eventType As DgvItemsChanged) Implements ISubscriber(Of DgvItemsChanged).OnEventHandler
        If eventType.PropertyName = "Visible" Then
            ProcessChildren(eventType.Row, True)
        Else
            ProcessChildren(eventType.Row, False)
        End If
    End Sub

End Class