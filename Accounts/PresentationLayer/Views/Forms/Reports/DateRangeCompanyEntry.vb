Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class DateRangeCompanyEntry
        Implements IContactDateRangeView

        Public Property MainTableName As String
        Protected SortOrderKey As String
        Private ReadOnly _reportParameters As New ArrayList
        Private ReadOnly _reportModel As ReportModel
        Private ReadOnly _period As String
        Private _insuranceList As Object
        Public Event FormLoaded() Implements IContactDateRangeView.FormLoaded
        Public Event PrintButtonClicked() Implements IContactDateRangeView.PrintButtonClicked


        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)


        End Sub

        Public Sub New(reportModel As ReportModel)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _reportModel = reportModel
            MainTableName = "Report"
            SortOrderKey = "IdNo"
            'Presenter = New DateRangeCompanyPresenter(Me)
            'Dim qParameters As String = _reportModel.QueryFormParameters
            'Dim lParameters As String() = qParameters.Split(","c)
            '_period = lParameters(0)
            'Dim defStart = lParameters(1)
            'Dim defEnd = lParameters(2)
            'Dim begValue As Date
            'Dim endValue As Date
            'Dim dStart As Date = GetCodedDate(defStart)
            'Dim dEnd As Date = GetCodedDate(defEnd)
            'Select Case _period
            '    Case "M"
            '        begValue = GregorianDateSerial(Year(dStart), Month(dStart), 1)
            '        endValue = AsMonthEndDate(dEnd)
            '    Case "Y"
            '        begValue = GregorianDateSerial(Year(dStart), 1, 1)
            '        endValue = GregorianDateSerial(Year(dEnd), 12, 31)
            '    Case "Q"
            '        Dim monthNumber As Int16 = Month(dEnd)
            '        Dim quarter = IIf(monthNumber < 4, 1, IIf(monthNumber < 7, 2, IIf(monthNumber < 10, 3, 4)))
            '        begValue = GregorianDateSerial(Year(dStart), quarter * 3 - 2, 1)
            '        endValue = AsMonthEndDate(GregorianDateSerial(Year(dEnd), quarter * 3, 1))
            '    Case "S"
            '        Dim monthNumber As Int16 = Month(dEnd)
            '        Dim semester = IIf(monthNumber < 7, 1, 2)
            '        begValue = GregorianDateSerial(Year(dStart), semester * 6 - 5, 1)
            '        endValue = AsMonthEndDate(GregorianDateSerial(Year(dEnd), semester * 6, 1))
            'End Select
            'dtpBeginningDate.Value = begValue
            'dtpEndingDate.Value = endValue
            'cboInsuranceIdNo.DataSource = InsuranceList

        End Sub

        'Protected Sub CreateMainFieldsDictionary()
        '    Presenter.MainFieldsDictionary = New Dictionary(Of String, Object) From
        '     {
        '        {"CompanyIdNo", cboInsuranceIdNo}
        '     }
        'End Sub



        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            RaiseEvent PrintButtonClicked()

            'Dim cForm
            'If dtpBeginningDate.Value <= dtpEndingDate.Value Then
            '    '    Dim reportName As String
            '    '    Dim reportTitle As String
            '    Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpBeginningDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
            '    Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpEndingDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
            '    'reportName = Messaging.TranslateCaption($"Shift Summary Report")
            '    'reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
            '    Dim cFormCulture = FormCulture
            '    Dim parameters As New ArrayList
            '    Dim reportTitle As String = Messaging.SelectReportName(_reportModel.ReportTitle, dtpBeginningDate.Value, dtpEndingDate.Value, FormCulture, _period)
            '    parameters.Add({"ReportTitle", Messaging.TranslateCaption(reportTitle)})
            '    parameters.Add({"BeginningDate", dtpBeginningDate.Value})
            '    parameters.Add({"EndingDate", dtpEndingDate.Value})
            '    parameters.Add({"InsuranceId", cboInsuranceIdNo.SelectedValue})
            '    If _reportModel.QueryParameters IsNot Nothing AndAlso _reportModel.QueryParameters <> "" Then
            '        Dim rParameters As String = _reportModel.QueryParameters
            '        Dim aParameters As String() = rParameters.Split(","c)
            '        For i = 0 To aParameters.Count() - 1 Step 2
            '            Dim parameterName = aParameters(i)
            '            Dim parameterValue = aParameters(i + 1)
            '            parameters.Add({parameterName, parameterValue})
            '        Next
            '    End If
            '    'If _reportParameters.Count() > 1 Then
            '    '    For i = 0 To _reportParameters.Count() - 1
            '    '        parameters.Add(_reportParameters(i))
            '    '    Next
            '    'End If
            '    'If Strings.Left(cFormCulture.Name, 2) = "ar" Then
            '    cForm = New ReportFormIGroup(_reportModel.ReportFileName + ".rpt", CultureInfo.CurrentCulture, parameters)
            '    'Else
            '    '    cForm = New ReportFormIGroup(_reportModel.ReportFileName + ".rpt", FormCulture, parameters)
            '    'End If
            '    cForm.Show()
            'Else
            '    Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            'End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Public Property InsuranceList As Object
            Get
                Return _insuranceList
            End Get
            Set(value As Object)
                _insuranceList = value
                BindInsuranceList()
            End Set
        End Property

        Public Property BeginningDate As Date? Implements IContactDateRangeView.BeginningDate
            Get
                Return dtpBeginningDate.Value
            End Get
            Set(value As Date?)
                dtpBeginningDate.Value = value
            End Set
        End Property

        Public Property EndingDate As Date? Implements IContactDateRangeView.EndingDate
            Get
                Return dtpEndingDate.Value
            End Get
            Set(value As Date?)
                dtpEndingDate.Value = value
            End Set
        End Property

        Public ReadOnly Property Language As String Implements IContactDateRangeView.Language

        Public Property IdNo As Integer Implements IContactDateRangeView.IdNo
            Get
                Return cboInsuranceIdNo.GetValue(Of Integer)
            End Get
            Set(value As Integer)
                cboInsuranceIdNo.SetValue(value)
            End Set
        End Property

        Public ReadOnly Property ReportCode As String Implements IContactDateRangeView.ReportCode
        Public Property Title As String Implements IContactDateRangeView.Title
        Public Property UserHasAccess As Boolean Implements IContactDateRangeView.UserHasAccess
        Public Property PersonSelectorControl As Control Implements IContactDateRangeView.PersonSelectorControl
        Public Property PersonSelectorLabel As String Implements IContactDateRangeView.PersonSelectorLabel
        Public Property NoDates As Boolean Implements IContactDateRangeView.NoDates

        Public Property ContactDataSource As Object

        Private Property IContactDateRangeView_ContactDataSource As Object Implements IContactDateRangeView.ContactDataSource

        Private Sub DateRangeCompanyEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent FormLoaded()
            cboInsuranceIdNo.DisplayOnly = False
            cboInsuranceIdNo.EditingMode = True
        End Sub

        Private Sub BindInsuranceList()
            cboInsuranceIdNo.DataSource = Nothing
            cboInsuranceIdNo.DataSource = InsuranceList
            cboInsuranceIdNo.EditingMode = True
            cboInsuranceIdNo.Refresh()
        End Sub

    End Class

End Namespace