Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Views.Interfaces

Public Class SecurityGroupPresenter
    Inherits Presenter(Of ISecurityGroupView, SecurityGroupModel)

    Protected DtInsertTable As New DataTable
    Protected DtUpdateTable As New DataTable
    Private _groupAccessModel

    Public Sub New(view As ISecurityGroupView)
        MyBase.New(view)
        ModelOfPresenter = New Model("SecurityGroup")
        'TableName = "SecurityGroup_View"
        SortOrderKey = "SecurityGroupName"
        TreeViewMainField = "SecurityGroupName"
        TreeViewSecondaryField = "SecurityGroupCode"
        TreeViewParentIdField = "ParentIdNo"
        OriginalModel = New SecurityGroupModel()
        DataModel = New SecurityGroupModel
        TreeViewList = New List(Of SecurityGroupModel)
        Ea = New EventAggregator()
        Ea.SubscribeEvent(Me)

        DtInsertTable.Columns.Add("Editable", GetType(Boolean))
        DtInsertTable.Columns.Add("SecurityGroupIdNo", GetType(Int16))
        DtInsertTable.Columns.Add("SecurityObjectIdNo", GetType(Int16))
        DtInsertTable.Columns.Add("Visible", GetType(Boolean))

        DtUpdateTable.Columns.Add("Editable", GetType(Boolean))
        DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
        DtUpdateTable.Columns.Add("SecurityGroupIdNo", GetType(Int16))
        DtUpdateTable.Columns.Add("SecurityObjectIdNo", GetType(Int16))
        DtUpdateTable.Columns.Add("Visible", GetType(Boolean))

        _groupAccessModel = New Model("GroupAccess")

    End Sub

    Private Sub OnBeforeAdd() Handles MyBase.BeforeAdd
        Dim gaModel = Model.GetRecordsWithGroupIdNo(Of GroupAccessModel)(0, "SecurityObjectName")
        Dim gaView = New List(Of GroupAccessView)
        View.GroupAccesses = GlobalVariables.Mapper.Map(gaModel, gaView)
    End Sub

    Private Sub OnBeforeSave() Handles MyBase.BeforeSave
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
    End Sub

    'Public Sub OnParentRecordUpdatedSuccessfully(ByRef passedValue As Integer) Handles MyBase.RecordUpdatedSuccessfully
    '    Dim updateReturnValue As Integer
    '    updateReturnValue = ModelOfPresenter.DelUpdateTvp(DtUpdateTable, View.ParentIdNo)
    '    If updateReturnValue >= 0 AndAlso DtInsertTable.Rows.Count > 0 Then
    '        For Each row As DataRow In DtInsertTable.Rows
    '            row.Item("SecurityGroupIdNo") = View.IdNo
    '        Next
    '        Dim insertReturnValue = Model.InsertTvp(DtInsertTable)
    '        If insertReturnValue >= 0 Then
    '            passedValue = updateReturnValue + insertReturnValue
    '        Else
    '            passedValue = insertReturnValue
    '        End If
    '    Else
    '        passedValue = updateReturnValue
    '    End If
    'End Sub

    Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
        Dim passedValue As Int32 = retVal
        retVal = UpdateChildData(_groupAccessModel, DtUpdateTable, DtInsertTable, passedValue, "SecurityGroupIdNo")
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

    Public Sub ProcessRows(groupAccessesView As List(Of GroupAccessView), propertyName As String, value As Boolean)
        For Each groupAccessView In groupAccessesView
            CallByName(groupAccessView, propertyName, CallType.Set, {value})
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

End Class