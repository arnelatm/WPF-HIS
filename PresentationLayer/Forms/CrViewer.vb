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
        ClearPromptedParameterValues(reportArgs)
        SetupCrViewer(ShouldPromptForParameters(reportArgs, AddDefaultParameters))

    End Sub

    Private Sub SetParameters(reportArgs As CrPrintableArgs, Optional addDefaultParameters As Boolean = False)
        Dim language As String
        language = Microsoft.VisualBasic.Strings.Left(reportArgs.Language, FormCulture.Name.IndexOf("-", StringComparison.Ordinal))
        Dim establishmentName As String = GlobalVariables.GetEstablishmentName(FormCulture)
        ReportPrinter.SetParameterValue(reportArgs.ReportParameters)
        If addDefaultParameters Then
            ReportPrinter.SetParameterValue({reportArgs.ReportTitle, "ReportTitle"})
            ReportPrinter.SetParameterValue({establishmentName, "EstablishmentName"})
            ReportPrinter.SetParameterValue({reportArgs.Language, "Language"})
        End If
    End Sub

    Private Function ShouldPromptForParameters(reportArgs As CrPrintableArgs, addDefaultParameters As Boolean) As Boolean
        If reportArgs Is Nothing Then
            Return False
        End If

        Dim hasPromptedParameters As Boolean =
            reportArgs.PromptParameterNames IsNot Nothing AndAlso
            reportArgs.PromptParameterNames.Length > 0

        Return hasPromptedParameters OrElse
               (Not addDefaultParameters AndAlso
                (reportArgs.ReportParameters Is Nothing OrElse reportArgs.ReportParameters.Length = 0))
    End Function

    Private Sub ClearPromptedParameterValues(reportArgs As CrPrintableArgs)
        If reportArgs Is Nothing OrElse
           reportArgs.PromptParameterNames Is Nothing OrElse
           reportArgs.PromptParameterNames.Length = 0 Then
            Return
        End If

        ReportPrinter.ClearParameterValues(reportArgs.PromptParameterNames)
    End Sub

    Private Sub SetParameters(reportTitle As String, formCulture As CultureInfo, args As Object)
        Dim language As String
        language = Microsoft.VisualBasic.Strings.Left(formCulture.Name, formCulture.Name.IndexOf("-", StringComparison.Ordinal))
        Dim establishmentName As String = GlobalVariables.GetEstablishmentName(formCulture)
        ReportPrinter.SetParameterValue(args)
        ReportPrinter.SetParameterValue({reportTitle, "ReportTitle"})
        ReportPrinter.SetParameterValue({establishmentName, "EstablishmentName"})
        ReportPrinter.SetParameterValue({language, "Language"})
    End Sub

    'Public Property ReportFileName As String

    'Protected Sub SetReportProperties()
    '    Report.SetReportProperties()
    'End Sub

    Protected Sub SetupCrViewer(Optional promptForParameters As Boolean = False)
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
            If promptForParameters Then
                .ToolPanelView = Global.CrystalDecisions.Windows.Forms.ToolPanelViewType.ParameterPanel
                .ShowParameterPanelButton = True
                SetViewerPropertyIfAvailable(CrystalReportViewer1, "EnableParameterPrompt", True)
                SetViewerPropertyIfAvailable(CrystalReportViewer1, "ReuseParameterValuesOnRefresh", False)
                .RefreshReport()
            Else
                .Refresh()
            End If
        End With
        btnQuit.Visible = True
    End Sub

    Private Sub SetViewerPropertyIfAvailable(viewer As Global.CrystalDecisions.Windows.Forms.CrystalReportViewer, propertyName As String, value As Object)
        Try
            Dim pi = viewer.GetType().GetProperty(propertyName)
            If pi IsNot Nothing AndAlso pi.CanWrite Then
                pi.SetValue(viewer, value, Nothing)
            End If
        Catch
        End Try
    End Sub

    Public Sub SetDb(Optional dbCName As String = Nothing)
        ReportPrinter.DataBaseConnectionName = IIf(dbCName Is Nothing, $"ISPDATA", dbCName)
    End Sub

    Public Sub SetPrintJob(Optional printJobName As String = "Default")
        ReportPrinter.PrintJobName = printJobName
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        RaiseEvent OkButtonClicked()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub CButton1_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Close()
    End Sub

End Class
