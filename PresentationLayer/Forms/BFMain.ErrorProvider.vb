Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary

Partial Class BfMain

    ' Restored legacy field (keeps existing code that references BfMain.MyErrorProvider working).
    Public MyErrorProvider As ErrorProviderExtended

    Private Sub EnsureErrorProvider()
        If MyErrorProvider Is Nothing Then
            MyErrorProvider = New ErrorProviderExtended() With {
                .ContainerControl = Me,
                .BlinkStyle = ErrorBlinkStyle.NeverBlink
            }
        End If
    End Sub

    ' Call from constructors without cluttering the main file.
    Private Sub InitializeErrorProvider()
        EnsureErrorProvider()
    End Sub

End Class