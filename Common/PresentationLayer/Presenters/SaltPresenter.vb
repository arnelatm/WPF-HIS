Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.ServiceLayer.ActionServices

Namespace PresentationLayer.Presenters

    Public Class SaltPresenter
        Inherits CommonPresenterOld(Of ISaltView, Salt, SaltModel)

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