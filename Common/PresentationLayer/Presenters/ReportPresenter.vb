Imports System.Globalization
Imports AATM.Common.BusinessLayer
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.PresentationLayer.Forms
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class ReportPresenter(Of TM As New)
        Inherits CommonPresenter(Of IReportView, TM)
        Implements ISubscriber(Of ShowReportRequested)

        Public Sub New(view As IView)
            MyBase.New(view)
            TableName = "Report"
            Service = New CommonService("Report")
            TreeViewMainField = "ReportName"
            SortOrderKey = "ReportName"
            WithTreeView = True
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Sub OnShowReportRequested(ByRef eventType As ShowReportRequested) Implements ISubscriber(Of ShowReportRequested).OnEventHandler
            ShowReport(eventType.reportFileName, eventType.reportTitle, eventType.FormCulture, eventType.DbConnName, eventType.Args)
        End Sub

        Public Sub ShowReport(reportFileName As String, reportTitle As String, cFormCulture As CultureInfo, dbConnectionName As String, args As Object)
            Dim crViewerForm As New CrViewer(reportFileName, reportTitle, cFormCulture, args)
            'Dim prPresenter As New PrintReportPresenter()
            'prPresenter.ViewReport(crViewerForm, dbConnectionName)
            crViewerForm.Show()
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub


        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"PrintJob", "PrintJobIdNo", Nothing, Nothing})
            CreateDataSourceThread(data)
        End Sub

    End Class

    Public Class DateRangeCompanyPresenter
        Inherits CommonPresenter(Of IView, ReportModel)

        Public Sub New(view As IView)
            MyBase.New(view)
            TableName = "Account"
            Service = New CommonService("Report")
            TableName = "Account"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

    End Class

End Namespace

Public Class ShowReportRequested

    Public Sub New(reportFileName As String, reportTitle As String, cFormCulture As CultureInfo, dbConnName As String, args As Array)
        Me.reportFileName = reportFileName
        Me.reportTitle = reportTitle
        Me.FormCulture = cFormCulture
        Me.DbConnName = dbConnName
        Me.Args = args
    End Sub

    Public Property reportFileName As String
    Public Property reportTitle As String
    Public Property FormCulture As CultureInfo
    Public Property DbConnName As String
    Public Property Args As Array

End Class