Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class DistributionSchemeItemView
        Implements IDistributionSchemeItemView, ISelfDuplicating

        Public Property IdNo As Int32 Implements IDistributionSchemeItemView.IdNo

        Public Property DistributionSchemeIdNo As Int32 Implements IDistributionSchemeItemView.DistributionSchemeIdNo

        Public Property Sequence As Int16 Implements IDistributionSchemeItemView.Sequence

        Public Property RevCostCenterIdNo As Int16 Implements IDistributionSchemeItemView.RevCostCenterIdNo

        Public Property RevCostCenterName As String Implements IDistributionSchemeItemView.RevCostCenterName

        Public Property Percentage As Decimal Implements IDistributionSchemeItemView.Percentage

        Public Property Errors As List(Of String) Implements IView.Errors

        Public Function BlankCopy() As Object Implements ISelfDuplicating.BlankCopy
            Return New DistributionSchemeItemView
        End Function
    End Class

End Namespace