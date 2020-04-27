Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    Public Class CommonForm

        Public Sub TranslateForm()
            Dim frm As New TranslationTableManager()
            frm.FormIdNoToTranslate = FormIdNo
            frm.AppDataDAC = AppDataDAC
            frm.TranslatorDAC = TranslatorDAC
            frm.Show()
        End Sub

    End Class
End Namespace