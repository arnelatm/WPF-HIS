Imports System.Globalization
Imports System.Reflection
Imports AATM.Accounts.Accounts.PresentationLayer.Views.Forms
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters.Views.Forms
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class ReportSelectorPresenter(Of TM As New)
        Inherits CommonPresenter(Of IReportSelectorView, TM)

        Private _reportGroupCode As String

        Public Sub New(view As IReportSelectorView, reportGroupCode As String)
            MyBase.New(view)
            WithTreeView = False
            Service = New CommonService("Report")
            TableName = "Report"
            SortOrderKey = "ReportName"
            AskBeforeSave = True
            DisableSaveMemento = True
            _reportGroupCode = reportGroupCode
            AddHandler view.ReportDoubleClickEvent, AddressOf OnReportDoubleClickEvent
            AddHandler view.ReportGroupDoubleClickEvent, AddressOf OnReportGroupDoubleClickEvent
        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim reportGroupList As List(Of ReportGroupModel) = Service.GetList(Of ReportGroupModel)
            GlobalVariables.Mapper.Map(reportGroupList, View.ReportGroupList)
            Dim selectedGroup = reportGroupList.Find(Function(rg) rg.ReportGroupCode = _reportGroupCode)
            If selectedGroup Is Nothing AndAlso reportGroupList.Count > 0 Then
                selectedGroup = reportGroupList(0)
            End If

            If selectedGroup IsNot Nothing Then
                UpdateReportList(selectedGroup.IdNo)
            End If
        End Sub

        Private Sub UpdateReportList(reportGroupIdNo As Int16)
            Dim reportList As List(Of ReportModel) = Service.GetListParametrized(Of ReportModel)(reportGroupIdNo)
            GlobalVariables.Mapper.Map(reportList, View.ReportList)
        End Sub

        Public Overrides Sub GoPrintRecord()
            'Dim dtIdPrinting As New DataTable
            'CreateDataTable(dtIdPrinting, {{"ReportIdNo", GetType(Int32)},
            '                               {"TransactionNumber", GetType(Int32)}
            '                               })
            Dim cForm
            cForm = New ReportForm(View.ReportFileName)
            cForm.Show()
        End Sub

        Public Sub OnReportGroupDoubleClickEvent(reportGroupIdNo As Int16)
            Dim reportList As List(Of ReportModel) = Service.GetListParametrized(Of ReportModel)(reportGroupIdNo)
            'Dim reportGroupList As List(Of ReportGroupModel) = Service.GetList(Of ReportGroupModel)
            GlobalVariables.Mapper.Map(reportList, View.ReportList)
        End Sub

        Public Sub OnReportDoubleClickEvent(reportIdNo As Int16)
            Dim report As ReportModel = Service.GetRecordByIdNo(Of ReportModel)(reportIdNo)
            Dim queryForm As String = If(report.QueryForm, "")
            report.ReportFileName = IIf(Strings.Right(report.ReportFileName, 4).ToLower() = $".rpt", report.ReportFileName, report.ReportFileName + ".rpt")
            'Dim formToRun As Form= Activator.CreateInstance(GetType(DocumentEntryTv))
            'Dim pType As Type
            'formToRun.Presenter = Activator.CreateInstance(pType, {formToRun})
            'formToRun.AddOnOpen = True
            'formToRun.QuitOnSave = True
            'formToRun.Show()
            Select Case queryForm.Trim()
                Case "ContactDateRangeForm"
                    Dim formToRun As New ContactDateRangeForm(report)
                    formToRun.Presenter = New ContactDateRangePresenter(Of ReportModel)(formToRun, report)
                    formToRun.Show()
                Case "DateRangeForm"
                    Dim formToRun As New DateRangeForm(report)
                    formToRun.Presenter = New DateRangePresenter(Of ReportModel)(formToRun, report)
                    formToRun.Show()
                Case "DateTimeRangeForm"
                    Dim formToRun As New DateTimeRangeForm(report)
                    formToRun.Presenter = New DateTimeRangePresenter(Of ReportModel)(formToRun, report)
                    formToRun.Show()
                Case Else
                    Dim fileName As String = report.ReportFileName
                    If Not fileName.ToLower().EndsWith(".rpt") Then fileName &= ".rpt"

                    Dim reportArgs As New CrPrintableArgs
                    'reportTitle = Libraries.MessagingLibrary.Messaging.SelectReportName(_reportModel.ReportTitle, beginningDate, endingDate, curCulture, "T")
                    'If _reportModel.QueryParameters IsNot Nothing AndAlso _reportModel.QueryParameters <> "" Then
                    '    Dim qParameters As String = _reportModel.QueryParameters
                    '    Dim lParameters As String() = qParameters.Split(","c)
                    '    For Each item In lParameters
                    '        reportArgs.ReportParameters.Add(item)
                    '    Next
                    'End If
                    If report.DatabaseName = "" Then
                        reportArgs.DataBaseConnectionName = "Kizen" ' _reportModel.DatabaseName
                    Else
                        reportArgs.DataBaseConnectionName = report.DatabaseName
                    End If

                    Dim p As New PrintReportPresenter(Of AccountModel)
                    p.ViewReport(fileName, reportArgs, False)


                    'Dim fullPath As String = If(IO.Path.IsPathRooted(fileName), fileName, IO.Path.Combine(Application.StartupPath, fileName))

                    'If Not IO.File.Exists(fullPath) Then
                    '    MessageBox.Show("Report file not found: " & fullPath)
                    '    Return
                    'End If

                    'Dim rptDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                    'rptDoc.Load(fullPath)

                    'Dim frm As New Form()
                    'Dim viewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer()
                    'viewer.Dock = DockStyle.Fill
                    'viewer.ReportSource = rptDoc
                    'frm.Controls.Add(viewer)
                    'frm.Text = If(String.IsNullOrEmpty(report.ReportName), IO.Path.GetFileNameWithoutExtension(fullPath), report.ReportName)

                    'AddHandler frm.FormClosed, Sub(s, e)
                    '                               Try
                    '                                   rptDoc.Close()
                    '                                   rptDoc.Dispose()
                    '                               Catch
                    '                               End Try
                    '                           End Sub

                    'frm.Show()
            End Select

        End Sub

    End Class

    Public Class FormFunctions

        Public Shared Function GetFormByName(ByVal formName As String) As Form
            Dim T As Type = GetFormObjectByName(formName)
            Return CType(Activator.CreateInstance(T), Form)
        End Function

        Private Shared Function GetFormObjectByName(formName As String) As Type
            'first try: in case the full namespace has been provided (as it should ;-) )
            Dim T As Type = Type.GetType(formName, False)
            'if not found, search for it
            If T Is Nothing Then T = FindType(formName)
            'if still not found, throw exception
            If T Is Nothing Then Throw New Exception(formName + " could not be found")
            Return T
        End Function

        'Public Shared Function GetFormByName(ByVal formName As String, parameter As ArrayList) As Form
        '    Dim T As Type = GetFormObjectByName(formName)
        '    Return CType(Activator.CreateInstance(T, parameter), Form)
        'End Function

        Public Shared Function GetFormByName(ByVal formName As String, report As ReportModel) As Form
            Dim T As Type = GetFormObjectByName(formName)
            Return CType(Activator.CreateInstance(T, report), Form)
        End Function

#Region "Assemblies and types"

        Public Shared Function GetAllAssemblies() As ArrayList
            Dim al As New ArrayList
            Dim a As [Assembly] = [Assembly].GetEntryAssembly()
            FillAssemblies(a, al)
            Return al
        End Function

        Private Shared Sub FillAssemblies(ByVal a As [Assembly], ByVal al As ArrayList)
            If Not al.Contains(a) Then
                al.Add(a)
                Dim an As AssemblyName
                For Each an In a.GetReferencedAssemblies()
                    If Not an.Name.StartsWith("System") Then FillAssemblies([Assembly].Load(an), al)
                Next
            End If
        End Sub

        Public Shared Function GetAllTypes() As ArrayList
            Dim a As [Assembly], t As Type, al As New ArrayList
            For Each a In GetAllAssemblies()
                For Each t In a.GetTypes
                    If Not al.Contains(t) Then al.Add(t)
                Next
            Next
            Return al
        End Function

        Public Shared Function FindType(ByVal Name As String) As Type
            Dim T As Type
            For Each T In GetAllTypes()
                If T.Name = Name Then Return T
            Next
            Return Nothing
        End Function

#End Region

    End Class

    'example call:
    'Dim f As Form = FormFunctions.GetFormByName("Form1")
    'f.Show()

End Namespace
