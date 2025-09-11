Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views

    Public Class ClinicLabSampleDetailView
        Implements IClinicLabSampleDetailView
        Public Property Age As Decimal Implements IClinicLabSampleDetailView.Age
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Integer Implements IClinicLabSampleDetailView.IdNo
        Public Property IqamaNo As String Implements IClinicLabSampleDetailView.IqamaNo
        Public Property LabNo As String Implements IClinicLabSampleDetailView.LabNo
        Public Property Nationality As String Implements IClinicLabSampleDetailView.Nationality
        Public Property PatientName As String Implements IClinicLabSampleDetailView.PatientName
        Public Property Sequence As Integer Implements IClinicLabSampleDetailView.Sequence
        Public Property TakenBy As String Implements IClinicLabSampleDetailView.TakenBy
        Public Property TakenDate As Date Implements IClinicLabSampleDetailView.TakenDate
        Public Property TakenTime As String Implements IClinicLabSampleDetailView.TakenTime
        Public Property TestName As String Implements IClinicLabSampleDetailView.TestName

        Public Property RegistrationNo As String Implements IClinicLabSampleDetailView.RegistrationNo
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property
    End Class

End Namespace