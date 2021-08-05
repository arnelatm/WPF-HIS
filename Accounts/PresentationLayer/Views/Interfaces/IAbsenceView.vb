Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Interface IAbsenceView
        Inherits IView

        Property AbsenceReason As String
        Property AbsenceType As Char
        Property AddedBy As Int16
        Property DateCreated As DateTime?
        Property EmployeeIdNo As Int32
        Property EquivalentHours As Decimal
        Property IdNo As Int32
        Property PayrollIdNo As Int16
    End Interface

End Namespace