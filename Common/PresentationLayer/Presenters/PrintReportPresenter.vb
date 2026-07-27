Imports System.Collections.Generic
Imports System.Data.Entity.Design.PluralizationServices
Imports System.Dynamic
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Common.Models
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Forms
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class PrintReportPresenter(Of TM As New)
        Inherits CommonPresenter(Of ICrPrintableReportView, TM)
        Implements ISubscriber(Of GetControlDataSource)
        'Implements ISubscriber(Of GetControlEnumDataSource)
        Implements ISubscriber(Of GetLookupDataTableRequested)
        Implements ISubscriber(Of OtherData)

        Private _psService As Object
        Private _pjService As Object
        Private _prService As Object
        Private _presenter As CommonPresenter(Of IView, ReportModel)
        Private _computerName As String
        Private _computerIdNo As Int16

        Public Sub New()
            MakeServices()
            _computerName = Environment.MachineName      ' "Pharmacy" '
            _computerIdNo = _psService.GetRecordFieldWithKeyG(Of Int16)(_computerName, "Computer", "ComputerName", "IdNo")

        End Sub

        Public Sub New(view As ICrPrintableReportView)
            MyBase.New(view)
            MakeServices()
            AddHandler view.PrintReport, AddressOf OnPrintCrystalReport
            'AddHandler view.CreateDataSourceEnum, AddressOf OnCreateDataSourceEnum
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Private Sub MakeServices()
            Service = New CommonService("Report")
            _pjService = New CommonService("PrintJob")
            _psService = New CommonService("PrintSetup")
            _prService = New CommonService("Printer")
        End Sub

        Public Sub OnPrintReport(reportFileName As String, databaseConnectionName As String, Optional args() As Object = Nothing, Optional copies As Integer = 1, Optional collate As Boolean = False, Optional startPage As Integer = 0, Optional endPage As Integer = 0)
            ' leave startpage and endpage to 0 - to print all pages
            ProcessReport(reportFileName, databaseConnectionName, True, args, copies, collate, startPage, endPage)
        End Sub

        Private Function GetPrintSetupIdNo(reportFileName As String, printJobIdNo As Int16) As Int16
            Return _psService.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(printJobIdNo, _computerIdNo, "PrintSetup", "PrintJobIdNo", "ComputerIdNo", "IdNo")
        End Function

        Private Function GetPrintJobIdNo(reportFileName) As Int16
            Return _psService.GetRecordFieldWithKeyG(Of Int16, String)(reportFileName, "Report", "ReportFileName", "PrintJobIdNo")
        End Function

        Public Sub ProcessReport(reportFileName As String, printArgs As CrPrintableArgs, printDirectly As Boolean, Optional addDefaultParameters As Boolean = False)
            ApplyPromptSettingsFromReportTable(reportFileName, printArgs)

            Dim crReport As CrystalReportPrinter
            crReport = GetPrinterSetup(reportFileName, printArgs.DataBaseConnectionName, printArgs.ReportParameters)
            If printDirectly Then
                crReport.PrintReport(printArgs.Copies, printArgs.Collate, printArgs.StartPage, printArgs.EndPage)
            Else
                Dim crViewer As New CrViewer(reportFileName, printArgs, addDefaultParameters, crReport)
                ShowReportViewer(crViewer, reportFileName, printArgs, addDefaultParameters)
            End If
        End Sub


        Public Sub ProcessReport(reportFileName As String, databaseConnectionName As String, printDirectly As Boolean, Optional args() As Object = Nothing, Optional copies As Integer = 1, Optional collate As Boolean = False, Optional startPage As Integer = 0, Optional endPage As Integer = 0)
            ' leave startPage & endPage to 0 to print all pages
            Dim crReport As CrystalReportPrinter
            If printDirectly Then
                crReport = GetPrinterSetup(reportFileName, databaseConnectionName, args)
                crReport.PrintReport(copies, collate, startPage, endPage)
            Else
                crReport = GetPrinterSetup(reportFileName, databaseConnectionName, args)
                Dim reportArgs As New CrPrintableArgs
                reportArgs.ReportTitle = reportFileName
                reportArgs.Copies = copies
                reportArgs.StartPage = startPage
                reportArgs.EndPage = endPage
                reportArgs.ReportParameters = args
                reportArgs.CultureInfo = CultureInfo.CurrentCulture.Name
                reportArgs.DataBaseConnectionName = databaseConnectionName
                ApplyPromptSettingsFromReportTable(reportFileName, reportArgs)
                ViewReport(reportFileName, reportArgs)
            End If
        End Sub

        Private Sub ShowReportViewer(crViewer As CrViewer, reportFileName As String, reportArgs As CrPrintableArgs, addDefaultParameters As Boolean)
            If ShouldRepeatPromptAfterClose(reportArgs) Then
                AddHandler crViewer.FormClosed,
                    Sub(sender, e)
                        Dim repeat = MessageBox.Show(
                            "Run this report again with different prompted parameters?",
                            "Run Report Again",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question)

                        If repeat = DialogResult.Yes Then
                            ProcessReport(reportFileName, reportArgs, False, addDefaultParameters)
                        End If
                    End Sub
            End If

            crViewer.Show()
        End Sub

        Private Shared Function ShouldRepeatPromptAfterClose(reportArgs As CrPrintableArgs) As Boolean
            Return reportArgs IsNot Nothing AndAlso
                   reportArgs.RepeatPromptAfterClose AndAlso
                   reportArgs.PromptParameterNames IsNot Nothing AndAlso
                   reportArgs.PromptParameterNames.Length > 0
        End Function

        Private Sub ApplyPromptSettingsFromReportTable(reportFileName As String, reportArgs As CrPrintableArgs)
            If reportArgs Is Nothing Then
                Return
            End If

            If reportArgs.PromptParameterNames Is Nothing OrElse reportArgs.PromptParameterNames.Length = 0 Then
                Dim promptParameterNames As String = GetPromptParameterNamesFromReportTable(reportFileName)
                reportArgs.PromptParameterNames = SplitPromptParameterNames(promptParameterNames)
            End If

            If Not reportArgs.RepeatPromptAfterClose Then
                reportArgs.RepeatPromptAfterClose = GetRepeatPromptAfterCloseFromReportTable(reportFileName)
            End If
        End Sub

        Private Function GetPromptParameterNamesFromReportTable(reportFileName As String) As String
            For Each lookupReportFileName As String In GetReportFileNameLookupKeys(reportFileName)
                Dim promptParameterNames As String = GetPromptParameterNames(lookupReportFileName)

                If Not String.IsNullOrWhiteSpace(promptParameterNames) Then
                    Return promptParameterNames
                End If
            Next

            Return Nothing
        End Function

        Private Function GetRepeatPromptAfterCloseFromReportTable(reportFileName As String) As Boolean
            For Each lookupReportFileName As String In GetReportFileNameLookupKeys(reportFileName)
                Dim repeatPromptAfterClose As Boolean

                If TryGetRepeatPromptAfterClose(lookupReportFileName, repeatPromptAfterClose) Then
                    Return repeatPromptAfterClose
                End If
            Next

            Return False
        End Function

        Private Function GetPromptParameterNames(reportFileName As String) As String
            If String.IsNullOrWhiteSpace(reportFileName) Then
                Return Nothing
            End If

            Try
                Return _psService.GetRecordFieldWithKeyG(Of String, String)(reportFileName, "Report", "ReportFileName", "PromptParameterNames")
            Catch
                Return Nothing
            End Try
        End Function

        Private Function TryGetRepeatPromptAfterClose(reportFileName As String, ByRef repeatPromptAfterClose As Boolean) As Boolean
            If String.IsNullOrWhiteSpace(reportFileName) Then
                Return False
            End If

            Try
                Dim matchedReportFileName As String =
                    _psService.GetRecordFieldWithKeyG(Of String, String)(reportFileName, "Report", "ReportFileName", "ReportFileName")

                If String.IsNullOrWhiteSpace(matchedReportFileName) Then
                    Return False
                End If

                repeatPromptAfterClose = GetRepeatPromptAfterClose(reportFileName)
                Return True
            Catch
                Return False
            End Try
        End Function

        Private Function GetRepeatPromptAfterClose(reportFileName As String) As Boolean
            If String.IsNullOrWhiteSpace(reportFileName) Then
                Return False
            End If

            Try
                Return _psService.GetRecordFieldWithKeyG(Of Boolean, String)(reportFileName, "Report", "ReportFileName", "RepeatPromptAfterClose")
            Catch
                Return False
            End Try
        End Function

        Private Shared Function GetReportFileNameLookupKeys(reportFileName As String) As IEnumerable(Of String)
            Dim lookupKeys As New List(Of String)

            AddReportFileNameLookupKey(lookupKeys, reportFileName)

            If String.IsNullOrWhiteSpace(reportFileName) Then
                Return lookupKeys
            End If

            Dim trimmedReportFileName As String = reportFileName.Trim()
            Dim fileNameOnly As String = trimmedReportFileName

            Try
                fileNameOnly = IO.Path.GetFileName(trimmedReportFileName)
            Catch
            End Try

            AddReportFileNameLookupKey(lookupKeys, fileNameOnly)

            If trimmedReportFileName.EndsWith(".rpt", StringComparison.OrdinalIgnoreCase) Then
                Try
                    AddReportFileNameLookupKey(lookupKeys, IO.Path.GetFileNameWithoutExtension(trimmedReportFileName))
                Catch
                End Try
            Else
                AddReportFileNameLookupKey(lookupKeys, trimmedReportFileName & ".rpt")

                If Not String.Equals(fileNameOnly, trimmedReportFileName, StringComparison.OrdinalIgnoreCase) Then
                    AddReportFileNameLookupKey(lookupKeys, fileNameOnly & ".rpt")
                End If
            End If

            Return lookupKeys
        End Function

        Private Shared Sub AddReportFileNameLookupKey(lookupKeys As List(Of String), lookupKey As String)
            If String.IsNullOrWhiteSpace(lookupKey) Then
                Return
            End If

            Dim normalizedLookupKey As String = lookupKey.Trim()

            For Each existingLookupKey As String In lookupKeys
                If String.Equals(existingLookupKey, normalizedLookupKey, StringComparison.OrdinalIgnoreCase) Then
                    Return
                End If
            Next

            lookupKeys.Add(normalizedLookupKey)
        End Sub

        Private Shared Function SplitPromptParameterNames(value As String) As String()
            If String.IsNullOrWhiteSpace(value) Then
                Return Nothing
            End If

            Return value.Split(New Char() {","c, ";"c, ControlChars.Cr, ControlChars.Lf}, StringSplitOptions.RemoveEmptyEntries).
                Select(Function(parameterName) parameterName.Trim()).
                Where(Function(parameterName) parameterName <> "").
                ToArray()
        End Function


        Private Function GetPrinterSetup(reportFileName As String, databaseConnectionName As String, args() As Object) As CrystalReportPrinter
            Dim crReport As New CrystalReportPrinter(reportFileName, databaseConnectionName, args)
            Dim printer As PrinterModel = Nothing
            Dim printJobIdNo As Int16 = GetPrintJobIdNo(reportFileName)
            Dim printSetupIdNo As Int16 = GetPrintSetupIdNo(reportFileName, printJobIdNo)
            Dim psModel As New PrintSetupModel
            If printSetupIdNo <> 0 Then
                psModel = _psService.GetRecordByIdNo(Of PrintSetupModel)(printSetupIdNo)
                If psModel IsNot Nothing Then
                    printer = _prService.GetRecordByIdNo(Of PrinterModel)(psModel.PrinterIdNo)
                    printer.PaperSize = IIf(psModel.PaperSize <> 0, psModel.PaperSize, printer.PaperSize)
                    printer.PaperOrientation = IIf(psModel.PaperOrientation <> 0, psModel.PaperOrientation, printer.PaperOrientation)
                    printer.PaperSource = IIf(psModel.PaperSource <> 0, psModel.PaperSource, printer.PaperSource)
                Else
                    Dim pjModel As New PrintJobModel
                    pjModel = _pjService.GetRecordByIdNo(Of PrintJobModel)(printJobIdNo)
                    If pjModel IsNot Nothing Then
                        printer = _prService.GetRecordByIdNo(Of PrinterModel)(pjModel.PrinterIdNo)
                        printer.PaperSize = IIf(pjModel.PaperSize <> 0, pjModel.PaperSize, printer.PaperSize)
                        printer.PaperOrientation = IIf(pjModel.PaperOrientation <> 0, pjModel.PaperOrientation, printer.PaperOrientation)
                        printer.PaperSource = IIf(pjModel.PaperSource <> 0, pjModel.PaperSource, printer.PaperSource)
                    Else
                        printer.PrinterName = Nothing
                    End If
                End If
            Else
                Dim pjModel As New PrintJobModel
                pjModel = _pjService.GetRecordByIdNo(Of PrintJobModel)(printJobIdNo)
                If pjModel.IdNo <> 0 Then
                    printer = _prService.GetRecordByIdNo(Of PrinterModel)(pjModel.PrinterIdNo)
                    printer.PaperSize = IIf(pjModel.PaperSize <> 0, pjModel.PaperSize, printer.PaperSize)
                    printer.PaperOrientation = IIf(pjModel.PaperOrientation <> 0, pjModel.PaperOrientation, printer.PaperOrientation)
                    printer.PaperSource = IIf(pjModel.PaperSource <> 0, pjModel.PaperSource, printer.PaperSource)
                End If
            End If
            If printer IsNot Nothing Then
                crReport.SetPrintOption(printer.PrinterName, printer.PaperSize, printer.PaperOrientation, printer.PaperSource)
            End If
            Return crReport
        End Function

        Private Function GetPrintJobIdNo(computerIdNo As Int16, printSetupIdNo As Integer) As Short
            Return GetService.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(computerIdNo, printSetupIdNo, "PrintJob", "ComputerIdNo", "PrintSetupIdNo", "IdNo")
        End Function

        Public Sub ViewReport(viewer As CrViewer, databaseConnectionName As String)
            ProcessReport(viewer.ReportPrinter.ReportFileName, databaseConnectionName, False)
        End Sub

        Public Function GetService1()
            Return _pjService
        End Function

        Public Sub OnGetControlDataSourceHandler(ByRef eventType As GetControlDataSource) Implements ISubscriber(Of GetControlDataSource).OnEventHandler
            MakeControlDataSources({New Object() {eventType.TableName, eventType.Control, eventType.FieldNames, eventType.Filter, eventType.SortOrder, eventType.Ascending, eventType.DisplayMember, eventType.ValueMember}})
        End Sub

        Public Sub OnOtherDataHandler(ByRef eventType As OtherData) Implements ISubscriber(Of OtherData).OnEventHandler
            If eventType.ReferenceName = "GetUnitDescription" Then
                Dim unitsIdNo As Object
                Dim baseUnitIdNo As Int16 = Service.GetRecordWithIdNo("Product", "BaseUnitIdNo", DirectCast(eventType.EventArgs, Int32)).BaseUnitIdNo
                Dim baseUnitName As String = Service.GetRecordWithIdNo("Unit", "UnitName", baseUnitIdNo).UnitName
                unitsIdNo = Service.GetRecords("ProductUnit", "BaseQty", {"IdNo"}, "ProductIdNo = " + eventType.EventArgs.ToString())
                eventType.ReturnArgs = "Base Unit Name = " & baseUnitName.Trim() + " "
                Dim ps As PluralizationService = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"))
                Dim nSeq As Int16 = 0
                For Each idNo In unitsIdNo
                    Dim units As Object = New ExpandoObject
                    Dim unitName As String
                    units = Service.GetRecordWithIdNo("ProductUnit", "BaseQty,UnitQty,UnitIdNo", idNo)
                    unitName = Service.GetRecordWithIdNo("Unit", "UnitName", units.UnitIdNo).UnitName
                    unitName = IIf(units.UnitQty < 2, ps.Singularize(unitName), ps.Pluralize(unitName))
                    baseUnitName = IIf(units.BaseQty < 2, ps.Singularize(baseUnitName), ps.Pluralize(baseUnitName))
                    nSeq = nSeq + 1
                    eventType.ReturnArgs = eventType.ReturnArgs + " : " + units.BaseQty.ToString() + " " + baseUnitName.Trim() + " = " + units.UnitQTy.ToString() + " " + unitName.Trim()
                Next
            End If
        End Sub
        Public Sub PrintReport(reportFileName As String, reportArgs As CrPrintableArgs, printDirectly As Boolean, Optional addDefaultParameters As Boolean = False)
            ' leave startpage and endpage to 0 - to print all pages
            ProcessReport(reportFileName, reportArgs, printDirectly, addDefaultParameters) 'rp.DataBaseConnectionName, True, rp.ReportParameters, rp.Copies, rp.Collate, rp.StartPage, rp.EndPage)
        End Sub

        Public Sub ViewReport(reportFileName As String, reportArgs As CrPrintableArgs, Optional AddDefaultParameters As Boolean = False)
            ProcessReport(reportFileName, reportArgs, False, AddDefaultParameters)
        End Sub

        Public Sub ViewReport(reportFileName As String, reportTitle As String, cFormCulture As CultureInfo, dbConnectionName As String, args As Object)
            Dim crViewerForm As New CrViewer(reportFileName, reportTitle, cFormCulture, args)
            crViewerForm.Show()
        End Sub

        Public Sub OnPrintCrystalReport(reportFileName As String, reportArgs As CrPrintableArgs, printDirectly As Boolean)
            If reportFileName Is Nothing Or reportFileName = "" Then
                Debugger.Break()
                MessageBox.Show("Crystal Report Printing - Empty Filename Error")
            End If
            PrintReport(reportFileName, reportArgs, printDirectly)
        End Sub

    End Class

End Namespace
