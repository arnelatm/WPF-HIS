Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer

    Public Class SecurityGroupPresenter
        Inherits Presenter(Of ISecurityGroupView, SecurityGroupModel)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable

        Public Sub New(view As ISecurityGroupView)
            MyBase.New(view)
            ModelPresenter = New Model("SecurityGroup")
            TableName = "SecurityGroup_View"
            SortOrderKey = "SecurityGroupName"
            TreeViewMainField = "SecurityGroupName"
            TreeViewSecondaryField = "SecurityGroupCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New SecurityGroupModel()
            DataModel = New SecurityGroupModel
            TreeViewList = New List(Of SecurityGroupModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

            DtInsertTable.Columns.Add("SecurityGroupIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("SecurityObjectIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Visible", GetType(Boolean))
            DtInsertTable.Columns.Add("Editable", GetType(Boolean))

            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("SecurityGroupIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("SecurityObjectIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Visible", GetType(Boolean))
            DtUpdateTable.Columns.Add("Editable", GetType(Boolean))

        End Sub

        Private Sub OnBeforeAdd() Handles MyBase.BeforeAdd
            Dim gaModel = Model.GetRecordsWithIdNo(Of GroupAccessModel)(0, "SecurityObjectName")
            Dim gaView = New List(Of GroupAccessView)
            View.GroupAccesses = GlobalVariables.Mapper.Map(gaModel, gaView)
        End Sub

        Private Sub OnBeforeSave() Handles MyBase.BeforeSave
            DtInsertTable.Clear()
            DtUpdateTable.Clear()
            For Each groupAccess In View.GroupAccesses
                If groupAccess.IdNo <= 0 Then
                    If groupAccess.Visible OrElse groupAccess.Editable Then
                        DtInsertTable.Rows.Add(View.IdNo, groupAccess.SecurityObjectIdNo, groupAccess.Visible, groupAccess.Editable)
                    End If
                Else
                    DtUpdateTable.Rows.Add(groupAccess.IdNo, View.IdNo, groupAccess.SecurityObjectIdNo,
                                           groupAccess.Visible, groupAccess.Editable)
                End If
            Next
        End Sub

        Public Sub OnParentRecordUpdatedSuccessfully(ByRef passedValue As Integer) Handles MyBase.RecordUpdatedSuccessfully
            Dim updateReturnValue As Integer
            updateReturnValue = ModelPresenter.DelUpdateTvp(DtUpdateTable, View.ParentIdNo)
            If updateReturnValue >= 0 AndAlso DtInsertTable.Rows.Count > 0 Then
                For Each row As DataRow In DtInsertTable.Rows
                    row.Item("SecurityGroupIdNo") = View.IdNo
                Next
                Dim insertReturnValue = Model.InsertTvp(DtInsertTable)
                If insertReturnValue >= 0 Then
                    passedValue = updateReturnValue + insertReturnValue
                Else
                    passedValue = insertReturnValue
                End If
            Else
                passedValue = updateReturnValue
            End If
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Int32 = retVal
            retVal = UpdateDataTables(DtUpdateTable, DtInsertTable, passedValue, "SecurityGroupIdNo")
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

    End Class

End Namespace