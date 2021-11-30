Imports AATM.Accounts.BusinessLayer
Imports AATM.BusinessLayer
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IHolidayTransferView
        Inherits IView

        Property AppliedBy As Int32
        Property DateCreated As DateTime?
        Property HolidayIdNo As Int32
        Property IdNo As Int32
        Property HolidayTransferItems As List(Of HolidayTransferItemView)
        Property HolidayList As List(Of Lookup.LookupData)
        Property EmployeeList As List(Of Lookup.LookupData)
    End Interface

End Namespace