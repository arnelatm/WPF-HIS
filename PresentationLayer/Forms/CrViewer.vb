Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports CrystalDecisions.ReportAppServer.DataDefModel

Public Class CrViewer

    Public ReportPrinter As New CrystalReportPrinter

    Public Event OkButtonClicked()

    Private ReadOnly _myCeLocale As CeLocale

    Public Sub New() 'Optional ByVal ceLocal As CeLocale = CeLocale.ceLocaleEnglish)

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    'Public Sub New(ByVal fileName As String, ByVal reportTitle As String, formCulture As CultureInfo, ByVal ParamArray args() As Object)
    Public Sub New(reportFileName As String, reportTitle As String, formCulture As CultureInfo, args As Object)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Text = reportTitle
        ReportPrinter.SetReportProperties(reportFileName)
        ReportPrinter.ReportFileName = reportFileName
        SetParameters(reportTitle, formCulture, args)
        ReportPrinter.ClearDataSourceConnections()
        SetupCrViewer()

    End Sub

    Public Sub New(reportFileName As String, reportArgs As CrPrintableArgs, Optional AddDefaultParameters As Boolean = False, Optional crReport As CrystalReportPrinter = Nothing)

        ' This call is required by the designer.
        InitializeComponent()
        ReportPrinter = crReport
        ReportPrinter.SetReportProperties(reportFileName, reportArgs.DataBaseConnectionName)
        ReportPrinter.ReportFileName = reportFileName
        SetParameters(reportArgs, AddDefaultParameters)
        ReportPrinter.ClearDataSourceConnections()
        SetupCrViewer()

    End Sub

    Private Sub SetParameters(reportArgs As CrPrintableArgs, Optional addDefaultParameters As Boolean = False)
        Dim language As String
        If reportArgs.Language Is Nothing Then
            language = Microsoft.VisualBasic.Strings.Left(reportArgs.Language, GlobalVariables.AppCurrentCultureInfo.Name.IndexOf("-", StringComparison.Ordinal))
            'language = Microsoft.VisualBasic.Strings.Left(reportArgs.Language, FormCulture.Name.IndexOf("-", StringComparison.Ordinal))
        Else
            language = reportArgs.Language
        End If
        If FormCulture Is Nothing Then
            FormCulture = GlobalVariables.AppCurrentCultureInfo
        End If
        Dim establishmentName As String = GetEstablishmentName(FormCulture, language)
        ReportPrinter.SetParameterValue(reportArgs.ReportParameters)
        If addDefaultParameters Then
            ReportPrinter.SetParameterValue({reportArgs.ReportTitle, "ReportTitle"})
            ReportPrinter.SetParameterValue({establishmentName, "EstablishmentName"})
            ReportPrinter.SetParameterValue({reportArgs.Language, "Language"})
        End If
    End Sub

    Private Sub SetParameters(reportTitle As String, formCulture As CultureInfo, args As Object)
        Dim language As String
        language = Microsoft.VisualBasic.Strings.Left(formCulture.Name, formCulture.Name.IndexOf("-", StringComparison.Ordinal))
        Dim establishmentName As String = GetEstablishmentName(formCulture, language)
        ReportPrinter.SetParameterValue(args)
        ReportPrinter.SetParameterValue({reportTitle, "ReportTitle"})
        ReportPrinter.SetParameterValue({establishmentName, "EstablishmentName"})
        ReportPrinter.SetParameterValue({language, "Language"})
    End Sub

    Private Function GetEstablishmentName(cFormCulture As CultureInfo, language As String) As String
        Dim establishmentName As String
        Dim lLanguage As String = ""
        lLanguage = Microsoft.VisualBasic.Strings.Left(cFormCulture.Name, cFormCulture.Name.IndexOf("-", StringComparison.Ordinal))
        If lLanguage <> "ar" Then
            establishmentName = GlobalVariables.EstablishmentName
        Else
            establishmentName = GlobalVariables.EstablishmentNameAra
        End If
        Return establishmentName
    End Function

    'Public Property ReportFileName As String

    'Protected Sub SetReportProperties()
    '    Report.SetReportProperties()
    'End Sub

    Protected Sub SetupCrViewer()
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
            .ReportSource = ReportPrinter.GetReportSource()
            .SetProductLocale(CInt(ceCulture))
            .Refresh()
        End With
        btnQuit.Visible = True
    End Sub

    Public Sub SetDb(Optional dbCName As String = Nothing)
        ReportPrinter.DataBaseConnectionName = IIf(dbCName Is Nothing, $"ISPDATA", dbCName)
    End Sub

    Public Sub SetPrintJob(Optional printJobName As String = "Default")
        ReportPrinter.PrintJobName = printJobName
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs)
        RaiseEvent OkButtonClicked()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Dispose()
        Close()
    End Sub

    Private Sub CButton1_Click(sender As Object, e As EventArgs)
        Dispose()
        Close()
    End Sub

End Class