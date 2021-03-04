Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EarningSummaryView
        Implements IEarningSummaryView

        Private _earningIdNo As Short

        Public Property EarningSummaryIdNo As Short Implements IEarningSummaryView.EarningSummaryIdNo

        Public Property EarningIdNo As Short Implements IEarningSummaryView.EarningIdNo
            Get
                Return _earningIdNo
            End Get
            Set(value As Short)
                _earningIdNo = value
                If Multiplier = 0 Then
                    Multiplier = 1
                End If
            End Set
        End Property

        Public Property IdNo As Int16 Implements IEarningSummaryView.IdNo
        Public Property Multiplier As Decimal Implements IEarningSummaryView.Multiplier
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property Sequence As Int16 Implements IEarningSummaryView.Sequence
    End Class

End Namespace