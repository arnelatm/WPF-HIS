Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IStockRequestApprovalView
        Inherits IView

        Property IdNo As Int32
        Property ApprovedBy As Int32
        Property DateCreated As DateTime?
        Property StockRequestApprovalItems As List(Of StockRequestApprovalItemView)
        Property EmployeeList As List(Of Lookup.LookupData)
        Property LeaveList As List(Of Lookup.LookupData)
        Property LeaveStatusList As List(Of Lookup.LookupData)
        Property ApprovalStatusList As List(Of Lookup.LookupData)

        Event ApprovalCheckedEvent(sender As Object)

    End Interface

End Namespace