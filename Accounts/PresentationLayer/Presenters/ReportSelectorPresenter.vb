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

        Public Sub New(pView As IReportSelectorView)
            MyBase.New(pView)
            View = pView
            Service = New CommonService("Report")
            TableName = "Report"
            AddHandler View.PrintReportEvent, AddressOf OnPrintReportEvent
            AddHandler View.SelectedReportGroupChangedEvent, AddressOf OnSelectedGroupChangedEvent
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

        Public Sub OnSelectedGroupChangedEvent(ByRef bsReportGroupList As BindingSource, ByRef bsReportList As BindingSource)
            Dim reportGroupIdNo As Int32 = GetReportGroupIdNo(bsReportGroupList)
            Dim reportList As List(Of ReportModel) = Service.GetListParametrized(Of ReportModel)(reportGroupIdNo)
            GlobalVariables.Mapper.Map(reportList, View.ReportList)
            bsReportList.DataSource = View.ReportList
            bsReportList.ResetBindings(False)
        End Sub

        Public Sub OnPrintReportEvent(bsReportList As BindingSource)
            Dim reportIdNo = bsReportList.Current.IdNo
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

        Private Function GetReportGroupIdNo(bsReportGroupList As BindingSource) As Integer
            Dim selectedReportIdNo As Int16 = 0
            If bsReportGroupList.Current Is Nothing Then
                Debugger.Break()
            Else
                selectedReportIdNo = bsReportGroupList.Current.IdNo
            End If
            Return selectedReportIdNo
        End Function

    End Class

End Namespace