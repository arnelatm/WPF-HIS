Imports AATM.Libraries
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Public Class SecurityGroupPresenter
    Inherits Presenter(Of ISecurityGroupView, SecurityGroupModel)

    Public Sub New(view As ISecurityGroupView)
        MyBase.New(view)
        ModelPresenter = New ModelSecurityGroup
        TableName = "SecurityGroup"
        SortOrderKey = "SecurityGroupName"
        TreeViewMainField = "SecurityGroupName"
        TreeViewSecondaryField = "SecurityGroupCode"
        OriginalModel = New SecurityGroupModel()
        DataModel = New SecurityGroupModel
        TreeViewList = New List(Of SecurityGroupModel)
        Ea = New EventAggregator()
        Ea.SubscribeEvent(Me)

    End Sub

    Public Property GroupAccessesPresenter As GroupAccessesPresenter

    'Public Overrides Sub Display(idNo As Integer)
    '    If idNo <> 0 Then
    '        Dim modelData As New SecurityGroupModel
    '        modelData = Model.GetRecordById(Of SecurityGroupModel)(idNo)
    '        MapObject(modelData, View)
    '        MapObject(modelData, OriginalModel)
    '        GroupAccessesPresenter.View.GroupAccesses = New List(Of GroupAccessModel)
    '        GroupAccessesPresenter.Display(idNo)
    '    End If
    'End Sub

End Class