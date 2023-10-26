Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class IbLabSamplePresenter(Of TM As New)
        Inherits CommonPresenter(Of IIbLabSampleView, TM)

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
            'AddHandler View.DataChanged, AddressOf UpdateData
            'AddHandler View.GetPmrDataAccessRequested, AddressOf GetPMRDataAccess
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

        Private Sub PrintReport()
            'Dim pmrPatients As New IbLabSampleModel
            'pmrPatients = Service.GetParametrized(Of IbLabSampleModel)({View.DoctorCode, View.TransactionDate})
            'GlobalVariables.Mapper.Map(pmrPatients, View)
        End Sub

    End Class

End Namespace