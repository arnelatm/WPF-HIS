Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer

    Public Class SecurityObjectPresenter
        Inherits Presenter(Of ISecurityObjectView, SecurityObjectModel)

        Public Sub New(view As ISecurityObjectView)
            MyBase.New(view)
            ModelPresenter = New Model("SecurityObject")
            TableName = "SecurityObject_View"
            SortOrderKey = "SecurityObjectName"
            TreeViewMainField = "SecurityObjectName"
            TreeViewSecondaryField = "IdNo"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New SecurityObjectModel()
            DataModel = New SecurityObjectModel
            TreeViewList = New List(Of SecurityObjectModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

    End Class
End NameSpace