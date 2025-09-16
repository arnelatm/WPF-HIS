Imports System.IO
Imports AATM.Contracts

''' <summary>
''' A simple file-based logger implementation.
''' </summary>
Public Class FileLogger
    Implements ILogger

    Private ReadOnly _logFilePath As String

    Public Sub New(logFilePath As String)
        _logFilePath = logFilePath
    End Sub

    Private Sub WriteToLog(level As String, message As String)
        Dim logEntry As String = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} [{level.ToUpper()}] - {message}"
        File.AppendAllText(_logFilePath, logEntry & Environment.NewLine)
    End Sub

    Public Sub LogInfo(message As String) Implements ILogger.LogInfo
        WriteToLog("INFO", message)
    End Sub

    Public Sub LogWarning(message As String) Implements ILogger.LogWarning
        WriteToLog("WARN", message)
    End Sub

    Public Sub LogError(message As String) Implements ILogger.LogError
        WriteToLog("ERROR", message)
    End Sub

    Public Sub LogException(ex As Exception) Implements ILogger.LogException
        WriteToLog("EXCEPTION", $"An exception occurred: {ex.Message}{Environment.NewLine}{ex.StackTrace}")
    End Sub

End Class
