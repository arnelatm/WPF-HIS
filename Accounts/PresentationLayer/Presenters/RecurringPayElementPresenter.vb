Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class RecurringPayElementPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IRecurringPayElementView, TM)

        Public Sub New(itemView As IRecurringPayElementView)
            MyBase.New(itemView)
            Service = New AccountsService("RecurringPayElement")
            TableName = "RecurringPayElement"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

    End Class

End Namespace