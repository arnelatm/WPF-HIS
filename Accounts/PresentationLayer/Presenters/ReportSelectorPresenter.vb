Imports AATM.Accounts.Accounts.PresentationLayer.Views.Forms
Imports AATM.Accounts.PresentationLayer.Presenters.Views.Forms
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class ReportSelectorPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IReportSelectorView, TM)

        Public Sub New(view As IReportSelectorView)
            MyBase.New(view)
            Service = New CommonService("Report")
            TableName = "Report"
            AddHandler view.PrintReportEvent, AddressOf OnPrintReportEvent
            AddHandler view.SelectedReportGroupChangedEvent, AddressOf OnSelectedReportGroup
            CreateDataSources()
        End Sub

        Private Sub CreateDataSources()
            Dim reportGroupList As List(Of ReportGroupModel) = Service.GetList(Of ReportGroupModel)
            GlobalVariables.Mapper.Map(reportGroupList, View.ReportGroupList)
            If reportGroupList.Count() > 0 Then
                UpdateReportList(reportGroupList.Item(0).IdNo)
            End If
        End Sub

        Private Sub UpdateReportList(reportGroupIdNo As Int16)
            Dim reportList As List(Of ReportModel) = Service.GetListParametrized(Of ReportModel)(reportGroupIdNo)
            GlobalVariables.Mapper.Map(reportList, View.ReportList)
        End Sub

        Private Sub GoPrintRecord()
            Dim cForm
            cForm = New ReportForm(View.ReportFileName)
            cForm.Show()
        End Sub

        Public Sub OnSelectedReportGroup(reportGroupIdNo As Int16)
            Dim reportList As List(Of ReportModel) = Service.GetListParametrized(Of ReportModel)(reportGroupIdNo)
            GlobalVariables.Mapper.Map(reportList, View.ReportList)
        End Sub

        Public Sub OnPrintReportEvent(reportIdNo As Int16)
            Dim report As ReportModel = Service.GetRecordByIdNo(Of ReportModel)(reportIdNo)
            Dim queryForm As String = report.QueryForm
            report.ReportFileName = IIf(Strings.Right(report.ReportFileName, 4).ToLower() = $".rpt", report.ReportFileName, report.ReportFileName + ".rpt")
            If queryForm Is Nothing Then
                MessageBox.Show("Missing QueryForm Parameter on Report")
            Else
                Select Case queryForm
                    Case "ContactDateRangeForm"
                        Dim formToRun As New ContactDateRangeForm(report)
                        formToRun.Presenter = New ContactDateRangePresenter(Of ReportModel)(formToRun, report)
                        formToRun.Show()
                    Case "DateRangeForm"
                        Dim formToRun As New DateRangeForm(report)
                        formToRun.Presenter = New DateRangePresenter(Of ReportModel)(formToRun, report)
                        formToRun.Show()
                End Select

            End If

        End Sub

    End Class

End Namespace