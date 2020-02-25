Imports AATM.BusinessLayer.BusinessLayer
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class SaltPresenter
        Inherits Presenter(Of ISaltView, Salt, SaltModel)

        Public Sub New(ByRef view As ISaltView)
            MyBase.New(view)
            TableName = "Salt"
            SortOrderKey = "Salt"
            OriginalModel = New SaltModel
            BizObject = New Salt
            DbDataDao = New SaltDao
            Model.SetService(New SaltService)

        End Sub

    End Class

End Namespace