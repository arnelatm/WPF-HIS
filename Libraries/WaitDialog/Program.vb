
Imports System.Windows.Forms

Class Program
    Private Sub New()
    End Sub

    <STAThread>
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New FormMain)
    End Sub
End Class
