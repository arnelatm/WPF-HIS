Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views.PresentationLayer.Views

Public Class SecurityObjectPresenter
    Inherits Presenter(Of ISecurityObjectView, SecurityObjectModel)

    Public Sub New(view As ISecurityObjectView)
        MyBase.New(view)
        'CurrentModel = New ModelSecurityObject
        TableName = "SecurityObject"
        SortOrderKey = "SecurityObjectName"
        TreeViewMainField = "SecurityObjectName"
        TreeViewSecondaryField = ""
        OriginalModel = New SecurityObjectModel()
        DataBizObject = New SecurityObject
        DataModel = New SecurityObjectModel
        TreeViewList = New List(Of SecurityObjectModel)

    End Sub

End Class