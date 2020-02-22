Imports AATM.HIS.BusinessLayer.BusinessRules


' abstract business object class
' ** Enterprise Design Pattern: Domain Model
Public MustInherit Class BusinessObject
    ' list of business rules

    Private ReadOnly _rules As New List(Of BusinessRule)()

    ' list of validation errors (following validation failure)

    Private ReadOnly _errors As New List(Of String)

    ' gets list of validations errors
    Public ReadOnly Property Errors As List(Of String)
        Get
            Return _errors
        End Get
    End Property

    ' adds a business rule to the business object

    Protected Sub AddRule(rule As BusinessRule)
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
                _errors.Add(rule.Error)
            End If
        Next rule
        Return valid
    End Function

    Public Function GetRules()
        Return _rules
    End Function

    Public Function GetErrors()
        Return _errors
    End Function

End Class