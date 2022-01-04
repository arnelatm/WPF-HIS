' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Report
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("ReportName"))
                AddRule(New ValidateRequired("ReportCode"))
                'AddRule(New ValidateUnique("ReportName"))
                'AddRule(New ValidateUnique("ReportCode"))
            End If
        End Sub

        Public Property IdNo As Int16
        Public Property QueryForm As String
        Public Property ReportCode As String
        Public Property ReportName As String
        Public Property ReportNameAra As String
        Public Property ReportTitle As String
        Public Property ReportTitleAra As String
        

    End Class

End Namespace