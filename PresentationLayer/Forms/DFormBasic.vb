Imports AATM.PresentationLayer.Views

Public Class DFormBasic
    Implements IViewNew

    Private _debugSwitch As Byte = 0
    Private _systemViewIdNo As Int32


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        KeyPreview = False
    End Sub

    Public Property ViewDisplayName As String Implements IViewNew.ViewDisplayName
    Public ReadOnly Property FormName As String Implements IViewNew.FormName
        Get
            Return Name.Trim()
        End Get
    End Property


    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        Close()
    End Sub

    Private Sub btnDebug_Click(sender As Object, e As EventArgs) Handles btnDebug.Click
        If _debugSwitch = 0 Then
            _debugSwitch = 1
            Debugger.Break()
            btnDebug.Checked = False
        Else
            _debugSwitch = 0
            btnDebug.Checked = True
        End If
    End Sub

    Protected Property VSystemViewIdNo As Short
        Get
            Return GetSystemViewIdNo()
        End Get
        Set(value As Short)
            _systemViewIdNo = value
        End Set
    End Property

    Private Sub CutToolStripButton_Click(sender As Object, e As EventArgs) Handles CutToolStripButton.Click
        CutText()
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        CopyText()
    End Sub

    Private Sub btnTranslate_Click(sender As Object, e As EventArgs) Handles btnTranslate.Click
        If _debugSwitch Then
            Debugger.Break()
        End If

        RunTranslator(VSystemViewIdNo)
    End Sub


    Protected Sub RunTranslator(ByVal nSystemViewIdNo)
        Dim frm As New TranslationTableManager()
        frm.SystemViewIdNoToTranslate = nSystemViewIdNo
        frm.AppDataDAC = AppDataDac
        frm.TranslatorDAC = TranslatorDac
        frm.Show()
    End Sub

    Protected Function GetSystemViewIdNo()
        Dim cmd As String
        If ViewDisplayName Is Nothing Or ViewDisplayName = "" Then
            ViewDisplayName = Name
        End If
        cmd = "SELECT IdNo FROM SystemView where SystemViewName ='" + ViewDisplayName.Trim() + "'"
        Return TranslatorDac.ExecScalar(Of Int16)(cmd)
    End Function

End Class
