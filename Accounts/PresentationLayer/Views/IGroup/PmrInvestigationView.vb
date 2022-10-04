Imports AATM.Accounts.BusinessLayer.IGroup
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces.IGroup

    Public Class PmrInvestigationView
        Implements IPmrInvestigationView

        Property DoctorID As String Implements IPmrInvestigationView.DoctorID
        Property DoctorName As String Implements IPmrInvestigationView.DoctorName
        Property TransactionDate As String Implements IPmrInvestigationView.TransactionDate
        Property PmrPatientsDisplay As List(Of IPmrPatientDisplayView) Implements IPmrInvestigationView.PmrPatientsDisplay
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Event GetDoctorPatientsRequested() Implements IPmrInvestigationView.GetDoctorPatientsRequested
    End Class

End Namespace