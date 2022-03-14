' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class ItemDetails
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("ItemDetailsName"))
                'AddRule(New ValidateRequired("ItemDetailsCode"))
            End If
            'Dim user As Object = New ExpandoObject()
            'user.Add("IdNo", 0I)
            'user.Add("Age",25)
            'user.Add("Married",True)
            'user.Name = "John Doe"
            'user.Age = 42
            'user.Code = {"a","b"}

        End Sub

        Public Property BranchID As String
        Public Property Category As String
        Public Property Created_By_Branch
        Public Property DosageForm As String
        Public Property IdNo As Int32
        Public Property Item_status As String
        Public Property ItemDetailsCode As String
        Public Property ItemDetailsName As String
        Public Property ItemGroup As String
        Public Property Pack1 As Int16
        Public Property Pack2 As Int16
        Public Property Pack3 As Int16
        PUblic Property PackageSize As Decimal?
        PUblic Property PackageType As String
        Public Property SaleStrip As String
        Public Property StrengthValue As String
        Public Property UnitOfStrength As String
        Public Property UnitOfVolume As String
        Public Property UserId As String
        Public Property Volume As Decimal?


    End Class

End Namespace