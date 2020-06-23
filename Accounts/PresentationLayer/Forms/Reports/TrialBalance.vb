Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Forms.Reports
    Public Class TrialBalance

        Public Property MainTableName As String
        Protected SortOrderKey As String
        Private ReadOnly _period As String

        Public Sub New(period As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            PresenterObj = New ReportPresenter(Me)

            _period = period
            ' returns previous month last day


            'Select Case _period
            '    Case "Y"
            '        endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year - 1, 12, 31)
            '        Text = "Trial Balance for the Year"
            '        lblDateCaption.Text = "Year End Date:"
            '    Case "M"
            '        endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, Month(currentDate), 0)
            '        Text = "Trial Balance for the Month"
            '        lblDateCaption.Text = "Month End Date:"
            'End Select
            'lblTitle.Text = Text


        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If _period = "Y" And (Month(dtpEndingDate.Value) <> 12 Or Microsoft.VisualBasic.DateAndTime.Day(dtpEndingDate.Value) <> 31) Then
                Messaging.Show(True, "MsgInvalidEndOfYearDate", $"Invalid year end date entry. Month must be 12 and day must be 31!", "Invalid Entry")
            Else
                Dim beginningDate As Date
                Dim lastPostingDate As Date
                Dim chartBalanceYear As Integer
                Dim begDataDate As Date
                lastPostingDate = PresenterObj.GetRecordFieldWithKeyG(Of Date)("LastFiscalYearEnd", "LastPosting", "TransactionName", "lastPostingDate")

                Select Case _period
                    Case "Y"
                        beginningDate = DateSerial(Year(dtpEndingDate.Value), 1, 1)
                    Case "M"
                        beginningDate = DateSerial(Year(dtpEndingDate.Value), Month(dtpEndingDate.Value), 1)
                        dtpEndingDate.Value = DateSerial(Year(dtpEndingDate.Value),month(dtpEndingDate.Value)+1,0)
                End Select
                If beginningDate < lastPostingDate Then
                    chartBalanceYear = Year(beginningDate)
                    begDataDate = beginningDate
                Else
                    chartBalanceYear = Year(lastPostingDate)
                    begDataDate = lastPostingDate
                End If
                Dim cForm As New ReportForm("Trial Balance.Rpt", beginningDate, "BeginningDate", dtpEndingDate.Value, "EndingDate", chartBalanceYear, "ChartBalanceYear", begDataDate, "begDataDate", _period, "Period")
                cForm.Show()
            End If

        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub CButton1_ClickButtonArea_1(Sender As Object, e As MouseEventArgs) Handles btnTranslate.ClickButtonArea
            RunTranslator(FormIdNo)
        End Sub

        Private Sub TrialBalance_BeforeLoad() Handles MyBase.BeforeLoad
            Dim currentDate = Now()
            Dim endDate As Date
            Select Case _period
                Case "Y"
                    endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year - 1, 12, 31)
                    Text = "Trial Balance for the Year"
                    lblDateCaption.Text = "Year End Date:"
                Case "M"
                    endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, Month(currentDate), 0)
                    Text = "Trial Balance for the Month"
                    lblDateCaption.Text = "Month End Date:"
            End Select
            lblTitle.Text = Text
            dtpEndingDate.Value = endDate
        End Sub
    End Class
End Namespace