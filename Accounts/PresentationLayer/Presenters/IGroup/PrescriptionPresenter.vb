Imports System.Dynamic
Imports AATM.Accounts.BusinessLayer
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
Imports Telerik.Licensing
Imports Telerik.WinControls.UI

Namespace PresentationLayer.Presenters

    Public Class PrescriptionPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPrescriptionView, TM)

        Private _prescriptionItemService = New AccountsService("PrescriptionItem")
        Private _computerName As String
        Private _labelIdNo As Int32
        Private ReadOnly _itemDetailsService As New AccountsService("ItemDetails")

        Public Sub New(itemView As IPrescriptionView)
            MyBase.New(itemView)
            Service = New AccountsService("Prescription")
            TableName = "Prescription_View"
            SortOrderKey = "TransKey"
            WithTreeView = False
            _computerName = Environment.MachineName
            AddHandler View.PrintLabels, AddressOf OnPrintLabels
            AddHandler View.ItemCodeChanged, AddressOf OnItemCodeChanged
            AddHandler View.GTinScanned, AddressOf OnGTinScanned
        End Sub

        Private Sub OnItemCodeChanged(itemCode As String, bs As BindingSource)
            Dim prescriptionItem As PrescriptionItemView = bs.Current
            InitializePrescriptionItemValues(prescriptionItem, itemCode)
            bs.ResetCurrentItem()
        End Sub

        Private Sub OnPrintLabels()
            UpdatePrintableLabels()

            CreateLabels()

            Dim printModel As New ReportModel
            Dim reportPrinter As New PrintReportPresenter(Of ReportModel)
            reportPrinter.OnPrintReport("DosageLabel.Rpt", "IGROUPCLINIC", {_labelIdNo, "LabelIdNo"})

            ' after printing marked the records as not printable so as to avoid duplicate printing of labels
            For Each item As PrescriptionItemView In View.PrescriptionDetails
                MarkLabelAsNotPrintable(item)
            Next

        End Sub

        Private Sub InitializePrescriptionItemValues(ByRef prescriptionDetail As PrescriptionItemView, itemCode As String)
            Dim itemDetail As ItemDetailsModel = GetItemDetailsCode(itemCode)
            If itemDetail IsNot Nothing Then
                With prescriptionDetail
                    prescriptionDetail.ItemIdNo = itemDetail.IdNo
                    prescriptionDetail.ItemName = itemDetail.ItemDetailsName
                    prescriptionDetail.ItemCode = itemDetail.ItemDetailsCode
                    prescriptionDetail.GenericName = itemDetail.GenericName
                End With
            Else
                prescriptionDetail.ItemIdNo = ""
                prescriptionDetail.ItemName = ""
                AATM.Libraries.Messaging.MessagingService.Show(True, "Invalid ItemDetails Code!")
            End If
        End Sub

        Private Function GetItemDetailsCode(itemCode As String) As ItemDetailsModel
            Dim itemDetailsIdNo As Int32 = GetitemDetailsIdNo(itemCode)
            Dim itemDetails As ItemDetailsModel = _itemDetailsService.GetRecordByIdNo(Of ItemDetailsModel)(itemDetailsIdNo)
            Return itemDetails
        End Function

        Private Function GetitemDetailsIdNo(itemCode As String) As Int32
            Return GetRecordFieldWithKeyG(Of Int32)(itemCode, "ItemDetails", "Item_Code", "Primary_Key")
        End Function

        Private Sub UpdatePrintableLabels()
            For Each item As PrescriptionItemView In View.PrescriptionDetails
                If item.PrintLabel Then
                    MarkLabelAsPrintable(item)
                Else
                    MarkLabelAsNotPrintable(item)
                End If
            Next
        End Sub

        Private Sub OnGTinScanned(gTin As String, bs As BindingSource, ByRef productCode As String)
            Dim idNo As Int32 = GetRecordFieldWithKeyG(Of Int32)(gTin, "ItemDetails", "GTin", "Primary_Key")
            Dim purchaseDetail As PurchaseDetailView = bs.Current
            Dim itemDetailsModel As ItemDetailsModel = _prescriptionItemService.GetRecordByIdNo(Of ItemDetailsModel)(idNo)
            productCode = itemDetailsModel.ItemDetailsCode
            OnItemCodeChanged(productCode, bs)
        End Sub

        Private Sub MarkLabelAsPrintable(item As PrescriptionItemView)
            _prescriptionItemService.GenericUpdateRecordWithIdNo(Of Boolean)(item.PrescriptionItemIdNo, "PMRMedicineDetails", "LabelPrinted", False)
        End Sub

        Private Sub MarkLabelAsNotPrintable(item As PrescriptionItemView)
            _prescriptionItemService.GenericUpdateRecordWithIdNo(Of Boolean)(item.PrescriptionItemIdNo, "PMRMedicineDetails", "LabelPrinted", True)
        End Sub

        Private Sub CreateLabels()
            _labelIdNo = Service.GetField(Of Int32, String)(_computerName, "DosageLabel", "ComputerName", "IdNo")
            Dim retVal As Int32
            If _labelIdNo > 0 Then
                retVal = Service.DeleteRecords(Of Int32)(_labelIdNo, "DosageLabelDetail", "DosageLabelIdNo")
                If retVal >= 0 Then
                    retVal = Service.DeleteRecord(Of Int32)(_labelIdNo, "DosageLabel", "IdNo")
                End If
            End If

            Service.InsertRecord("DosageLabel", {"ComputerName", "PrescriptionIdNo", "PatientName", "FileNo", "Age", "AgeYmd", "Gender", "DoctorName"},
                                                {"String", "Integer", "String", "Integer", "Integer", "String", "String", "String"},
                                                {_computerName, View.TransKey, View.PatientName, View.FileNo, Val(View.Age), View.AgeYmd, Left(View.Gender, 1), View.DoctorName})
            _labelIdNo = Service.GetField(Of Int32, String)(_computerName, "DosageLabel", "ComputerName", "IdNo")
            For Each item As PrescriptionItemView In View.PrescriptionDetails
                If item.PrintLabel Then
                    Dim itemName As String
                    Dim duration As String = IIf(item.Duration Is Nothing OrElse item.Duration = "", "", " for " & item.Duration)
                    Dim dosage As String = IIf(item.Dosage Is Nothing, "", item.Dosage.Trim()) + duration
                    Dim durationArabic As String = ""
                    Dim dosageAra As String
                    If duration = "" Then
                        durationArabic = ""
                    Else
                        durationArabic = " ل " + Service.GetField(Of String, String)(item.Duration, "PMRQtyDays", "DescriptionEnglish", "DescriptionArabic")
                    End If
                    Dim doseAra As String = Service.GetField(Of String, String)(item.Dosage, "MedicineDosageMaster", "ItemNameEnglish", "ItemNameArabic")
                    If doseAra Is Nothing OrElse doseAra = "" Then
                        dosageAra = item.Dosage.Trim() + " " + durationArabic
                    Else
                        dosageAra = doseAra + " " + durationArabic
                    End If
                    If item.GenericName Is Nothing OrElse item.GenericName = "" Then
                        itemName = item.ItemName
                    Else
                        itemName = item.GenericName.Trim() + " (" + item.ItemName.Trim() + ")"
                    End If
                    Service.InsertRecord("DosageLabelDetail", {"DosageLabelIdNo", "ItemName", "Dosage", "DosageAra"},
                                                          {"Integer", "String", "String", "String"},
                                                          {_labelIdNo, itemName, dosage, dosageAra})
                End If
            Next
        End Sub

        'Protected Overrides Sub CreateDataSources()
        '    Service.SaveConnectionString()
        '    Service.SetConnectionString($"ISPDATA")
        '    Service.RestoreConnectionString()
        'End Sub

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
            prescriptionDetails = _prescriptionItemService.GetRecordsWithGroupIdNo(Of PrescriptionItemModel)(transKey)
            GlobalVariables.Mapper.Map(prescriptionDetails, View.PrescriptionDetails)
        End Sub

    End Class

End Namespace