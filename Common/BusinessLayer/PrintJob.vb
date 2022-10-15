' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PrintJob
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("PrintJobName"))
                AddRule(New ValidateRequired("PrintJobCode"))
                AddRule(New ValidateRequired("PrnterName"))
            End If
        End Sub

        Public Property ComputerName As String
        Public Property IdNo As Int16
        Public Property PaperOrientation As String
        Public Property PaperSize As Int32
        Public Property PaperSource As Int16
        Public Property PrinterName As String
        Public Property PrintJobCode As String
        Public Property PrintJobName As String
        Public Property PrintJobNameAra As String

    End Class

End Namespace