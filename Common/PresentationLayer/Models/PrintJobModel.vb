Namespace Models

    Public Class PrintJobModel

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Property ComputerName As String
        Public Property IdNo As Int16
        Public Property PaperOrientation As Int16?
        Public Property PaperSize As Int32?
        Public Property PaperSource As Int16?
        Public Property PrinterName As String
        Public Property PrintJobName As String

    End Class

End Namespace