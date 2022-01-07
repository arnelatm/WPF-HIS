Imports System.Configuration
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ReportFormIGroup

        Public Sub New(ByVal fileName As String, formCulture As CultureInfo, args As Object)

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
            'Dim companyName =
            'Dim companyNameAra =
            For i = 0 To args.Count() - 1 Step 2
                Report.SetParameterValue(args(i)(0), args(i)(1))
            Next
            Report.SetParameterValue("Language", language)
            Report.SetParameterValue("EstablishmentName", Presenter.GetRecordField("Establishment", "EstablishmentName"))
            Report.SetParameterValue("EstablishmentNameAra", Presenter.GetRecordField("Establishment", "EstablishmentNameAra"))
            Report.DataSourceConnections.Clear()
            ProcessReport()

        End Sub

        Public Property MainTableName As String

        Private Sub GetIgroupReportProperties()
            Dim reportPaths As String = ConfigurationManager.AppSettings.Get($"ReportPathsIGroup")
            Dim uid As String = ConfigurationManager.AppSettings.Get("UID")
            Dim pwd As String = ConfigurationManager.AppSettings.Get("PWD")
            Dim server As String = ConfigurationManager.AppSettings.Get("ServerTranslator1")
            Dim database As String = ConfigurationManager.AppSettings.Get("DATABASEIGroup")

            Report.Load(reportPaths & ReportFileName)

            If Report.DataSourceConnections.Count > 0 Then

                Report.DataSourceConnections(0).SetConnection(server, database, uid, pwd)

            End If

        End Sub

    End Class

End Namespace