'Following class is inherited from basic ErrorProvider class

#Region "Error Provider Extended"

Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Languages

Public Class ErrorProviderExtended
    Inherits ErrorProvider
    Private _validationControls As New ValidationControlCollection
    Private _summaryMessage As String = "Please enter following mandatory fields,"

    'Public Function GetAutoValidations() As Boolean
    '    If Controls.Count <= 0 Then
    '        Return True
    '    End If
    '    Dim i As Integer
    '    For i = 0 To Controls.Count - 1
    '        If Controls(i).Validate Then
    '            If Controls(i).ValueIsNumeric() Then

    '            End If
    '            If Trim(Controls(i).ControlObj.text) = "" Then
    '                msg &= "> " & Controls(i).DisplayName & vbNewLine
    '                SetError(Controls(i).ControlObj, Controls(i).ErrorMessage)
    '                berrors = True
    '            Else
    '                SetError(Controls(i).ControlObj, "")
    '            End If
    '        Else
    '            SetError(Controls(i).ControlObj, "")
    '        End If
    '    Next
    '    If berrors Then
    '        System.Windows.Forms.MessageBox.Show(msg, "Missing Information", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
    '        Return False
    '    Else
    '        Return True
    '    End If
    'End Function

    'This property will be used for displaying a summary message about all empty fields
    'Default value is "Please enter following mandatory fields,". You can set any other
    'message using this property.
    Public Property SummaryMessage As String
        Get
            Return _summaryMessage
        End Get
        Set
            _summaryMessage = Value
        End Set
    End Property

    'Controls property is of type ValidationControlCollection which is inherited from CollectionBase
    'Controls holds all those objects which should be validated.
    Public Property Controls As ValidationControlCollection
        Get
            Return _validationControls
        End Get
        Set
            _validationControls = Value
        End Set
    End Property

    'Following function returns true if all fields on form are entered.
    'If not all fields are entered, this function displays a message box which contains all those field names
    'which are empty and returns FALSE.
    Public Function CheckAndShowSummaryErrorMessage() As Boolean
        If Controls.Count <= 0 Then
            Return True
        End If
        Dim i As Integer
        Dim msg As String = SummaryMessage + vbNewLine + vbNewLine
        Dim bErrors = False
        For i = 0 To Controls.Count - 1
            If Controls(i).Validate Then
                If TypeOf Controls(i).ControlObj Is IEntryControl Then
                    If TypeOf Controls(i).ControlObj Is CTextBox AndAlso GetPropertyValue(Controls(i).ControlObj, "ComputedValue") Then
                        ' ignore this also computed values don't need to be validated for empty values
                    ElseIf TypeOf Controls(i).ControlObj Is CTextBoxArabic OrElse TypeOf Controls(i).ControlObj Is CTextBoxIdNo Then
                        ' Don't check this fields for mandatory values they are checked later when saving and besides
                        ' for CTextBoxArabic this controls are automatically filled with their English Counterpart values if empty.
                        ' and for CTextBoxIDNo this are Identity Columns and are automatically filled by the Server.
                    Else
                        If Trim(Controls(i).ControlObj.text) = "" Then
                            msg &= "> " & Controls(i).DisplayName & vbNewLine
                            SetError(Controls(i).ControlObj, Controls(i).ErrorMessage)
                            bErrors = True
                        Else
                            SetError(Controls(i).ControlObj, "")
                        End If
                    End If

                End If
            Else
                SetError(Controls(i).ControlObj, "")
            End If
        Next
        If bErrors Then
            MessageBox.Show(msg, Messages.MissingInformation, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        Else
            Return True
        End If
    End Function

    Public Function ShowErrorMessage(msg As String) As Boolean
        MessageBox.Show(msg, Languages.StringWords.ShowErrorMessage_Error, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Return False
    End Function

    'Following function clears error messages from all controls.
    Public Sub ClearAllErrorMessages()
        Dim i As Integer
        For i = 0 To Controls.Count - 1
            SetError(Controls(i).ControlObj, "")
        Next
    End Sub

    'This function hooks validation event with all controls.
    Public Sub SetErrorEvents()
        Dim i As Integer
        For i = 0 To Controls.Count - 1
            AddHandler CType(Controls(i).ControlObj, Control).Validating, AddressOf Validation_Event
        Next
    End Sub

    'Following event is hooked for all controls, it sets an error message with the use of ErrorProvider.
    Private Sub Validation_Event(sender As Object, e As CancelEventArgs)
        If Controls(sender).Validate Then
            If Trim(sender.Text) = "" Then
                SetError(sender, Controls(sender).ErrorMessage)
            Else
                SetError(sender, "")
            End If
        End If
    End Sub

End Class

#End Region

'Following class is inherited from CollectionBase class. It is used for holding all Validation Controls.
'This class is collection of ValidationControl class objects.
'This class is used by ErrorProviderExtended class.

'ValidationControl class is used to hold any control from windows form.
'It holds any control in ControlObj property.