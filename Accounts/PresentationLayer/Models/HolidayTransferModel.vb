Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class HolidayTransferModel

        Public Property EnteredBy As Int32
        Public Property DateCreated As DateTime?
        Public Property DateEnd As DateTime?
        Public Property DateStart As DateTime?
        Public Property HolidayIdNo As Int16
        Public Property IdNo As Int32
        Public Property HolidayTransferItems As List(Of HolidayTransferItemModel)
    End Class

End Namespace