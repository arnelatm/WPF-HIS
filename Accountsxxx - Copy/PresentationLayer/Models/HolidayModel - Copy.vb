Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class HolidayModel

        Property DateCreated As DateTime?
        Property DateEnd As Date
        Property DateStart As Date
        Property Description As String
        Property IdNo As Int32
        Property LeaveIdNo As Int16
        Property PayrollIdNo As Int32

    End Class

End Namespace