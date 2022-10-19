Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PmrInvestigationPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPmrInvestigationView, TM)

        Public Sub New(itemView As IPmrInvestigationView)
            MyBase.New(itemView)
            Service = New AccountsService("PmrInvestigation")
            Service.SaveConnectionString()
            Service.SetConnectionString($"IGROUPCLINIC")
            TableName = "PmrPatientDisplay_View"
            SortOrderKey = "Trans_Key"
            Service.RestoreConnectionString()
            WithTreeView = False
            AddHandler View.DoctorCodeRequested, AddressOf GetDoctorCode
            AddHandler View.GetDoctorPatientsRequested, AddressOf GetDoctorsPatients

        End Sub

        Protected Overrides Sub CreateDataSources()
            Service.SaveConnectionString()
            Service.SetConnectionString($"ISPDATA")
            CreateDataSource("Doctor_View", "DoctorName")
            Service.RestoreConnectionString()
        End Sub

        Private Sub GetDoctorsPatients()
            Dim pmrPatients As New PmrInvestigationModel
            Dim transactionDateString As String = View.TransactionDate
            If String.IsNullOrEmpty(View.DoctorCode) Then
                pmrPatients = Nothing
            Else
                pmrPatients = Service.GetParametrized(Of PmrInvestigationModel)({View.DoctorCode, View.TransactionDate})
            End If
            GlobalVariables.Mapper.Map(pmrPatients, View)
        End Sub

        Private Sub GetDoctorCode(ByRef drId As String)
            Dim employeeIdNo As Int32
            employeeIdNo = Service.GetUserEmployeeIdNo()
            Service.SaveConnectionString()
            Service.SetConnectionString($"ISPDATA")
            drId = Service.GetField(Of String, Int32)(employeeIdNo, "Doctor", "EmployeeIdNo", "DoctorCode")
            Service.RestoreConnectionString()
        End Sub

        Private Sub PrintReport()
            Dim pmrPatients As New PmrInvestigationModel
            pmrPatients = Service.GetParametrized(Of PmrInvestigationModel)({View.DoctorCode, View.TransactionDate})
            GlobalVariables.Mapper.Map(pmrPatients, View)
        End Sub

    End Class

End Namespace