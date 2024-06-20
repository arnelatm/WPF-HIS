Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class HolidayTransferItemModel

        Public Property EmployeeIdNo As Int32
        Public Property HolidayTransferIdNo As Int32
        Public Property IdNo As Int32
        Public Property Transfer As Boolean

    End Class

End Namespace