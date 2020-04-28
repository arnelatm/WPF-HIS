Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IAccountReconciliationView
        Inherits IView

        Property AccountIdNo as Int32
        Property Balance As Decimal
        Property DateCreated As DateTime?
        Property GlSystemBalance As Decimal
        Property IdNo As Integer
        Property Posted As Boolean
        Property ReconciliationDate As Date?
        Property TotalCreditsCleared As Decimal
        Property TotalCreditsNotCleared As Decimal
        Property TotalDebitsCleared As Decimal
        Property TotalDebitsNotCleared As Decimal
        Property TotalQtyCreditsCleared As Integer
        Property TotalQtyCreditsNotCleared As Integer
        Property TotalQtyDebitsCleared As Integer
        Property TotalQtyDebitsNotCleared As Integer
        Property UnreconciledDifference As Decimal

    End Interface

End Namespace