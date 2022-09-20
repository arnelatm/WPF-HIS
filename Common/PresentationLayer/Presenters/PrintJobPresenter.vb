Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer

Namespace PresentationLayer.Presenters

    Public Class PrintJobPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPrintJobView, TM)

        Public Sub New(view As IPrintJobView)
            MyBase.New(view)

            Service = New CommonService("PrintJob")
            TableName = "PrintJob"
            TreeViewMainField = "PrintJobName"
            SortOrderKey = "PrintJobName"
        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim control = GetControlName("PrinterName")
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