Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EarningSummaryView
        Implements IEarningSummaryView

        Public Property EarningGroupIdNo As Short Implements IEarningSummaryView.EarningGroupIdNo
        Public Property EarningIdNo As Short Implements IEarningSummaryView.EarningIdNo
        Public Property IdNo As Int16 Implements IEarningSummaryView.IdNo
        Public Property Multiplier As Decimal Implements IEarningSummaryView.Multiplier
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property Sequence As Int16 Implements IEarningSummaryView.Sequence
    End Class

End Namespace