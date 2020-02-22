
Namespace PresentationLayer.Models
    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DistributionSchemeModel

        Public Sub New()
            DistributionSchemeItems = New List(Of DistributionSchemeItemModel)
        End Sub

        Public Property Errors As List(Of String)
        Public Property IdNo As Integer
        Public Property DistributionSchemeCode As String
        Public Property DistributionSchemeName As String
        Public Property DistributionSchemeNameAra As String
        Public Property ValidityStartDate As Date
        Public Property ValidityEndDate As Date
        Public Property Notes As String
        Public Property DistributionSchemeItems As List(Of DistributionSchemeItemModel)
        Public Property TotalPercentage As Decimal
    End Class

    Public Class DistributionSchemeItemModel
        Public Property IdNo As Integer
        Public Property DistributionSchemeIdNo As Integer
        Public Property Sequence As Integer
        Public Property ProfitCenterIdNo As Integer
        Public Property ProfitCenterName As String
        Public Property Percentage As Decimal
    End Class
End NameSpace