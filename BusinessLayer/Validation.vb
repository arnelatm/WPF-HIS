Imports System.Text

Public Class Validation

    'The constructor ensures that a new instance of the ValidationList Dictionary is created.
    Public Sub New()
        ' Create the list to contain the validation errors
        ValidationList = New Dictionary(Of String, String)
    End Sub

    'The Count Property returns the number Of properties With validation errors by returning the count Of the ValidationList items.
    Public ReadOnly Property Count() As Integer
        Get
            Return ValidationList.Count
        End Get
    End Property

    'The Item Property provides access To the validation errors given a Property name. 
    Public ReadOnly Property Item(ByVal propertyName As String) As String
        Get
            If ValidationList.ContainsKey(propertyName) Then
                Return ValidationList.Item(propertyName)
            Else
                Return Nothing
            End If
        End Get
    End Property

    'The ValidationList Property retains a Private Dictionary Of validation errors. 
    'The key Of the dictionary Is the Property name And the value Is the Error text. 
    'For example, the “LastName” Property may have a validation Error such As “Last Name is required.”
    Private _ValidationList As Dictionary(Of String, String)
    Private Property ValidationList() As Dictionary(Of String, String)
        Get
            Return _ValidationList
        End Get
        Set(ByVal value As Dictionary(Of String, String))
            _ValidationList = value
        End Set
    End Property

    'The ToString method is overwritten in the Validation class to build a single string containing all of the validation errors.
    'This method uses the StringBuilder Class To build up the potentially large String Of errors.
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder

        For Each k As String In ValidationList.Keys
            sb.AppendLine(k & ": " & ValidationList(k))
        Next
        Return sb.ToString
    End Function

    'When a validation error Is added to the list, it Is added for a particular property. 
    'If the Property already has a validation Error, additional validation errors are appended To it, separated by semi-colons (;). 
    'An AddValidationError method Handles this logic.
    Private Sub AddValidationError(ByVal propertyName As String,
         ByVal message As String)

        ' If the property already has a message, append this message
        If ValidationList.ContainsKey(propertyName) Then
            Dim existingMessage As String = ValidationList(propertyName)

            If Not existingMessage.Contains(message) Then
                ' Append the new message to the existing message
                ValidationList(propertyName) &= "; " & message
            End If
        Else
            ' Add the message to the validation list
            ValidationList.Add(propertyName, message)
        End If
    End Sub

    'A ValidateClear method clears any existing validation errors for a property. 
    'This method should be called before performing any New validation On the Property. 
    'For example, the user leaves the Last Name field empty. 
    'The validation Is performed And a validation Error entry Is created In the ValidationList. 
    'Then the user enters a value into the last name field. 
    'The original validation Error must be cleared before revalidating the value.
    'The ValidateClear method uses the Remove method of the Dictionary to remove any Dictionary entry for the property.
    Public Sub ValidateClear(ByVal propertyName As String)
        ' If the Property doesn’t have any messages, this is done
        If ValidationList.ContainsKey(propertyName) Then
            ' Otherwise, remove the entry
            ValidationList.Remove(propertyName)
        End If
    End Sub

    Public Function ValidateRequired(ByVal propertyName As String, ByVal value As String) As Boolean
        Dim newMessage As String = String.Empty
        If String.IsNullOrEmpty(value) Then
            newMessage = String.Format("{0} is required. Please enter a valid value.", propertyName)
            ' Add the message to the validation list
            AddValidationError(propertyName, newMessage)
            Return False
        Else
            Return True
        End If

    End Function

    Public Function ValidateLength(ByVal propertyName As String, ByVal value As String, ByVal maxLength As Integer) As Boolean
        Dim sMessage As String = String.Empty
        If Not String.IsNullOrEmpty(value) AndAlso
                                 value.Length > maxLength Then
            sMessage = String.Format("{0} has a maximum size of {1}.",
                                    propertyName, maxLength)
            ' Add the message to the validation list
            AddValidationError(propertyName, sMessage)
            Return False
        Else
            Return True
        End If
    End Function


End Class


'Some additional suggestions

'ValidateAlphaNumeric
'ValidateDirectory
'ValidateEnum
'ValidateFileExists
'ValidateMinLength
'ValidateNonZero
'ValidateNoSpaces
'ValidateNumeric
'You can create any validation method you need For your application. Just add code To perform the validation And Then Call AddValidationError As appropriate.

'You call these validation methods from your business objects as shown below.

'Private _LastName As String
'Public Property LastName() As String
'    Get
'        Return _LastName
'    End Get
'    Set(ByVal value As String)
'        If _LastName Is Nothing OrElse _LastName <> value Then
'            Dim propertyName As String = "LastName"
'            _LastName = value

'            ' Validate the last name
'            ValidationInstance.ValidateClear(propertyName)
'            ValidationInstance.ValidateRequired(propertyName, value)
'        End If
'    End Set
'End Property