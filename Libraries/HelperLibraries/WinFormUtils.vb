Imports System.Windows.Forms

Public Module WinFormUtils

    Public Sub DoPaintEvents()
        Application.AddMessageFilter(PaintMessageFilter.Instance)
        Application.DoEvents()
        Application.RemoveMessageFilter(PaintMessageFilter.Instance)
    End Sub

    Private Class PaintMessageFilter
        Implements IMessageFilter

        Public Shared ReadOnly Instance As IMessageFilter = New PaintMessageFilter()

        Private Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
            Select Case m.Msg
                Case &HF
                    Return False
                Case Else
                    If m.Msg >= &HC000 Then Return False
                    Return True
            End Select
            'Return (m.Msg <> &HF)
        End Function

    End Class

End Module