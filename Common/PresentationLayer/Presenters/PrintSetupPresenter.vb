Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer

Namespace PresentationLayer.Presenters

    Public Class PrintSetupPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPrintSetupView, TM)

        Public Sub New(view As IPrintSetupView)
            MyBase.New(view)

            Service = New CommonService("PrintSetup")
            TableName = "PrintSetup"
            TreeViewMainField = "PrintSetupName"
            SortOrderKey = "PrintSetupName"
        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim control = GetControlName("PrinterIdNo")
            AAtm.Libraries.Invoker.SetProperty(control, "DataSource", GetInstalledPrinters)
        End Sub

        Private Function GetInstalledPrinters()
            Dim sPrinters As New ArrayList
            For Each printer In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                sPrinters.Add(printer)
            Next
            Return sPrinters
        End Function

    End Class

End Namespace