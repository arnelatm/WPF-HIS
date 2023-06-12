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
            End If
        End Sub

        Public Property ReportTitleAra As String
        Public Property ReportTitle As String
        Public Property ReportNameAra As String
        Public Property ReportName As String
        Public Property ReportFileName As String
        Public Property ReportCode As String
        Public Property QueryParameters As String
        Public Property QueryFormParameters As String
        Public Property QueryForm As String
        Public Property PrintJobIdNo As Int16
        Public Property IdNo As Int16

    End Class

End Namespace