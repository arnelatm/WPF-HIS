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
                AddRule(New ValidateRequired("ReportFileName"))
            End If
        End Sub

        Public Property Active As Boolean
        Public Property BranchIdNo As Int16
        Public Property DatabaseName As String
        Public Property DateCreated As DateTime
        Public Property IdNo As Int16
        Public Property PrintJobIdNo As Int16
        Public Property QueryForm As String
        Public Property QueryFormParameters As String
        Public Property QueryParameters As String
        Public Property PromptParameterNames As String
        Public Property RepeatPromptAfterClose As Boolean
        Public Property ReportCode As String
        Public Property ReportFileName As String
        Public Property ReportGroupIdNo As Int16
        Public Property ReportName As String
        Public Property ReportNameAra As String
        Public Property ReportTitle As String
        Public Property ReportTitleAra As String

    End Class

End Namespace
