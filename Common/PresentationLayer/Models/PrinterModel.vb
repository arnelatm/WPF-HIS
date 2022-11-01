Namespace Models

    Public Class PrinterModel

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Property DefaultPaperOrientation As Int32?
        Public Property DefaultPaperSize As String
        Public Property DefaultPaperSource As Int32?
        Public Property HostOrIpName As String
        Public Property IdNo As Int16
        Public Property PrinterCode As String
        Public Property PrinterName As String

    End Class

End Namespace