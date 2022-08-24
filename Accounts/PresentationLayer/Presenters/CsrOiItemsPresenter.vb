Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Presenters

    Public Class CsrOiItemsPresenter(Of TM As New)
        Inherits AccountsPresenter(Of ICsrOiItemsView, CsrOiItemModel)

        Public Sub New(view As ICsrOiItemsView)
            MyBase.New(view)
            Service = New AccountsService("CsrOiItem")
            TableName = "CsrOiItem"
            SortOrderKey = "Sequence"
        End Sub

        Public Property ChangesMadeInCsrOiItem As Boolean = False

        '''' <summary>
        ''''     Displays list of Ap CsrOi Items.
        '''' </summary>
        '''' <param name="csrOiIdNo">CsrOiIdNo id to display.</param>
        Public Shadows Sub Display(csrOiIdNo As Int32)
            View.CsrOiItems = Service.GetRecordsWithGroupIdNo(Of CsrOiItemModel)(csrOiIdNo, "Sequence")
        End Sub

        Public Function GetCustomerOpenInvoices(ByVal customerIdNo As Int32) As List(Of CsrOiItemModel)
            Return Service.GetCustomerOpenInvoices(Of CsrOiItemModel)(customerIdNo)
        End Function

    End Class

End Namespace