Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class GenerateDailyDrugSaleCsv
        Implements IDrugSaleView

        Public Property MainTableName As String

        Public Property BatchNo As String Implements IDrugSaleView.BatchNo
        Public Property Expiry As Date? Implements IDrugSaleView.Expiry
        Public Property GTin As String Implements IDrugSaleView.GTin
        Public Property IdNo As Integer Implements IDrugSaleView.IdNo
        Public Property Item_Code As String Implements IDrugSaleView.Item_Code
        Public Property ItemNameEnglish As String Implements IDrugSaleView.ItemNameEnglish
        Public Property SerializationNo As String Implements IDrugSaleView.SerializationNo

        Public Event GenerateCsvFile(salesDate As Date) Implements IDrugSaleView.GenerateCsvFile

        Public Event GetDrugName() Implements IDrugSaleView.GetDrugName

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            MainTableName = "DrugSale"
            SingleData = True
            SaleDate = Today()
        End Sub

        Public Property SaleDate As Date? Implements IDrugSaleView.SaleDate
            Get
                Return dtpSaleDate.Value
            End Get
            Set
                dtpSaleDate.Value = Value
            End Set
        End Property

        Private Sub GenerateDrugSaleBankCsv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            btnPrint.Visible = False
            btnSave.Visible = False
            btnEdit.Visible = False
            btnFilter.Visible = False
            btnDelete.Visible = False
            btnUndo.Visible = False
            btnNew.Visible = False
            btnOpen.Visible = False
            TurnOnInputs()
        End Sub

        Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            RaiseEvent GenerateCsvFile(SaleDate)
        End Sub

        Private Sub btnCancel_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Public Event FinderValueChanged(itemIdNo As Short) Implements IDrugSaleView.FinderValueChanged

        Protected Overrides Sub CreateMainFieldsDictionary()
            Dim txtBatchNo As New CTextBox
            Dim txtExpiry As New CCustomDateTimePicker
            Dim txtGTin As New CTextBox
            Dim dtpExpiry As New CCustomDateTimePicker
            Dim txtIdNo As New CTextBox
            Dim txtItemNameEnglish As New CTextBox
            Dim txtItem_Code As New CTextBox
            Dim txtSerializationNo As New CTextBox
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {{"BatchNo", txtBatchNo},
                {"Expiry", dtpExpiry},
                {"GTin", txtGTin},
                {"IdNo", txtIdNo},
                {"Item_Code", txtItem_Code},
                {"ItemNameEnglish", txtItemNameEnglish},
                {"SaleDate", dtpSaleDate},
                {"SerializationNo", txtSerializationNo}
                }
        End Sub

    End Class

End Namespace