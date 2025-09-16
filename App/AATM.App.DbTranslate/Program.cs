using System;

public static class Program
{
    [STAThread] // Required for Windows Forms
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new TranslationForm());
    }
}