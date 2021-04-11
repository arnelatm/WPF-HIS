Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessObjects

    Public Class SecurityControl
        Inherits BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property IdNo As Int32
        Public Property SystemViewIdNo As Int16
        Public Property SecurityControlName As String
        Public Property ParentIdNo As Int32

    End Class

End Namespace