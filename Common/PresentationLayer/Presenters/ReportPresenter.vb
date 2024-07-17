Imports System.Globalization
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
            'Dim crViewerForm As New CrViewer(reportFileName, reportTitle, cFormCulture, args)
            Dim crViewerForm As New CrViewer(reportFileName, args, dbConnectionName)
            'Dim prPresenter As New PrintReportPresenter()
            'prPresenter.ViewReport(crViewerForm, dbConnectionName)
            crViewerForm.Show()
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub


        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New Object() {"PrintJob", "PrintJobIdNo", Nothing, Nothing},
                                    New Object() {"ReportGroup", "ReportGroupIdNo", Nothing}})
        End Sub


        'Protected Overrides Sub CreateDataSources()
        '    Dim data As New ArrayList
        '    data.Add({"PrintJob", "PrintJobIdNo", Nothing, Nothing})
        '    data.Add({"PrintJob", "PrintJobIdNo", Nothing, Nothing})
        '    CreateControlDataSources(data)
        'End Sub

        'Protected Sub GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As T 
        '    Service.Presenter.GetRecordFieldWithKeyG(Of Date)("LastFiscalYearEnd", "LastPosting", "TransactionName", "lastPostingDate")
        'End Sub


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