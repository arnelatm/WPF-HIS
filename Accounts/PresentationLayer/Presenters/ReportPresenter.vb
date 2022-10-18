Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.BusinessLayer
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.PresentationLayer.Forms
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class ReportPresenter
        Inherits AccountsPresenter(Of IView, AccountModel)
        Implements ISubscriber(Of ShowReportRequested)

        Public Sub New(view As IView)
            MyBase.New(view)
            TableName = "Account"
            Service = New AccountsService("Account")
            TableName = "Account"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

        Public Sub ShowReport(reportFileName As String, reportTitle As String, cFormCulture As CultureInfo, printJobName As String, dbConnectionName As String, args As Array)
            Dim crViewerForm As New CrViewer(reportFileName, reportTitle, cFormCulture, args)
            Dim pjPresenter As New PrintJobPresenter()
            pjPresenter.ViewReport(crViewerForm, printJobName, dbConnectionName)
            crViewerForm.Show()
        End Sub

        Public Sub OnShowReportRequested(ByRef eventType As ShowReportRequested) Implements ISubscriber(Of ShowReportRequested).OnEventHandler
            ShowReport(eventType.reportFileName, eventType.reportTitle, eventType.FormCulture, eventType.PrintJobName, eventType.DbConnName, eventType.Args)
        End Sub
    End Class

    Public Class DateRangeCompanyPresenter
        Inherits AccountsPresenter(Of IView, AccountModel)

        Public Sub New(view As IView)
            MyBase.New(view)
            TableName = "Account"
            Service = New AccountsService("Account")
            TableName = "Account"
            SortOrderKey = "IdNo"
            WithTreeView = False
            Service.SaveConnectionString()
            Service.SetConnectionString("IGROUPCLINIC")
            CreateLookupData("InsuranceDetails", "InsuranceList", {"InsuranceId", "NameEnglish"}, "NameEnglish", Nothing)
            Service.RestoreConnectionString()
        End Sub

    End Class

End Namespace

Public Class ShowReportRequested

    Public Sub New(reportfileName As String, reportTitle As String, cFormCulture As CultureInfo, printJobName As String, dbConnName As String, args As Array)
        Me.reportFileName = reportfileName
        Me.reportTitle = reportTitle
        Me.FormCulture = cFormCulture
        Me.PrintJobName = printJobName
        Me.DbConnName = dbConnName
        Me.Args = args
    End Sub

    Public Property reportFileName As String
    Public Property reportTitle As String
    Public Property FormCulture As CultureInfo
    Public Property PrintJobName As String
    Public Property DbConnName As String
    Public Property Args As Array

End Class