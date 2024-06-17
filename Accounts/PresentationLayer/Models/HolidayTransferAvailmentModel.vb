Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class HolidayTransferAvailmentModel

        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32
        Public Property EnteredBy As Int16
        Public Property IdNo As Int32

    End Class

End Namespace