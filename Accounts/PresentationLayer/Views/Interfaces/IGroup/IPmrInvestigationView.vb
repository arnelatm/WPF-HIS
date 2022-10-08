Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPmrInvestigationView
        Inherits IView

        Property DoctorCode As String
        Property DoctorName As String
        Property TransactionDate As Date?
        Property PmrPatientsDisplay As List(Of PmrPatientDisplayView)

        Event GetDoctorPatientsRequested()

        Event DoctorCodeRequested(ByRef drId As String)

    End Interface

End Namespace