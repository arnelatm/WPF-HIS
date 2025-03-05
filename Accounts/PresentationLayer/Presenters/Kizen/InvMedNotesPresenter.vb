Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class InvMedNotesPresenter(Of TM As New)
        Inherits CommonPresenter(Of IInvMedNotesView, TM)

        Private _InvMedNotesDetailDao As New InvMedNotesDetailDao("Kizen")

        Public Sub New()

        End Sub

        Public Sub New(itemView As IInvMedNotesView)
            MyBase.New(itemView)
            Service = New AccountsService("InvMedNotes")
            Service.SaveConnectionString()
            Service.SetConnectionString("Kizen")
            TableName = "InvMedNotes_View"
            SortOrderKey = ""
            Service.RestoreConnectionString()
            WithTreeView = False
            AddHandler View.InvMedNotesRequested, AddressOf GetInvMedNotes
            AddHandler View.InvMedNotesChanged, AddressOf UpdateLabSample
        End Sub

        Public Sub UpdateLabSample(bindingSource As BindingSource)
            With bindingSource.Current
                _InvMedNotesDetailDao.UpdateRecord(.idNo, .note)
            End With
        End Sub

        Private Sub GetInvMedNotes(idNo As Int32)
            UpdateData()
        End Sub

        Protected Overrides Sub CreateDataSources()
            Service.SaveConnectionString()
            Service.SetConnectionString($"Kizen")
            Service.RestoreConnectionString()
        End Sub

        Private Sub UpdateData()
            Dim InvMedNotesModel As New InvMedNotesModel
            If View.InvoiceNo = 0 Then
                'InvMedNotesModel = Nothing
            Else
                InvMedNotesModel = Service.GetRecordByIdNo(Of InvMedNotesModel)(View.InvoiceNo)
                GlobalFunctions.ManualMap(InvMedNotesModel, View)
                View.InvMedNotesDetails = View.InvMedNotesDetails
            End If
        End Sub

    End Class

End Namespace