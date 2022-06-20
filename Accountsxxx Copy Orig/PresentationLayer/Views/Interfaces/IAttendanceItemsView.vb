Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IAttendanceItemsView
        Inherits IView

        Property AttendanceItems As IList(Of AttendanceItemModel)

    End Interface

End Namespace