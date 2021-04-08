Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views.Interfaces


Public Class SecurityPresenter
    Inherits Presenter(Of ISecurityGroupView, SecurityGroupModel)

    Public Sub New(view As ISecurityGroupView)
        MyBase.New(view)
        ModelOfPresenter = New Model("SecurityGroup")
        TableName = "SecurityGroup"
        SortOrderKey = "SecurityGroupName"
        TreeViewMainField = "SecurityGroupName"
        TreeViewSecondaryField = "SecurityGroupCode"
        DataModel = New SecurityGroupModel
        TreeViewList = New List(Of SecurityGroupModel)
    End Sub

End Class