''' <summary>
''' Defines a contract for a service that provides user feedback and notifications.
''' This interface decouples the Presenter from specific UI implementations like MessageBox.
''' </summary>
Public Interface IMessagingService

    ''' <summary>
    ''' Displays a success message to the user.
    ''' </summary>
    ''' <param name="message">The message to display.</param>
    Sub ShowSuccess(message As String)

    ''' <summary>
    ''' Displays an error message to the user.
    ''' </summary>
    ''' <param name="message">The message to display.</param>
    Sub ShowError(message As String)

    ''' <summary>
    ''' Displays an informational message to the user.
    ''' </summary>
    ''' <param name="message">The message to display.</param>
    Sub ShowInformation(message As String)

End Interface