Imports System.Configuration
Imports System.Globalization
Imports System.IO
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class DrugSaleEntry
        Implements IDrugSaleView

        Public Event CheckDuplicateDrug(ByRef duplicate As Boolean) Implements IDrugSaleView.CheckDuplicateDrug

        Public Event ClearEntry() Implements IDrugSaleView.ClearEntry

        Public Event FinderValueChanged(itemIdNo As Int16) Implements IDrugSaleView.FinderValueChanged

        Public Event GenerateCsvFile(salesDate As Date) Implements IDrugSaleView.GenerateCsvFile

        Public Event ValidateEntries() Implements IDrugSaleView.ValidateEntries

        Public Event ValidateQrCode(ByRef valid As Boolean) Implements IDrugSaleView.ValidateQrCode

        Public Event SaveDrugSale() Implements IDrugSaleView.SaveDrugSale

        Public Event AddDrugSale() Implements IDrugSaleView.AddDrugSale

        Public Property DrugSaleByName As DataTable

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtQrCode
            AutoAddOnSave = True
            qrCodeErrorProvider.SetIconAlignment(txtQrCode, ErrorIconAlignment.MiddleRight)
            qrCodeErrorProvider.SetIconPadding(txtQrCode, 2)
            qrCodeErrorProvider.BlinkRate = 1000
            qrCodeErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink

        End Sub

#Region "Field Items"

        Public Property IdNo As Int32 Implements IDrugSaleView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property GTIN As String Implements IDrugSaleView.GTin
            Get
                Return txtGTIN.Text
            End Get
            Set(value As String)
                txtGTIN.Text = value
            End Set
        End Property

        Public Property BatchNo As String Implements IDrugSaleView.BatchNo
            Get
                Return txtBatchNo.Text
            End Get
            Set(value As String)
                txtBatchNo.Text = value
            End Set
        End Property

        Public Property Expiry As Date? Implements IDrugSaleView.Expiry
            Get
                Return dtpExpiry.Value
            End Get
            Set
                dtpExpiry.Value = Value
            End Set
        End Property

        Public Property Manufacture As Date? Implements IDrugSaleView.Manufacture
            Get
                Return dtpManufacture.Value
            End Get
            Set
                dtpManufacture.Value = Value
            End Set
        End Property

        Public Property ProductCode As String Implements IDrugSaleView.ProductCode
            Get
                Return TxtProductCode.Text
            End Get
            Set(value As String)
                TxtProductCode.Text = value
            End Set
        End Property

        Public Shadows Property ProductName As String Implements IDrugSaleView.ProductName
            Get
                Return txtProductName.Text
            End Get
            Set(value As String)
                txtProductName.Text = value
            End Set
        End Property

        Public Property SerializationNo As String Implements IDrugSaleView.SerializationNo
            Get
                Return txtSerializationNo.Text
            End Get
            Set(value As String)
                txtSerializationNo.Text = value
            End Set
        End Property

        Public Property SaleDate As Date? Implements IDrugSaleView.SaleDate
            Get
                Return dtpSaleDate.Value
            End Get
            Set(value As Date?)
                dtpSaleDate.Value = value
            End Set
        End Property

        Public Property QrCode As String Implements IDrugSaleView.QrCode
            Get
                Return txtQrCode.Text
            End Get
            Set(value As String)
                txtQrCode.Text = value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"QrCode", txtQrCode},
                {"BatchNo", txtBatchNo},
                {"Expiry", dtpExpiry},
                {"GTin", txtGTIN},
                {"IdNo", TxtIdNo},
                {"Item_Code", TxtProductCode},
                {"ItemNameEnglish", txtProductName},
                {"SaleDate", dtpSaleDate},
                {"SerializationNo", txtSerializationNo}
                }
        End Sub

        Protected Overrides Sub BeforeEdit()
            SetDisplayOnly(True)
            Refresh()
        End Sub

        Private Sub SetDisplayOnly(value As Boolean)
            txtProductName.DisplayOnly = value
            TxtProductCode.DisplayOnly = value
        End Sub

        Private Sub txtQrCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQrCode.KeyPress

            Dim i As Integer = Me.txtQrCode.SelectionStart 'save for later use

            Select Case Asc(e.KeyChar)

                'Case 4 'EOT

                '    Me.txtQrCode.Text = Me.txtQrCode.Text.Insert(Me.txtQrCode.SelectionStart, "<EOT>")

                '    Me.txtQrCode.SelectionStart = i + 5

                '    e.Handled = True

                Case 29 'GS

                    Me.txtQrCode.Text = Me.txtQrCode.Text.Insert(Me.txtQrCode.SelectionStart, "<GS>")

                    Me.txtQrCode.SelectionStart = i + 5

                    e.Handled = True

                    'Case 30 'RS

                    '    Me.txtQrCode.Text = Me.txtQrCode.Text.Insert(Me.txtQrCode.SelectionStart, "<RS>")

                    '    Me.txtQrCode.SelectionStart = i + 5

                    '    e.Handled = True

            End Select

        End Sub

        Private Sub btnClearEntry_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnClearEntry.ClickButtonArea
            RaiseEvent ClearEntry()
        End Sub

        Private Sub DrugSaleEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            btnAdd.PerformClick()
            txtQrCode.Focus()
        End Sub

        Private Sub btnValidate_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnValidate.ClickButtonArea
            RaiseEvent ValidateEntries()
        End Sub

        Private Sub txtQrCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtQrCode.Validating
            Dim valid As Boolean = False
            RaiseEvent ValidateQrCode(valid)
            If valid Then
                e.Cancel = False
            Else
                e.Cancel = True
                MessageBox.Show("Invalid QR Code!")
            End If
        End Sub

        'Private Sub txtQrCode_Validated(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtQrCode.Validated
        '    If txtQrCode.Text IsNot Nothing Then
        '        RaiseEvent SaveDrugSale()
        '    End If
        'End Sub

        Private Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            txtQrCode.Text = ""
            dtpManufacture.Value = Nothing
            txtQrCode.Focus()
        End Sub

        Private Sub txtQrCode_Validated(sender As Object, e As EventArgs) Handles txtQrCode.Validated
            If Not IsEmpty(txtQrCode.Text) Then
                RaiseEvent SaveDrugSale()
                RaiseEvent AddDrugSale()
                txtQrCode.Focus()
            End If
        End Sub

    End Class

End Namespace