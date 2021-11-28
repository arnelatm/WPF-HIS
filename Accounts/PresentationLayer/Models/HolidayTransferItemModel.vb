Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class HolidayTransferItemModel

        Property EmployeeIdNo As Int32
        Property HolidayTransferIdNo As Int32
        Property IdNo As Int32
        Property Transfer As Boolean

    End Class

End Namespace