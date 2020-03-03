Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.ServiceLayer.ActionServices

Namespace PresentationLayer.Presenters

    Public Class SecurityObjectPresenter
        Inherits CommonPresenter(Of ISecurityObjectView, SecurityObjectModel)

        Public Sub New(view As ISecurityObjectView)
            MyBase.New(view)
            CurrentModel = New ModelSecurityObject
            TableName = "SecurityObject"
            SortOrderKey = "SecurityObjectName"
            TreeViewMainField = "SecurityObjectName"
            TreeViewSecondaryField = ""
            OriginalModel = New SecurityObjectModel()
            BizObject = New SecurityObject
            DataModel = New SecurityObjectModel
            TreeViewList = New List(Of SecurityObjectModel)

        End Sub

    End Class

End Namespace