Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DistributionSchemeModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property DistributionSchemeCode As String
        Public Property DistributionSchemeName As String
        Public Property DistributionSchemeNameAra As String
        Public Property ValidityStartDate As Date
        Public Property ValidityEndDate As Date
        Public Property Notes As String
        Public Property TotalPercentage As Decimal
        Public Property DistributionSchemeItems As IList(Of DistributionSchemeItemModel)

    End Class

End Namespace