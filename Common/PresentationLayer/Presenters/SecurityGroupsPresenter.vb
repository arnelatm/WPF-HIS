Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class SecurityGroupsPresenter
        Inherits CommonPresenter(Of IGroupAccessesView, GroupAccessModel)

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

End Namespace