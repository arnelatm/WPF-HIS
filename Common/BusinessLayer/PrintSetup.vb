' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PrintSetup
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("ComputerIdNo"))
                AddRule(New ValidateRequired("PrinterIdNo"))
                AddRule(New ValidateRequired("PaperOrientation"))
                AddRule(New ValidateRequired("PaperSize"))
                AddRule(New ValidateRequired("PrintJobIdNo"))
            End If
        End Sub

        Public Property ComputerIdNo As Int16
        Public Property IdNo As Int16
        Public Property PaperOrientation As Int32
        Public Property PaperSize As Int32
        Public Property PaperSource As Int32
        Public Property PrinterIdNo As Int16
        Public Property PrintJobIdNo As Int16
        Public Property PrintSetupCode As String
        Public Property PrintSetupName As String

    End Class

End Namespace