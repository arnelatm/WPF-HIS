Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Public Class SecurityObjectPresenter
    Inherits Presenter(Of ISecurityObjectView, SecurityObjectModel)

    Public Sub New(view As ISecurityObjectView)
        MyBase.New(view)
        ModelPresenter = New ModelSecurityObject
        TableName = "SecurityObject"
        SortOrderKey = "SecurityObjectName"
        TreeViewMainField = "SecurityObjectName"
        TreeViewSecondaryField = ""
        OriginalModel = New SecurityObjectModel()
        DataModel = New SecurityObjectModel
        TreeViewList = New List(Of SecurityObjectModel)

    End Sub

End Class