Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class LabReportStatusPresenter(Of TM As New)
        Inherits CommonPresenter(Of ILabReportStatusView, TM)

        Public Sub New()

        End Sub

        Public Sub New(itemView As ILabReportStatusView)
            MyBase.New(itemView)
            Service = New AccountsService("LabReportStatus")
            Service.SaveConnectionString()
            Service.SetConnectionString("Kizen")
            TableName = "LabReportStatus_View"
            SortOrderKey = ""
            Service.RestoreConnectionString()
            WithTreeView = False
            AddHandler View.LabReportStatusRequested, AddressOf GetLabReportStatus
            'AddHandler View.LabReportStatusChanged, AddressOf UpdateLabSample
        End Sub

        Public Sub UpdateLabSample(bindingSource As BindingSource)
            Debugger.Break()
        End Sub

        Private Sub GetLabReportStatus(idNo As Int32)
            UpdateData()
        End Sub

        Protected Overrides Sub CreateDataSources()
            Service.SaveConnectionString()
            Service.SetConnectionString($"Kizen")
            Service.RestoreConnectionString()
        End Sub

        Private Sub UpdateData()
            Dim LabReportStatusModel As New LabReportStatusModel
            If View.SampleNo = 0 Then
                LabReportStatusModel = Nothing
            Else
                LabReportStatusModel = Service.GetRecordByIdNo(Of LabReportStatusModel)(View.SampleNo)
            End If
            GlobalVariables.Mapper.Map(LabReportStatusModel, View)
        End Sub


    End Class

End Namespace