Imports AATM.Common.BusinessLayer
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.ServiceLayer.ActionServices

Namespace PresentationLayer.Presenters

    Public Class PhoneTypePresenter
        Inherits CommonPresenterOld(Of IPhoneTypeView, PhoneType, PhoneTypeModel)

        Public Sub New(view As IPhoneTypeView)
            MyBase.New(view)
            TableName = "PhoneType"
            SortOrderKey = "PhoneTypeCode"
            TreeViewMainField = "PhoneTypeName"
            TreeViewSecondaryField = "PhoneTypeCode"
            OriginalModel = New PhoneTypeModel
            BizObject = New PhoneType
            DataModel = New PhoneTypeModel
            TreeViewList = New List(Of PhoneTypeModel)
            Model.SetService(New PhoneTypeService)
        End Sub

    End Class

End Namespace