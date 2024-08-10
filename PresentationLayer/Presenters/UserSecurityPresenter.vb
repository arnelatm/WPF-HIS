Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Views.Interfaces
Imports AATM.ServicesLayer.Services

Public Class UserSecurityPresenter(Of TM As New)
    Inherits Presenter(Of IUserSecurityView, TM)
    Implements ISubscriber(Of DgvItemsChanged)

    Protected DtInsertTable As New DataTable
    Protected DtUpdateTable As New DataTable
    Private _UserAccessService
    Private WithEvents _UserAccessDataGrid As CtDataGridView

    Public Sub New(itemView As IUserSecurityView)
        MyBase.New(itemView)
        Service = New Service("UserSecurity")
        TableName = "User"
        SortOrderKey = "UserName"
        TreeViewMainField = "UserName"
        TreeViewSecondaryField = Nothing

        DtInsertTable.Columns.Add("Editable", GetType(Boolean))
        DtInsertTable.Columns.Add("SecurityObjectIdNo", GetType(Int16))
        DtInsertTable.Columns.Add("UserIdNo", GetType(Int16))
        DtInsertTable.Columns.Add("Visible", GetType(Boolean))

        DtUpdateTable.Columns.Add("Editable", GetType(Boolean))
        DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
        DtUpdateTable.Columns.Add("SecurityObjectIdNo", GetType(Int16))
        DtUpdateTable.Columns.Add("UserIdNo", GetType(Int16))
        DtUpdateTable.Columns.Add("Visible", GetType(Boolean))

        _UserAccessService = New Service("UserAccess")

        AddHandler View.CheckAllEvent, AddressOf OnCheckAllHandler
        AddHandler View.UncheckAllEvent, AddressOf OnUnCheckAllHandler

    End Sub

    'Protected Overrides Sub CreateDataSources()
    'End Sub

    Private Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
        Dim gaModel = Service.GetRecordsWithGroupIdNo(Of UserAccessModel)(0, "SecurityObjectName")
        Dim gaView = New List(Of UserAccessView)
        GlobalFunctions.ManualMap(gaModel, gaView)
        View.UserAccesses = gaView
    End Sub

    Private Sub OnBeforeSave() Handles MyBase.BeforeSave
        If Not CancelSave Then
            DtInsertTable.Clear()
            DtUpdateTable.Clear()
            For Each UserAccess In View.UserAccesses
                If UserAccess.IdNo <= 0 Then
                    If UserAccess.Visible OrElse UserAccess.Editable Then
                        DtInsertTable.Rows.Add(UserAccess.Editable, UserAccess.SecurityObjectIdNo, View.IdNo, UserAccess.Visible)
                    End If
                Else
                    DtUpdateTable.Rows.Add(UserAccess.Editable, UserAccess.IdNo, UserAccess.SecurityObjectIdNo, View.IdNo, UserAccess.Visible)
                End If
            Next
        End If
    End Sub

    Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
        Dim passedValue As Int32 = retVal
        retVal = UpdateChildData(_UserAccessService, DtUpdateTable, DtInsertTable, passedValue, "UserIdNo")
    End Sub

    Protected Overrides Function IsBizDataValid() As Boolean
        Dim retValue = False
        If MyBase.IsBizDataValid() Then
            retValue = True
        End If
        Return retValue
    End Function

    Public Sub ProcessRows(propertyName As String, value As Boolean)
        For Each UserAccessView In View.UserAccesses
            Invoker.SetProperty(UserAccessView, propertyName, {value})
        Next
    End Sub

    Public Sub ProcessChildren(index As Integer, visibleColumn As Boolean)
        Dim key = View.UserAccesses(index).SecurityObjectName
        Dim keyLength = Len(key)
        Dim visible = View.UserAccesses(index).Visible
        Dim editable = View.UserAccesses(index).Editable
        For Each UserAccess In View.UserAccesses
            If Left(UserAccess.SecurityObjectName, keyLength) = key Then
                If visibleColumn Then
                    UserAccess.Visible = visible
                Else
                    UserAccess.Editable = editable
                End If
            End If
        Next
        If (visibleColumn And visible) Or (Not visibleColumn And editable) Then
            ' update parent only when Visible or Editable is True, otherwise don't
            UpdateParent(key, keyLength, visibleColumn, visible, editable)
        End If

    End Sub

    Private Sub UpdateParent(key As String, keyLength As Integer, visibleColumn As Boolean, visible As Boolean, editable As Boolean)
        For Each UserAccess In View.UserAccesses
            Dim index As Integer = key.LastIndexOf(" > ", StringComparison.Ordinal)
            If index > 0 Then
                Dim parentKey = Left(key, index)
                If Left(UserAccess.SecurityObjectName, keyLength) = parentKey Then
                    If visibleColumn Then
                        UserAccess.Visible = visible
                    Else
                        UserAccess.Editable = editable
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