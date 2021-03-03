Imports AATM.Accounts.BusinessLayer
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEarningSummaryView
        Inherits IView
        Property EarningGroupIdNo As Int16
        Property EarningIdNo As Int16
        Property IdNo As Int16
        Property Multiplier As Decimal
        Property Sequence As Int16
    End Interface

End Namespace