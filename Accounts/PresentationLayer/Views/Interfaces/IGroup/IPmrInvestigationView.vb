Imports AATM.Accounts.BusinessLayer.IGroup
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces.IGroup

    Public Interface IPmrInvestigationView
        Inherits IView

        Property DoctorID As String
        Property DoctorName As String
        Property TransactionDate As String
        Property PmrPatientsDisplay As List(Of IPmrPatientDisplayView)
        Event GetDoctorPatientsRequested()
    End Interface

End Namespace