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
                AddRule(New ValidateIfRequired("GenericName", "PrescriptionDrug", ValidationDataType.Boolean, ValidationOperator.Equal, True))
                AddRule(New ValidateIfRequired("DosageForm", "PrescriptionDrug", ValidationDataType.Boolean, ValidationOperator.Equal, True))
                AddRule(New ValidateIfRequired("PackageType", "PrescriptionDrug", ValidationDataType.Boolean, ValidationOperator.Equal, True))
                AddRule(New ValidateIfRequired("PackageSize", "PrescriptionDrug", ValidationDataType.Boolean, ValidationOperator.Equal, True))
                AddRule(New ValidateIfRequired("RouteOfAdministration", "PrescriptionDrug", ValidationDataType.Boolean, ValidationOperator.Equal, True))
                'AddRule(New ValidateRequired("ItemDetailsCode"))
            End If

        End Sub

        Public Property BranchID As String
        Public Property DosageForm As String
        Public Property GenericName As String
        Public Property GTin As String
        Public Property IdNo As Int32
        Public Property ItemDetailsCode As String
        Public Property ItemDetailsName As String
        Public Property ItemGroup As String
        Public Property Pack1 As Int16
        Public Property Pack2 As Int16
        Public Property Pack3 As Int16
        Public Property PackageSize As Double?
        Public Property PackageType As String
        Public Property Price_Cash As Decimal?
        Public Property RegistrationNo As String
        Public Property SaleStrip As String
        Public Property StrengthValue As String
        Public Property UnitOfStrength As String
        Public Property UnitOfVolume As String
        Public Property UserId As String
        Public Property Volume As Double?
        Public Property PrescriptionDrug As Boolean
        Public Property RouteOfAdministration As String

    End Class

End Namespace