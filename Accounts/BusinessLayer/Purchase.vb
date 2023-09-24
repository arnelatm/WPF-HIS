' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Purchase
        Inherits AATM.BusinessLayer.BusinessObject

        Private Const PurchaseOrderElement = 0
        Private Const PurchaseReturnElement = 1

        Public Sub New()

        End Sub

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New(ParamArray parameter As Object())
            ' establish business rules
            'If createRules Then
            Dim purOrder As Boolean
            Dim purReturn As Boolean
            Try
                purOrder = parameter(0)(PurchaseOrderElement)
                purReturn = parameter(0)(PurchaseReturnElement)
            Catch ex As Exception
                purOrder = DirectCast(parameter(0), Boolean(,))(0, PurchaseOrderElement) 'parameter(0)(PurchaseOrderElement)
                purReturn = DirectCast(parameter(0), Boolean(,))(0, PurchaseReturnElement) 'parameter(0)(PurchaseReturnElement)
            End Try
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("TransactionDate"))
                AddRule(New ValidateRequired("WarehouseIdNo"))
                AddRule(New ValidateRange("TransactionDate", Date.MinValue, Date.Today, ValidationDataType.Date))
                AddRule(New ValidateRequired("SupplierIdNo"))
                If Not purOrder Then
                    AddRule(New ValidateRequired("InvoiceNo"))
                    AddRule(New ValidateVatNumber("VatNumber"))
                End If
                AddRule(New ValidateIfRequired("VatNumber", "VatAmount", ValidationDataType.Decimal, ValidationOperator.NotEqual, 0))
            End If
        End Sub

        Public Property Amount As Decimal
        Public Property Approved As Boolean
        Public Property BranchIdNo As Int16
        Public Property Cancelled As Boolean
        Public Property DateCreated As DateTime?
        Public Property Disapproved As Boolean
        Public Property DueDate As Date?
        Public Property IdNo As Int32
        Public Property InvoiceAmount As Decimal
        Public Property InvoiceDate As Date?
        Public Property InvoiceNo As String
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property PurchaseDetails As List(Of PurchaseDetail)
        Public Property PurchaseHistory As List(Of PurchaseHistory)
        Public Property ReferenceNo As String
        Public Property PurchaseReturn As Boolean
        Public Property SupplierIdNo As Int32?
        Public Property TransactionDate As Date?
        Public Property UserIdNo As Int16
        Public Property VatAmount As Decimal
        Public Property VatNumber As String
        Public Property WarehouseIdNo As Int16

    End Class

End Namespace