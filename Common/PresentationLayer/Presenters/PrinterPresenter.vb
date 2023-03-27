Imports System.Drawing.Printing
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PrinterPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPrinterView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(view As IPrinterView)
            MyBase.New(view)
            Service = New CommonService("Printer")
            TableName = "Printer"
            TableBaseName = "Printer"
            TreeViewMainField = "PrinterName"
            TreeViewSecondaryField = "PrinterCode"
            AddHandler view.CheckPrinterClicked, AddressOf OnCheckPrinterClicked
            AddHandler view.PrinterChanged, AddressOf UpdatePrinterDataSource

        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSourceGroupCode("DefaultPaperOrientation", "PPOR")
            SetDataSourceInstalledPrinter("PrinterName")
        End Sub

        Private Sub OnCheckPrinterClicked(sender As Object)
            If String.IsNullOrEmpty(View.PrinterName) Then
                MessageBox.Show("Invalid Printer for this workstation.")
            Else
                If View.PrinterName IsNot Nothing Then
                    Dim printer As String
                    printer = View.PrinterName
                    If PrinterSettings.InstalledPrinters.Cast(Of String)().Any(Function(name) printer.ToUpper().Trim() = name.ToUpper().Trim()) Then
                        Dim data = GetPrinterPageInfo(printer)
                        Dim printOut As String = ""
                        For Each item As PaperSize In data.PrinterSettings.PaperSizes
                            printOut += item.PaperName + vbCrLf
                        Next
                        printOut += " Paper Sources " + vbCrLf
                        For Each item As PaperSource In data.PrinterSettings.PaperSources
                            printOut += item.SourceName + vbCrLf
                        Next
                        MessageBox.Show(printOut)
                    Else
                        MessageBox.Show("Printer doesn't exist or is not Installed")
                    End If
                End If
            End If
        End Sub

        Private Sub OnBeforeMappingData(ByVal dataModel As Object) Handles MyBase.BeforeMappingData
            View.PrinterName = dataModel.PrinterName
            View.DefaultPaperSize = dataModel.DefaultPaperSize
            View.DefaultPaperSource = dataModel.DefaultPaperSource
            UpdatePrinterDataSource()
        End Sub

        Private Sub UpdatePrinterDataSource()
            If IsPrinterValid(View.PrinterName) Then
                SetPrinterSupportedPaper(View.PrinterName, View.DefaultPaperSize)
                SetPrinterSupportedSources(View.PrinterName, View.DefaultPaperSource)
            End If
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.HostOrIpName = Environment.MachineName
        End Sub

    End Class

End Namespace