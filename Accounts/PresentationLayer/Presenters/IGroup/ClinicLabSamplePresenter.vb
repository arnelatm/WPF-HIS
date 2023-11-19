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

    Public Class ClinicLabSamplePresenter(Of TM As New)
        Inherits CommonPresenter(Of IClinicLabSampleView, TM)

        Private _ClinicLabSampleDetailDao As New ClinicLabSampleDetailDao

        Public Sub New()

        End Sub

        Public Sub New(itemView As IClinicLabSampleView)
            MyBase.New(itemView)
            Service = New AccountsService("ClinicLabSample")
            Service.SaveConnectionString()
            Service.SetConnectionString($"IGROUPCLINIC")
            TableName = "ClinicLabSampleList_View"
            SortOrderKey = ""
            Service.RestoreConnectionString()
            WithTreeView = False
            AddHandler View.ClinicLabSamplesRequested, AddressOf GetClinicLabSamples
            AddHandler View.ClinicLabSampleChanged, AddressOf UpdateLabSample


            'AddHandler View.DataChanged, AddressOf UpdateData
            'AddHandler View.GetPmrDataAccessRequested, AddressOf GetPMRDataAccess
        End Sub

        Public Sub UpdateLabSample(bindingSource As BindingSource)
            With bindingSource.Current
                _ClinicLabSampleDetailDao.UpdateRecord(.idNo, .urine, .stool, .Rbs)
            End With
        End Sub

        Private Sub GetClinicLabSamples(transactionDate As Date?)
            UpdateData()
            'Dim ClinicLabSamples As New ClinicLabSampleModel
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
            Dim ClinicLabSampleModel As New ClinicLabSampleModel
            'Dim transactionDateString As String = View.TransactionDate
            If String.IsNullOrEmpty(View.TransactionDate) Then
                ClinicLabSampleModel = Nothing
            Else
                ClinicLabSampleModel = Service.GetParametrized(Of ClinicLabSampleModel)({View.TransactionDate})
            End If
            GlobalVariables.Mapper.Map(ClinicLabSampleModel, View)
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