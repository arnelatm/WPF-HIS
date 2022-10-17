Imports System.Configuration
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.Libraries.GlobalFuncNSub
Imports CrystalDecisions.ReportAppServer.DataDefModel

Public Class CrViewer

    Public Report As New ReportPrinter

    Public Event OkButtonClicked()

    Private ReadOnly _myCeLocale As CeLocale

    Public Sub New() 'Optional ByVal ceLocal As CeLocale = CeLocale.ceLocaleEnglish)

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Public Sub New(ByVal fileName As String, ByVal reportTitle As String, formCulture As CultureInfo, ByVal ParamArray args() As Object)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Text = fileName
        ReportFileName = fileName
        Report.ReportFileName = ReportFileName
        GetReportProperties()
        Dim language As String
        Dim establishmentName As String

        language = Microsoft.VisualBasic.Strings.Left(formCulture.Name, formCulture.Name.IndexOf("-", StringComparison.Ordinal))
        If language <> "ar" Then
            establishmentName = GlobalVariables.EstablishmentName
        Else
            establishmentName = GlobalVariables.EstablishmentNameAra
        End If

        Report.SetParameterValue(args)
        Report.SetParameterValue(reportTitle, "ReportTitle")
        Report.SetParameterValue(establishmentName, "EstablishmentName")
        Report.SetParameterValue(language, "Language")
        Report.ClearDataSourceConnections()
        ProcessReport()

    End Sub

    Public Shadows Sub Load()

    End Sub

    Public Property ReportFileName As String

    Protected Sub GetReportProperties()
        Report.SetReportProperties()
    End Sub

    Protected Sub ProcessReport()
        WindowState = FormWindowState.Maximized
        Dim ceCulture As CeLocale
        If Me.FormCulture.Name.ToLower().Remove(2) = "ar" Then
            ceCulture = CeLocale.ceLocaleArabicSaudiArabia
        Else
            ceCulture = CeLocale.ceLocaleEnglish
        End If
        'Dim x As Integer = CInt(ceCulture)
        With CrystalReportViewer1
            .Visible = True
            .BringToFront()
            .ReportSource = Report.GetReportSource()
            .SetProductLocale(CInt(ceCulture))
            .Refresh()
        End With
        btnQuit.Visible = True
    End Sub

    Public Sub SetDb(Optional dbCName As String = Nothing)
        Report.DataBaseConnectionName = IIf(dbCName Is Nothing, $"ISPDATA", dbCName)
    End Sub

    Public Sub SetPrintJob(Optional printJobName As String = "Default")
        Report.PrintJobName = printJobName
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        RaiseEvent OkButtonClicked()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dispose()
        Close()
    End Sub

    Private Sub CButton1_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Dispose()
        Close()
    End Sub

End Class