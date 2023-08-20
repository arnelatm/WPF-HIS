Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters

Public Class HRReportsPresenter(Of TM As New)
    Inherits AccountsPresenter(Of IHrReportsView, TM)

    Private _period As String

    Public Sub New()
    End Sub

    Public Sub New(view As IHrReportsView)
        MyBase.New(view)
        TableName = "Employee"
        WithTreeView = False
        Service = New AccountsService("Employee")
        AddHandler view.PrintButtonClicked, AddressOf OnPrintButtonClicked
        AddHandler view.FormLoaded, AddressOf OnFormLoaded
    End Sub

    Private Function OnFormLoaded() As Object
        Dim showAll As Boolean = False
        If UserHasAccess("HumanResources") Then
            CreateDataSource("Employee", View.EmployeeSelectorControl)
        Else
            Dim employeeIdNo = GetUserEmployeeIdNo()
            If IsUserASupervisor() Then
                CreateDataSource("Employee", View.EmployeeSelectorControl, "SupervisorIdNo = " & employeeIdNo.ToString() & " or IdNo = " & employeeIdNo.ToString())
            Else
                CreateDataSource("Employee", View.EmployeeSelectorControl, "IdNo = " & employeeIdNo.ToString())
            End If
        End If
    End Function


    Public Sub OnPrintButtonClicked()
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        Dim estName As String
        If View.Language = "ar" Then
            estName = GlobalVariables.EstablishmentNameAra
        Else
            estName = GlobalVariables.EstablishmentName
        End If
        Dim reportTitle As String
        Dim reportArgs As New CrPrintableArgs
        Dim reportName As String = View.ReportName
        reportTitle = reportName
        reportArgs.Language = View.Language
        reportArgs.ReportFileName = View.ReportFileName
        reportArgs.ReportParameters = {reportTitle, "ReportTitle",
                                           View.EmployeeIdNo, "EmployeeIdNo",
                                           View.Language, "Language",
                                           View.EmployeeIdNo, "EmployeeIdNo",
                                           estName, "EstablishmentName"}
        Dim p As New PrintReportPresenter(Of EmployeeModel)
        p.ViewReport(reportArgs.ReportFileName, reportArgs, False)
        CultureInfo.CurrentCulture = curCulture

    End Sub


End Class


