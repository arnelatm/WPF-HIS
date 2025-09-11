Imports AATM.Libraries
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IHolidayAvailmentView
        Inherits IView

        Property Approve As Boolean
        Property DateCreated As DateTime?
        Property EmployeeIdNo As Int32
        Property EnteredBy As Int32
        Property IdNo As Int32
        Property HolidayTransferIdNo As Int32
        Property SupervisorIdNo As Integer
        Property Disapprove As Boolean
        Property Status As String
        Property Users As DataTable
        Property HolidayStatusList As DataTable
        Property ApprovalHistory As List(Of IHolidayAvailmentApprovalHistoryView)
    End Interface

End Namespace