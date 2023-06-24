Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.DataLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PrescriptionPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPrescriptionView, TM)

        Private _prescriptionDetailsService = New AccountsService("PrescriptionItem")

        Public Sub New(itemView As IPrescriptionView)
            MyBase.New(itemView)
            Service = New AccountsService("Prescription")
            Service.SaveConnectionString()
            Service.SetConnectionString($"IGROUPCLINIC")
            TableName = "Prescription_View"
            SortOrderKey = "TransKey"
            Service.RestoreConnectionString()
            WithTreeView = False
            AddHandler View.PrintLabels, AddressOf OnPrintLabels
        End Sub

        Private Sub OnPrintLabels()
            UpdatePrintableLabels()
            Dim printModel As New ReportModel
            Dim reportPrinter As New PrintReportPresenter(Of ReportModel)
            reportPrinter.OnPrintReport("DosageLabel.Rpt", "IGROUPCLINIC", {View.TransKey, "IdNo"})

            ' after printing marked the records as not printable 
            For Each item As PrescriptionItemView In View.PrescriptionDetails
                MarkLabelAsNotPrintable(item)
            Next

        End Sub

        Private Sub UpdatePrintableLabels()
            For Each item As PrescriptionItemView In View.PrescriptionDetails
                If item.PrintLabel Then
                    MarkLabelAsPrintable(item)
                Else
                    MarkLabelAsNotPrintable(item)
                End If
            Next
        End Sub

        Private Sub MarkLabelAsPrintable(item As PrescriptionItemView)
            _prescriptionDetailsService.GenericUpdateRecordWithIdNo(Of Boolean)(item.PrescriptionItemIdNo, "PMRMedicineDetails", "LabelPrinted", False)
        End Sub

        Private Sub MarkLabelAsNotPrintable(item As PrescriptionItemView)
            _prescriptionDetailsService.GenericUpdateRecordWithIdNo(Of Boolean)(item.PrescriptionItemIdNo, "PMRMedicineDetails", "LabelPrinted", True)
        End Sub

        Protected Overrides Sub CreateDataSources()
            Service.SaveConnectionString()
            Service.SetConnectionString($"ISPDATA")
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

        Private Sub UpdatePrescriptionDetail(transKey As Int32?)
            Dim prescriptionDetails As New List(Of PrescriptionItemModel)
            prescriptionDetails = _prescriptionDetailsService.GetRecordsWithGroupIdNo(Of PrescriptionItemModel)(transKey)
            GlobalVariables.Mapper.Map(prescriptionDetails, View.PrescriptionDetails)
        End Sub

    End Class

End Namespace