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
            Dim printJobIdNo = Presenter.GetRecordField(fileName)
            SetPrintOption(printJobIdNo)
            ProcessReport()

        End Sub

        Public Sub SetPrintOption(printJobIdNo As Int32)
            If printJobIdNo > 0 Then
                Dim computerName = Environment.MachineName
                Dim computerIdNo = Presenter.GetComputerIdNo()
                Report.PrintOptions.PrinterName = "Ad"
                'Report.PrintOptions.PaperSize = 257
                Report.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
                Report.PrintOptions.PaperSource = PaperSource.Auto
            End If
        End Sub

        Public Function GetPrintJobIdNo(reportFileName As String) As Int32
            Dim searchValue As String = reportFileName
            Dim tableName As String = "ReportFile"
            Dim searchFieldName As String = "ReportFileName"
            Dim returnFieldName As String = "PrintJobIdNo"
            Return Presenter.GetField(reportFileName, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetPrintSetupIdNo(computerName As String, printJobIdNo As Int32) As Int32
            Dim searchValue As String = ReportFileName
            Dim tableName As String = "ReportFile"
            Dim searchFieldName As String = "ReportFileName"
            Dim returnFieldName As String = "PrintJobIdNo"
            Return Presenter.GetField(ReportFileName, tableName, searchFieldName, returnFieldName)
        End Function


        Public Function GetComputerIdNo(computerName As String, printJobIdNo As Int32) As Int32
            Dim searchValue As String = Environment.MachineName
            Dim tableName As String = "ReportFile"
            Dim searchFieldName As String = "ReportFileName"
            Dim returnFieldName As String = "PrintJobIdNo"
            Return Presenter.GetField(searchValue, "Compuer", searchFieldName, returnFieldName)
        End Function


        Public Property MainTableName As String

    End Class

End Namespace