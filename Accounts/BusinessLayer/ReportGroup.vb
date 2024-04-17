' ReportGroup business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class ReportGroup
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("ReportGroupName"))
                AddRule(New ValidateRequired("ReportGroupCode"))
            End If
        End Sub


        Public Property IdNo As Int32
        Public Property ReportGroupCode As String
        Public Property ReportGroupName As String
        Public Property ReportGroupNameAra As String
    End Class

End Namespace
