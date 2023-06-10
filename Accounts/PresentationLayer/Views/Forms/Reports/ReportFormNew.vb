Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports CrystalDecisions.Shared

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ReportFormNew

        Public Sub New(ByVal fileName As String, ByVal reportTitle As String, formCulture As CultureInfo, ByVal ParamArray args() As Object)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Text = fileName
            ReportFileName = fileName
            MainTableName = "Account"
            GetReportProperties()
            Dim language As String
            Dim establishmentName As String
            Presenter = New ReportPresenter(Me)
            language = Strings.Left(formCulture.Name, formCulture.Name.IndexOf("-", StringComparison.Ordinal))
            If language <> "ar" Then
                establishmentName = Presenter.GetRecordField("Establishment", "EstablishmentName")
            Else
                establishmentName = Presenter.GetRecordField("Establishment", "EstablishmentNameAra")
            End If

            For i = 0 To args.Length - 1 Step 2
                Dim value As Object = args(i)
                Report.SetParameterValue(args(i + 1).ToString(), ConvertObjectToType(value))
            Next
            Report.SetParameterValue("ReportTitle", reportTitle)
            Report.SetParameterValue("EstablishmentName", establishmentName)
            Report.SetParameterValue("Language", language)
            Report.DataSourceConnections.Clear()
            SetPrintOption(fileName)
            ProcessReport()

        End Sub

        Public Sub SetPrintOption(reportFileName As String)

            Dim computerName As String = Environment.MachineName
            Dim computerIdNo As Int16 = GetComputerIdNo(computerName)
            Dim printJobIdNo As Int16 = GetPrintJobIdNo(reportFileName)
            Dim printSetup As Object = GetPrintSetupObject(computerIdNo, printJobIdNo)

            Report.PrintOptions.PrinterName = GetPrinterName(printSetup.PrinterIdNo)
            Report.PrintOptions.PaperSize = GetPaperSize(printSetup.PaperSizeIdNo)
            Report.PrintOptions.PaperOrientation = GetPaperOrientation(printSetup.PaperOrientation)
            Report.PrintOptions.PaperSource = GetPaperSource(printSetup.PaperOrientation)

        End Sub

        Public Function GetPrintJobIdNo(reportFileName As String) As Int32
            Dim searchValue As String = reportFileName
            Dim tableName As String = "ReportFile"
            Dim searchFieldName As String = "ReportFileName"
            Dim returnFieldName As String = "PrintJobIdNo"
            Return Presenter.GetField(reportFileName, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetPrintSetupIdNo(computerIdNo As Int16, printJobIdNo As Int32) As Int32
            Dim searchValue As String = ReportFileName
            Dim tableName As String = "ReportFile"
            Dim searchFieldName As String = "ReportFileName"
            Dim returnFieldName As String = "PrintJobIdNo"
            Return Presenter.GetField(ReportFileName, tableName, searchFieldName, returnFieldName)
        End Function


        Public Function GetComputerIdNo(computerName As String) As Int16
            Dim searchValue As String = Environment.MachineName
            Dim tableName As String = "Computer"
            Dim searchFieldName As String = "ComputerName"
            Dim returnFieldName As String = "IdNo"
            Return Presenter.GetField(searchValue, "Computer", searchFieldName, returnFieldName)
        End Function

        Public Function GetPrintSetupIdNo(computerIdNo As Int16, printJobIdNo As Int16) As Int16
            Dim searchValue1 As Int16 = computerIdNo
            Dim searchValue2 As Int16 = printJobIdNo
            Dim tableName As String = "PrintSetup"
            Dim searchFieldName1 As String = "ComputerIdNo"
            Dim searchFieldName2 As String = "PrintJobIdNo"
            Dim returnFieldName As String = "IdNo"
            Dim printSetupIdNo As Int32 = Presenter.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2, returnFieldName)
            Return Presenter.GetPrintSetupObject(printSetupIdNo, tableName, "PrinterIdNo,PaperSource,PaperOrientation,PaperSize")
        End Function

        Public Function GetPrintSetupObject(computerIdNo As Int16, printJobIdNo As Int16) As Object
            Dim printSetupIdNo As Int16 = GetPrintSetupIdNo(computerIdNo, printJobIdNo)
            Return Presenter.GetFieldsWithIdNo(printSetupIdNo, "PrintSetup", "PrinterIdNo,PaperSource,PaperOrientation,PaperSize", "IdNo")
        End Function


        Public Property MainTableName As String

    End Class

End Namespace