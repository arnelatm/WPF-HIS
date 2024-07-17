Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class DistributionSchemeItemView
        Implements IDistributionSchemeItemView

        Public Property IdNo As Int32 Implements IDistributionSchemeItemView.IdNo

        Public Property DistributionSchemeIdNo As Int32 Implements IDistributionSchemeItemView.DistributionSchemeIdNo

        Public Property Sequence As Int16 Implements IDistributionSchemeItemView.Sequence

        Public Property RevCostCenterIdNo As Int16 Implements IDistributionSchemeItemView.RevCostCenterIdNo

        Public Property RevCostCenterName As String Implements IDistributionSchemeItemView.RevCostCenterName

        Public Property Percentage As Decimal Implements IDistributionSchemeItemView.Percentage
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors


    End Class

End Namespace