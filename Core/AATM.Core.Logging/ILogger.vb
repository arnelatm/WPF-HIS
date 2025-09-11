''' <summary>
''' Defines methods for logging messages and exceptions.
''' </summary>
Public Interface ILogger

    ''' <summary>
    ''' Logs a message with informational severity.
    ''' </summary>
    Sub LogInfo(message As String)

    ''' <summary>
    ''' Logs a message with a warning severity.
    ''' </summary>
    Sub LogWarning(message As String)

    ''' <summary>
    ''' Logs an error message.
    ''' </summary>
    Sub LogError(message As String)

    ''' <summary>
    ''' Logs an exception, including its full details.
    ''' </summary>
    Sub LogException(ex As Exception)

End Interface
