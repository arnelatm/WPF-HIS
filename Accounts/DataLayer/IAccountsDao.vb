Imports AATM.Common.DataLayer
Imports AATM.DataLayer

Namespace DataLayer

    Public Interface IAccountsDao
        Inherits ICommonDao

    End Interface

    Public Interface IJournalsDao(Of TM)

        Function UpdateGlReferenceNumber(ByRef model As TM) As Integer

    End Interface

    Public Interface IOpenInvoiceDao

        Function AddInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

        Function RemoveInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

    End Interface

End Namespace