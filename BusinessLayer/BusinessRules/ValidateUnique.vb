Namespace BusinessRules

    Public Class ValidateUnique
        Inherits BusinessRule

        Protected Presenter As Object

        Public Sub New(propertyName As String, ByRef pPresenter As Object)
            MyBase.New(propertyName)
            Presenter = pPresenter
            [Error] = propertyName &
                      " is not unique, an existing record exist with this same value. Please provide a unique " &
                      propertyName & "!"
        End Sub

        Public Overrides Function Validate(businessObject As BusinessObject) As Boolean
            Try
                Dim propValue As String = businessObject.GetType().GetProperty([Property]).GetValue(businessObject, Nothing).ToString()
                Dim dataType = businessObject.GetType().GetProperty([Property])
                Select Case dataType.PropertyType.Name
                    Case "String"
                        If Presenter.IsUnique(propValue, [Property]) Then
                            Return True
                        End If
                    Case "Integer"
                        ' passing here
                        'Dim x = "passed here"
                End Select
                Return False
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return False
            End Try
        End Function

    End Class

End Namespace