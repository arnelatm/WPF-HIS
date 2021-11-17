Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views.Interfaces
Imports AATM.ServicesLayer.Services

Public Class SecurityObjectPresenter(Of TM As New)
    Inherits Presenter(Of ISecurityObjectView, TM)

    Public Sub New(view As ISecurityObjectView)
        MyBase.New(view)
        Service = New Service("SecurityObject")
        TableName = "SecurityObject_View"
        SortOrderKey = "SortKey"
        TreeViewMainField = "SecurityObjectName"
        TreeViewSecondaryField = "IdNo"
        ParentFieldName = "ParentIdNo"
    End Sub

    Protected Overrides Sub CreateDataSources()
        CreateDataSource("SystemView", "SystemViewIdNo")
        CreateDataSource("SecurityObject", "ParentIdNo")
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