Imports System.ComponentModel
Imports System.Dynamic
Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports Telerik.WinControls.VirtualKeyboard

Namespace PresentationLayer.Views.Forms

    Public Class PurchaseEntry
        Implements IPurchaseView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _footer As DgvFooter
        Private _PurchaseDetails As List(Of PurchaseDetailView)
        Private _purchaseHistory As List(Of PurchaseHistoryView)
        Private _noOfUnits As Int16
        Public Event ProductCodeChanged(productCode As String, bs As BindingSource) Implements IPurchaseView.ProductCodeChanged
        Public Event GTinScanned(GTin As String, bs As BindingSource, ByRef productCode As String) Implements IPurchaseView.GTinScanned
        Public Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource) Implements IPurchaseView.ProductUnitSelection
        Public Event ProductUnitEditing(productIdNo As Int32, bs As BindingSource) Implements IPurchaseView.ProductUnitEditing
        Public Event UnitChanged(oldUnit As Int16, newUnit As Int16, bs As BindingSource) Implements IPurchaseView.UnitChanged
        Public Event RowChanged(productIdNo As Int32) Implements IPurchaseView.RowChanged
        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            _nfi.NumberDecimalDigits = 2
        End Sub

        'Private Sub JiBs_AddingNew(ByVal sender As Object, ByVal e As AddingNewEventArgs) Handles bsPurchaseDetails.AddingNew
        '    e.NewObject = New PurchaseDetailView
        '    ' work around for error on datagrid entry on lastrow please do not remove.
        '    ' The reason it works Is because On a DataGridView where AllowUserToAddRows Is True,
        '    ' it adds an empty row at the end of its rows which if bound to a list creates a null element at the end of the list.
        '    ' The code removes that element And then the AddNew in the BindingList will trigger the DataGridView to add it again
        '    If DataGridViewPurchaseDetails.Rows.Count = bsPurchaseDetails.Count Then
        '        bsPurchaseDetails.RemoveAt(bsPurchaseDetails.Count - 1)
        '    End If
        'End Sub

#Region "Fields"


        Private Property ProductsByCode Implements IPurchaseView.ProductsByCode
        Private Property UnitsByCode Implements IPurchaseView.UnitsByCode
        Private Property UnitsByProduct Implements IPurchaseView.UnitsByProduct

        Public Property Amount As Decimal Implements IPurchaseView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IPurchaseView.DateCreated
            Get
                Try
                    Return Convert.ToDateTime(txtDateCreated.Text)
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
            Set
                If Value.HasValue Then
                    txtDateCreated.Text = Value
                Else
                    txtDateCreated.Text = Date.Now().ToString()
                End If
            End Set
        End Property

        Public Property DueDate As Date? Implements IPurchaseView.DueDate
            Get
                Return dtpDueDate.Value
            End Get
            Set
                dtpDueDate.Value = Value
            End Set
        End Property

        Public Property IdNo As Int32 Implements IPurchaseView.IdNo
            Get
                If TxtIdNo.Text <> "" Then
                    Return Convert.ToInt16(TxtIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property InvoiceDate As Date? Implements IPurchaseView.InvoiceDate
            Get
                Return dtpInvoiceDate.Value
            End Get
            Set
                If Value IsNot Nothing Then
                    dtpInvoiceDate.Value = Value
                Else
                    dtpInvoiceDate.Value = Today()
                End If
            End Set
        End Property

        Public Property InvoiceNo As String Implements IPurchaseView.InvoiceNo
            Get
                Return txtInvoiceNo.Text
            End Get
            Set
                txtInvoiceNo.Text = Value
            End Set
        End Property

        Public Property PurchaseDetails As List(Of PurchaseDetailView) Implements IPurchaseView.PurchaseDetails
            Get
                Return _PurchaseDetails
            End Get
            Set
                _PurchaseDetails = Value
                BindPurchaseDetail()
            End Set
        End Property

        Public Property PurchaseHistory As List(Of PurchaseHistoryView) Implements IPurchaseView.PurchaseHistory
            Get
                Return _purchaseHistory
            End Get
            Set
                _purchaseHistory = Value
                BindPurchaseHistory()
            End Set
        End Property

        'Public Property Notes As String Implements IPurchaseView.Notes
        '    Get
        '        Return txtNotes.Text
        '    End Get
        '    Set
        '        txtNotes.Text = If(Value, "")
        '    End Set
        'End Property

        Public Property Posted As Boolean Implements IPurchaseView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set(value As Boolean)
                chkPosted.Checked = value
            End Set
        End Property

        'Public Property SettlementDiscount As Decimal Implements IPurchaseView.SettlementDiscount
        '    Get
        '        If txtSettlementDiscount.Text <> "" Then
        '            Return Convert.ToDecimal(txtSettlementDiscount.Text)
        '        Else
        '            Return 0D
        '        End If
        '    End Get
        '    Set
        '        txtSettlementDiscount.Text = Value
        '    End Set
        'End Property

        'Public Property SettlementDueDate As Date? Implements IPurchaseView.SettlementDueDate
        '    Get
        '        Return dtpSettlementDueDate.Value
        '    End Get
        '    Set
        '        dtpSettlementDueDate.Value = Value
        '    End Set
        'End Property

        Public Property SupplierIdNo As Int32? Implements IPurchaseView.SupplierIdNo
            Get
                Return cboSupplierIdNo.GetValue(Of Int32?)
            End Get
            Set
                cboSupplierIdNo.SetValue(Value)
            End Set
        End Property

        Public Property WarehouseIdNo As Int16 Implements IPurchaseView.WarehouseIdNo
            Get
                Return cboWarehouseIdNo.GetValue(Of Int16)
            End Get
            Set
                cboWarehouseIdNo.SetValue(Value)
            End Set
        End Property

        'Public ReadOnly Property TotalCredits As Decimal Implements IPurchaseView.TotalCredits
        '    Get
        '        Return NumParser(Of Decimal)(txtTotalCredits.Text)
        '    End Get
        'End Property

        'Public ReadOnly Property TotalDebits As Decimal Implements IPurchaseView.TotalDebits
        '    Get
        '        Return NumParser(Of Decimal)(txtTotalDebits.Text)
        '    End Get
        'End Property

        Public Property TransactionDate As Date? Implements IPurchaseView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set
                If Value Is Nothing Then
                    dtpTransactionDate.Value = Date.Now()
                Else
                    dtpTransactionDate.Value = Value
                End If
            End Set
        End Property

        'Public Property TransactionType As String Implements IPurchaseView.TransactionType
        '    Get
        '        Return cboTransactionType.GetValue()
        '    End Get
        '    Set
        '        cboTransactionType.SetValue(Value)
        '    End Set
        'End Property

        Public Property VatAmount As Decimal Implements IPurchaseView.VatAmount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtVatAmount.Text), _nfi)
            End Get
            Set
                txtVatAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property VatNumber As String Implements IPurchaseView.VatNumber
            Get
                Return txtVatNumber.Text
            End Get
            Set
                txtVatNumber.Text = Value
            End Set
        End Property

        Public Property Cancelled As Boolean Implements IPurchaseView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"Amount", txtAmount},
         {"Cancelled", chkCancelled},
         {"DateCreated", txtDateCreated},
         {"DueDate", dtpDueDate},
         {"IdNo", TxtIdNo},
         {"InvoiceNo", txtInvoiceNo},
         {"Posted", chkPosted},
         {"ReferenceNo", cboWarehouseIdNo},
         {"SupplierIdNo", cboSupplierIdNo},
         {"TransactionDate", dtpTransactionDate},
         {"VatAmount", txtVatAmount},
         {"VatNumber", txtVatNumber},
         {"WarehouseIdNo", cboWarehouseIdNo}
        }
        End Sub

        Protected Sub PurchaseUpdateView() Handles MyBase.AfterUpdateView
            UpdateTotals()
        End Sub

        Private Sub PurchaseEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _footer = New DgvFooter(DataGridViewPurchaseDetails) With {
                .AutoCalc = True
            }
            _footer.ColumnToSum("dgvQuantity", 0) = True
            _footer.ColumnToSum("dgvBonusQuantity", 0) = True
            _footer.ColumnToSum("dgvGrossAmount") = True
            _footer.ColumnToSum("dgvDiscountAmount") = True
            _footer.ColumnToSum("dgvAmtBefVat") = True
            _footer.ColumnToSum("dgvVatAmount") = True
            _footer.ColumnToSum("dgvNetAmount") = True
            _footer.SetAlignment("dgvQuantity", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvBonusQuantity", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvGrossAmount", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvDiscountAmount", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvAmtBefVat", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvVatAmount", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvNetAmount", ContentAlignment.MiddleRight)
            _footer.SetText("dgvProductName", "Totals ->")
            DataGridViewPurchaseDetails.Columns("dgvExpiryDate").DefaultCellStyle.Format = "yyyy/MM"
            UpdateTotals()
        End Sub

        Private Sub BindPurchaseDetail()
            SuspendLayout()
            bsPurchaseDetails.DataSource = Nothing
            DataGridViewPurchaseDetails.Refresh()
            bsPurchaseDetails.DataSource = PurchaseDetails
            bsPurchaseDetails.AllowNew = True
            SetupDgvColumns()
            ResumeLayout()
        End Sub


        Private Sub BindPurchaseHistory()
            SuspendLayout()
            bsPurchaseHistory.DataSource = Nothing
            DataGridViewPurchaseHistory.Refresh()
            bsPurchaseHistory.DataSource = PurchaseHistory
            bsPurchaseHistory.AllowNew = False
            'SetupDgvColumns()
            ResumeLayout()
        End Sub

        Private Sub SetupDgvColumns()
            dgvSequence.DisplayOnly = True
            dgvUnitIdNo.DataSource = UnitsByCode
            dgvUnitIdNo.DisplayMember = "Name"
            dgvUnitIdNo.ValueMember = "idNo"
            dgvUnitIdNo.DisplayStyleForCurrentCellOnly = True
            dgvQuantity.DecimalPlaces = 0
            dgvBonusQuantity.DecimalPlaces = 0
            dgvUnitCost.DisplayOnly = True
            dgvUnitCost.SetFormat(7, 2)
        End Sub

        Private Sub CboSupplierIdNo_Changed(sender As Object, e As EventArgs) Handles cboSupplierIdNo.Validated, cboSupplierIdNo.SelectionChangeCommitted
            Presenter.UpdateDueDate()
            'Presenter.UpdateEarlySettlementValues()
            If SupplierIdNo IsNot Nothing Then
                Presenter.SetSupplierVatNumber(VatNumber, SupplierIdNo, True)
            End If
        End Sub

        Private Sub CboSupplierIdNo_Validating(sender As Object, e As CancelEventArgs)
            'If PaymentOrDiscountMade() Then
            '    ' revert to previous value
            '    cboSupplierIdNo.RevertValue()
            'End If
        End Sub

        Private Overloads Sub Dispose()
            Close()
            '_footer.Dispose()
        End Sub

        'Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewPurchaseDetails.CellBeginEdit
        '    'If DataGridViewPurchaseDetails.CurrentCell.RowIndex() = 0 Then
        '    With DataGridViewPurchaseDetails.CurrentCell
        '        Dim cColumnName = .OwningColumn.Name()
        '        If cColumnName = $"dgvUnitIdNo" Then
        '            RaiseEvent ProductUnitSelection(DataGridViewPurchaseDetails.CurrentRow.Cells("dgvProductIdNo").Value, bsPurchaseDetails)
        '        End If
        '        '    Beep()
        '        '    e.Cancel = True
        '        '    DataGridViewPurchaseDetails.EndEdit()
        '        'End If
        '    End With
        '    'ElseIf (DataGridViewPurchaseDetails.CurrentRow.Cells("dgvPaidAmount").Value <> 0 Or DataGridViewPurchaseDetails.CurrentRow.Cells("dgvDiscountTaken").Value <> 0) _
        '    '       And DataGridViewPurchaseDetails.CurrentCell.OwningColumn.Name.ToLower() = $"dgvProductIdNo" Then
        '    '    Beep()
        '    '    e.Cancel = True
        '    '    DataGridViewPurchaseDetails.EndEdit()
        '    '    Messaging.Show(True, "MsgPaymentDiscExistChangeNotAllowed")
        '    ' End If
        'End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPurchaseDetails.CellEndEdit
            'With bsPurchaseDetails.Current
            '    Dim gAmt As Decimal = 0
            '    Dim dAmt As Decimal = 0
            '    Dim price As Decimal = 0
            '    Dim vAmt As Decimal = 0
            '    Dim amtBefVat As Decimal = 0
            '    Dim dPerc As Decimal = 0
            '    Dim vPerc As Decimal = 0
            '    Dim nAmt As Decimal = 0
            '    If DataGridViewPurchaseDetails.CurrentCell().OwningColumn.Name = "dgvQuantity" Then
            '        gAmt = bsPurchaseDetails.Current.Price * bsPurchaseDetails.Current.Quantity
            '        bsPurchaseDetails.Current.GrossAmount = gAmt
            '        dAmt = gAmt * bsPurchaseDetails.Current.DiscountPercent / 100
            '        bsPurchaseDetails.Current.DiscountAmount = dAmt
            '        bsPurchaseDetails.Current.AmtBefVat = gAmt - dAmt
            '        vAmt = (gAmt - dAmt) * bsPurchaseDetails.Current.VatPercent / 100
            '        bsPurchaseDetails.Current.VatAmount = vAmt
            '        bsPurchaseDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewPurchaseDetails.CurrentCell().OwningColumn.Name = "dgvPrice" Then
            '        gAmt = bsPurchaseDetails.Current.Price * bsPurchaseDetails.Current.Quantity
            '        bsPurchaseDetails.Current.GrossAmount = gAmt
            '        dAmt = gAmt * bsPurchaseDetails.Current.DiscountPercent / 100
            '        bsPurchaseDetails.Current.DiscountAmount = dAmt
            '        bsPurchaseDetails.Current.AmtBefVat = gAmt - dAmt
            '        vAmt = (gAmt - dAmt) * bsPurchaseDetails.Current.VatPercent / 100
            '        bsPurchaseDetails.Current.VatAmount = vAmt
            '        bsPurchaseDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewPurchaseDetails.CurrentCell().OwningColumn.Name = "dgvGrossAmount" Then
            '        gAmt = bsPurchaseDetails.Current.GrossAmount
            '        price = IIf(bsPurchaseDetails.Current.Quantity = 0, 0, gAmt / bsPurchaseDetails.Current.Quantity)
            '        bsPurchaseDetails.Current.Price = price
            '        dAmt = gAmt * bsPurchaseDetails.Current.DiscountPercent / 100
            '        bsPurchaseDetails.Current.DiscountAmount = dAmt
            '        bsPurchaseDetails.Current.DiscountPercent = dAmt / gAmt * 100
            '        vAmt = (gAmt - dAmt) * bsPurchaseDetails.Current.VatPercent / 100
            '        bsPurchaseDetails.Current.VatAmount = vAmt
            '        bsPurchaseDetails.Current.AmtBefVat = gAmt - dAmt
            '        bsPurchaseDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewPurchaseDetails.CurrentCell().OwningColumn.Name = "dgvVatAmount" Then
            '        gAmt = bsPurchaseDetails.Current.GrossAmount
            '        dAmt = bsPurchaseDetails.Current.DiscountAmount
            '        vAmt = bsPurchaseDetails.Current.VatAmount
            '        vPerc = IIf(gAmt - dAmt = 0, 0, vAmt / (gAmt - dAmt) * 100)
            '        bsPurchaseDetails.Current.VatPercent = vPerc
            '        bsPurchaseDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewPurchaseDetails.CurrentCell().OwningColumn.Name = "dgvVatPercent" Then
            '        vPerc = bsPurchaseDetails.Current.VatPercent
            '        gAmt = bsPurchaseDetails.Current.GrossAmount
            '        dAmt = bsPurchaseDetails.Current.DiscountAmount
            '        vAmt = (gAmt - dAmt) * vPerc / 100
            '        bsPurchaseDetails.Current.VatAmount = vAmt
            '        bsPurchaseDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewPurchaseDetails.CurrentCell().OwningColumn.Name = "dgvDiscountPercent" Then
            '        gAmt = bsPurchaseDetails.Current.GrossAmount
            '        dAmt = gAmt * bsPurchaseDetails.Current.DiscountPercent / 100
            '        bsPurchaseDetails.Current.DiscountAmount = dAmt
            '        bsPurchaseDetails.Current.AmtBefVat = gAmt - dAmt
            '        vAmt = (gAmt - dAmt) * bsPurchaseDetails.Current.VatPercent / 100
            '        bsPurchaseDetails.Current.VatAmount = vAmt
            '        bsPurchaseDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewPurchaseDetails.CurrentCell().OwningColumn.Name = "dgvDiscountAmount" Then
            '        gAmt = bsPurchaseDetails.Current.GrossAmount
            '        dAmt = bsPurchaseDetails.Current.DiscountAmount
            '        dPerc = IIf(gAmt = 0, 0, dAmt / gAmt * 100)
            '        bsPurchaseDetails.Current.DiscountPercent = dPerc
            '        bsPurchaseDetails.Current.AmtBefVat = gAmt - dAmt
            '        vAmt = (gAmt - dAmt) * bsPurchaseDetails.Current.VatPercent / 100
            '        bsPurchaseDetails.Current.VatAmount = vAmt
            '        bsPurchaseDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewPurchaseDetails.CurrentCell().OwningColumn.Name = "dgvAmtBefVat" Then
            '        amtBefVat = bsPurchaseDetails.Current.AmtBefVat
            '        gAmt = bsPurchaseDetails.Current.GrossAmount
            '        If amtBefVat <= gAmt Then
            '            dAmt = gAmt - amtBefVat
            '            bsPurchaseDetails.Current.DiscountAmount = dAmt
            '            dPerc = IIf(gAmt = 0, 0, dAmt / gAmt * 100)
            '            bsPurchaseDetails.Current.DiscountPercent = dPerc
            '            vAmt = amtBefVat * bsPurchaseDetails.Current.VatPercent / 100
            '            bsPurchaseDetails.Current.VatAmount = vAmt
            '            bsPurchaseDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '        Else
            '            dAmt = bsPurchaseDetails.Current.DiscountAmount
            '            gAmt = amtBefVat - dAmt
            '            bsPurchaseDetails.Current.GrossAmount = gAmt
            '            price = IIf(bsPurchaseDetails.Current.Quantity = 0, 0, gAmt / bsPurchaseDetails.Current.Quantity)
            '            bsPurchaseDetails.Current.Price = price
            '            dPerc = IIf(gAmt = 0, 0, dAmt / gAmt * 100)
            '            bsPurchaseDetails.Current.DiscountPercent = dPerc
            '            vAmt = amtBefVat * bsPurchaseDetails.Current.VatPercent / 100
            '            bsPurchaseDetails.Current.VatAmount = vAmt
            '            bsPurchaseDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '        End If
            '    ElseIf DataGridViewPurchaseDetails.CurrentCell().OwningColumn.Name = "dgvNetAmount" Then
            '        nAmt = bsPurchaseDetails.Current.NetAmount
            '        vPerc = bsPurchaseDetails.Current.VatPercent
            '        dPerc = bsPurchaseDetails.Current.DiscountPercent
            '        amtBefVat = nAmt / (1 + vPerc / 100)
            '        bsPurchaseDetails.Current.AmtBefVat = amtBefVat
            '        bsPurchaseDetails.Current.VatAmount = nAmt - amtBefVat
            '        gAmt = amtBefVat / (1 - dPerc / 100)
            '        bsPurchaseDetails.Current.GrossAmount = gAmt
            '        bsPurchaseDetails.Current.DiscountAmount = gAmt - amtBefVat
            '        bsPurchaseDetails.Current.Price = IIf(bsPurchaseDetails.Current.Quantity = 0, 0, gAmt / bsPurchaseDetails.Current.Quantity)
            '    End If
            '    Dim totQty As Int32 = bsPurchaseDetails.Current.Quantity + bsPurchaseDetails.Current.BonusQuantity
            '    bsPurchaseDetails.Current.UnitCost = IIf(totQty = 0, 0, bsPurchaseDetails.Current.NetAmount / totQty)
            UpdateTotals()
            'End With
        End Sub

        'Private Sub OnCellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewPurchaseDetails.CellFormatting
        '    'If e.ColumnIndex = DataGridViewPurchaseDetails.Columns("dgvDiscountAmount").Index Then
        '    '    e.FormattingApplied = True
        '    '    Dim row As DataGridViewRow = DataGridViewPurchaseDetails.Rows(e.RowIndex)
        '    '    e.Value = String.Format("{0,12:N2}", row.Cells("dgvGrossAmount").Value * row.Cells("dgvDiscountPercent").Value / 100)
        '    'End If
        'End Sub

        'Private Sub OnRowsAdded(ByVal sender As Object, ByVal e As DataGridViewRowsAddedEventArgs) Handles DataGridViewPurchaseDetails.RowsAdded
        '    If DataGridViewPurchaseDetails.CurrentRow IsNot Nothing Then
        '        For i As Integer = e.RowIndex - 1 To e.RowCount
        '            Dim row As DataGridViewRow = DataGridViewPurchaseDetails.Rows(i)
        '            row.Cells("dgvGrossAmount").Value = row.Cells("dgvQuantity").Value * row.Cells("dgvPrice").Value
        '            If row.Cells("dgvGrossAmount").Value Is Nothing OrElse row.Cells("dgvGrossAmount").Value = 0 Then
        '                row.Cells("dgvDiscountPercent").Value = String.Format("{0,6:N2}", 0)
        '            Else
        '                row.Cells("dgvDiscountPercent").Value = String.Format("{0,6:N2}", row.Cells("dgvDiscountAmount").Value / row.Cells("dgvGrossAmount").Value * 100)
        '            End If
        '            row.Cells("dgvAmtBefVat").Value = row.Cells("dgvGrossAmount").Value - row.Cells("dgvDiscountAmount").Value
        '            row.Cells("dgvAmtBefVat").Value = row.Cells("dgvGrossAmount").Value - row.Cells("dgvDiscountAmount").Value
        '        Next i
        '        'For i As Integer = 0 To e.RowCount
        '        '    Dim row As DataGridViewRow = DataGridViewPurchaseDetails.Rows(i)
        '        '    row.Cells("dgvGrossAmount").Value = row.Cells("dgvQuantity").Value * row.Cells("dgvPrice").Value
        '        '    If row.Cells("dgvGrossAmount").Value Is Nothing OrElse row.Cells("dgvGrossAmount").Value = 0 Then
        '        '        row.Cells("dgvDiscountPercent").Value = String.Format("{0,6:N2}", 0)
        '        '    Else
        '        '        row.Cells("dgvDiscountPercent").Value = String.Format("{0,6:N2}", row.Cells("dgvDiscountAmount").Value / row.Cells("dgvGrossAmount").Value * 100)
        '        '    End If
        '        '    row.Cells("dgvAmtBefVat").Value = row.Cells("dgvGrossAmount").Value - row.Cells("dgvDiscountAmount").Value
        '        '    row.Cells("dgvAmtBefVat").Value = row.Cells("dgvGrossAmount").Value - row.Cells("dgvDiscountAmount").Value
        '        'Next
        '    End If
        'End Sub


        Private Sub dataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DataGridViewPurchaseDetails.CellValidating
            If DataGridViewPurchaseDetails.IsCurrentCellDirty() Then
                With DataGridViewPurchaseDetails
                    Dim cColumnName = .CurrentCell.OwningColumn.Name
                    If cColumnName = $"dgvProductCode" Then
                        ValidateProductCode(DataGridViewPurchaseDetails, e)
                    ElseIf cColumnName = $"dgvProductName" Then
                        ValidateProductName(DataGridViewPurchaseDetails, e)
                    ElseIf cColumnName = $"dgvUnitIdNo" Then
                        ValidateUnit(DataGridViewPurchaseDetails, e)
                    ElseIf cColumnName = $"dgvExpiryDate" Then
                        DataGridViewPurchaseDetails.ValidateExpiryDate(e)
                    End If
                End With
            End If
        End Sub

        Private Sub ValidateProductName(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim findText = dgv.CurrentRow.Cells("dgvProductName").EditedFormattedValue
            If findText.Contains("<GS>") Then
                Dim scannedProduct As Object = New ExpandoObject
                scannedProduct = GetScannedData(findText)
                Dim productCode As String = ""
                RaiseEvent GTinScanned(scannedProduct.GTin, bsPurchaseDetails, productCode)
                If productCode IsNot Nothing Then
                    'Dim item As IProductView = DirectCast(product, IProductView)
                    dgv.CurrentRow.Cells("dgvProductCode").Value = productCode
                    RaiseEvent ProductCodeChanged(productCode, bsPurchaseDetails)
                    If scannedProduct.ExpiryDate IsNot Nothing Then
                        bsPurchaseDetails.Current.ExpiryDate = scannedProduct.ExpiryDate
                    End If
                    If scannedProduct.BatchNo IsNot Nothing Then
                        bsPurchaseDetails.Current.BatchNo = scannedProduct.BatchNo
                    End If
                    Dim unitIdNo As Int16 = DirectCast(bsPurchaseDetails.Current, AATM.Accounts.PresentationLayer.Views.PurchaseDetailView).UnitIdNo
                    If unitIdNo <= 0 Or _noOfUnits <= 1 Then
                        SendKeys.Send("{Tab}{Tab}{Tab}")
                    Else
                        SendKeys.Send("{Tab}{Tab}")
                    End If
                    bsPurchaseDetails.ResetBindings(False)
                End If
            Else
                Dim form As New ProductFinder(findText, dgv)
                If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim product As IProductView = form.Product
                    _noOfUnits = form.NoOfUnits
                    If product Is Nothing Then
                        Dim msg = Messaging.GetParametrizedMessage(True, "MsgInvalidValue", {"fieldValue", findText, "fieldDescription", "Product Name"})
                        Messaging.Show(msg)
                        e.Cancel = True
                        dgv.Rows(e.RowIndex).ErrorText = msg
                    Else
                        dgv.CurrentRow.Cells("dgvProductCode").Value = product.ProductCode
                        RaiseEvent ProductCodeChanged(product.ProductCode, bsPurchaseDetails)
                        Dim unitIdNo As Int16 = DirectCast(bsPurchaseDetails.Current, AATM.Accounts.PresentationLayer.Views.PurchaseDetailView).UnitIdNo
                        If unitIdNo <= 0 Or _noOfUnits <= 1 Then
                            SendKeys.Send("{Tab}")
                        End If
                        bsPurchaseDetails.ResetBindings(False)
                        ' Yes, so grab the values you want from the dialog here
                        '. = form.SelectedId
                    End If
                Else
                    e.Cancel = True
                End If
            End If
        End Sub

        Private Sub ValidateProductCode(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim code As String = dgv.CurrentRow.Cells("dgvProductCode").EditedFormattedValue
            RaiseEvent ProductCodeChanged(code, bsPurchaseDetails)
            Dim cProductName = dgv.CurrentRow().Cells("dgvProductName").Value
            If Not String.IsNullOrEmpty(cProductName) Then
                If dgv.CurrentRow.Cells("dgvUnitCount").Value = 0 Then
                    SendKeys.Send("{Tab}{Tab}")
                Else
                    SendKeys.Send("{Tab}")
                End If
            Else
                If Not String.IsNullOrEmpty(code) Then
                    e.Cancel = True
                    Messaging.ShowPmMessage(True, "MsgInvalidValue", {"fieldValue", code, "fieldDescription", "Product Code"})
                End If
            End If
        End Sub

        Private Sub ValidateUnit(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim oldUnitIdNo As Int16 = dgv.CurrentRow.Cells("dgvUnitIdNo").Value
            Dim newUnitIdNo = DirectCast(dgv.CurrentCell, AATM.Libraries.CBaseControlsLibrary.CtDgvComboBoxCell).CellEditingControl.SelectedValue
            If oldUnitIdNo <> newUnitIdNo Then
                RaiseEvent UnitChanged(oldUnitIdNo, newUnitIdNo, bsPurchaseDetails)
            End If
            'RaiseEvent ProductCodeChanged(code, bsPurchaseDetails)
            'Dim cProductName = dgv.CurrentRow().Cells("dgvProductName").Value
            'If Not String.IsNullOrEmpty(cProductName) Then
            '    SendKeys.Send("{Tab}")
            '    If dgv.CurrentRow.Cells("dgvUnitCount").Value = 1 Then
            '        SendKeys.Send("{Tab}")
            '    End If
            'Else
            '    If Not String.IsNullOrEmpty(code) Then
            '        Messaging.ShowPmMessage(True, "MsgInvalidValue", {"fieldValue", code, "fieldDescription", "Product Code"})
            '        e.Cancel = True
            '    End If
            'End If
        End Sub


        'Private Sub dataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DataGridViewPurchaseDetails.CellValidating

        '    Me.DataGridViewPurchaseDetails.Rows(e.RowIndex).ErrorText = ""

        '    ' Don't try to validate the 'new row' until finished 
        '    ' editing since there
        '    ' is not any point in validating its initial value.
        '    If DataGridViewPurchaseDetails.Rows(e.RowIndex).IsNewRow Then Return
        '    With DataGridViewPurchaseDetails
        '        Dim cColumnName = .CurrentCell.OwningColumn.Name
        '        If cColumnName = "dgvProductCode" Then
        '            If e.FormattedValue <> "" Then
        '                RaiseEvent ProductCodeChanged(e.FormattedValue, bsPurchaseDetails)
        '                If DataGridViewPurchaseDetails.CurrentRow().Cells("dgvProductName").Value = "" Then
        '                    Messaging.ShowPmMessage(True, "MsgInvalidCode", {"fieldName", Messaging.TranslateCaption("Product Code")})
        '                    e.Cancel = True
        '                Else
        '                    'MoveToGridView(DataGridViewPurchaseDetails, "dgvUnitIdNo")
        '                    'DataGridViewPurchaseDetails.CurrentCell = DataGridViewPurchaseDetails(3, DataGridViewPurchaseDetails.CurrentCell.RowIndex())
        '                End If
        '            End If
        '        ElseIf cColumnName = "dgvProductName" Then

        '            'With bsPurchaseDetails
        '            '    Dim findText = DirectCast(bsPurchaseDetails.Current, AATM.Accounts.PresentationLayer.Views.PurchaseDetailView).ProductName
        '            '    Dim form As New ProductFinder(findText, DataGridViewPurchaseDetails)
        '            '    If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '            '        Dim sIdNo As Int32 = form.SelectedId
        '            '        Dim sName As String = form.SelectedName
        '            '        DirectCast(bsPurchaseDetails.Current, AATM.Accounts.PresentationLayer.Views.PurchaseDetailView).ProductIdNo = sIdNo
        '            '        DirectCast(bsPurchaseDetails.Current, AATM.Accounts.PresentationLayer.Views.PurchaseDetailView).ProductName = sName
        '            '        ' Yes, so grab the values you want from the dialog here
        '            '        '. = form.SelectedId
        '            '    Else

        '            '    End If

        '            'End With

        '        End If
        '    End With

        '    'If Not Integer.TryParse(e.FormattedValue.ToString(), newInteger) OrElse newInteger < 0 Then

        '    '    e.Cancel = True
        '    '    Me.DataGridViewPurchaseDetails.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"

        '    'End If
        'End Sub


        Private Sub CellValidated(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewPurchaseDetails.CellValidated
            '' Clear any error messages that may have been set in cell validation.
            'DataGridViewPurchaseDetails.Rows(e.RowIndex).ErrorText = Nothing
            'With DataGridViewPurchaseDetails
            '    Dim cColumnName = .CurrentCell.OwningColumn.Name
            '    Dim cProductName = DataGridViewPurchaseDetails.CurrentRow().Cells("dgvProductName").Value
            '    If cColumnName = "dgvProductCode" And Not String.IsNullOrEmpty(cProductName) Then
            '        'MoveToGridView(DataGridViewPurchaseDetails, "dgvUnitIdNo")
            '        'ataGridViewPurchaseDetails.CurrentCell = DataGridViewPurchaseDetails(3, DataGridViewPurchaseDetails.CurrentCell.RowIndex())
            '        SendKeys.Send("{Tab}")
            '        If _noOfUnits = 0 Then
            '            SendKeys.Send("{Tab}")
            '        End If
            '    End If
            'End With
        End Sub

        'Private Sub ValidateByCell(ByVal sender As Object, ByVal data As DataGridViewCellCancelEventArgs) Handles DataGridViewPurchaseDetails.CellValidating

        '    Dim row As DataGridViewRow = DataGridViewPurchaseDetails.Rows(data.RowIndex)
        '    Dim productCodeCell As DataGridViewCell = row.Cells(DataGridViewPurchaseDetails.Columns("dgvProductCode").Index)
        '    Dim productNameCell As DataGridViewCell = row.Cells(DataGridViewPurchaseDetails.Columns("dgvProductName").Index)
        '    data.Cancel = Not (IsProductCodeGood(productCodeCell) AndAlso IsProductNameGood(productNameCell))
        'End Sub

        'Private Function IsProductCodeGood(ByRef cell As DataGridViewCell) As Boolean
        '    If cell.Value IsNot Nothing Then
        '        If cell.Value.ToString().Length = 0 Then
        '            cell.ErrorText = "Please enter a product code"
        '            DataGridViewPurchaseDetails.Rows(cell.RowIndex).ErrorText = "Please enter a product code"
        '            Return False
        '        ElseIf cell.Value.ToString().Equals("0") Then
        '            cell.ErrorText = "Zero is not a valid product code"
        '            DataGridViewPurchaseDetails.Rows(cell.RowIndex).ErrorText = "Zero is not a valid product code"
        '            Return False
        '            'ElseIf Not Integer.TryParse(cell.Value.ToString(), New Integer()) Then
        '            '    cell.ErrorText = "A Track must be a number"
        '            '    DataGridViewPurchaseDetails.Rows(cell.RowIndex).ErrorText =
        '            '"A Track must be a number"
        '            '    Return False
        '        End If
        '    End If
        '    Return True
        'End Function

        'Private Function IsProductNameGood(ByRef cell As DataGridViewCell) As Boolean
        '    If cell.Value IsNot Nothing Then
        '        If cell.Value.ToString().Length = 0 Or cell.Value.ToString().Equals("") Then
        '            cell.ErrorText = "Please enter a product name"
        '            DataGridViewPurchaseDetails.Rows(cell.RowIndex).ErrorText = "Please enter a product name"
        '            Return False
        '        End If
        '    End If
        '    Return True
        'End Function

        Private Sub OnTransactionDateValidated(sender As Object, e As EventArgs) Handles dtpTransactionDate.Validated
            Presenter.UpdateDueDate()
            Presenter.UpdateEarlySettlementValues()
            Presenter.UpdateSupplierDate()
        End Sub

        'Private Function PaymentOrDiscountMade()
        '    Dim retVal As Boolean = False
        '    If (DataGridViewPurchaseDetails.Rows(0).Cells("dgvPaidAmount").Value <> 0 Or DataGridViewPurchaseDetails.Rows(0).Cells("dgvDiscountTaken").Value <> 0) Then
        '        Messaging.Show(True, "MsgPaymentDiscExistChangeNotAllowed")
        '        retVal = True
        '    End If
        '    Return retVal
        'End Function

        'Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
        '    MoveToGridView(DataGridViewPurchaseDetails, "dgvUnitIdNo")
        'End Sub

        Private Sub UpdateTotals()
            If _footer IsNot Nothing Then
                _footer.CalculateTotals()
                txtAmount.Text = _footer.Value("dgvNetAmount").ToString("n2")
                txtVatAmount.Text = _footer.Value("dgvVatAmount").ToString("n2")
                txtGrossAmount.Text = _footer.Value("dgvGrossAmount").ToString("n2")
                txtDiscountAmount.Text = _footer.Value("dgvDiscountAmount").ToString("n2")
            End If
        End Sub


        Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles DataGridViewPurchaseDetails.UserDeletingRow
            'RaiseEvent UserDeletedRow()
            'UpdateTotals()
        End Sub

        Private Sub OnUserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewPurchaseDetails.UserDeletedRow
            UpdateTotals()
            'UpdateInputVatAmount()
        End Sub


        'Private Sub PurchaseEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    'TODO: This line of code loads data into the 'ISPDATADataSet.Product' table. You can move, or remove it, as needed.
        '    Me.ProductTableAdapter.Fill(Me.ISPDATADataSet.Product)

        'End Sub


        Private Sub grid_EditingControlShowing(ByVal s As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewPurchaseDetails.EditingControlShowing
            With DataGridViewPurchaseDetails
                Dim cColumnName = .CurrentCell.OwningColumn.Name
                If cColumnName = "dgvUnitIdNo" Then
                    Dim comboBox = TryCast(e.Control, DataGridViewComboBoxEditingControl)
                    If comboBox IsNot Nothing Then
                        RaiseEvent ProductUnitEditing(DataGridViewPurchaseDetails.CurrentRow.Cells("dgvProductIdNo").Value, bsPurchaseDetails)
                        comboBox.DropDownStyle = ComboBoxStyle.DropDown
                        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                        comboBox.DataSource = UnitsByProduct
                    End If
                ElseIf cColumnName = "dgvExpiryDate" Then
                    'Display the date in the editing format.
                    Dim cellValue = DataGridViewPurchaseDetails.CurrentCell.Value
                    Dim text = If(cellValue Is DBNull.Value, String.Empty, CDate(cellValue).ToString("yyyy/MM"))
                    e.Control.Text = text
                End If
            End With
        End Sub

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewPurchaseDetails.CellBeginEdit
            'If DataGridViewPurchaseDetails.CurrentCell.RowIndex() = 0 Then
            With DataGridViewPurchaseDetails.CurrentCell
                Dim cColumnName = .OwningColumn.Name()
                If cColumnName = $"dgvUnitIdNo" Then
                    RaiseEvent ProductUnitSelection(DataGridViewPurchaseDetails.CurrentRow.Cells("dgvProductIdNo").Value, bsPurchaseDetails)
                End If
                '    Beep()
                '    e.Cancel = True
                '    DataGridViewPurchaseDetails.EndEdit()
                'End If
            End With
            'ElseIf (DataGridViewPurchaseDetails.CurrentRow.Cells("dgvPaidAmount").Value <> 0 Or DataGridViewPurchaseDetails.CurrentRow.Cells("dgvDiscountTaken").Value <> 0) _
            '       And DataGridViewPurchaseDetails.CurrentCell.OwningColumn.Name.ToLower() = $"dgvProductIdNo" Then
            '    Beep()
            '    e.Cancel = True
            '    DataGridViewPurchaseDetails.EndEdit()
            '    Messaging.Show(True, "MsgPaymentDiscExistChangeNotAllowed")
            ' End If
        End Sub


        'Private Sub DataGridViewPurchase_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPurchaseDetails.CellValueChanged
        '    If e.RowIndex >= 0 Then
        '        Dim newDate As DateTime

        '        Select Case DataGridViewPurchaseDetails.Columns(e.ColumnIndex).Name
        '            Case "ProductName"
        '                Dim newText As String = Me.DataGridViewPurchaseDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        '                'Case "ColumnCombo"
        '                '    Dim newPriority As String = Me.DataGridViewPurchase.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        '                'Case "ColumnDate"
        '                '    DateTime.TryParse(Me.DataGridViewPurchase.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), newDate)
        '        End Select
        '    End If
        'End Sub


        'Private Sub DataGridViewPurchase_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPurchaseDetails.CellValueChanged
        '    With eventType.BindingSource
        '        If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
        '            Dim accountId = eventType.BindingSource.Current.AccountIdNo
        '            Select Case eventType.PropertyName
        '                Case $"AccountIdNo"
        '                    MakePayTypeAndSpecialAccount(eventType.BindingSource.Current, accountId)
        '                    View.VatAmount = UpdateInputVatAmount(View.JournalItems)
        '                    eventType.BindingSource.ResetItem(eventType.Row)
        '                Case $"Debit"
        '                    MakeDebitAmount(eventType.BindingSource.Current, eventType.BindingSource.Current.Debit)
        '                    eventType.BindingSource.ResetItem(eventType.Row)
        '                    View.VatAmount = UpdateInputVatAmount(View.JournalItems)
        '                Case $"Credit"
        '                    MakeCreditAmount(eventType.BindingSource.Current, eventType.BindingSource.Current.Credit)
        '                    eventType.BindingSource.ResetItem(eventType.Row)
        '                    View.VatAmount = UpdateInputVatAmount(View.JournalItems)
        '            End Select
        '        End If
        '    End With
        'End Sub


        <System.Security.Permissions.UIPermission(System.Security.Permissions.SecurityAction.LinkDemand, Window:=System.Security.Permissions.UIPermissionWindow.AllWindows)>
        Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean

            ' Extract the key code from the key value. 
            Dim key As Keys = keyData And Keys.KeyCode

            ' Handle the ENTER key as if it were a RIGHT ARROW key. 
            'If key = Keys.Enter Then
            '    Return Me.ProcessRightKey(keyData)
            'End If


            Return MyBase.ProcessDialogKey(keyData)

        End Function


        '<System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, Flags:=System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)>
        'Protected Overrides Function ProcessDataGridViewKey(ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean

        '    ' Handle the ENTER key as if it were a RIGHT ARROW key. 
        '    If e.KeyCode = Keys.Enter Then
        '        Return Me.ProcessRightKey(e.KeyData)
        '    End If

        '    Return MyBase.ProcessDataGridViewKey(e)

        'End Function


        Private WithEvents txtQrText As New DataGridViewTextBoxEditingControl

        Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridViewPurchaseDetails.EditingControlShowing
            If DataGridViewPurchaseDetails.CurrentCell.OwningColumn.Name = "dgvProductName" Then
                txtQrText = CType(DataGridViewPurchaseDetails.EditingControl, DataGridViewTextBoxEditingControl)
            End If
        End Sub

        Private Sub txtQrText_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtQrText.KeyPress
            Dim i As Integer = txtQrText.SelectionStart 'save for later use

            Select Case Asc(e.KeyChar)

                'Case 4 'EOT

                '    Me.txtQrCode.Text = Me.txtQrCode.Text.Insert(Me.txtQrCode.SelectionStart, "<EOT>")

                '    Me.txtQrCode.SelectionStart = i + 5

                '    e.Handled = True

                Case 29 'GS

                    txtQrText.Text = txtQrText.Text.Insert(txtQrText.SelectionStart, "<GS>")
                    txtQrText.SelectionStart = i + 5
                    e.Handled = True

                    'Case 30 'RS

                    '    Me.txtQrCode.Text = Me.txtQrCode.Text.Insert(Me.txtQrCode.SelectionStart, "<RS>")

                    '    Me.txtQrCode.SelectionStart = i + 5

                    '    e.Handled = True
                    Dim x = 1
                    x = 1

            End Select
        End Sub


        Private Sub DataGridViewPurchaseDetails_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPurchaseDetails.RowEnter
            Dim newRow As DataGridViewRow = DataGridViewPurchaseDetails.Rows(e.RowIndex)
            Dim prIdNo As Int32 = newRow.Cells("dgvProductIdNo").Value
            RaiseEvent RowChanged(prIdNo)
            bsPurchaseHistory.ResetBindings(False)
        End Sub

    End Class

End Namespace