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
            AddHandler View.GetPmrDataAccessRequested, AddressOf GetPMRDataAccess

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

        Public Sub GetPMRDataAccess(ByRef dataAccessLevel As String)
            dataAccessLevel = ""
            dataAccessLevel += IIf(CanUserViewSecurity("PMRPrescription"), "1", "0")
            dataAccessLevel += IIf(CanUserViewSecurity("PMRLab"), "1", "0")
            dataAccessLevel += IIf(CanUserViewSecurity("PMRXray"), "1", "0")
            dataAccessLevel += IIf(CanUserViewSecurity("PMREROther"), "1", "0")
        End Sub

        Private Function CanUserViewSecurity(securityKey As String) As String
            If UserIsASuperAdministrator() Then
                Return True
            End If
            Dim securityIdNo As Int16 = GetControlSecurityIdNo(securityKey)
            Dim controlSecurityValues As ArrayList
            Dim viewBit As Boolean
            If securityIdNo <> 0 Then
                controlSecurityValues = GetUserSecurity(Convert.ToInt16(securityIdNo), GlobalVariables.SecurityGroupIdNo)
                If controlSecurityValues.Count > 0 Then
                    ' Visible property stored in first element of the array
                    viewBit = controlSecurityValues(0)
                    ' Editable property stored in second element of the array
                End If
            End If
            Return viewBit
        End Function
    End Class

End Namespace