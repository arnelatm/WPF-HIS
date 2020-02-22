Imports System.IO
Imports System.Windows.Forms

<CLSCompliant(True)>
Public Class ErrorLogger

    Public Sub New()

        'default constructor
    End Sub

    '*************************************************************
    'NAME:          WriteToErrorLog
    'PURPOSE:       Open or create an error log and submit error message
    'PARAMETERS:    msg - message to be written to error file
    '               stkTrace - stack trace from error message
    '               title - title of the error file entry
    'RETURNS:       Nothing
    '*************************************************************
    Public Sub WriteToErrorLog(msg As String, stkTrace As String, title As String)

        'check and make the directory if necessary; this is set to look in the application
        'folder, you may wish to place the error log in another location depending upon the
        'the user's role and write access to different areas of the file system
        If Not Directory.Exists(Application.StartupPath & "\Errors\") Then
            Directory.CreateDirectory(Application.StartupPath & "\Errors\")
        End If

        'check the file
        Dim fs = New FileStream(Application.StartupPath & "\Errors\errlog.txt", FileMode.OpenOrCreate,
                                FileAccess.ReadWrite)
        Dim s = New StreamWriter(fs)
        s.Close()
        fs.Close()

        'log it
        Dim fs1 = New FileStream(Application.StartupPath & "\Errors\errlog.txt", FileMode.Append, FileAccess.Write)
        Dim s1 = New StreamWriter(fs1)
        s1.Write("Title: " & title & vbCrLf)
        s1.Write("Message: " & msg & vbCrLf)
        s1.Write("StackTrace: " & stkTrace & vbCrLf)
        s1.Write("Date/Time: " & DateTime.Now.ToString() & vbCrLf)
        s1.Write("===========================================================================================" & vbCrLf)
        s1.Close()
        fs1.Close()
        'MessageBox.Show("Error Logged!",)
    End Sub

End Class