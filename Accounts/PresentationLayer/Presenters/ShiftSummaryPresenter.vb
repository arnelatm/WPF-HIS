Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class ShiftSummaryPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IShiftSummaryView, TM)


        Public userCanEdit As Boolean = False

        Public Sub New(itemView As IShiftSummaryView)
            MyBase.New(itemView)
            Service = New AccountsService("ShiftSummary")
            TableName = "ShiftSummary"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("VUser", "UserIdNo")
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            Dim time = Today
            View.DateStart = time
            View.DateEnd = time
            Dim employeeIdNo As Int32 = Service.GetUserEmployeeIdNo()
            View.UserIdNo = GlobalVariables.UserIdNo
        End Sub

        Public Overrides Sub GoPrintRecord()
            Dim reportTitle = Messaging.TranslateCaption("Shift Summary Report")
            Dim language As String
            Dim curCulture = CultureInfo.CurrentCulture
            Dim establishmentName As String
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))

            If language <> "ar" Then
                establishmentName = GetRecordField("Establishment", "EstablishmentName")
            Else
                establishmentName = GetRecordField("Establishment", "EstablishmentNameAra")
            End If

            Dim cForm As New ReportForm("Shift Summary Report.Rpt", View.IdNo.ToString(), "TransactionIdNo", reportTitle, "ReportTitle", language, "Language", establishmentName, "EstablishmentName", reportTitle, "ReportTitle")
            cForm.Show()
        End Sub

        Public Overrides Sub EntryFormLoaded()
            If UserHasAccess("ShiftMaintenance") Then
                userCanEdit = True
            Else
                Dim control As Control = Nothing
                Dim x = MainFieldsDictionary
                If MainFieldsDictionary.TryGetValue("UserIdNo", control) Then
                    CallByName(control, "DisplayOnly", CallType.Set, True)
                End If
            End If
        End Sub

        Public Overrides Function IsOkToEditRecord() As Boolean
            If userCanEdit Then
                Return True
            End If
            Return false
        End Function

    End Class

End Namespace