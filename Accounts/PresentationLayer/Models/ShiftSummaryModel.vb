Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ShiftSummaryModel

        Public Property Cards As Decimal
        Public Property Cash As Decimal
        Public Property DateCreated As DateTime?
        Public Property DateEnd As DateTime
        Public Property DateStart As DateTime
        Public Property IdNo As Int32
        Public Property UserIdNo As Int32

    End Class

End Namespace