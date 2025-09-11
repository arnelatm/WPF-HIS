Imports System.Text.RegularExpressions
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.DataLayer
Imports AATM.Libraries
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Presentation.Events

Namespace PresentationLayer.Presenters

    Public Class IbLabSamplePresenter(Of TM As New)
        Inherits CommonPresenter(Of IIbLabSampleView, TM)

        Private _ibLabSampleDetailDao
        Private _connectionName As String

        Public Sub New(connectionName As String)
            _ibLabSampleDetailDao = New IbLabSampleDetailDao(connectionName)
            _connectionName = connectionName
        End Sub

        Public Sub New(itemView As IIbLabSampleView, connectionName As String)
            MyBase.New(itemView)
            _connectionName = connectionName
            _ibLabSampleDetailDao = New IbLabSampleDetailDao(_connectionName)
            Service = New AccountsService("IbLabSample")
            Service.SaveConnectionString()
            Service.SetConnectionString(_connectionName)
            TableName = "IbLabSampleList_View"
            SortOrderKey = ""
            'Service.RestoreConnectionString()
            WithTreeView = False
            AddHandler View.IbLabSamplesRequested, AddressOf GetIbLabSamples
            AddHandler View.IbLabSampleChanged, AddressOf UpdateLabSample


            'AddHandler View.DataChanged, AddressOf UpdateData
            'AddHandler View.GetPmrDataAccessRequested, AddressOf GetPMRDataAccess
        End Sub

        Public Sub UpdateLabSample(bindingSource As BindingSource)
            With bindingSource.Current
                With bindingSource.Current
                    If .IdNo < 0 Then
                        AddNewRecord(bindingSource.Current)
                    Else
                        _ibLabSampleDetailDao.UpdateRecord(.idNo, .urine, .stool, .Rbs)
                    End If
                End With
            End With
        End Sub

        Private Sub GetIbLabSamples(transactionDate As Date?)
            UpdateData()
        End Sub

        Protected Overrides Sub CreateDataSources()
            Service.SaveConnectionString()
            Service.SetConnectionString($"ISPDATA")
            Service.RestoreConnectionString()
        End Sub

        Private Sub UpdateData()
            Dim IbLabSampleModel As New IbLabSampleModel
            If String.IsNullOrEmpty(View.TransactionDate) Then
                IbLabSampleModel = Nothing
            Else
                IbLabSampleModel = Service.GetParametrized(Of IbLabSampleModel)({View.TransactionDate})
            End If
            GlobalVariables.Mapper.Map(IbLabSampleModel, View)
        End Sub

        Private Sub AddNewRecord(item As IbLabSampleDetailView)
            If item.IdNo <= 0 Then
                Dim newIdNo As Int32 = _ibLabSampleDetailDao.AddRecord(item.InvoiceNo, item.Urine, item.Stool, item.Rbs, item.LabNo, item.TakenBy, item.TakenDate.ToString("dd/MM/yyyy"), Right(item.TakenTime, 8))
                item.IdNo = newIdNo
            End If
        End Sub

        Public Overrides Sub GoPrintRecord()
            If View.TransactionDate Is Nothing Then
                AATM.Libraries.Messaging.MessagingService.Show(True, "MsgDateCannotBeBlank")
            Else
                Dim reportArgs As New CrPrintableArgs
                Dim reportParameters As New Object
                Dim dateString As String
                Dim tempDate As DateTime = View.TransactionDate.Value
                dateString = tempDate.ToString("yyyy/MM/dd")
                Dim reportTitle As String = AATM.Libraries.Messaging.MessagingService.TranslateCaption("Diagnostic Test Samples Taken Report for ") + dateString
                reportArgs.ReportParameters = {dateString, "TransactionDate",
                                               GlobalVariables.EstablishmentName, "EstablishmentName",
                                               reportTitle, "ReportTitle"}
                reportArgs.DataBaseConnectionName = _connectionName
                Dim reportFileName As String = "IB Lab Sample Daily Report.Rpt"
                Dim rpPresenter = New PrintReportPresenter(Of ReportModel)
                rpPresenter.ViewReport(reportFileName, reportArgs, False)

            End If

        End Sub


    End Class

    Public Class IbLabResultPresenter(Of TM As New)
        Inherits CommonPresenter(Of IIbLabResultView, TM)
        'Implements ISubscriber(Of DgvItemsChanged)

        Private _ibLabResultDetailDao
        Private _connectionName As String
        Private _testType As String

        Public Sub New()

        End Sub


        Public Sub New(itemView As IIbLabResultView, parameter As Object)
            MyBase.New(itemView)
            _connectionName = parameter(0)
            _testType = parameter(1)
            _ibLabResultDetailDao = New IbLabResultDetailDao(parameter)
            Service = New AccountsService("IbLabResult")
            Service.SaveConnectionString()
            Service.SetConnectionString(_connectionName)
            TableName = "IbLabResultList_View"
            SortOrderKey = ""
            'Service.RestoreConnectionString()
            WithTreeView = False
            AddHandler View.IbLabResultRequested, AddressOf GetIbLabResults
            AddHandler View.IbLabResultChanged, AddressOf UpdateLabResult
            AddHandler View.FillUpButtonClicked, AddressOf OnFillUpButtonClicked


            'AddHandler View.DataChanged, AddressOf UpdateData
            'AddHandler View.GetPmrDataAccessRequested, AddressOf GetPMRDataAccess
        End Sub

        Private Sub OnFillUpButtonClicked()
            For Each item As IbLabResultDetailView In View.IbLabResultDetails
                Dim pregnancy As Boolean? = SetDefaultPregnancyValue(item.Gender)
                item.Clinical = True
                item.XRay = True
                item.TBSputum = True
                item.HIVEliza = True
                item.HCVEliza = True
                item.HBSAgEliza = True
                item.Malaria = True
                item.VDRL = True
                item.Widal = True
                item.BilharziasisStool = True
                item.BilharziasisUrine = True
                item.Shigella = True
                item.Cholera = True
                item.Pregnancy = pregnancy
                AddNewRecord(item)
            Next
            UpdateData()
        End Sub

        Private Sub AddNewRecord(item As IbLabResultDetailView)
            If item.IdNo <= 0 Then

                Dim newIdNo As Int32 = _ibLabResultDetailDao.AddRecord(item.InvoiceNo, item.PassportNumber, item.Clinical, item.XRay, item.TBSputum,
                              item.HIVEliza, item.HCVEliza, item.HBSAgEliza, item.Malaria, item.VDRL, item.Widal, item.Pregnancy, item.BilharziasisUrine,
                              item.BilharziasisStool, item.Shigella, item.Cholera)
                item.IdNo = newIdNo
            End If
        End Sub

        Private Shared Function SetDefaultPregnancyValue(gender As Char?) As Boolean?
            Dim pregnant As Boolean?
            If gender = "F" Then
                pregnant = True
            ElseIf gender = "M" Then
                pregnant = False
            Else
                pregnant = False
            End If
            Return pregnant
        End Function

        Private Function Approve(value As Boolean?) As Boolean?
            If value.HasValue = True Then
                If value Then
                    value = True
                Else
                    value = Nothing
                End If
            Else
                value = False
            End If
            Return value
        End Function

        Public Sub UpdateLabResult(bindingSource As BindingSource)
            With bindingSource.Current
                If .IdNo < 0 Then
                    AddNewRecord(bindingSource.Current)
                Else
                    _ibLabResultDetailDao.UpdateRecord(.IdNo, .passportNumber, .clinical, .Xray, .TBSputum,
                                                   .hivEliza, .HCVEliza, .hbsagEliza, .malaria,
                                                   .vdrl, .Widal, .pregnancy, .bilharziasisUrine,
                                                   .bilharziasisStool, .shigella, .cholera)

                End If
            End With
        End Sub

        'Public Function SetActualValue(displayValue As Boolean?) As Boolean?
        '    If displayValue.HasValue Then
        '        If displayValue Then
        '            Return True
        '        Else
        '            Return Nothing
        '        End If
        '    Else
        '        Return False
        '    End If
        'End Function

        Private Sub GetIbLabResults(transactionDate As Date?)
            UpdateData()
        End Sub

        Private Function ActualValue(value As Boolean?) As Boolean?
            If value.HasValue Then
                If value Then
                    Return True
                Else
                    Return Nothing
                End If
            Else
                Return False
            End If
        End Function

        Protected Overrides Sub CreateDataSources()
            Service.SaveConnectionString()
            Service.SetConnectionString($"ISPDATA")
            Service.RestoreConnectionString()
        End Sub

        Private Sub UpdateData()
            Dim IbLabResultModel As New IbLabResultModel
            If String.IsNullOrEmpty(View.TransactionDate) Then
                IbLabResultModel = Nothing
            Else
                IbLabResultModel = Service.GetParametrized(Of IbLabResultModel)({View.TransactionDate, _testType, _connectionName})
            End If
            GlobalVariables.Mapper.Map(IbLabResultModel, View)
        End Sub

        Public Overrides Sub GoPrintRecord()
            If View.TransactionDate Is Nothing Then
                AATM.Libraries.Messaging.MessagingService.Show(True, "MsgDateCannotBeBlank")
            Else
                Dim reportArgs As New CrPrintableArgs
                Dim reportParameters As New Object
                Dim dateString As String
                Dim tempDate As DateTime = View.TransactionDate.Value
                Dim ibType As String = IIf(_testType = "Iqama", "1", "2")
                dateString = tempDate.ToString("yyyy/MM/dd")
                Dim reportTitle As String = AATM.Libraries.Messaging.MessagingService.TranslateCaption("Diagnostic Test Samples Taken Report for ") + dateString
                reportArgs.ReportParameters = {dateString, "TransactionDate",
                                               GlobalVariables.EstablishmentName, "EstablishmentName",
                                               reportTitle, "ReportTitle",
                                               ibType, "IbType"}
                reportArgs.DataBaseConnectionName = _connectionName
                Dim reportFileName As String = "IB Lab Result Daily Report.Rpt"
                Dim rpPresenter = New PrintReportPresenter(Of ReportModel)
                rpPresenter.ViewReport(reportFileName, reportArgs, False)

            End If

        End Sub

        'Public Sub OndgvItemsChangedEventHandler(ByRef eventType As DgvItemsChanged) Implements ISubscriber(Of DgvItemsChanged).OnEventHandler
        '    With eventType.BindingSource
        '        If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
        '            Dim gender = eventType.BindingSource.Current.Gender
        '            Select Case eventType.PropertyName
        '                Case $"Pregnancy"
        '                    If gender = "M" Then
        '                        Beep()
        '                        eventType.BindingSource.Current.Pregnancy = Nothing
        '                        'eventType.BindingSource.ResetItem(eventType.Row)
        '                    End If
        '                    'If bsIbLabResultDetails.Current.Gender = "M" Then
        '                    '        Beep()
        '                    '        e.Cancel = True
        '                    '        DataGridViewIbLabResultDetails.EndEdit()
        '                    '    End If
        '                    'End If
        '                    '    MakePayTypeAndSpecialAccount(eventType.BindingSource.Current, accountId)
        '                    '    View.VatAmount = UpdateInputVatAmount(View.JournalItems)
        '                    '    eventType.BindingSource.ResetItem(eventType.Row)
        '                    'Case $"Debit"
        '                    '    MakeDebitAmount(eventType.BindingSource.Current, eventType.BindingSource.Current.Debit)
        '                    '    eventType.BindingSource.ResetItem(eventType.Row)
        '                    '    View.VatAmount = UpdateInputVatAmount(View.JournalItems)
        '                    'Case $"Credit"
        '                    '    MakeCreditAmount(eventType.BindingSource.Current, eventType.BindingSource.Current.Credit)
        '                    '    eventType.BindingSource.ResetItem(eventType.Row)
        '                    '    View.VatAmount = UpdateInputVatAmount(View.JournalItems)
        '            End Select
        '        End If
        '    End With
        'End Sub

    End Class

End Namespace