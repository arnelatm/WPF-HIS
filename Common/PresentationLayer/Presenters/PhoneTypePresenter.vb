Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class PhoneTypePresenter
        Inherits CommonPresenter(Of IPhoneTypeView, PhoneTypeModel)

        Public Sub New(view As IPhoneTypeView)
            MyBase.New(view)
            ModelOfPresenter = New ModelCommon("PhoneType")
            TableName = "PhoneType"
            SortOrderKey = "PhoneTypeCode"
            TreeViewMainField = "PhoneTypeName"
            TreeViewSecondaryField = "PhoneTypeCode"
            OriginalModel = New PhoneTypeModel
            DataModel = New PhoneTypeModel
            TreeViewList = New List(Of PhoneTypeModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

    End Class

End Namespace