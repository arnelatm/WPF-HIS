Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views

    Public Class IbLabSampleDetailView
        Implements IIbLabSampleDetailView

        Public Property IdNo As Integer Implements IIbLabSampleDetailView.IdNo
        Public Property TransKey As Integer Implements IIbLabSampleDetailView.TransKey
        Public Property TakenDate As Date Implements IIbLabSampleDetailView.TakenDate
        Public Property TakenTime As Date Implements IIbLabSampleDetailView.TakenTime
        Public Property TakenBy As String Implements IIbLabSampleDetailView.TakenBy
        Public Property Urine As Boolean Implements IIbLabSampleDetailView.Urine
        Public Property Stool As Boolean Implements IIbLabSampleDetailView.Stool
        Public Property Rbs As Decimal Implements IIbLabSampleDetailView.Rbs

    End Class

End Namespace