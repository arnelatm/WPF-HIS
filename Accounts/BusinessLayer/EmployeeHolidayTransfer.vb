' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules
Imports AATM.Libraries
Imports AATM.Libraries.Lookup

Namespace BusinessLayer

    Public Class EmployeeHolidayTransfer
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

        Public Property AppliedBy As Int32
        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32
        Public Property HolidayIdNo As Int32
        Public Property IdNo As Int32

    End Class

End Namespace