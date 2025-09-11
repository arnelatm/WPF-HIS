Imports AATM.Accounts.BusinessLayer
Imports AATM.BusinessLayer
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IHolidayTransferView
        Inherits IView

        Property EnteredBy As Int32
        Property DateCreated As DateTime?
        Property DateEnd As DateTime?
        Property DateStart As DateTime?
        Property HolidayIdNo As Int16
        Property IdNo As Int32
        Property HolidayTransferItems As List(Of HolidayTransferItemView)
        Property HolidayList As DataTable
        Property EmployeeList As DataTable

        Event HolidayIdChangedEvent()

    End Interface

End Namespace