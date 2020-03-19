Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DistributionSchemeModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Integer
        Public Property DistributionSchemeCode As String
        Public Property DistributionSchemeName As String
        Public Property DistributionSchemeNameAra As String
        Public Property ValidityStartDate As Date
        Public Property ValidityEndDate As Date
        Public Property Notes As String
        Public Property TotalPercentage As Decimal

    End Class

End Namespace