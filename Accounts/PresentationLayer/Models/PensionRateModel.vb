' GeneralJournal business object as seen by the Service client.
Namespace PresentationLayer.Models

    Public Class PensionRateModel
        Public Errors As List(Of String)
        Public Property EmployeeShare As Decimal
        Public Property EmployerShare As Decimal
        Public Property HighRange As Decimal
        Public Property IdNo As Int32
        Public Property LowRange As Decimal
        Public Property MaxAmount As Decimal
        Public Property PensionSchemeIdNo As Int16
        Public Property Sequence As Int16
    End Class

End Namespace