Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer

Namespace PresentationLayer.Presenters

    Public Class PhoneTypePresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IPhoneTypeView, TM)

        Public Sub New(itemView As IPhoneTypeView)
            MyBase.New(itemView)
            Service = New ServiceCommon("PhoneType")
            TableName = "PhoneType"
            SortOrderKey = "PhoneTypeCode"
            TreeViewMainField = "PhoneTypeName"
            TreeViewSecondaryField = "PhoneTypeCode"
        End Sub

    End Class

End Namespace