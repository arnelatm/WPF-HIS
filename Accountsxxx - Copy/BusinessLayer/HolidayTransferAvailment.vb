' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class HolidayTransferAvailment
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("DateAvailed"))
                AddRule(New ValidateRequired("EmployeeIdNo"))
                AddRule(New ValidateRequired("HolidayTransferIdNo"))
            End If
        End Sub

        Property DateCreated As DateTime?
        Property DateAvailed As Date
        Property Description As String
        Property EmployeeIdNo As Int32
        Property IdNo As Int32
        Property HolidayTransferIdNo As Int16

    End Class

End Namespace