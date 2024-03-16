Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PMRInvestigationPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPmrInvestigationView, TM)

        Public Sub New()

        End Sub

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
            AddHandler View.DataChanged, AddressOf UpdateData
            AddHandler View.GetPmrDataAccessRequested, AddressOf GetPMRDataAccess
        End Sub

        Protected Overrides Sub CreateDataSources()
            Service.SaveConnectionString()
            Service.SetConnectionString($"ISPDATA")
            MakeControlDataSources({New Object() {"Doctor_View", "DoctorName", "IdNo,DoctorName,DoctorCode", Nothing, Nothing}})
            Service.RestoreConnectionString()
        End Sub

        Private Sub UpdateData()
            Dim pmrInvestigationModel As New PmrInvestigationModel
            Dim transactionDateString As String = View.TransactionDate
            If String.IsNullOrEmpty(View.DoctorCode) Then
                pmrInvestigationModel = Nothing
            Else
                pmrInvestigationModel = Service.GetParametrized(Of PmrInvestigationModel)({View.DoctorCode, View.TransactionDate})
            End If
            GlobalVariables.Mapper.Map(pmrInvestigationModel, View)
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

    Public Class DoctorsPrescriptionPresenter(Of TM As New)
        Inherits CommonPresenter(Of IDoctorsPrescriptionView, TM)

        Private _prescriptionDetailsService = New AccountsService("PrescriptionItem")

        Public Sub New(itemView As IDoctorsPrescriptionView)
            MyBase.New(itemView)
            Service = New AccountsService("DoctorsPrescription")
            Service.SaveConnectionString()
            Service.SetConnectionString($"IGROUPCLINIC")
            TableName = "PmrPatientDisplay_View"
            SortOrderKey = "Trans_Key"
            Service.RestoreConnectionString()
            WithTreeView = False
            AddHandler View.DoctorCodeRequested, AddressOf GetDoctorCode
            AddHandler View.DataChanged, AddressOf UpdateData
            AddHandler View.RowChanged, AddressOf OnRowChanged
            AddHandler View.SaveDosage, AddressOf OnSaveDosage
            AddHandler View.PrintDosageLabel, AddressOf OnPrintDosageLabel
        End Sub

        Private Sub OnPrintDosageLabel()
            Throw New NotImplementedException()
        End Sub

        Private Sub OnSaveDosage()
            Throw New NotImplementedException()
        End Sub

        Protected Overrides Sub CreateDataSources()
            Service.SaveConnectionString()
            Service.SetConnectionString($"ISPDATA")
            MakeControlDataSources({New Object() {"Doctor_View", "DoctorName", "IdNo,DoctorName,DoctorCode", Nothing, Nothing}})
            Service.RestoreConnectionString()
        End Sub

        Private Sub UpdateData()
            Dim DoctorsPrescriptionModel As New DoctorsPrescriptionModel
            Dim transactionDateString As String = View.TransactionDate
            If String.IsNullOrEmpty(View.DoctorCode) Then
                DoctorsPrescriptionModel = Nothing
            Else
                DoctorsPrescriptionModel = Service.GetParametrized(Of DoctorsPrescriptionModel)({View.DoctorCode, View.TransactionDate})
            End If
            GlobalVariables.Mapper.Map(DoctorsPrescriptionModel, View)
        End Sub

        Private Sub GetDoctorCode(ByRef drId As String)
            Dim employeeIdNo As Int32
            employeeIdNo = Service.GetUserEmployeeIdNo()
            Service.SaveConnectionString()
            Service.SetConnectionString($"ISPDATA")
            drId = Service.GetField(Of String, Int32)(employeeIdNo, "Doctor", "EmployeeIdNo", "DoctorCode")
            Service.RestoreConnectionString()
        End Sub

        Private Sub OnRowChanged(transKey As Int32)
            UpdatePrescriptionDetail(transKey)
        End Sub

        Private Sub UpdatePrescriptionDetail(transKey As Int32?)
            Dim prescriptionDetails As New List(Of PrescriptionItemModel)
            prescriptionDetails = _prescriptionDetailsService.GetRecordsWithGroupIdNo(Of PrescriptionItemModel)(transKey)
            GlobalVariables.Mapper.Map(prescriptionDetails, View.PrescriptionDetails)
        End Sub

        'Private Sub PrintReport()
        '    Dim pmrPatients As New DoctorsPrescriptionModel
        '    pmrPatients = Service.GetParametrized(Of DoctorsPrescriptionModel)({View.DoctorCode, View.TransactionDate})
        '    GlobalVariables.Mapper.Map(pmrPatients, View)
        'End Sub

        'Private ReadOnly _prescriptionDetailsService As New AccountsService("PrescriptionDetail")
        ''Private ReadOnly _doctorsPatientService As New AccountsService("DoctorsPatient")

        'Public Sub New(itemView As IDoctorsPrescriptionView)
        '    MyBase.New(itemView)
        '    Service = New AccountsService("DoctorsPrescription")
        '    Service.SaveConnectionString()
        '    Service.SetConnectionString($"IGROUPCLINIC")
        '    TableName = "PmrPatientDisplay_View"
        '    SortOrderKey = "Trans_Key"
        '    Service.RestoreConnectionString()
        '    WithTreeView = False
        '    AddHandler View.DoctorCodeRequested, AddressOf GetDoctorCode
        '    'AddHandler View.DataChanged, AddressOf GetDoctorsPatients

        'End Sub

        'Protected Overrides Sub CreateDataSources()
        '    Service.SaveConnectionString()
        '    Service.SetConnectionString($"ISPDATA")
        '    MakeControlDataSources({"Doctor_View", "DoctorName")
        '    Service.RestoreConnectionString()
        'End Sub

        ''Private Sub GetDoctorsPatients()
        ''    Dim pmrPatients As New DoctorsPatientModel
        ''    Dim transactionDateString As String = View.TransactionDate
        ''    If String.IsNullOrEmpty(View.DoctorCode) Then
        ''        pmrPatients = Nothing
        ''    Else
        ''        'pmrPatients = _doctorsPatientService.GetParametrized(Of DoctorsPatientModel)({View.DoctorCode, View.TransactionDate})
        ''        pmrPatients = Service.GetParametrized(Of DoctorsPatientModel)({View.DoctorCode, View.TransactionDate})
        ''    End If
        ''    GlobalVariables.Mapper.Map(pmrPatients, View.DoctorsPatients)
        ''End Sub

        'Private Sub GetDoctorCode(ByRef drId As String)
        '    Dim employeeIdNo As Int32
        '    employeeIdNo = Service.GetUserEmployeeIdNo()
        '    Service.SaveConnectionString()
        '    Service.SetConnectionString($"ISPDATA")
        '    drId = Service.GetField(Of String, Int32)(employeeIdNo, "Doctor", "EmployeeIdNo", "DoctorCode")
        '    Service.RestoreConnectionString()
        'End Sub

        'Private Sub PrintReport()
        '    Dim pmrPatients As New DoctorsPrescriptionModel
        '    pmrPatients = Service.GetParametrized(Of DoctorsPrescriptionModel)({View.DoctorCode, View.TransactionDate})
        '    GlobalVariables.Mapper.Map(pmrPatients, View)
        'End Sub

        'Private Sub OnRowChanged(patientIdNo As Int32)
        '    UpdatePrescriptionDetail(patientIdNo)
        'End Sub


        'Private Sub UpdatePrescriptionDetail(patientIdNo As Int32)
        '    Dim prescriptionDetails As List(Of PrescriptionDetailModel)
        '    prescriptionDetails = _prescriptionDetailsService.GetRecordsWithGroupIdNo(Of PrescriptionDetailModel)(patientIdNo)
        '    GlobalVariables.Mapper.Map(prescriptionDetails, View.PrescriptionDetails)
        'End Sub

    End Class

    'Public Class DoctorsPrescriptionPresenter(Of TM As New)
    '    Inherits PMRInvestigationPresenter(Of DoctorsPrescriptionModel)

    '    Private ReadOnly _prescriptionDetailsService As New AccountsService("PrescriptionDetail")

    '    Public Sub New(itemView As IDoctorsPrescriptionView)
    '        MyBase.New(itemView)

    '        AddHandler View.RowChanged, AddressOf OnRowChanged

    '    End Sub

    '    Private Sub OnRowChanged(patientIdNo As Int32)
    '        UpdatePrescriptionDetail(patientIdNo)
    '    End Sub


    '    Private Sub UpdatePrescriptionDetail(patientIdNo As Int32)
    '        Dim prescriptionDetails As List(Of PrescriptionDetailModel)
    '        prescriptionDetails = _prescriptionDetailsService.GetRecordsWithGroupIdNo(Of PrescriptionDetailModel)(patientIdNo)
    '        GlobalVariables.Mapper.Map(prescriptionDetails, View.PrescriptionDetails)
    '    End Sub

    'End Class
    
    Public Class PmrInvestigationRequestPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPmrInvestigationRequestView, TM)

        Public Sub New(itemView As IPmrInvestigationRequestView)
            MyBase.New(itemView)
            Service = New AccountsService("PmrInvestigationRequest")
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
            MakeControlDataSources({New Object() {"Doctor_View", "DoctorName", "IdNo,DoctorName,DoctorCode", Nothing, Nothing}})
            Service.RestoreConnectionString()
        End Sub

        Private Sub GetDoctorsPatients()
            Dim pmrPatients As New PmrInvestigationRequestModel
            Dim transactionDateString As String = View.TransactionDate
            If String.IsNullOrEmpty(View.DoctorCode) Then
                pmrPatients = Nothing
            Else
                pmrPatients = Service.GetParametrized(Of PmrInvestigationRequestModel)({View.DoctorCode, View.TransactionDate})
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
            Dim pmrPatients As New PmrInvestigationRequestModel
            pmrPatients = Service.GetParametrized(Of PmrInvestigationRequestModel)({View.DoctorCode, View.TransactionDate})
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