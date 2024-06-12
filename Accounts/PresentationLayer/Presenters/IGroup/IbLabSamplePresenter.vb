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
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Presenters

    Public Class IbLabSamplePresenter(Of TM As New)
        Inherits CommonPresenter(Of IIbLabSampleView, TM)

        Private _ibLabSampleDetailDao As New IbLabSampleDetailDao

        Public Sub New()

        End Sub

        Public Sub New(itemView As IIbLabSampleView)
            MyBase.New(itemView)
            Service = New AccountsService("IbLabSample")
            Service.SaveConnectionString()
            Service.SetConnectionString($"IGROUPCLINIC")
            TableName = "IbLabSampleList_View"
            SortOrderKey = ""
            Service.RestoreConnectionString()
            WithTreeView = False
            AddHandler View.IbLabSamplesRequested, AddressOf GetIbLabSamples
            AddHandler View.IbLabSampleChanged, AddressOf UpdateLabSample


            'AddHandler View.DataChanged, AddressOf UpdateData
            'AddHandler View.GetPmrDataAccessRequested, AddressOf GetPMRDataAccess
        End Sub

        Public Sub UpdateLabSample(bindingSource As BindingSource)
            With bindingSource.Current
                _ibLabSampleDetailDao.UpdateRecord(.idNo, .urine, .stool, .Rbs)
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

        Public Overrides Sub GoPrintRecord()
            If View.TransactionDate Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgDateCannotBeBlank")
            Else
                Dim reportArgs As New CrPrintableArgs
                Dim reportParameters As New Object
                Dim dateString As String
                Dim tempDate As DateTime = View.TransactionDate.Value
                dateString = tempDate.ToString("yyyy/MM/dd")
                Dim reportTitle As String = AATM.Libraries.MessagingLibrary.Messaging.TranslateCaption("Diagnostic Test Samples Taken Report for ") + dateString
                reportArgs.ReportParameters = {dateString, "TransactionDate",
                                               GlobalVariables.EstablishmentName, "EstablishmentName",
                                               reportTitle, "ReportTitle"}
                reportArgs.DataBaseConnectionName = "IGroupClinic"
                Dim reportFileName As String = "IB Lab Sample Daily Report.Rpt"
                Dim rpPresenter = New PrintReportPresenter(Of ReportModel)
                rpPresenter.ViewReport(reportFileName, reportArgs, False)

            End If

        End Sub


    End Class

    Public Class IbLabResultPresenter(Of TM As New)
        Inherits CommonPresenter(Of IIbLabResultView, TM)
        'Implements ISubscriber(Of DgvItemsChanged)

        Private _ibLabResultDetailDao As New IbLabResultDetailDao

        Public Sub New()

        End Sub

        Public Sub New(itemView As IIbLabResultView)
            MyBase.New(itemView)
            Service = New AccountsService("IbLabResult")
            Service.SaveConnectionString()
            Service.SetConnectionString($"IGROUPCLINIC")
            TableName = "IbLabResultList_View"
            SortOrderKey = ""
            Service.RestoreConnectionString()
            WithTreeView = False
            AddHandler View.IbLabResultRequested, AddressOf GetIbLabResults
            AddHandler View.IbLabResultChanged, AddressOf UpdateLabResult
            AddHandler View.FillUpButtonClicked, AddressOf OnFillUpButtonClicked


            'AddHandler View.DataChanged, AddressOf UpdateData
            'AddHandler View.GetPmrDataAccessRequested, AddressOf GetPMRDataAccess
        End Sub

        Private Sub OnFillUpButtonClicked()
            For Each item As IbLabResultDetailView In View.IbLabResultDetails
                If item.IdNo <= 0 Then
                    Dim pregnancy As Boolean?
                    If item.Gender = "F" Then
                        pregnancy = False
                    ElseIf item.Gender = "M" Then
                        pregnancy = Nothing
                    Else
                        pregnancy = False
                    End If
                    _ibLabResultDetailDao.AddRecord(item.TransKey, item.PassportNumber, Approve(item.Clinical), Approve(item.XRay), Approve(item.TBSputum),
                                  Approve(item.HIVEliza), Approve(item.HCVEliza), Approve(item.HBSAgEliza), Approve(item.Malaria), Approve(item.VDRL), Approve(item.Widal), pregnancy,
                                  Approve(item.BilharziasisUrine), Approve(item.BilharziasisStool), Approve(item.Shigella), Approve(item.Cholera))
                End If
            Next
            UpdateData()
        End Sub

        Private Function Approve(value As Boolean?) As Boolean?
            If value.HasValue = True Then
                Return value
            Else
                Return False
            End If
        End Function


        Public Sub UpdateLabResult(bindingSource As BindingSource)
            With bindingSource.Current
                _ibLabResultDetailDao.UpdateRecord(.IdNo, .passportNumber, .clinical, .Xray, .TBSputum, .hivEliza,
                                                   .HCVEliza, .hbsagEliza, .malaria, .vdrl, .Widal, .pregnancy,
                                                   .bilharziasisUrine, .bilharziasisStool, .shigella, .cholera)
            End With
        End Sub

        Private Sub GetIbLabResults(transactionDate As Date?)
            UpdateData()
        End Sub

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
                IbLabResultModel = Service.GetParametrized(Of IbLabResultModel)({View.TransactionDate})
            End If
            GlobalVariables.Mapper.Map(IbLabResultModel, View)
        End Sub

        Public Overrides Sub GoPrintRecord()
            If View.TransactionDate Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgDateCannotBeBlank")
            Else
                Dim reportArgs As New CrPrintableArgs
                Dim reportParameters As New Object
                Dim dateString As String
                Dim tempDate As DateTime = View.TransactionDate.Value
                dateString = tempDate.ToString("yyyy/MM/dd")
                Dim reportTitle As String = AATM.Libraries.MessagingLibrary.Messaging.TranslateCaption("Diagnostic Test Samples Taken Report for ") + dateString
                reportArgs.ReportParameters = {dateString, "TransactionDate",
                                               GlobalVariables.EstablishmentName, "EstablishmentName",
                                               reportTitle, "ReportTitle"}
                reportArgs.DataBaseConnectionName = "IGroupClinic"
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