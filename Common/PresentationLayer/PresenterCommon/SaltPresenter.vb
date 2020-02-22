Imports AATM.HIS.Common.BusinessLayer
Imports AATM.HIS.Common.DataLayer.AdoNet
Imports AATM.HIS.Common.PresentationLayer.Models
Imports AATM.HIS.Common.PresentationLayer.Views
Imports AATM.HIS.Common.ServiceLayer.ActionService

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