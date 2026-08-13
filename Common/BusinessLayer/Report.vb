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
                AddRule(New ValidateRequired("DatabaseName"))
                AddRule(New ValidateRequired("ReportGroupIdNo"))
                AddRule(New ValidateRegex("DatabaseName",
                                          "Database Name must be ISPDATA, IGROUPCLINIC, KIZEN, or BIOTIME.",
                                          "^(ISPDATA|IGROUPCLINIC|KIZEN|BIOTIME)$"))
                AddRule(New ValidateRegex("QueryForm",
                                          "Query Form must be blank, ContactDateRangeForm, DateRangeForm, or DateTimeRangeForm.",
                                          "^(ContactDateRangeForm|DateRangeForm|DateTimeRangeForm)?$"))
                AddRule(New ValidateReportQueryFormParameters())
                AddRule(New ValidateRange("ReportOrder", 0, 99999, ValidationDataType.Integer))
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
        Public Property ReportOrder As Int32
        Public Property ReportTitle As String
        Public Property ReportTitleAra As String

    End Class

    Friend Class ValidateReportQueryFormParameters
        Inherits BusinessRule

        Private Shared ReadOnly ValidPeriods As String() = {"D", "M", "Y", "Q", "S"}
        Private Shared ReadOnly ValidDateCodes As String() = {
            "CD", "PD", "ND", "CM", "CME", "PM", "PME", "NM",
            "CY", "PY", "NY", "PQ", "CQ", "NQ", "PS", "CS", "NS",
            "BM", "ED"
        }

        Public Sub New()
            MyBase.New("QueryFormParameters",
                       "Query Form Parameters must contain Period, Start Date Code, End Date Code, and optionally Contact Type.")
        End Sub

        Public Overrides Function Validate(businessObject As AATM.BusinessLayer.BusinessObject) As Boolean
            Dim queryFormValue As Object = GetPropertyValue("QueryForm", businessObject)
            Dim parameterValue As Object = GetPropertyValue(businessObject)
            Dim queryForm As String = If(queryFormValue Is Nothing, "", queryFormValue.ToString().Trim())
            Dim queryFormParameters As String = If(parameterValue Is Nothing, "", parameterValue.ToString().Trim())

            If queryForm = "" Then
                Return queryFormParameters = ""
            End If

            Dim parameters As String() = queryFormParameters.Split(","c).
                Select(Function(value) value.Trim().ToUpperInvariant()).
                ToArray()

            If parameters.Length < 3 OrElse parameters.Length > 4 Then
                Return False
            End If

            If parameters.Any(Function(value) value = "") Then
                Return False
            End If

            Return ValidPeriods.Contains(parameters(0)) AndAlso
                   ValidDateCodes.Contains(parameters(1)) AndAlso
                   ValidDateCodes.Contains(parameters(2))
        End Function
    End Class

End Namespace
