Imports System.ComponentModel
Imports System.Text
Imports AATM.BusinessLayer.BusinessRules

' abstract business object class
' ** Enterprise Design Pattern: Domain Model
Public MustInherit Class BusinessObject
    ' list of business rules

    Private ReadOnly _rules As New List(Of BusinessRule)()

    ' list of validation errors (following validation failure)

    Private ReadOnly _errors As New List(Of String)
    'Private ReadOnly _dErrors As New Dictionary(Of String, String)

    ' gets list of validations errors
    Public ReadOnly Property Errors As List(Of String)
        Get
            Return _errors
        End Get
    End Property

    ' gets dictionary of validations errors
    'Public ReadOnly Property dErrors As Dictionary(Of String, String)
    '    Get
    '        Return _dErrors
    '    End Get
    'End Property

    ' adds a business rule to the business object

    Public Sub AddRule(rule As BusinessRule)
        _rules.Add(rule)
    End Sub

    ' determines whether business rules are valid or not.
    ' creates a list of validation errors when appropriate

    Public Function IsValid() As Boolean
        Dim valid = True

        _errors.Clear()

        For Each rule In _rules
            If Not rule.Validate(Me) Then
                valid = False
                rule.Valid = valid
                _errors.Add(rule.Error)
            End If
        Next rule
        Return valid
    End Function

    Public Function IsRuleValid(pRule As BusinessRule) As Boolean
        Dim valid = True
        If Not pRule.Validate(Me) Then
            valid = False
            _errors.Add(pRule.Error)
        End If
        Return valid
    End Function

    Public Function GetRules()
        Return _rules
    End Function

    Public Function GetErrors() As List(Of String)
        Return _errors
    End Function

    'Public Function Get_dErrors() As Dictionary(Of String, String)
    '    Return _dErrors
    'End Function

    Public Sub AddError(errorList As List(Of String))
        For Each aError In errorList
            _errors.Add(aError)
        Next
    End Sub

    'The Error property uses the overridden ToString method of the validation class to return the full list of validation errors.
    <Bindable(False)>
    <BrowsableAttribute(False)>
    Public ReadOnly Property [Error]() As String
        Get
            Dim sb As New StringBuilder
            For Each k As String In _errors
                sb.AppendLine(k)
            Next
            Return sb.ToString
        End Get
    End Property

    'Public Sub Add_dError(errorList As Dictionary(Of String, String))
    '    For Each aError In errorList
    '        _errors.Add(aError)
    '    Next
    'End Sub

End Class