Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeAbsenceModel

        Public Property AbsenceReason As String
        Public Property AbsenceType As String
        Public Property AddedByUser As Int16
        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32
        Public Property EquivalentHours As Decimal
        Public Property IdNo As Int32
        Public Property PayrollIdNo As Int16
        Public Property UserName As String

    End Class

End Namespace