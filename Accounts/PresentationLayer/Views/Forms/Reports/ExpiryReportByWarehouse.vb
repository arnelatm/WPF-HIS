Imports System.Globalization
Imports AATM.Common
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ExpiryReportByWarehouse
        Implements IReportPrinterView

        Public Property MainTableName As String

        Public Property FileName As String Implements IReportPrinterView.FileName
        Public Property ReportTitle As String Implements IReportPrinterView.ReportTitle
        Public Property FormCultureLanguage As String Implements IReportPrinterView.FormCultureLanguage
        Public Property Args As Object() Implements IReportPrinterView.Args
        Public Property DataBaseConnectionName As String Implements IReportPrinterView.DataBaseConnectionName
        Public Property Copies As Integer Implements IReportPrinterView.Copies

        Public Property Collate As Boolean Implements IReportPrinterView.Collate
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Boolean)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property StartPage As Integer Implements IReportPrinterView.StartPage
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Integer)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property EndPage As Integer Implements IReportPrinterView.EndPage
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Integer)
                Throw New NotImplementedException()
            End Set
        End Property

        Protected SortOrderKey As String
        Private Event PrintReport(ByVal sender As IReportPrinterView) Implements IReportPrinterView.PrintReport

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Report"
            SortOrderKey = "IdNo"

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpExpiryDate.Value Is Nothing Then
                Messaging.Show(True, "MsgDateCannotBeBlank")
            Else
                Dim reportName As String
                reportName = Messaging.TranslateCaption("Inventory Expiry Report By Warehouse")
                ReportTitle = Messaging.TranslateCaption("Inventory Expiry Report By Warehouse")
                FormCultureLanguage = FormCulture.Name
                FileName = "Inventory Expiry Report By Warehouse.Rpt"
                Args = {cboWarehouseIdNo.SelectedItem.IdNo, "WarehouseIdNo",
                        chkAllWarehouses.Checked, "AllWarehouses",
                        dtpExpiryDate.Value, "ExpiryDate"}
                Copies = 1
                RaiseEvent PrintReport(Me)
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub


        Private Sub ExpiryReportByWarehouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Ea.PublishEvent(New GetControlDataSource("Warehouse", cboWarehouseIdNo))
            cboWarehouseIdNo.EditingMode = True
        End Sub


    End Class

End Namespace