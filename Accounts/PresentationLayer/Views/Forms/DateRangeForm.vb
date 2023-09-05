Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class DateRangeForm
        Implements IDateRangeView

        Public ReadOnly Property Language As String Implements IDateRangeView.Language
        Public ReadOnly Property ReportCode As String Implements IDateRangeView.ReportCode
        Public Property UserHasAccess As Boolean Implements IDateRangeView.UserHasAccess
        Public Property Title As String Implements IDateRangeView.Title
        Protected SortOrderKey As String
        Private ReadOnly _reportParameters As New ArrayList
        Private ReadOnly _reportModel As ReportModel
        Private ReadOnly _period As String
        Public Event FormLoaded() Implements IDateRangeView.FormLoaded
        Public Event PrintButtonClicked() Implements IDateRangeView.PrintButtonClicked

        Public Property MainTableName As String

        Public Property BeginningDate As Date? Implements IDateRangeView.BeginningDate
            Get
                Return dateRange.BeginningDate.Value
            End Get
            Set(value As Date?)
                dateRange.BeginningDate = value
            End Set
        End Property

        Public Property EndingDate As Date? Implements IDateRangeView.EndingDate
            Get
                Return dateRange.EndingDate
            End Get
            Set(value As Date?)
                dateRange.EndingDate = value
            End Set
        End Property

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "Report"
            SortOrderKey = "IdNo"
            Dim today = Now()
            dateRange.BeginningDate = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)
            dateRange.EndingDate = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)

        End Sub

        Public Sub New(reportModel As ReportModel)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _reportModel = reportModel
            MainTableName = "Report"
            SortOrderKey = "IdNo"
            'Dim qParameters As String = _reportModel.QueryFormParameters
            'Dim lParameters As String() = qParameters.Split(","c)
            '_period = lParameters(0)
            'Dim defStart = lParameters(1)
            'Dim defEnd = lParameters(2)
            'Dim begValue As Date
            'Dim endValue As Date
            'begValue = GetCodedDate(defStart)
            'endValue = GetCodedDate(defEnd)
            'dateRange.BeginningDate = begValue
            'dateRange.EndingDate = endValue

        End Sub

        'Private Shared Function GetCodedDate(dateCode As String) As Date
        '    Dim value As Date
        '    Dim now As Date = Today()
        '    value = GlobalFunctions.GregorianDateSerial(now.Year, 1, 1).AddYears(-1)
        '    Select Case dateCode
        '        Case "CD"
        '            value = GlobalFunctions.GregorianDateSerial(now.Year, now.Month, now.Day)
        '        Case "PD"
        '            value = GlobalFunctions.GregorianDateSerial(now.Year, now.Month, now.Day).AddDays(-1)
        '        Case "ND"
        '            value = GlobalFunctions.GregorianDateSerial(now.Year, now.Month, now.Day).AddDays(1)
        '        Case "CM"
        '            value = GlobalFunctions.GregorianDateSerial(now.Year, now.Month, 1)
        '        Case = "PM"
        '            value = GlobalFunctions.GregorianDateSerial(now.Year, now.Month, 1).AddMonths(-1)
        '        Case = "NM"
        '            value = GlobalFunctions.GregorianDateSerial(now.Year, now.Month, 1).AddMonths(1)
        '        Case = "CY"
        '            value = GlobalFunctions.GregorianDateSerial(now.Year, 1, 1)
        '        Case = "PY"
        '            value = GlobalFunctions.GregorianDateSerial(now.Year, 1, 1).AddYears(-1)
        '        Case = "NY"
        '            value = GlobalFunctions.GregorianDateSerial(now.Year, 1, 1).AddYears(1)
        '        Case Else
        '            value = now
        '    End Select
        '    Return value
        'End Function

        Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            RaiseEvent PrintButtonClicked()
            'Dim cForm
            'If dateRange.BeginningDate <= dateRange.EndingDate Then
            '    '    Dim reportName As String
            '    '    Dim reportTitle As String
            '    Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dateRange.BeginningDate, CultureInfo.CreateSpecificCulture("en-GB"))
            '    Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dateRange.EndingDate, CultureInfo.CreateSpecificCulture("en-GB"))
            '    'reportName = Messaging.TranslateCaption($"Shift Summary Report")
            '    'reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
            '    Dim cFormCulture = FormCulture
            '    Dim parameters As New ArrayList
            '    Dim reportTitle As String = Messaging.SelectReportName(_reportModel.ReportTitle, dateRange.BeginningDate, dateRange.EndingDate, FormCulture, _period)
            '    parameters.Add({"ReportTitle", Messaging.TranslateCaption(reportTitle)})
            '    parameters.Add({"BeginningDate", dateRange.BeginningDate})
            '    parameters.Add({"EndingDate", dateRange.EndingDate})
            '    If _reportModel.QueryParameters IsNot Nothing AndAlso _reportModel.QueryParameters <> "" Then
            '        Dim rParameters As String = _reportModel.QueryParameters
            '        Dim aParameters As String() = rParameters.Split(","c)
            '        For i = 0 To aParameters.Count() - 1 Step 2
            '            Dim parameterName = aParameters(i)
            '            Dim parameterValue = aParameters(i + 1)
            '            parameters.Add({parameterName, parameterValue})
            '        Next
            '    End If
            '    cForm = New ReportFormIGroup(_reportModel.ReportFileName + ".rpt", CultureInfo.CurrentCulture, parameters)
            '    cForm.Show()
            'Else
            '    Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            'End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace