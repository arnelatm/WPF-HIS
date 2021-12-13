Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer

Namespace PresentationLayer.Presenters

    Public Class ReligionPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IReligionView, TM)

        Public Sub New(view As IReligionView)
            MyBase.New(view)
            Service = New CommonService("Religion")
            TableName = "Religion"
            TreeViewMainField = "ReligionName"
            'TreeViewSecondaryField = "ReligionCode"
            SortOrderKey = "IdNo"
        End Sub

    End Class

End Namespace