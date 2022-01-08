Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class DateRangeEntry

        Public Property MainTableName As String
        Protected SortOrderKey As String
        Private ReadOnly _reportParameters As New ArrayList
        Private ReadOnly _reportModel As ReportModel
        Private ReadOnly _period As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            Presenter = New ReportPresenter(Me)

            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)

            'If parameters.Count() > 1 Then
            '    For i = 0 To parameters.Count() - 1
            '        _reportParameters.Add(parameters(i)(0), parameters(i)(1))
            '    Next
            'End If

        End Sub

        Public Sub New(reportModel As ReportModel)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _reportModel = reportModel
            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            Presenter = New ReportPresenter(Me)
            Dim qParameters As String = _reportModel.QueryFormParameters
            Dim lParameters As String() = qParameters.Split(","c)
            _period = lParameters(0)
            Dim defStart = lParameters(1)
            Dim defEnd = lParameters(2)
            Dim begValue As Date
            Dim endValue As Date
            begValue = GetCodedDate(defStart)
            endValue = GetCodedDate(defEnd)
            dtpBeginningDate.Value = begValue
            dtpEndingDate.Value = endValue

        End Sub

        Private Shared Function GetCodedDate(dateCode As String) As Date
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

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim cForm
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then
                '    Dim reportName As String
                '    Dim reportTitle As String
                Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpBeginningDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpEndingDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                'reportName = Messaging.TranslateCaption($"Shift Summary Report")
                'reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
                Dim cFormCulture = FormCulture
                Dim parameters As New ArrayList
                Dim reportTitle As String = Messaging.SelectReportName(_reportModel.ReportTitle, dtpBeginningDate.Value, dtpEndingDate.Value, FormCulture, _period)
                parameters.Add({"ReportTitle", Messaging.TranslateCaption(reportTitle)})
                parameters.Add({"BeginningDate", dtpBeginningDate.Value})
                parameters.Add({"EndingDate", dtpEndingDate.Value})
                If _reportModel.QueryParameters IsNot Nothing AndAlso _reportModel.QueryParameters <> "" Then
                    Dim rParameters As String = _reportModel.QueryParameters
                    Dim aParameters As String() = rParameters.Split(","c)
                    For i = 0 To aParameters.Count() - 1 Step 2
                        Dim parameterName = aParameters(i)
                        Dim parameterValue = aParameters(i + 1)
                        parameters.Add({parameterName, parameterValue})
                    Next
                End If
                'If _reportParameters.Count() > 1 Then
                '    For i = 0 To _reportParameters.Count() - 1
                '        parameters.Add(_reportParameters(i))
                '    Next
                'End If
                'If Strings.Left(cFormCulture.Name, 2) = "ar" Then
                cForm = New ReportFormIGroup(_reportModel.ReportFileName + ".rpt", FormCulture, parameters)
                'Else
                '    cForm = New ReportFormIGroup(_reportModel.ReportFileName + ".rpt", FormCulture, parameters)
                'End If
                cForm.Show()
            Else
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace