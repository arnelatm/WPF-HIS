Namespace BusinessRules
    ' email validation rule

    Public Class ValidateEmail
        Inherits ValidateRegex

        Public Sub New(propertyName As String)
            MyBase.New(propertyName, "^$|\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
            'MyBase.New(propertyName, "^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")
            'MyBase.New(propertyName, "^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z)")
            [Error] = propertyName & " is not a valid email address"
        End Sub

        Public Sub New(propertyName As String, errorMessage As String)
            Me.New(propertyName)
            [Error] = errorMessage
        End Sub

    End Class

End Namespace