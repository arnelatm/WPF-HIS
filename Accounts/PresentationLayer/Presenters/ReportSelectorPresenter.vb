Imports AATM.Accounts.Accounts.PresentationLayer.Views.Forms
Imports AATM.Accounts.PresentationLayer.Presenters.Views.Forms
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.GlobalFuncNSub
Imports System.Reflection
Imports Telerik.WinControls.VirtualKeyboard

Namespace PresentationLayer.Presenters

    Public Class ReportSelectorPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IReportSelectorView, TM)

        Private _reportGroupCode As String

        Public Sub New(view As IReportSelectorView, reportGroupCode As String)
            MyBase.New(view)
            Service = New CommonService("Report")
            TableName = "Report"
            _reportGroupCode = reportGroupCode
            AddHandler view.ReportDoubleClickEvent, AddressOf OnReportDoubleClickEvent
            AddHandler view.ReportGroupClickEvent, AddressOf OnReportGroupClickEvent
            view.BsReportGroup = New BindingSource
            CreateDataSources()
        End Sub

        Private Sub CreateDataSources()
            Dim reportGroupList As List(Of ReportGroupModel) = Service.GetList(Of ReportGroupModel)
            GlobalVariables.Mapper.Map(reportGroupList, View.ReportGroupList)
            If reportGroupList.Count() > 0 Then
                UpdateReportList(reportGroupList.Item(0).IdNo)
            End If
            View.BsReportGroup.DataSource = View.ReportGroupList
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

        Public Sub OnReportGroupClickEvent(reportGroupIdNo As Int16)
            Dim reportList As List(Of ReportModel) = Service.GetListParametrized(Of ReportModel)(reportGroupIdNo)
            GlobalVariables.Mapper.Map(reportList, View.ReportList)
        End Sub

        Public Sub OnReportDoubleClickEvent(reportIdNo As Int16)
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