Namespace Models

    Public Class PrintJobModel

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Property ComputerName As String
        Public Property IdNo As Int16
        Public Property NetworkName As String
        Public Property PaperOrientation As Int32?
        Public Property PaperSize As Int32?
        Public Property PaperSource As Int32?
        Public Property PrinterName As String
        Public Property PrintJobName As Int32?

    End Class

End Namespace