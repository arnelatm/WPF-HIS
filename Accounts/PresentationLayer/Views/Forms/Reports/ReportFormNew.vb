Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters

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
            language = Strings.Left(formCulture.Name, formCulture.Name.IndexOf("-", StringComparison.Ordinal))
            If language <> "ar" Then
                establishmentName = PresenterObj.GetRecordField("Establishment", "EstablishmentName")
            Else
                establishmentName = PresenterObj.GetRecordField("Establishment", "EstablishmentNameAra")
            End If
            PresenterObj = New ReportPresenter(Me)
            For i = 0 To args.Length - 1 Step 2
                Dim value = args(i)
                Report.SetParameterValue(args(i + 1).ToString(), ConvertObjectToType(value))
            Next
            Report.SetParameterValue("Language", language)
            Report.SetParameterValue("ReportTitle", reportTitle)
            Report.SetParameterValue("EstablishmentName", establishmentName)
            Report.DataSourceConnections.Clear()
            ProcessReport()

        End Sub

        Public Property MainTableName As String

    End Class

End Namespace