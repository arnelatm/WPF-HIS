Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.ServiceLayer.ActionServices

Namespace PresentationLayer.Presenters

    Public Class SecurityObjectPresenter
        Inherits CommonPresenterOld(Of ISecurityObjectView, SecurityObject, SecurityObjectModel)

        Public Sub New(view As ISecurityObjectView)
            MyBase.New(view)
            TableName = "SecurityObject"
            SortOrderKey = "SecurityObjectName"
            TreeViewMainField = "SecurityObjectName"
            TreeViewSecondaryField = ""
            OriginalModel = New SecurityObjectModel()
            BizObject = New SecurityObject
            DataModel = New SecurityObjectModel
            DbDataDao = New SecurityObjectDao
            TreeViewList = New List(Of SecurityObjectModel)
            Model.SetService(New SecurityObjectService)

        End Sub

    End Class

End Namespace