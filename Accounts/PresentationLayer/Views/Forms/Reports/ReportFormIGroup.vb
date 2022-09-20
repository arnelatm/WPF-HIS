Imports System.Configuration
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports CrystalDecisions.Shared

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ReportFormIGroup

        Public Sub New(ByVal fileName As String, formCulture As CultureInfo, args As Object, Optional printJobName As String = Nothing)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Text = fileName
            ReportFileName = fileName
            MainTableName = "Account"
            GetIgroupReportProperties()
            Dim language As String
            language = Strings.Left(formCulture.Name, formCulture.Name.IndexOf("-", StringComparison.Ordinal))
            Presenter = New ReportPresenter(Me)
            If args IsNot Nothing AndAlso args.Count > 0 Then
                For i = 0 To args.Count() - 1
                    Dim parameterName As String = args(i)(0)
                    Dim parameterValue = args(i)(1)
                    Report.SetParameterValue(parameterName, parameterValue)
                Next
            End If
            Report.SetParameterValue("Language", language)
            Report.SetParameterValue("EstablishmentName", Presenter.GetRecordField("Establishment", "EstablishmentName"))
            Report.DataSourceConnections.Clear()
            SetPrintOption(printJobName)
            ProcessReport()

        End Sub

        Public Property MainTableName As String

        Private Sub GetIgroupReportProperties()
            Dim reportPaths As String = ConfigurationManager.AppSettings.Get($"ReportPathsIGroup")
            Dim uid As String = ConfigurationManager.AppSettings.Get("UID")
            Dim pwd As String = ConfigurationManager.AppSettings.Get("PWD")
            Dim server As String = ConfigurationManager.AppSettings.Get("ServerTranslator")
            Dim database As String = ConfigurationManager.AppSettings.Get("DATABASEIGroup")

            Report.Load(reportPaths & ReportFileName)

            If Report.DataSourceConnections.Count > 0 Then

                Report.DataSourceConnections(0).SetConnection(server, database, uid, pwd)

            End If

        End Sub


        Public Sub SetPrintOption(printJobName As String)
            If printJobName IsNot Nothing Then
                Report.PrintOptions.PrinterName = "Ad"
                'Report.PrintOptions.PaperSize = 257
                Report.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
                Report.PrintOptions.PaperSource = PaperSource.Auto
            End If
        End Sub

    End Class

End Namespace