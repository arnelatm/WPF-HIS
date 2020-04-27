Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class DistributionSchemeItemView


        Implements IDistributionSchemeItemView

        Public Property IdNo As Integer Implements IDistributionSchemeItemView.IdNo

        Public Property DistributionSchemeIdNo As Integer Implements IDistributionSchemeItemView.DistributionSchemeIdNo

        Public Property Sequence As Integer Implements IDistributionSchemeItemView.Sequence

        Public Property ProfitCenterIdNo As Integer Implements IDistributionSchemeItemView.ProfitCenterIdNo

        Public Property ProfitCenterName As String Implements IDistributionSchemeItemView.ProfitCenterName

        Public Property Percentage As Decimal Implements IDistributionSchemeItemView.Percentage

        Public Property Errors As List(Of String) Implements IView.Errors


    End Class
End Namespace