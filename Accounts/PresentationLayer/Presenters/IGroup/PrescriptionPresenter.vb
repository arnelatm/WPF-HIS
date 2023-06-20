Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PrescriptionPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPrescriptionView, TM)

        Private _prescriptionDetailsService = New AccountsService("PrescriptionDetail")

        Public Sub New(itemView As IPrescriptionView)
            MyBase.New(itemView)
            Service = New AccountsService("Prescription")
            Service.SaveConnectionString()
            Service.SetConnectionString($"IGROUPCLINIC")
            TableName = "Prescription_View"
            SortOrderKey = "TransKey"
            Service.RestoreConnectionString()
            WithTreeView = False

            'AddHandler View.SaveDosage, AddressOf OnSaveDosage
            'AddHandler View.PrintDosageLabel, AddressOf OnPrintDosageLabel
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
            'CreateDataSource("Doctor_View", "DoctorName")
            Service.RestoreConnectionString()
        End Sub

        Private Sub UpdateData()
            Dim prescriptionModel As New PrescriptionModel
            Dim transactionDateString As String = View.TransDate
            If String.IsNullOrEmpty(View.DoctorCode) Then
                prescriptionModel = Nothing
            Else
                prescriptionModel = Service.GetParametrized(Of PrescriptionModel)({View.DoctorCode, View.TransDate})
            End If
            GlobalVariables.Mapper.Map(prescriptionModel, View)
        End Sub

        Private Sub GetDoctorCode(ByRef drId As String)
            Dim employeeIdNo As Int32
            employeeIdNo = Service.GetUserEmployeeIdNo()
            Service.SaveConnectionString()
            Service.SetConnectionString($"ISPDATA")
            drId = Service.GetField(Of String, Int32)(employeeIdNo, "Doctor", "EmployeeIdNo", "DoctorCode")
            Service.RestoreConnectionString()
        End Sub

        'Private Sub OnRowChanged(transKey As Int32)
        '    UpdatePrescriptionDetail(transKey)
        'End Sub

        Private Sub UpdatePrescriptionDetail(transKey As Int32?)
            Dim prescriptionDetails As New List(Of PrescriptionDetailModel)
            prescriptionDetails = _prescriptionDetailsService.GetRecordsWithGroupIdNo(Of PrescriptionDetailModel)(transKey)
            GlobalVariables.Mapper.Map(prescriptionDetails, View.PrescriptionDetails)
        End Sub

        'Private Sub PrintReport()
        '    Dim pmrPatients As New DoctorsPrescriptionModel
        '    pmrPatients = Service.GetParametrized(Of DoctorsPrescriptionModel)({View.DoctorCode, View.TransactionDate})
        '    GlobalVariables.Mapper.Map(pmrPatients, View)
        'End Sub

    End Class

End Namespace