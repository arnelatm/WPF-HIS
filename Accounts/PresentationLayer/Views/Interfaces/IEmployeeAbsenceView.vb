Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeAbsenceView
        Inherits IView

        Property AbsenceReason As String
        Property AbsenceType As Char
        Property AddedByUser As Int16
        Property DateCreated As DateTime?
        Property EmployeeIdNo As Int32
        Property EquivalentHours As Decimal
        Property IdNo As Int32
        Property PayrollIdNo As Int16
        Property UserName As String

        Event AddedByUserChanged()

    End Interface

End Namespace