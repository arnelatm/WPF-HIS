Imports System.Globalization
Imports AATM.Common
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class AccountActivity
        Implements ICrPrintableReportView

        Public Property MainTableName As String
        Public Event PrintReport(reportFileName As String, reportArgs As CrPrintableArgs, printDirectly As Boolean) Implements ICrPrintableReportView.PrintReport
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Account"
            SortOrderKey = "IdNo"
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(Today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(Today.Year, Today.Month, Today.Day)

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim beginningDate As Date
            Dim lastFiscalYearDate As Date
            Dim AccountBalanceYear As Integer
            Dim begDataDate As Date
            Dim cTemp As String
            Dim dDate As Date
            lastFiscalYearDate = Presenter.GetRecordFieldWithKeyG(Of Date)("LastFiscalYearEnd", "LastPosting", "TransactionName", "lastPostingDate")
            beginningDate = dtpBeginningDate.Value

            If beginningDate < lastFiscalYearDate Then
                AccountBalanceYear = Year(beginningDate)
                begDataDate = beginningDate
            Else
                AccountBalanceYear = Year(lastFiscalYearDate)
                begDataDate = DateSerial(AccountBalanceYear, 1, 1)
            End If

            If dtpBeginningDate.Value > dtpEndingDate.Value Then
                dDate = dtpBeginningDate.Value
                dtpBeginningDate.Value = dtpEndingDate.Value
                dtpEndingDate.Value = dDate
            End If
            If cboStartAccountCode.SelectedValue > cboEndAccountCode.SelectedValue Then
                cTemp = cboStartAccountCode.SelectedValue
                cboStartAccountCode.SelectedValue = cboEndAccountCode.SelectedValue
                cboEndAccountCode.SelectedValue = cTemp
            End If

            Refresh()
            Dim valid As Boolean = True
            If dtpBeginningDate.Value Is Nothing Or dtpBeginningDate.Value Is Nothing Then
                Messaging.Show(True, "MsgDatesCannotBeEmpty")
                valid = False
            ElseIf dtpBeginningDate.Value > dtpBeginningDate.Value Then
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
                valid = False
            End If
            If valid Then
                Dim reportTitle As String
                Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpBeginningDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpEndingDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                reportTitle = Messaging.TranslateCaption("Account Activity Report")
                Dim formCultureLanguage As String = CultureInfo.CurrentUICulture.Name
                Dim language As String = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))
                Dim reportFileName As String
                reportFileName = "Account Activity Report.Rpt"
                Dim reportArgs As New CrPrintableArgs
                Dim reportParameters As New Object
                Dim estName As String
                If language = "ar" Then
                    estName = GlobalVariables.EstablishmentNameAra
                Else
                    estName = GlobalVariables.EstablishmentName
                End If
                reportArgs.ReportParameters = {reportTitle, "ReportTitle",
                                               language, "Language",
                                               dtpBeginningDate.Value, "BeginningDate",
                                               dtpEndingDate.Value, "EndingDate",
                                               estName, "EstablishmentName",
                                               cboStartAccountCode.SelectedValue, "BegAccountCode",
                                               cboEndAccountCode.SelectedValue, "EndAccountCode"}
                RaiseEvent PrintReport(reportFileName, reportArgs, False)


                'Dim reportTitle As String
                'reportTitle = Messaging.TranslateCaption("Account Activity Report")
                'Dim currentCulture As CultureInfo = CultureInfo.CurrentUICulture
                'Dim cForm As New ReportFormNew("Account Activity Report.Rpt", reportTitle, currentCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate", cboStartAccountCode.SelectedValue, "BegAccountCode", cboEndAccountCode.SelectedValue, "EndAccountCode")
                'cForm.Show()
            End If
            CultureInfo.CurrentCulture = curCulture

        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub CButton1_ClickButtonArea_1(Sender As Object, e As MouseEventArgs) Handles btnTranslate.ClickButtonArea
            RunTranslator(VSystemViewIdNo)
        End Sub

        Private Sub AccountActivity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Ea.PublishEvent(New GetControlDataSource("Account", cboStartAccountCode, "DetailAccount=1"))
            Ea.PublishEvent(New GetControlDataSource("Account", cboEndAccountCode, "DetailAccount=1"))
            cboStartAccountCode.EditingMode = True
            cboEndAccountCode.EditingMode = True
        End Sub


        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboStartAccountCode As Libraries.CBaseControlsLibrary.CtCombobox
        Friend WithEvents cboEndAccountCode As Libraries.CBaseControlsLibrary.CtCombobox
    End Class

End Namespace
