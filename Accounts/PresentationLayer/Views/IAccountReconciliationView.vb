Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IAccountReconciliationView
        Inherits IView

        Property AccountIdNo As Int32?
        Property Balance As Decimal
        Property DateCreated As DateTime?
        Property GlSystemBalance As Decimal
        Property IdNo As Int32
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
        Property AccountReconciliationItems As List(Of AccountReconciliationItemView)
    End Interface

End Namespace