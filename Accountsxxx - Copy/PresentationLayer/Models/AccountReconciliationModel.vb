Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class AccountReconciliationModel
        'Inherits ModelNew

        'Public Property Accounts As List(Of Lookup.LookupData)
        Public Property AccountReconciliationItems As List(Of AccountReconciliationItemModel)

        Public Property AccountIdNo As Int16?
        Public Property Balance As Decimal
        Public Property DateCreated As DateTime?
        Public Property Errors As List(Of String)
        Public Property GlSystemBalance As Decimal
        Public Property IdNo As Int32
        Public Property OutstandingCredits As Decimal
        Public Property OutstandingDeposits As Decimal
        Public Property Posted As Boolean
        Public Property ReconciliationDate As Date?
        Public Property TotalCreditsCleared As Decimal
        Public Property TotalCreditsNotCleared As Decimal
        Public Property TotalDebitsCleared As Decimal
        Public Property TotalDebitsNotCleared As Decimal
        Public Property TotalQtyCreditsCleared As Integer
        Public Property TotalQtyCreditsNotCleared As Integer
        Public Property TotalQtyDebitsCleared As Integer
        Public Property TotalQtyDebitsNotCleared As Integer
        Public Property UnreconciledDifference As Decimal

    End Class

End Namespace