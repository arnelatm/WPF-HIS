Imports AATM.Libraries.MessagingLibrary
Imports AATM.Libraries.Translations

Namespace BusinessRules
    ' abstract base class for business rules.
    ' maintains property name to which rule applies and validation error message

    Public MustInherit Class BusinessRule
        Public Property [Property] As String
        Public Property [Error] As String
        Protected Dac As New Dac
        'Public Property Control As Object
        'Protected Property Presenter As Object
        'Protected Property TargetIdNo As Int32

        Public Sub New([property] As String)
            Me.Property = [property]
            [Error] = [property] & " is not valid"
        End Sub

        Public Sub New([property] As String, [error] As String)
            Me.New([property])
            Me.Error = [error]
        End Sub

        Public Sub New(ParamArray properties() As String)
            Me.Property = properties(0)
            Me.Error = [Property] & " is not valid"
        End Sub

        'Public Sub New([property] As String, ByRef presenter As Object, ByVal fieldName As String, ByVal targetIdNo As Int32)
        '    Me.Presenter = presenter
        '    Me.TargetIdNo = targetIdNo
        '    Me.Property = [property]
        '    [Error] = [property] & " is not unique. An existing record with that value already exist."
        'End Sub

        ' validation method. To be implemented in derived classes

        Public MustOverride Function Validate(businessObject As BusinessObject) As Boolean

        ' gets value for given business object's property using reflection

        Protected Function GetPropertyValue(businessObject As BusinessObject) As Object
            ' note: reflection is relatively slow
            If businessObject.GetType().GetProperty([Property]) Is Nothing Then
                Return Nothing
            Else
                Return businessObject.GetType().GetProperty([Property]).GetValue(businessObject, Nothing)
            End If
        End Function

        Protected Function GetPropertyValue(cProperty As String, businessObject As BusinessObject) As Object
            ' note: reflection is relatively slow
            Return businessObject.GetType().GetProperty(cProperty).GetValue(businessObject, Nothing)
        End Function

    End Class

End Namespace