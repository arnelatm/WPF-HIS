Imports System.Drawing
Imports System.Reflection.Emit
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Public Class DisplayProgressForm

    Private _description As String

    Public Sub New()

        ' This call is required by the designer.

        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub InitializeDisplay(Optional nMaxValue As Int32 = 100, Optional description As String = Nothing)
        Me.CenterToScreen()
        If description Is Nothing Then
            Dim caption = Messaging.TranslateCaption("Please wait processing request...")
            _description = caption
        Else
            _description = description
        End If       
        ProgressBar.Maximum = nMaxValue
        ProgressBar.Value = 0
        Me.Text = description
    End Sub

    Public Sub DisplayProgress(count As Int32)
        ProgressBar.Maximum = count
    End Sub

    Public Sub UpdateProgressBar(counter As Int32)
        ProgressBar.Value = counter
        Dim percent As Decimal = (counter / ProgressBar.Maximum * 100)
        Me.Text = _description & " " & percent.ToString("#.##") & $"%"
    End Sub

    Public Sub ResetProgressBar()
        ProgressBar.Value = 0
    End Sub

End Class