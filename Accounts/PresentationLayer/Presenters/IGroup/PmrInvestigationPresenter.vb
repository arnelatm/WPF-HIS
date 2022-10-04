Imports AATM.Accounts.DataLayer
Imports AATM.Accounts.PresentationLayer.Models.IGroup
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.PresentationLayer.Views.Interfaces.IGroup
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class PmrInvestigationPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPmrInvestigationView, TM)

        Public Sub New(itemView As IPmrInvestigationView)
            MyBase.New(itemView)
            Service = New AccountsService("PmrInvestigation")
            Service.SaveConnectionString()
            Service.SetConnectionString("IGROUPCLINIC")
            TableName = "PmrPatientDisplay_View"
            SortOrderKey = "Trans_Key"
            Service.RestoreConnectionString()
            WithTreeView = False
            AddHandler View.GetDoctorPatientsRequested, AddressOf GetDoctorsPatients
        End Sub

        Private Sub GetDoctorsPatients()
            Dim pmrInvestigations As PmrInvestigationModel
            pmrInvestigations = Service.GetParametrized(Of PmrInvestigationModel)({View.DoctorID, View.TransactionDate})
            GlobalVariables.Mapper.Map(pmrInvestigations, View)
        End Sub
    End Class

End Namespace