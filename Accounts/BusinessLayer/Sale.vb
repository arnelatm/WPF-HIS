' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Sale
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If createRules Then
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("TransactionDate"))
                AddRule(New ValidateRange("TransactionDate", Date.MinValue, Date.Today, ValidationDataType.Date))
                AddRule(New ValidateRequired("CustomerIdNo"))
                AddRule(New ValidateRequired("InvoiceNo"))
                AddRule(New ValidateVatNumber("VatNumber"))
                AddRule(New ValidateIfRequired("VatNumber", "VatAmount", ValidationDataType.Decimal, ValidationOperator.NotEqual, 0))
            End If
        End Sub


        Public Property Amount As Decimal
        Public Property BranchIdNo As Int16
        Public Property Cancelled As Boolean
        Public Property CustomerIdNo As Int32?
        Public Property DateCreated As DateTime?
        Public Property DueDate As Date?
        Public Property IdNo As Int32
        Public Property InvoiceAmount As Decimal
        Public Property InvoiceNo As Int32
        Public Property PatientIdNo As Int32?
        Public Property PatientName As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property SaleDetails As List(Of SaleDetail)
        Public Property SaleHistory As List(Of SaleHistory)
        Public Property TransactionDate As Date?
        Public Property VatAmount As Decimal
        Public Property VatNumber As String
        Public Property WarehouseIdNo As Int16

    End Class

End Namespace