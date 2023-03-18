Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class DosagePresenter(Of TM As New)
        Inherits CommonPresenter(Of IDosageView, TM)

        'Private ReadOnly _DosageService As New AccountsService("Dosage")

        Public Sub New(itemView As IDosageView)
            MyBase.New(itemView)
            Service = New AccountsService("Dosage")
            'Service.SaveConnectionString()
            'Service.SetConnectionString("IGROUPCLINIC")
            TableName = "Dosage_View"
            TreeViewMainField = "DosageName"
            SortOrderKey = "DosageName"
            'Service.RestoreConnectionString()
            WithTreeView = True
        End Sub

        
        Protected Overrides Sub CreateDataSources()
            'Dim data As New ArrayList
            'data.Add({"ItemCode", "DosageUnit", "ItemCodeName,ItemCodeCode", "CodeGroupIdNo = 7"})
            'CreateDataSourceThread(data)


            'CreateDataSourceGroupCodeThread({{"DosageUnit", "DSUN"},
            '                                 {"Route", "DSRT"},
            '                                 {"Direction", "DSDI"},
            '                                 {"Frequency", "DSFQ"},
            '                                 {"FrequencyTiming", "DSFT"},
            '                                 {"DurationTiming", "DSDT"}})
            'CreateDataSourceGroupCode("DosageUnit", "DSUN")
            CreateDataSourceGroupCode("DosageUnit", "DSUN")
            CreateDataSourceGroupCode("Route", "DSRT")
            CreateDataSourceGroupCode("Direction", "DSDI")
            CreateDataSourceGroupCode("Frequency", "DSFQ")
            CreateDataSourceGroupCode("FrequencyTiming", "DSFT")
            CreateDataSourceGroupCode("DurationTiming", "DSDT")
        End Sub


    End Class

End Namespace