Imports AATM.Accounts.DataLayer
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interface

Namespace PresentationLayer.Presenters

    Public Class PmrInvestigationPresenter(Of TM As New)
        Inherits CommonPresenter(Of AATM.Accounts.PresentationLayer.Views.Interfaces.IPmrInvestigationView, TM)

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
            Dim pmrPatients As New CPmrInvestigationModel
            pmrPatients = Service.GetParametrized(Of PmrInvestigationModel)({View.DoctorID, View.TransactionDate})
            GlobalVariables.Mapper.Map(pmrPatients, View)
            'GlobalVariables.Mapper.Map(pmrPatients, View)
        End Sub
    End Class

End Namespace