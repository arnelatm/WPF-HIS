Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class DosagePresenter(Of TM As New)
        Inherits CommonPresenter(Of IDosageView, TM)

        Public Sub New(itemView As IDosageView)
            MyBase.New(itemView)
            Service = New AccountsService("Dosage")
            TableName = "Dosage_View"
            TreeViewMainField = "DosageName"
            TableBaseName = "Dosage"
            SortOrderKey = "DosageName"
            WithTreeView = True
        End Sub
        
        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList 
            data.Add({"ItemCode", "Direction", Nothing, "CodeGroupIdNo=10"})
            data.Add({"ItemCode", "Frequency", Nothing, "CodeGroupIdNo=6"})
            data.Add({"ItemCode", "FrequencyTiming", Nothing, "CodeGroupIdNo=11"})
            data.Add({"ItemCode", "Route", Nothing, "CodeGroupIdNo=9"})
            CreateDataSourceThread(data)
        End Sub

    End Class

End Namespace