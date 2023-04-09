' Product business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Product
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("ProductName"))
                AddRule(New ValidateRequired("ProductCode"))
            End If
        End Sub


        Public Property Active As Boolean
        Public Property BarCode As String
        Public Property BaseUnitIdNo As Int16
        Public Property CategoryIdNo As Int16
        Public Property DateCreated As DateTime?
        Public Property Drug As Boolean
        Public Property GTIN As String
        Public Property IdNo As Int32
        Public Property ProductCode As String
        Public Property ProductName As String
        Public Property ProductNameAra As String

    End Class

End Namespace