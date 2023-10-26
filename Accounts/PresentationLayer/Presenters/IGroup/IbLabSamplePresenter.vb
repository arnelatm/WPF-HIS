Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
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
            'Dim ibLabSamples As New IbLabSampleModel
            'Dim transactionDateString As String = View.TransactionDate
            'If String.IsNullOrEmpty(View.DoctorCode) Then
            '    pmrPatients = Nothing
            'Else
            '    pmrPatients = Service.GetParametrized(Of PmrInvestigationRequestModel)({View.DoctorCode, View.TransactionDate})
            'End If
            'GlobalVariables.Mapper.Map(pmrPatients, View)
        End Sub

        Protected Overrides Sub CreateDataSources()
            Service.SaveConnectionString()
            Service.SetConnectionString($"ISPDATA")
            'CreateDataSource(None)
            Service.RestoreConnectionString()
        End Sub

        Private Sub UpdateData()
            Dim IbLabSampleModel As New IbLabSampleModel
            'Dim transactionDateString As String = View.TransactionDate
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

End Namespace