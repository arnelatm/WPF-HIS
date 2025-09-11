Public Class ConsoleLogger
    Implements ILogger

    Public Sub LogInfo(message As String) Implements ILogger.LogInfo
        Console.WriteLine($"INFO: {message}")
    End Sub

    Public Sub LogWarning(message As String) Implements ILogger.LogWarning
        Console.WriteLine($"WARNING: {message}")
    End Sub

    Public Sub LogError(message As String) Implements ILogger.LogError
        Console.WriteLine($"ERROR: {message}")
    End Sub

    Public Sub LogException(ex As Exception) Implements ILogger.LogException
        Console.WriteLine($"EXCEPTION: An exception occurred: {ex.Message}")
        Console.WriteLine($"Stack Trace: {ex.StackTrace}")
    End Sub

End Class