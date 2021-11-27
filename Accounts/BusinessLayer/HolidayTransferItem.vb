' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules
Imports AATM.Libraries
Imports AATM.Libraries.Lookup

Namespace BusinessLayer

    Public Class HolidayTransferItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If createRules Then
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EmployeeIdNo"))
                AddRule(New ValidateRequired("HolidayTransferIdNo"))
            End If
        End Sub

        Public Property HolidayTransferIdNo As Int32
        Public Property EmployeeIdNo As Int32
        Public Property IdNo As Int32

    End Class

End Namespace