Namespace CascadingComboboBox
    Friend Module Program
        ''' <summary>
        '''  The main entry point for the application.
        ''' </summary>
        <STAThread>
        Private Sub Main()
            ' To customize application configuration such as set high DPI settings or default font,
            ' see https://aka.ms/applicationconfiguration.
            CascadingComboboBox.ApplicationConfiguration.Initialize()
            Call Windows.Forms.Application.Run(New Form1())
        End Sub
    End Module
End Namespace
