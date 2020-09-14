' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class EmployeeDeduction
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("DeductionIdNo"))
            End If
        End Sub

        Public Property AccountIdNo As Integer
        Public Property Amount As Decimal
        Public Property ComputationType As String
        Public Property DeductionCode As String
        Public Property DeductionIdNo As Int16
        Public Property DeductionName As String
        Public Property DeductionNameAra As String
        Public Property DeductionPlace As String
        Public Property DeductionType As String
        Public Property DefaultFrequency As String
        Public Property EmployeeIdNo As Integer
        Public Property EndAmount As Decimal
        Public Property EndDate As Date
        Public Property IdNo As Int32
        Public Property Notes As String
        Public Property PayFrequency As String
        Public Property Percentage As Decimal
        Public Property StartDate As Date
    End Class

End Namespace