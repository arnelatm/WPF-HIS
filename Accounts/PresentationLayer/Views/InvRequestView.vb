Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class InvRequestView
        Implements IInvRequestView

        Public Property InvTransactionRequests As List(Of IInvTransactionBaseView) Implements IInvRequestView.InvTransactionRequests
        Public Property WarehouseIdNo As Short Implements IInvRequestView.WarehouseIdNo
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property DataFilter As String Implements IView.DataFilter

        Public Property WarehouseList As DataTable Implements IInvRequestView.WarehouseList
        Public Property UserList As DataTable Implements IInvRequestView.UserList

        Public Event WarehouseIdNoChanged() Implements IInvRequestView.WarehouseIdNoChanged

    End Class

    'Public Class InvRequestListView
    '    Implements IInvRequestListView

    '    Public Property Amount As Decimal Implements IInvRequestListView.Amount
    '    Public Property Cancelled As Boolean Implements IInvRequestListView.Cancelled
    '    Public Property DateCreated As Date Implements IInvRequestListView.DateCreated
    '    Public Property IdNo As Integer Implements IInvRequestListView.IdNo
    '    Public Property InvTransTypeIdNo As Short Implements IInvRequestListView.InvTransTypeIdNo
    '    Public Property Notes As String Implements IInvRequestListView.Notes
    '    Public Property Posted As Boolean Implements IInvRequestListView.Posted
    '    Public Property ReferenceNo As String Implements IInvRequestListView.ReferenceNo
    '    Public Property TransactionDate As Date? Implements IInvRequestListView.TransactionDate
    '    Public Property UserIdNo As Short Implements IInvRequestListView.UserIdNo
    '    Public Property WarehouseIdNo As Short Implements IInvRequestListView.WarehouseIdNo
    '    Public Property WarehouseToIdNo As Short? Implements IInvRequestListView.WarehouseToIdNo
    '    Public Property Errors As List(Of String) Implements IView.Errors
    '    Public Property DataFilter As String Implements IView.DataFilter
    'End Class

End Namespace