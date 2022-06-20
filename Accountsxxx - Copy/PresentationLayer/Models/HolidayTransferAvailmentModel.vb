Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class HolidayTransferAvailmentModel

        Property DateCreated As DateTime?
        Property EmployeeIdNo As Int32
        Property EnteredBy As Int16
        Property IdNo As Int32

    End Class

End Namespace