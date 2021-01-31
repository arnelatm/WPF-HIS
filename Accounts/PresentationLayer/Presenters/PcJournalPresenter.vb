Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Presenters

    Public Class PcJournalPresenter
        Inherits AccountsPresenter(Of IPcJournalsView, PcJournalModel)

        Protected DtUpdateTable As New DataTable

        Private _pcJournalModel

        Public Sub New(view As IPcJournalsView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("PcJournals")
            TableName = "PcJournal_View"
            OriginalModel = New PcJournalModel()
            DataModel = New PcJournalModel()

            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

            CreateDataTable(DtUpdateTable, {{"IdNo", GetType(Int32)},
                                            {"PcClose", GetType(Boolean)}
                                            })
        End Sub

    End Class

End Namespace