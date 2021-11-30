Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class HolidayTransferModel

        Property AppliedBy As Int32
        Property DateCreated As DateTime?
        Property HolidayIdNo As Int32
        Property IdNo As Int32
        Property HolidayTransferItems As List(Of HolidayTransferItemModel)
    End Class

End Namespace