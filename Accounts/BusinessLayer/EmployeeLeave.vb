' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules
Imports AATM.Libraries
Imports AATM.Libraries.Lookup

Namespace BusinessLayer

    Public Class EmployeeLeave
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If createRules Then
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EmployeeIdNo"))
                AddRule(New ValidateRequired("StartDate"))
            End If

        End Sub

        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32
        Public Property EndDate As DateTime
        Public Property FullDay As Boolean
        Public Property IdNo As Int32
        Public Property LeaveIdNo As Int16
        Public Property LeaveReason As String
        Public Property LeaveStatus As Char
        Public Property StartDate As DateTime

    End Class

End Namespace