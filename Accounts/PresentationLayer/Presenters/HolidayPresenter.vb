Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class HolidayPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IHolidayView, TM)

        Public Sub New(itemView As IHolidayView)
            MyBase.New(itemView)
            Service = New AccountsService("Holiday")
            TableName = "Holiday"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

    End Class

End Namespace