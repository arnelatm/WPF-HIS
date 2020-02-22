Public Class TranslationTable
    Inherits DataTable

    Friend Sub New()
        Clear()
        Columns.Add("Original")
        Columns.Add("Translated")
    End Sub

End Class