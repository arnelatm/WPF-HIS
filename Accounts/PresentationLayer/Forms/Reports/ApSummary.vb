Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms.Reports

    Public Class ApSummary

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            PresenterObj = New ReportPresenter(Me)
            Dim currentDate = Now()
            ' returns previous month last day
            Dim endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, currentDate.Month, 0)
            dtpEndingDate.Value = endDate
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(endDate.Year, endDate.Month, 1)
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim language As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))
            Dim cForm As New ReportForm("Summary of Accounts Payable.Rpt", dtpBeginningDate.Value, "BeginningDate",
                                        dtpEndingDate.Value, "EndingDate", chkIncludeZeroBalances.Checked, "IncludeZeroBalance", language, "Language"
            )
            cForm.Show()
        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace