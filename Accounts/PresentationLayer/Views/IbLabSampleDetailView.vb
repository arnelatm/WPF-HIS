Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class IbLabSampleDetailView
        Implements IIbLabSampleDetailView
        Public Property Age As Decimal Implements IIbLabSampleDetailView.Age
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Integer Implements IIbLabSampleDetailView.IdNo
        Public Property IqamaNo As String Implements IIbLabSampleDetailView.IqamaNo
        Public Property LabNo As String Implements IIbLabSampleDetailView.LabNo
        Public Property Nationality As String Implements IIbLabSampleDetailView.Nationality
        Public Property PatientName As String Implements IIbLabSampleDetailView.PatientName
        Public Property Rbs As Decimal Implements IIbLabSampleDetailView.Rbs
        Public Property Sequence As Integer Implements IIbLabSampleDetailView.Sequence
        Public Property Stool As Boolean Implements IIbLabSampleDetailView.Stool
        Public Property TakenBy As String Implements IIbLabSampleDetailView.TakenBy
        Public Property TakenDate As Date Implements IIbLabSampleDetailView.TakenDate
        Public Property TakenTime As String Implements IIbLabSampleDetailView.TakenTime
        Public Property Urine As Boolean Implements IIbLabSampleDetailView.Urine
    End Class

End Namespace