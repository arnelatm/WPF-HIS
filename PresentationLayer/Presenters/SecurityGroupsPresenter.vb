Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Public Class SecurityGroupsPresenter
    Inherits Presenter(Of IGroupAccessesView, GroupAccessModel)

    Protected ViewObject As List(Of SecurityGroupModel)

    ''' <summary>
    '''     Constructor
    ''' </summary>
    ''' <param name="view">The view.</param>
    Public Sub New(view As ISecurityGroupsView)
        MyBase.New(view)
        TableName = "SecurityGroup"
        SortOrderKey = "SecurityGroupName"
        OriginalModel = New List(Of SecurityGroupModel)
        'BizObject = New List(Of SecurityGroup)
        ViewObject = New List(Of SecurityGroupModel)
        'DbDataDao = New SecurityGroupDao
    End Sub

End Class