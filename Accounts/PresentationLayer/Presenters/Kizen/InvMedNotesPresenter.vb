Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class InvMedNotesPresenter(Of TM As New)
        Inherits CommonPresenter(Of IInvMedNotesView, TM)

        Private _InvMedNotesDetailDao As New InvMedNotesDetailDao

        Public Sub New()

        End Sub

        Public Sub New(itemView As IInvMedNotesView)
            MyBase.New(itemView)
            Service = New AccountsService("InvMedNotes")
            Service.SaveConnectionString()
            Service.SetConnectionString($"Kizen")
            TableName = "InvMedNotesList_View"
            SortOrderKey = ""
            Service.RestoreConnectionString()
            WithTreeView = False
            AddHandler View.InvMedNotesRequested, AddressOf GetInvMedNotess
            AddHandler View.InvMedNotesChanged, AddressOf UpdateLabSample
        End Sub

        Public Sub UpdateLabSample(bindingSource As BindingSource)
            With bindingSource.Current
                _InvMedNotesDetailDao.UpdateRecord(.idNo, .urine, .stool, .Rbs)
            End With
        End Sub

        Private Sub GetInvMedNotes(transactionDate As Date?)
            UpdateData()
        End Sub

        Protected Overrides Sub CreateDataSources()
            Service.SaveConnectionString()
            Service.SetConnectionString($"ISPDATA")
            Service.RestoreConnectionString()
        End Sub

        Private Sub UpdateData()
            Dim InvMedNotesModel As New InvMedNotesModel
            If String.IsNullOrEmpty(View.TransactionDate) Then
                InvMedNotesModel = Nothing
            Else
                InvMedNotesModel = Service.GetParametrized(Of InvMedNotesModel)({View.TransactionDate})
            End If
            GlobalVariables.Mapper.Map(InvMedNotesModel, View)
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