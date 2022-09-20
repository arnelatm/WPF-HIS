' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Printer
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("PrinterName"))
                AddRule(New ValidateRequired("PrinterCode"))
            End If
        End Sub

        Public Property DefaultPaperOrientation As Int32?
        Public Property DefaultPaperSize As String
        Public Property DefaultPaperSource As Int32?
        Public Property HostOrIpName As String
        Public Property IdNo As Int16
        Public Property PrinterCode As String
        Public Property PrinterName As String

    End Class

End Namespace