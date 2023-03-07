Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class DosagePrintingPresenter(Of TM As New)
        Inherits CommonPresenter(Of IDosagePrintView, TM)

        'Private ReadOnly _dosagePrintingService As New AccountsService("DosagePrinting")

        Public Sub New(itemView As IDosagePrintView)
            MyBase.New(itemView)
            Service = New AccountsService("DosagePrinting")
            'Service.SaveConnectionString()
            'Service.SetConnectionString("IGROUPCLINIC")
            TableName = "DosagePrinting"
            'Service.RestoreConnectionString()
            WithTreeView = False
        End Sub

        
        Protected Overrides Sub CreateDataSources()
            CreateDataSourceGroupCode("DosageUnit", "DSUN")
            CreateDataSourceGroupCode("Route", "DSRT")
            CreateDataSourceGroupCode("Direction", "DSDI")
            CreateDataSourceGroupCode("Frequency", "DSFQ")
            CreateDataSourceGroupCode("FrequencyTiming", "DSFT")
            CreateDataSourceGroupCode("DurationUnit", "DSDU")
        End Sub


    End Class

End Namespace