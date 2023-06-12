Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class TransactionSummary

        Public Property MainTableName As String
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
            Dim language As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))

            Dim valid As Boolean = True
            If dtpBeginningDate.Value Is Nothing Or dtpBeginningDate.Value Is Nothing Then
                Messaging.Show(True, "MsgDatesCannotBeEmpty")
                valid = False
            ElseIf dtpBeginningDate.Value > dtpEndingDate.Value Then
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
                valid = False
            End If
            If valid Then
                Dim reportTitle As String
                Dim currentCulture As CultureInfo = CultureInfo.CurrentUICulture
                reportTitle = Messaging.TranslateCaption("Transaction Summary Report")
                Dim cForm As New ReportFormNew("Transaction Summary Report.Rpt", reportTitle, currentCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate")
                cForm.Show()
            End If
            CultureInfo.CurrentCulture = curCulture

        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub CButton1_ClickButtonArea_1(Sender As Object, e As MouseEventArgs) Handles btnTranslate.ClickButtonArea
            RunTranslator(VSystemViewIdNo)
        End Sub

    End Class

End Namespace