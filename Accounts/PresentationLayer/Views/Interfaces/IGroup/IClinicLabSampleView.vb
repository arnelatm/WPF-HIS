Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IClinicLabSampleView
        Inherits IView

        Property TransactionDate As Date?
        Property ClinicLabSampleDetails As List(Of ClinicLabSampleDetailView)
        Event ClinicLabSamplesRequested(transactionDate As Date?)
        Event ClinicLabSampleChanged(bindingSource As BindingSource)
    End Interface



    Public Interface IClinicLabSampleDetailView
        Inherits IView

        Property Age As Decimal
        Property IdNo As Int32
        Property IqamaNo As String
        Property LabNo As String
        Property Nationality As String
        Property PatientName As String
        Property RegistrationNo As String
        Property Sequence As Int32
        Property TakenBy As String
        Property TakenDate As Date
        Property TakenTime As String
        Property TestName As String
    End Interface

End Namespace