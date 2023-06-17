Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPmrInvestigationView
        Inherits IView

        Property DoctorCode As String
        Property DoctorName As String
        Property TransactionDate As Date?
        Property DoctorsPatients As List(Of DoctorsPatientView)

        Event GetDoctorPatientsRequested()

        Event DoctorCodeRequested(ByRef drId As String)
        Event GetPmrDataAccessRequested(ByRef drId As String)
    End Interface

    Public Interface IDoctorsPrescriptionView
        Inherits IPmrInvestigationView

        Property PrescriptionDetails As List(Of PrescriptionDetailView)
        Event RowChanged(productIdNo As Integer)

    End Interface

End Namespace