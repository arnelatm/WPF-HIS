Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.ServiceLayer.ActionServices

Namespace PresentationLayer.Presenters

    Public Class SecurityGroupPresenter
        Inherits CommonPresenter(Of ISecurityGroupView, SecurityGroupModel)

        Public Sub New(view As ISecurityGroupView)
            MyBase.New(view)
            TableName = "SecurityGroup"
            SortOrderKey = "SecurityGroupName"
            TreeViewMainField = "SecurityGroupName"
            TreeViewSecondaryField = "SecurityGroupCode"
            OriginalModel = New SecurityGroupModel()
            'BizObject = New SecurityGroup
            DataModel = New SecurityGroupModel
            'DbDataDao = New SecurityGroupDao
            TreeViewList = New List(Of SecurityGroupModel)
            'Model.SetService(New SecurityGroupService)

        End Sub

        Public Property GroupAccessesPresenter As GroupAccessesPresenter

        'Public Overrides Sub Display(idNo As Integer, Optional ByVal undoMode As Boolean = False)
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

End Namespace