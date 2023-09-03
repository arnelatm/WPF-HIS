Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Public Class ReportPresenter(Of TM As New)
    Inherits AccountsPresenter(Of IReportSelectorView, TM)

    Private _reportFileName As String
    Private _reportName As String
    Private _reportCode As String
    Private _selectorFilter As String
    Private _tableName As String
    Private _filter As String = ""
    Private _withFiscalYearDateRequirement As Boolean


    Public Sub New()
    End Sub


    Public Sub New(view As IReportSelectorView, reportCode As String)
        MyBase.New(view)
        TableName = "Account"
        WithTreeView = False
        Service = New AccountsService("Account")
        _reportCode = reportCode
        AddHandler view.ReportDoubleClickEvent, AddressOf OnReportDoubleClickEvent
        'AddHandler view.PrintButtonClicked, AddressOf OnPrintButtonClicked
        'AddHandler view.ReportLoaded, AddressOf OnReportLoaded
        SetupReportSpecs()

    End Sub


    Public Sub OnReportDoubleClickEvent(reportIdNo As Int16)
        Dim report As ReportModel = Service.GetRecordByIdNo(Of ReportModel)(reportIdNo)
        Dim parameters As New ArrayList
        If report.QueryParameters IsNot Nothing AndAlso report.QueryParameters <> "" Then
            Dim rParameters As String = report.QueryParameters
            Dim aParameters As String() = rParameters.Split(","c)
            For i = 0 To aParameters.Count() - 1 Step 2
                Dim parameterName = aParameters(i)
                Dim parameterValue = aParameters(i + 1)
                parameters.Add({parameterName, parameterValue})
            Next
        End If
        'Dim parameters As New ArrayList
        'parameters.Add({"ReportTitle", Messaging.TranslateCaption(report.ReportTitle)})
        Dim queryForm As String = report.QueryForm
        If queryForm Is Nothing Then
            Dim cForm = New ReportFormIGroup(report.ReportFileName + ".rpt", CultureInfo.CurrentCulture, If(parameters.Count() = 0, Nothing, parameters))
            cForm.Show()
        Else
            Dim f As Form = FormFunctions.GetFormByName(queryForm, report)
            f.Show()
        End If

    End Sub


    Private Sub SetupReportSpecs()
        Select Case View.ReportCode
            Case "ApStatement"
                _reportName = "Statement Of Accounts Payable"
                If View.Language = "ar" Then
                    _reportFileName = "Statement of Accounts Payable Arabic.Rpt"
                Else
                    _reportFileName = "Statement of Accounts Payable.Rpt"
                End If
                _tableName = "Supplier"
                View.NoDates = False
            Case "ArStatement"
                _reportName = "Statement Of Accounts Receivable"
                If View.Language = "ar" Then
                    _reportFileName = "Statement of Accounts Receivable Arabic.Rpt"
                Else
                    _reportFileName = "Statement of Accounts Receivable.Rpt"
                End If
                _tableName = "Customer"
                View.NoDates = False
            Case "ErStatement"
                _reportName = "Statement Of Employee Loans"
                If View.Language = "ar" Then
                    _reportFileName = "Statement of Employee Loans Arabic.Rpt"
                Else
                    _reportFileName = "Statement of Employee Loans.Rpt"
                End If
                _tableName = "Employee"
                View.NoDates = False
            Case "EmployeeInfo"
                _reportName = "Employee Information"
                _reportFileName = "HR Employee Info.Rpt"
                _tableName = "Employee"
                View.NoDates = True
            Case "LeaveStatement"
                _reportName = "Statement of Employee Leaves"
                _reportFileName = "Statement Of Employee Leaves.Rpt"
                _tableName = "Employee"
                View.NoDates = False
        End Select
    End Sub

    Public Sub OnPrintButtonClicked()
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        Dim beginningDate As Date?
        Dim endingDate As Date?
        Dim estName As String

        If View.Language = "ar" Then
            estName = GlobalVariables.EstablishmentNameAra
        Else
            estName = GlobalVariables.EstablishmentName
        End If
        beginningDate = View.BeginningDate
        endingDate = View.EndingDate
        Dim reportName = Libraries.MessagingLibrary.Messaging.TranslateCaption(_reportName)
        Dim reportTitle As String
        Dim valid As Boolean = True
        If beginningDate Is Nothing Or endingDate Is Nothing Then
            Libraries.MessagingLibrary.Messaging.Show(True, "MsgDatesCannotBeEmpty")
            valid = False
        ElseIf beginningDate > endingDate Then
            Libraries.MessagingLibrary.Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            valid = False
        End If
        If valid Then
            Dim reportArgs As New CrPrintableArgs
            Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(beginningDate, CultureInfo.CreateSpecificCulture("en-GB"))
            Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(endingDate, CultureInfo.CreateSpecificCulture("en-GB"))
            reportTitle = Libraries.MessagingLibrary.Messaging.SelectReportName(reportName, beginningDate, endingDate, curCulture)
            Select Case View.ReportCode
                Case "ApStatement"
                    reportArgs.ReportParameters = {beginningDate.Value, "BeginningDate",
                        endingDate.Value, "EndingDate",
                        View.IdNo, "SupplierIdNo",
                        View.PersonSelectorControl.Text, "DisplayName",
                        reportTitle, "ReportTitle",
                        GlobalVariables.EstablishmentName, "EstablishmentName",
                        View.Language, "Language"}
                Case "ArStatement"
                    reportArgs.ReportParameters = {beginningDate.Value, "BeginningDate",
                        endingDate.Value, "EndingDate",
                        View.IdNo, "CustomerIdNo",
                        View.PersonSelectorControl.Text, "DisplayName",
                        reportTitle, "ReportTitle",
                        GlobalVariables.EstablishmentName, "EstablishmentName",
                        View.Language, "Language"}
                Case "ErStatement"
                    reportArgs.ReportParameters = {beginningDate.Value, "BeginningDate",
                        endingDate.Value, "EndingDate",
                        View.IdNo, "EmployeeIdNo",
                        View.PersonSelectorControl.Text, "DisplayName",
                        reportTitle, "ReportTitle",
                        GlobalVariables.EstablishmentName, "EstablishmentName",
                        View.Language, "Language"}
                Case "EmployeeInfo"
                    reportArgs.ReportParameters = {View.IdNo, "EmployeeIdNo"}
                Case "LeaveStatement"
                    reportArgs.ReportParameters = {beginningDate.Value, "BeginningDate",
                        endingDate.Value, "EndingDate",
                        View.IdNo, "EmployeeIdNo",
                        reportTitle, "ReportTitle",
                        GlobalVariables.EstablishmentName, "EstablishmentName",
                        View.Language, "Language"}
            End Select
            Dim p As New PrintReportPresenter(Of AccountModel)
            p.ViewReport(_reportFileName, reportArgs, False)
        End If
        CultureInfo.CurrentCulture = curCulture

    End Sub

    Private Sub OnReportLoaded()
        View.BeginningDate = GlobalFunctions.GregorianDateSerial(Today.Year, 1, 1)
        View.EndingDate = GlobalFunctions.GregorianDateSerial(Today.Year, Today.Month, Today.Day)
        View.Title = Libraries.MessagingLibrary.Messaging.TranslateCaption(_reportName)
        SetDataSource(_tableName, View.PersonSelectorControl,,, _filter)
        Select Case View.ReportCode
            Case "LeaveStatement", "ErStatement", "EmployeeInfo"
                View.PersonSelectorLabel = "Employee Name"
            Case "ApStatement"
                View.PersonSelectorLabel = "Supplier Name"
            Case "ArStatement"
                View.PersonSelectorLabel = "Customer Name"
        End Select
    End Sub


End Class


