Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub

Public Class DateRangePresenter(Of TM As New)
    Inherits AccountsPresenter(Of IDateRangeView, TM)

    Private _reportFileName As String
    Private _reportName As String
    Private _reportCode As String
    Private _selectorFilter As String
    Private _tableName As String
    Private _filter As String = ""
    Private _reportModel As ReportModel

    Public Sub New(view As IDateRangeView, reportModel As ReportModel)
        MyBase.New(view)
        TableName = "Report"
        WithTreeView = False
        Service = New CommonService("Report")
        AddHandler view.PrintButtonClicked, AddressOf OnPrintButtonClicked
        AddHandler view.FormLoaded, AddressOf OnFormLoaded
        _reportModel = reportModel
    End Sub

    Private Sub OnFormLoaded()
        Dim qParameters As String = _reportModel.QueryFormParameters
        Dim lParameters As String() = qParameters.Split(","c)
        Dim period As String
        period = lParameters(0) ' D for daily, M for monthly, Y for yearly etc.
        Dim defStart = lParameters(1) ' default start date
        Dim defEnd = lParameters(2) ' default end date
        Dim contactName As String
        If lParameters.Count() = 4 Then
            contactName = lParameters(3)
        Else
            contactName = ""
        End If
        SetInitialDates(period, defStart, defEnd, View.BeginningDate, View.EndingDate)
    End Sub

    Public Sub New()
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
            Dim language = Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            _reportModel.ReportTitle = Libraries.MessagingLibrary.Messaging.SelectReportName(_reportModel.ReportName, beginningDate, endingDate, curCulture)
            reportArgs.ReportParameters = {
                                            beginningDate.Value, "BeginningDate",
                                            endingDate.Value, "EndingDate",
                                            _reportModel.ReportTitle, "ReportTitle",
                                            GlobalVariables.EstablishmentName, "EstablishmentName",
                                            language, "Language"}
            If _reportModel.QueryParameters IsNot Nothing AndAlso _reportModel.QueryParameters <> "" Then
                Dim qParameters As String = _reportModel.QueryParameters
                Dim lParameters As String() = qParameters.Split(","c)
                For Each item In lParameters
                    reportArgs.ReportParameters.Add(item)
                Next
            End If
            reportArgs.DataBaseConnectionName = _reportModel.DatabaseName
            Dim p As New PrintReportPresenter(Of AccountModel)
                p.ViewReport(_reportModel.ReportFileName, reportArgs, False)
            End If
            CultureInfo.CurrentCulture = curCulture

    End Sub

End Class

Public Class ContactDateRangePresenter(Of TM As New)
    Inherits AccountsPresenter(Of IContactDateRangeView, TM)

    Private _reportFileName As String
    Private _reportName As String
    Private _reportCode As String
    Private _selectorFilter As String
    Private _tableName As String
    Private _filter As String = ""
    Private _reportModel As ReportModel

    Public Sub New(view As IContactDateRangeView, reportModel As ReportModel)
        MyBase.New(view)
        TableName = "Report"
        WithTreeView = False
        Service = New CommonService("Report")
        AddHandler view.PrintButtonClicked, AddressOf OnPrintButtonClicked
        AddHandler view.ContactDateRangeFormLoaded, AddressOf ContactDateRangeFormLoaded
        _reportModel = reportModel
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
            Dim language = Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            reportTitle = Libraries.MessagingLibrary.Messaging.SelectReportName(_reportModel.ReportName, beginningDate, endingDate, curCulture)
            reportArgs.ReportParameters = {
                                            beginningDate.Value, "BeginningDate",
                                            endingDate.Value, "EndingDate",
                                            View.IdNo, "IdNo",
                                            _reportModel.ReportTitle, "ReportTitle",
                                            GlobalVariables.EstablishmentName, "EstablishmentName",
                                            language, "Language"}
            reportArgs.DataBaseConnectionName = _reportModel.DatabaseName
            Dim p As New PrintReportPresenter(Of AccountModel)
            p.ViewReport(_reportModel.ReportFileName, reportArgs, False)
        End If
        CultureInfo.CurrentCulture = curCulture

    End Sub

    Private Sub ContactDateRangeFormLoaded()
        Dim qParameters As String = _reportModel.QueryFormParameters
        Dim lParameters As String() = qParameters.Split(","c)
        Dim period As String
        period = lParameters(0) ' D for daily, M for monthly, Y for yearly etc.
        Dim defStart = lParameters(1) ' default start date
        Dim defEnd = lParameters(2) ' default end date
        Dim contactName As String
        If lParameters.Count() = 4 Then
            contactName = lParameters(3)
        Else
            contactName = ""
        End If
        Dim dStart As Date = GetCodedDate(defStart)
        Dim dEnd As Date = GetCodedDate(defEnd)
        SetInitialDates(period, defStart, defEnd, View.BeginningDate, View.EndingDate)
        If contactName <> "" And Not (_reportModel.DatabaseName Is Nothing OrElse _reportModel.DatabaseName = "") Then
            Service.SaveConnectionString()
            Service.SetConnectionString(_reportModel.DatabaseName)
            If contactName = "InsuranceDetails" Then
                MakeVarDataSources({New String() {"InsuranceDetails", "ContactDataSource", "InsuranceId,NameEnglish", Nothing}})
            Else
                Debugger.Break()
                MessageBox.Show("Missing ContactName <" & contactName & ">")
            End If
            Service.RestoreConnectionString()
        Else
            If contactName = "Customer" Then
                MakeVarDataSources({New String() {"Customer", "ContactDataSource", Nothing, Nothing}})
            End If
        End If
    End Sub

End Class


Friend Module DateRangeModule

    Friend Function GetCodedDate(dateCode As String) As Date
        Dim value As Date
        Dim now As Date = Today()
        value = GlobalFunctions.GregorianDateSerial(now.Year, 1, 1).AddYears(-1)
        Select Case dateCode
            Case "CD"
                value = GlobalFunctions.GregorianDateSerial(now.Year, now.Month, now.Day)
            Case "PD"
                value = GlobalFunctions.GregorianDateSerial(now.Year, now.Month, now.Day).AddDays(-1)
            Case "ND"
                value = GlobalFunctions.GregorianDateSerial(now.Year, now.Month, now.Day).AddDays(1)
            Case "CM"
                value = GlobalFunctions.GregorianDateSerial(now.Year, now.Month, 1)
            Case = "PM"
                value = GlobalFunctions.GregorianDateSerial(now.Year, now.Month, 1).AddMonths(-1)
            Case = "NM"
                value = GlobalFunctions.GregorianDateSerial(now.Year, now.Month, 1).AddMonths(1)
            Case = "CY"
                value = GlobalFunctions.GregorianDateSerial(now.Year, 1, 1)
            Case = "PY"
                value = GlobalFunctions.GregorianDateSerial(now.Year, 1, 1).AddYears(-1)
            Case = "NY"
                value = GlobalFunctions.GregorianDateSerial(now.Year, 1, 1).AddYears(1)
            Case Else
                value = now
        End Select
        Return value
    End Function

    Friend Sub SetInitialDates(period As String, defStart As String, defEnd As String, ByRef outputBegDate As Date?, ByRef outputEndDate As Date?)
        Dim begValue As Date
        Dim endValue As Date
        Dim dStart As Date = GetCodedDate(defStart)
        Dim dEnd As Date = GetCodedDate(defEnd)
        Select Case period
            Case "M"
                begValue = GregorianDateSerial(Year(dStart), Month(dStart), 1)
                endValue = AsMonthEndDate(dEnd)
            Case "Y"
                begValue = GregorianDateSerial(Year(dStart), 1, 1)
                endValue = GregorianDateSerial(Year(dEnd), 12, 31)
            Case "Q"
                Dim monthNumber As Int16 = Month(dEnd)
                Dim quarter = IIf(monthNumber < 4, 1, IIf(monthNumber < 7, 2, IIf(monthNumber < 10, 3, 4)))
                begValue = GregorianDateSerial(Year(dStart), quarter * 3 - 2, 1)
                endValue = AsMonthEndDate(GregorianDateSerial(Year(dEnd), quarter * 3, 1))
            Case "S"
                Dim monthNumber As Int16 = Month(dEnd)
                Dim semester = IIf(monthNumber < 7, 1, 2)
                begValue = GregorianDateSerial(Year(dStart), semester * 6 - 5, 1)
                endValue = AsMonthEndDate(GregorianDateSerial(Year(dEnd), semester * 6, 1))
        End Select
        outputBegDate = begValue
        outputEndDate = endValue
    End Sub

End Module