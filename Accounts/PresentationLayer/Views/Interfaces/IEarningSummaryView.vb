Imports AATM.Accounts.BusinessLayer
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEarningSummaryView
        Inherits IView
        Property EarningSummaryIdNo As Int16
        Property EarningIdNo As Int16
        Property IdNo As Int16
        Property FactorValue As Decimal
        Property Sequence As Int16
    End Interface

End Namespace