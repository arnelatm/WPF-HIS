Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer

    Public Class SecurityPresenter
        Inherits Presenter(Of ISecurityGroupView, SecurityGroupModel)

        Public Sub New(view As ISecurityGroupView)
            MyBase.New(view)
            ModelPresenter = New Model("SecurityGroup")
            TableName = "SecurityGroup"
            SortOrderKey = "SecurityGroupName"
            TreeViewMainField = "SecurityGroupName"
            TreeViewSecondaryField = "SecurityGroupCode"
            DataModel = New SecurityGroupModel
            TreeViewList = New List(Of SecurityGroupModel)
        End Sub

    End Class
End NameSpace