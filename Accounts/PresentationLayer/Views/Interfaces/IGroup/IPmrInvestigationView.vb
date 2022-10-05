Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPmrInvestigationView
        Inherits IView

        Property DoctorId As String
        Property DoctorName As String
        Property TransactionDate As Date?
        Property PmrPatientsDisplay As List(Of PmrPatientDisplayView)

        Event GetDoctorPatientsRequested()

        Event PrintReportRequested(rowIndex As Int16)

    End Interface

End Namespace