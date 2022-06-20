Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PensionRateView
        Implements IPensionRateView

        Public Property EmployeeShare As Decimal Implements IPensionRateView.EmployeeShare
        Public Property EmployerShare As Decimal Implements IPensionRateView.EmployerShare
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property HighRange As Decimal Implements IPensionRateView.HighRange
        Public Property IdNo As Int32 Implements IPensionRateView.IdNo
        Public Property LowRange As Decimal Implements IPensionRateView.LowRange
        Public Property MaxAmount As Decimal Implements IPensionRateView.MaxAmount
        Public Property PensionSchemeIdNo As Int16 Implements IPensionRateView.PensionSchemeIdNo
        Public Property Sequence As Int16 Implements IPensionRateView.Sequence

    End Class

End Namespace