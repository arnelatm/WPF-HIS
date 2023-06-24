Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPmrInvestigationView
        Inherits IView

        Property DoctorCode As String
        Property DoctorName As String
        Property TransactionDate As Date?
        Property DoctorsPatients As List(Of DoctorsPatientView)

        Event DataChanged()

        Event DoctorCodeRequested(ByRef drId As String)
        Event GetPmrDataAccessRequested(ByRef drId As String)
    End Interface

    Public Interface IDoctorsPrescriptionView
        Inherits IPmrInvestigationView

        Property PrescriptionDetails As List(Of PrescriptionItemView)
        Event RowChanged(productIdNo As Integer)
        Event PrintDosageLabel()
        Event SaveDosage()
    End Interface

End Namespace