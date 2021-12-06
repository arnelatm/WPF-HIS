Imports AATM.Accounts.BusinessLayer
Imports AATM.BusinessLayer
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

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
        Property HolidayList As List(Of Lookup.LookupData)
        Property EmployeeList As List(Of Lookup.LookupData)

        Event HolidayIdChangedEvent()

    End Interface

End Namespace