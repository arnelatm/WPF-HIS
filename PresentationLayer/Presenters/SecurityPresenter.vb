Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views.Interfaces
Imports Microsoft.VisualBasic.CompilerServices

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

    Public Sub OnAfterSave() Handles MyBase.AfterSave
        CallByName(View, "CreateDataSources", CallType.Method)
    End Sub

End Class