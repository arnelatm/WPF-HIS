Imports System.Dynamic
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class DosagePrintingPresenter(Of TM As New)
        Inherits CommonPresenter(Of IDosagePrintingView, TM)
        Implements ISubscriber(Of PrintCrEventArgs)

        'Implements IPrintReport


        'Public Event PrintReport As IPrintReport.PrintReportEventHandler Implements IPrintReport.PrintReport
        Private _drugSaleService As Object
        Private _labelIdNo As Int32
        Private _computerName As String

        Public Sub New(itemView As IDosagePrintingView)
            MyBase.New(itemView)
            Service = New AccountsService("DosagePrinting")
            _drugSaleService = New AccountsService("DrugSale")
            TableName = "Dosage_View"
            TableBaseName = "Dosage"
            TreeViewMainField = "DosageName"
            SortOrderKey = "DosageName"
            WithTreeView = True
            _computerName = Environment.MachineName
            AddHandler View.AddNewDosage, AddressOf OnAddNewDosage
            AddHandler View.UpdateTree, AddressOf OnUpdateTree
            AddHandler View.FindPatient, AddressOf OnFindPatient
        End Sub

        Private Sub OnFindPatient()
            Dim patientType As String = Service.GetRecordFieldWithKeyG(Of String, Int32)(View.PatientType, "ItemCode", "IdNo", "ItemCodeName")
            Dim filter As String = "RegistrationNo = " + View.FileNo.ToString() + " and PatientType = '" & patientType & "'"
            Dim patient As Object = New ExpandoObject
            patient = _drugSaleService.GetRecordFieldsFiltered("PatientDetails", "PatientNameEnglish,Age,AgeYMD,Sex", filter)
            If patient Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show("No Such Patient with that File number and type found on file.")
            Else
                View.PatientName = patient.PatientNameEnglish
                View.Age = patient.Age
                View.AgeDMY = patient.AgeYmd
                View.Gender = patient.Sex
            End If
        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"ItemCode", "DurationUnit", Nothing, "CodeGroupIdNo=12"})
            data.Add({"ItemCode", "DoseUnit", Nothing, "CodeGroupIdNo=7"})
            data.Add({"ItemCode", "PatientType", Nothing, "CodeGroupIdNo=15"})
            CreateDataSourceThread(data)
            CreateEnumDataSource(Of MaleFemaleSelection)("Gender")
            CreateEnumDataSource(Of YearMonthDaySelection)("AgeYmd")
            Dim viewIdNo As Int32 = GetRecordFieldWithKey("DosagePrintingForm", "SystemView", "SystemViewName", "IdNo")
            View.DefaultDoseUnit = Service.GetRecordFieldWith2KeyG(Of Int16, String, Int16)(viewIdNo, "DoseUnit", "DefaultFieldValue", "SystemViewIdNo", "FieldName", "DefaultValue")
            View.DefaultDurationUnit = Service.GetRecordFieldWith2KeyG(Of Int16, String, Int16)(viewIdNo, "DurationUnit", "DefaultFieldValue", "SystemViewIdNo", "FieldName", "DefaultValue")
        End Sub

        Public Overrides Sub GoPrintRecord()

            Dim qtyDescription As String = IIf(View.Dose <> 0, GlobalFunctions.NumberToWordEnglish(View.Dose, False).ToLower() + Trim(GetRecordFieldWithKeyG(Of String)(View.DoseUnit, "ItemCode", "IdNo", "ItemCodeName")) + IIf(View.Dose > 1, "s", ""), "")
            Dim duration As String = IIf(View.Duration <> 0, " for " + GlobalFunctions.NumberToWordEnglish(View.Duration).ToLower() + " " + Trim(GetRecordFieldWithKeyG(Of String)(View.DurationUnit, "ItemCode", "IdNo", "ItemCodeName")) + IIf(View.Dose > 1, "s", ""), "")
            Dim args As Object = {View.IdNo, "IdNo", qtyDescription, "QtyDescription", duration, "Duration"}
            Ea.PublishEvent(New PrintCrEventArgs("DosageLabel.Rpt", "ISPDATA", args, 1))

        End Sub


        Private Sub OnAddNewDosage()
            Dim formToRun = Activator.CreateInstance(GetType(DosageEntryTv))
            Dim pType As Type = GetType(DosagePresenter(Of DosageModel))
            formToRun.Presenter = Activator.CreateInstance(pType, {formToRun})
            formToRun.AddOnOpen = True
            formToRun.QuitOnSave = True
            formToRun.ShowDialog()
        End Sub

        Private Sub OnUpdateTree()
            Dim nIdNo As Int32 = GetFieldOnMaxField("IdNo", "Dosage", "IdNo")
            DisplayTree(nIdNo)
        End Sub

        Public Sub OnPrintReportEventHandler(ByRef eventType As PrintCrEventArgs) Implements ISubscriber(Of PrintCrEventArgs).OnEventHandler

            CreateLabels()

            'Dim printModel As New ReportModel
            'Dim reportPrinter As New PrintReportPresenter(Of ReportModel)
            'reportPrinter.OnPrintReport("DosageLabel.Rpt", "IGROUPCLINIC", {_labelIdNo, "LabelIdNo"})

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
                                                {_computerName, 0, View.PatientName, View.FileNo, Val(View.Age), View.AgeDMY, Left(View.Gender, 1), ""})
            _labelIdNo = Service.GetField(Of Int32, String)(_computerName, "DosageLabel", "ComputerName", "IdNo")

            Dim dose As String
            Dim doseArabic As String
            If View.Dose - CInt(View.Dose) > 0 Then
                dose = View.Dose.ToString() + " " + View.DoseUnit
                doseArabic = dose
            Else
                dose = GlobalFunctions.NumberToWordEnglish(CInt(View.Dose))
                doseArabic = ConvertWholeNumberToWord(CInt(View.Dose)) + " " + View.DoseUnit
            End If

            Dim duration As String
            Dim durationArabic As String
            If View.Duration - CInt(View.Duration) > 0 Then
                duration = " for " & View.Duration.ToString() + View.DurationUnit
                durationArabic = " ل " + View.Duration.ToString() + View.DurationUnit
            Else
                duration = " for " & GlobalFunctions.ConvertWholeNumberToWord(CInt(View.Duration)) + View.DurationUnit
                durationArabic = " ل " + GlobalFunctions.NumberToWordEnglish(CInt(View.Duration)) + " " + View.DurationUnit
            End If

            Dim dosage As String
            Dim dosageArabic As String
            dosage = dose + " " + View.DosageName.Trim() + " " + duration
            dosageArabic = doseArabic + View.DosageNameAra.Trim() + " " + durationArabic

            Dim itemName As String = ""
            'If View.item.GenericName Is Nothing OrElse item.GenericName = "" Then
            '    itemName = item.ItemName
            'Else
            '    itemName = item.GenericName.Trim() + " (" + item.ItemName.Trim() + ")"
            'End If

            Service.InsertRecord("DosageLabelDetail", {"DosageLabelIdNo", "ItemName", "Dosage", "DosageAra"},
                                                  {"Integer", "String", "String", "String"},
                                                  {_labelIdNo, itemName, dosage, dosageAra})


        End Sub

        'Public Sub OnEventHandler(ByRef eventType As PrintCrEventArgs) Implements ISubscriber(Of PrintCrEventArgs).OnEventHandler
        '    Throw New NotImplementedException()
        'End Sub

    End Class

End Namespace