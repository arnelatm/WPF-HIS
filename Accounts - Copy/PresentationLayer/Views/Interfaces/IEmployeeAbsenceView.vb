Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeAbsenceView
        Inherits IView

        Property AbsenceReason As String
        Property AbsenceType As String
        Property AddedByUser As Int16
        Property DateCreated As DateTime?
        Property EmployeeIdNo As Int32
        Property EndDate As Date
        Property EquivalentHours As Decimal
        Property IdNo As Int32
        Property PayrollIdNo As Int16
        Property PayrollCode As String
        Property PayrollName As String
        Property PayrollEndDate As Date
        Property PayrollStartDate As Date
        Property StartDate As Date
        Property UserName As String

        Event AddedByUserChanged()

    End Interface

End Namespace