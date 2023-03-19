Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class DosagePrintingPresenter(Of TM As New)
        Inherits CommonPresenter(Of IDosageView, TM)

        Public Sub New(itemView As IDosageView)
            MyBase.New(itemView)
            Service = New AccountsService("Dosage")
            TableName = "Dosage_View"
            TreeViewMainField = "DosageName"
            SortOrderKey = "DosageName"
            WithTreeView = True
        End Sub
        
        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList 
            data.Add({"ItemCode", "DurationTiming", Nothing, "CodeGroupIdNo=12"})
            data.Add({"ItemCode", "DosageUnit", Nothing, "CodeGroupIdNo=7"})
            CreateDataSourceThread(data)
        End Sub

    End Class

End Namespace