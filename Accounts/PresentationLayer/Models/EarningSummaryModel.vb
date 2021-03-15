Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EarningSummaryModel

        Public Property EarningSummaryIdNo As Int16
        Public Property EarningIdNo As Int16
        Public Property IdNo As Int16
        Public Property FactorValue As Decimal
        Public Property Sequence As Int16
    End Class

End Namespace