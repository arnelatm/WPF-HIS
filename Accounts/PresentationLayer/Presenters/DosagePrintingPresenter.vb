Imports System.Dynamic
Imports AATM.Accounts.BusinessLayer
Imports System.IO
Imports System.Security.AccessControl
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
Imports System.Net.WebRequestMethods
Imports System.Data.Entity.Design.PluralizationServices
Imports System.Globalization

Namespace PresentationLayer.Presenters

    Public Class DosagePrintingPresenter(Of TM As New)
        Inherits CommonPresenter(Of IDosagePrintingView, TM)
        Implements ISubscriber(Of PrintCrEventArgs)

        'Implements IPrintReport


        'Public Event PrintReport As IPrintReport.PrintReportEventHandler Implements IPrintReport.PrintReport
        Private _igService As Object
        Private _labelIdNo As Int32
        Private _computerName As String

        Public Sub New(itemView As IDosagePrintingView)
            MyBase.New(itemView)
            Service = New AccountsService("DosagePrinting")
            _igService = New AccountsService("DrugSale")
            TableName = "Dosage_View"
            TableBaseName = "Dosage"
            TreeViewMainField = "DosageName"
            SortOrderKey = "DosageName"
            WithTreeView = True
            _computerName = Environment.MachineName
            AddHandler View.AddNewDosage, AddressOf OnAddNewDosage
            AddHandler View.UpdateTree, AddressOf OnUpdateTree
            AddHandler View.FindPatient, AddressOf OnFindPatient
            AddHandler View.ItemCodeChanged, AddressOf OnItemCodeChanged
            AddHandler View.ItemNameChanged, AddressOf OnItemNameChanged
            AddHandler View.BarCodeChanged, AddressOf OnBarCodeChanged
            AddHandler View.GTinChanged, AddressOf OnGTinChanged
        End Sub

        Private Sub OnFindPatient()
            Dim patientType As String = Service.GetRecordFieldWithKeyG(Of String, Int32)(View.PatientType, "ItemCode", "IdNo", "ItemCodeName")
            Dim filter As String = "RegistrationNo = " + View.FileNo.ToString() + " and PatientType = '" & patientType & "'"
            Dim patient As Object = New ExpandoObject
            patient = _igService.GetRecordFieldsFiltered("PatientDetails", "PatientNameEnglish,Age,AgeYMD,Sex", filter)
            If patient Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show("No Such Patient with that File number and type found on file.")
            Else
                View.PatientName = patient.PatientNameEnglish
                View.Age = patient.Age
                View.AgeDMY = patient.AgeYmd
                View.Gender = patient.Sex
            End If
        End Sub

        Private Sub OnItemCodeChanged()
            Dim filter As String = "ItemCode = '" + View.ItemCode.Trim() + "'"
            Dim medicine As Object = New ExpandoObject
            medicine = _igService.GetRecordFieldsFiltered("Medicines_View", "IdNo,ItemName,GenericName,GTin,BarCode", filter)
            If medicine Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show("No Such medicine with that item code on file.")
            Else
                View.ItemIdNo = IIf(IsDBNull(medicine.IdNo), 0, medicine.IdNo)
                View.GenericName = IIf(IsDBNull(medicine.GenericName), "", medicine.GenericName)
                View.GTin = IIf(IsDBNull(medicine.GTin), "", medicine.GTin)
                View.BarCode = IIf(IsDBNull(medicine.BarCode), "", medicine.BarCode)
                View.ItemName = IIf(IsDBNull(medicine.ItemName), "", medicine.ItemName)
            End If
        End Sub

        Private Sub OnBarCodeChanged(cBarCode)
            Dim filter As String = "BarCode = '" + cBarCode.Trim() + "'"
            Dim medicine As Object = New ExpandoObject
            medicine = _igService.GetRecordFieldsFiltered("Medicines_View", "IdNo,ItemName,GenericName,GTin,ItemCode", filter)
            If medicine Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show("No Such medicine with that Barcode on file.")
            Else
                View.ItemIdNo = IIf(IsDBNull(medicine.IdNo), 0, medicine.IdNo)
                View.ItemName = IIf(IsDBNull(medicine.ItemName), "", medicine.ItemName)
                View.ItemCode = IIf(IsDBNull(medicine.ItemCode), "", medicine.ItemCode)
                View.GenericName = IIf(IsDBNull(medicine.GenericName), "", medicine.GenericName)
                View.GTin = IIf(IsDBNull(medicine.GTin), "", medicine.GTin)
            End If
        End Sub


        Private Sub OnGTinChanged(cGTin)
            Dim filter As String = "GTin = '" + cGTin + "'"
            Dim medicine As Object = New ExpandoObject
            medicine = _igService.GetRecordFieldsFiltered("Medicines_View", "IdNo,ItemName,GenericName,BarCode,ItemCode", filter)
            If medicine Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show("No Such medicine with that GTin on file.")
            Else
                View.ItemIdNo = IIf(IsDBNull(medicine.IdNo), 0, medicine.IdNo)
                View.ItemName = IIf(IsDBNull(medicine.ItemName), "", medicine.ItemName)
                View.ItemCode = IIf(IsDBNull(medicine.ItemCode), "", medicine.ItemCode)
                View.GenericName = IIf(IsDBNull(medicine.GenericName), "", medicine.GenericName)
                View.BarCode = IIf(IsDBNull(medicine.BarCode), "", medicine.BarCode)
            End If
        End Sub


        Private Sub OnItemNameChanged(idNo As Int32)
            Dim filter As String = "IdNo = " + idNo.ToString()
            Dim medicine As Object = New ExpandoObject
            medicine = _igService.GetRecordFieldsFiltered("Medicines_View", "ItemName,ItemCode,GenericName,GTin,BarCode", filter)
            If medicine Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show("No Such medicine with that item code on file.")
            Else
                View.ItemCode = IIf(IsDBNull(medicine.ItemCode), "", medicine.ItemCode)
                View.GenericName = IIf(IsDBNull(medicine.GenericName), "", medicine.GenericName)
                View.GTin = IIf(IsDBNull(medicine.GTin), "", medicine.GTin)
                View.BarCode = IIf(IsDBNull(medicine.BarCode), "", medicine.BarCode)
                View.ItemName = IIf(IsDBNull(medicine.ItemName), "", medicine.ItemName)
            End If
        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"ItemCode", "DurationUnit", Nothing, "CodeGroupIdNo=12"})
            data.Add({"ItemCode", "DoseUnit", Nothing, "CodeGroupIdNo=7"})
            data.Add({"ItemCode", "PatientType", Nothing, "CodeGroupIdNo=15"})
            Service.SetConnectionString("ISPDATA")
            CreateDataSourceThread(data)
            Dim data2 As New ArrayList
            'data2.Add({"Medicines_View", "ItemName", "IdNo,ItemName,ItemCode", Nothing, "ItemName"})
            data2.Add({"ItemDetails", "ItemIdNo", "Primary_Key,ItemNameEnglish,Item_Code", Nothing, "ItemNameEnglish"})
            Service.SetConnectionString("IGroupClinic")
            CreateDataSourceThread(data2)
            'Restore connection String
            Service.SetConnectionString("ISPDATA")
            CreateEnumDataSource(Of MaleFemaleSelection)("Gender")
            CreateEnumDataSource(Of YearMonthDaySelection)("AgeYmd")
            Dim viewIdNo As Int32 = GetRecordFieldWithKey("DosagePrintingForm", "SystemView", "SystemViewName", "IdNo")
            View.DefaultDoseUnit = Service.GetRecordFieldWith2KeyG(Of Int16, String, Int16)(viewIdNo, "DoseUnit", "DefaultFieldValue", "SystemViewIdNo", "FieldName", "DefaultValue")
            View.DefaultDurationUnit = Service.GetRecordFieldWith2KeyG(Of Int16, String, Int16)(viewIdNo, "DurationUnit", "DefaultFieldValue", "SystemViewIdNo", "FieldName", "DefaultValue")
        End Sub

        Public Overrides Sub GoPrintRecord()

            CreateLabels()

            Dim printModel As New ReportModel
            Dim reportPrinter As New PrintReportPresenter(Of ReportModel)
            reportPrinter.OnPrintReport("DosageLabel.Rpt", "ISPDATA", {_labelIdNo, "LabelIdNo"})


            'Dim qtyDescription As String = IIf(View.Dose <> 0, GlobalFunctions.NumberToWordEnglish(View.Dose, False).ToLower() + Trim(GetRecordFieldWithKeyG(Of String)(View.DoseUnit, "ItemCode", "IdNo", "ItemCodeName")) + IIf(View.Dose > 1, "s", ""), "")
            'Dim duration As String = IIf(View.Duration <> 0, " for " + GlobalFunctions.NumberToWordEnglish(View.Duration).ToLower() + " " + Trim(GetRecordFieldWithKeyG(Of String)(View.DurationUnit, "ItemCode", "IdNo", "ItemCodeName")) + IIf(View.Dose > 1, "s", ""), "")
            'Dim args As Object = {View.IdNo, "IdNo", qtyDescription, "QtyDescription", duration, "Duration"}
            'Ea.PublishEvent(New PrintCrEventArgs("DosageLabel.Rpt", "ISPDATA", args, 1))

        End Sub

        Public Sub OnEventHandler(ByRef eventType As PrintCrEventArgs) Implements ISubscriber(Of PrintCrEventArgs).OnEventHandler
            Dim printModel As New ReportModel
            Dim reportPrinter As New PrintReportPresenter(Of ReportModel)
            reportPrinter.OnPrintReport("DosageLabel.Rpt", "IGROUPCLINIC", {_labelIdNo, "LabelIdNo"})
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

        'Public Sub OnPrintReportEventHandler(ByRef eventType As PrintCrEventArgs) Implements ISubscriber(Of PrintCrEventArgs).OnEventHandler

        '    CreateLabels()

        '    'Dim printModel As New ReportModel
        '    'Dim reportPrinter As New PrintReportPresenter(Of ReportModel)
        '    'reportPrinter.OnPrintReport("DosageLabel.Rpt", "IGROUPCLINIC", {_labelIdNo, "LabelIdNo"})

        'End Sub


        Private Sub CreateLabels()
            _labelIdNo = Service.GetField(Of Int32, String)(_computerName, "DosageLabel", "ComputerName", "IdNo")
            Dim retVal As Int32
            If _labelIdNo > 0 Then
                retVal = Service.DeleteRecords(Of Int32)(_labelIdNo, "DosageLabelDetail", "DosageLabelIdNo")
                If retVal >= 0 Then
                    retVal = Service.DeleteRecord(Of Int32)(_labelIdNo, "DosageLabel", "IdNo")
                End If
            End If
            Dim ageDMY As String
            If Val(View.Age) > 1 Then
                Dim dmy As String = CodeToEnum(Of YearMonthDaySelection)(View.AgeDMY)
                'PluralizationService.Pluralize()
            End If


            Service.InsertRecord("DosageLabel", {"ComputerName", "PrescriptionIdNo", "PatientName", "FileNo", "Age", "AgeYmd", "Gender", "DoctorName"},
                                                {"String", "Integer", "String", "Integer", "Integer", "String", "String", "String"},
                                                {_computerName, 0, View.PatientName, View.FileNo, Val(View.Age), View.AgeDMY, Left(View.Gender, 1), ""})
            _labelIdNo = Service.GetField(Of Int32, String)(_computerName, "DosageLabel", "ComputerName", "IdNo")

            Dim dose As String
            Dim doseArabic As String
            Dim doseUnit As String
            Dim doseUnitArabic As String
            Dim durationUnit As String
            Dim durationUnitArabic As String
            Dim duration As String
            Dim durationArabic As String

            Dim ps As PluralizationService = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"))
            ''check if the supplied word is plural
            'Dim isPlural = ps.IsPlural("mangoes")
            ''true
            ''check if the supplied word is singular
            'Dim isSingular = ps.IsSingular("mangoe")
            ''true
            ''change a singular word to plural
            'Dim pluralWord = ps.Pluralize("boy")
            ''result: boys

            If View.Dose = 0 Then
                dose = ""
                doseArabic = ""
            Else
                If View.Dose - CInt(View.Dose) > 0 Then
                    dose = View.Dose.ToString() + " " + View.DoseUnit
                    doseArabic = dose
                Else
                    dose = GlobalFunctions.NumberToWordEnglish(CInt(View.Dose))
                    doseArabic = New ToWord(CInt(View.Dose)).ConvertToArabic()
                End If
            End If

            If View.DoseUnit = 0 Then
                doseUnit = ""
                doseUnitArabic = ""
            Else
                doseUnit = Service.GetField(Of String, Int32)(View.DoseUnit, "ItemCode", "IdNo", "ItemCodeName")
                If View.Dose > 1 Then
                    doseUnit = ps.Pluralize(doseUnit)
                End If
                doseUnitArabic = Service.GetField(Of String, Int32)(View.DoseUnit, "ItemCode", "IdNo", "ItemCodeNameAra")
            End If

            If View.Duration = 0 Then
                duration = ""
                durationArabic = ""
            Else
                If View.Duration - CInt(View.Duration) > 0 Then
                    duration = " for " & View.Duration.ToString() + View.DurationUnit
                    durationArabic = " ل " + View.Duration.ToString() + View.DurationUnit
                Else
                    duration = " for " & GlobalFunctions.NumberToWordEnglish(CInt(View.Duration)).ToLower()
                    durationArabic = New ToWord(CInt(View.Duration)).ConvertToArabic()
                End If
            End If

            If View.DurationUnit = 0 Then
                durationUnit = ""
                durationUnitArabic = ""
            Else
                durationUnit = Service.GetField(Of String, Int32)(View.DurationUnit, "ItemCode", "IdNo", "ItemCodeName")
                durationUnitArabic = Service.GetField(Of String, Int32)(View.DurationUnit, "ItemCode", "IdNo", "ItemCodeNameAra")
                If View.Duration > 1 Then
                    durationUnit = ps.Pluralize(durationUnit)
                End If
            End If

            Dim dosage As String
            Dim dosageArabic As String
            dosage = IIf(dose.Trim() = "", "", dose.Trim() + "(" + View.Dose.ToString().Trim() + ")" + " ") + IIf(doseUnit.Trim() = "", "", doseUnit.Trim() + " ") + View.DosageName.Trim() + " " + IIf(duration.Trim() = "", "", duration.Trim() + "(" + View.Duration.ToString() + ")" + " ") + durationUnit.Trim()
            dosageArabic = IIf(doseArabic.Trim() = "", "", doseArabic.Trim() + "(" + View.Dose.ToString().Trim() + ")" + " ") + IIf(doseUnitArabic.Trim() = "", "", doseUnitArabic.Trim() + " ") + View.DosageNameAra.Trim() + " " + IIf(durationArabic.Trim() = "", "", durationArabic.Trim() + "(" + View.Duration.ToString().Trim() + ")" + " ") + durationUnitArabic.Trim()

            Dim itemName As String = ""
            If View.GenericName Is Nothing OrElse View.GenericName = "" Then
                itemName = View.ItemName
            Else
                itemName = View.GenericName.Trim() + " (" + View.ItemName.Trim() + ")"
            End If

            Service.InsertRecord("DosageLabelDetail", {"DosageLabelIdNo", "ItemName", "Dosage", "DosageAra"},
                                                  {"Integer", "String", "String", "String"},
                                                  {_labelIdNo, itemName, dosage.ToLower(), dosageArabic})


        End Sub


        Private _savedDose As Decimal
        Private _savedDuration As Decimal
        Private _savedFileNo As String
        Private _savedGenericName As String
        Private _savedGTin As String
        Private _savedItemCode As String
        Private _savedItemName As String
        Private _savedPatientName As String
        Private _savedAge As Int16
        Private _savedAgeDmy As String
        Private _savedPatientType As Int16
        Private _savedGender As String

        Public Sub OnBeforeChangeRecord() Handles MyBase.BeforeChangeRecord
            _savedDose = View.Dose
            _savedDuration = View.Duration
            _savedFileNo = View.FileNo
            _savedGenericName = View.GenericName
            _savedGTin = View.GTin
            _savedItemCode = View.ItemCode
            _savedItemName = View.ItemName
            _savedPatientName = View.PatientName
            _savedFileNo = View.FileNo
            _savedAge = View.Age
            _savedAgeDmy = View.AgeDMY
            _savedPatientType = View.PatientType
            _savedGender = View.Gender
        End Sub
        Public Sub OnAfterChangeRecord() Handles MyBase.AfterChangeRecord
            View.Dose = _savedDose
            View.Duration = _savedDuration
            View.FileNo = _savedFileNo
            View.GenericName = _savedGenericName
            View.GTin = _savedGTin
            View.ItemCode = _savedItemCode
            View.ItemName = _savedItemName
            View.PatientName = _savedPatientName
            View.Age = _savedAge
            View.AgeDMY = _savedAgeDmy
            View.PatientType = _savedPatientType
            View.Gender = _savedGender
        End Sub



        'Public Sub OnEventHandler(ByRef eventType As PrintCrEventArgs) Implements ISubscriber(Of PrintCrEventArgs).OnEventHandler
        '    Throw New NotImplementedException()
        'End Sub

    End Class

End Namespace