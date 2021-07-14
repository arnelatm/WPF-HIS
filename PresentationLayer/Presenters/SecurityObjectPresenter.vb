Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views.Interfaces
Imports AATM.ServicesLayer.Services

Public Class SecurityObjectPresenter(Of TM As New)
    Inherits PresenterNew(Of ISecurityObjectView, SecurityObjectModel)

    Public Sub New(view As ISecurityObjectView)
        MyBase.New(view)
        Service = New Service("SecurityObject")
        TableName = "SecurityObject_View"
        SortOrderKey = "SecurityObjectName"
        TreeViewMainField = "SecurityObjectName"
        TreeViewSecondaryField = "IdNo"
        TreeViewParentIdField = "ParentIdNo"
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

    Protected Sub OnAfterSave() Handles MyBase.AfterSave
        CallByName(View, "UpdateParentIdData", CallType.Method)
    End Sub


End Class