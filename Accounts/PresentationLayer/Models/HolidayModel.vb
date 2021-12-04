Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class HolidayModel

        Property DateCreated As DateTime?
        Property HolidayDate As Date
        Property HolidayName As String
        Property HolidayNameAra As String
        Property IdNo As Int32
        
    End Class

End Namespace