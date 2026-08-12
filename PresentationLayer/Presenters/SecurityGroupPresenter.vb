Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Views.Interfaces
Imports AATM.ServicesLayer.Services

Public Class SecurityGroupPresenter(Of TM As New)
    Inherits Presenter(Of ISecurityGroupView, TM)

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
        AddHandler View.GroupAccessChanged, AddressOf OnGroupAccessChanged

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

    Public Sub UpdateCode(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
        'Dim passedValue As Integer = retVal
        If retVal >= 0 And GlobalFunctions.IsEmpty(View.SecurityGroupCode) Then
            retVal = Service.GenerateCode(View.IdNo)
            View.SecurityGroupCode = Service.GetFieldWithIdNo(View.IdNo, "SecurityGroup", "SecurityGroupCode")
        End If
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

    Public Sub ProcessChildren(selectedAccess As GroupAccessView, propertyName As String, selectedValue As Boolean)
        If View.GroupAccesses Is Nothing OrElse selectedAccess Is Nothing Then
            Return
        End If

        Dim key = If(selectedAccess.SecurityObjectName, String.Empty).Trim()
        If key.Length = 0 Then
            Return
        End If

        Dim visibleColumn = propertyName = "Visible"
        Dim descendantPrefix = key & " > "

        For Each groupAccess In View.GroupAccesses
            Dim securityObjectName = If(groupAccess.SecurityObjectName, String.Empty).Trim()
            If String.Equals(securityObjectName, key, StringComparison.Ordinal) OrElse
               securityObjectName.StartsWith(descendantPrefix, StringComparison.Ordinal) Then
                If visibleColumn Then
                    groupAccess.Visible = selectedValue
                Else
                    groupAccess.Editable = selectedValue
                End If
            End If
        Next

        If selectedValue Then
            UpdateParents(key, visibleColumn)
        End If
    End Sub

    Private Sub UpdateParents(key As String, visibleColumn As Boolean)
        Dim separatorIndex = key.LastIndexOf(" > ", StringComparison.Ordinal)

        While separatorIndex > 0
            Dim parentKey = key.Substring(0, separatorIndex)
            For Each groupAccess In View.GroupAccesses
                Dim securityObjectName = If(groupAccess.SecurityObjectName, String.Empty).Trim()
                If String.Equals(securityObjectName, parentKey, StringComparison.Ordinal) Then
                    If visibleColumn Then
                        groupAccess.Visible = True
                    Else
                        groupAccess.Editable = True
                    End If
                    Exit For
                End If
            Next

            key = parentKey
            separatorIndex = key.LastIndexOf(" > ", StringComparison.Ordinal)
        End While
    End Sub

    Private Sub OnCheckAllHandler(propertyName As String)
        ProcessRows(propertyName, True)
    End Sub

    Private Sub OnUnCheckAllHandler(propertyName As String)
        ProcessRows(propertyName, False)
    End Sub

    Private Sub OnGroupAccessChanged(groupAccess As GroupAccessView, propertyName As String, value As Boolean)
        Select Case propertyName
            Case "Visible"
                ProcessChildren(groupAccess, propertyName, value)
            Case "Editable"
                ProcessChildren(groupAccess, propertyName, value)
        End Select
    End Sub

End Class
