Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports System.Reflection

Namespace PresentationLayer.Presenters

    Public Class ReportSelectorPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IReportSelectorView, TM)

        'Private ReadOnly _journalItemService
        'Private ReadOnly _ReportIdsService

        Public Sub New(view As IReportSelectorView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("Report")
            TableName = "Report"
            SortOrderKey = "ReportName"
            AskBeforeSave = True
            DisableSaveMemento = True
            AddHandler view.ReportDoubleClickEvent, AddressOf OnReportDoubleClickEvent

        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim reportList As List(Of ReportModel) = Service.GetList(Of ReportModel)
            GlobalVariables.Mapper.Map(reportList, View.ReportList)
        End Sub

        'Private Sub OnReportIdCheckedEvent(sender As Object)
        '    sender.Print = Not sender.Print
        'End Sub

        Public Overrides Sub GoPrintRecord()
            'Dim transactionNumber As Int32
            'transactionNumber = Service.GetNextSeries("ReportSelectorSeries")
            Dim dtIdPrinting As New DataTable
            CreateDataTable(dtIdPrinting, {{"ReportIdNo", GetType(Int32)},
                                           {"TransactionNumber", GetType(Int32)}
                                           })
            'For Each Report As IReportView In View.ReportIdList
            '    Dim workRow As DataRow
            '    workRow = dtIdPrinting.NewRow()
            '    workRow("ReportIdNo") = Report.IdNo
            '    workRow("TransactionNumber") = transactionNumber
            '    dtIdPrinting.Rows.Add(workRow)
            'Next
            'Dim retVal = Service.ExecuteTvpSp("InsertReportSelectorTvp", dtIdPrinting)
            Dim cForm
            cForm = New ReportForm(View.ReportFileName)
            cForm.Show()
        End Sub

        Public Sub OnReportDoubleClickEvent(idNo As Int16)
            Dim report As ReportModel = Service.GetRecordByIdNo(Of ReportModel)(idNo)

            Dim parameters As New ArrayList

            parameters.Add(report.ReportFileName)
            parameters.Add("ReportTitle")
            parameters.Add(Messaging.TranslateCaption(report.ReportTitle))

            Dim queryForm As String = report.QueryForm
            Dim f As Form = FormFunctions.GetFormByName(queryForm, parameters)
            f.Show()

        End Sub

    End Class



    Public Class FormFunctions
        Public Shared Function GetFormByName(ByVal FormName As String) As Form
            'first try: in case the full namespace has been provided (as it should ;-) )
            Dim T As Type = Type.GetType(FormName, False)
            'if not found, search for it
            If T Is Nothing Then T = FindType(FormName)
            'if still not found, throw exception
            If T Is Nothing Then Throw New Exception(FormName + " could not be found")
            Return CType(Activator.CreateInstance(T), Form)
        End Function

        Public Shared Function GetFormByName(ByVal FormName As String, parameter As ArrayList) As Form
            'first try: in case the full namespace has been provided (as it should ;-) )
            Dim T As Type = Type.GetType(FormName, False)
            'if not found, search for it
            If T Is Nothing Then T = FindType(FormName)
            'if still not found, throw exception
            If T Is Nothing Then Throw New Exception(FormName + " could not be found")
            Return CType(Activator.CreateInstance(T, parameter), Form)
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


