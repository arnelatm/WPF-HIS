Imports System.ComponentModel
Imports System.Dynamic
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class InvTransactionEntry
        Implements IInvTransactionView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _footer As DgvFooter
        Private _InvTransactionDetails As List(Of InvTransactionDetailView)
        Private _noOfUnits As Int16
        Public Event ProductCodeChanged(productCode As String, bs As BindingSource) Implements IInvTransactionView.ProductCodeChanged
        Public Event GTinScanned(GTin As String, bs As BindingSource, ByRef productCode As String) Implements IInvTransactionView.GTinScanned
        Public Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource) Implements IInvTransactionView.ProductUnitSelection
        Public Event ProductUnitEditing(productIdNo As Int32) Implements IInvTransactionView.ProductUnitEditing
        Public Event UnitChanged(oldUnit As Int16, newUnit As Int16, bs As BindingSource, formattedValue As String) Implements IInvTransactionView.UnitChanged
        Public Event RowChanged(productIdNo As Int32) Implements IInvTransactionView.RowChanged
        Public Event PostData(idNo As Int32) Implements IInvTransactionView.PostData

        Public Property ProductsByCode As DataTable Implements IInvTransactionView.ProductsByCode
        Public Property UnitsByCode As DataTable Implements IInvTransactionView.UnitsByCode
        Public Property UnitsByProduct As DataTable Implements IInvTransactionView.UnitsByProduct

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            _nfi.NumberDecimalDigits = 2
        End Sub

        'Private Sub JiBs_AddingNew(ByVal sender As Object, ByVal e As AddingNewEventArgs) Handles bsInvTransactionDetails.AddingNew
        '    e.NewObject = New InvTransactionDetailView
        '    ' work around for error on datagrid entry on lastrow please do not remove.
        '    ' The reason it works Is because On a DataGridView where AllowUserToAddRows Is True,
        '    ' it adds an empty row at the end of its rows which if bound to a list creates a null element at the end of the list.
        '    ' The code removes that element And then the AddNew in the BindingList will trigger the DataGridView to add it again
        '    If DataGridViewInvTransactionDetails.Rows.Count = bsInvTransactionDetails.Count Then
        '        bsInvTransactionDetails.RemoveAt(bsInvTransactionDetails.Count - 1)
        '    End If
        'End Sub

#Region "Fields"

        Public Property Amount As Decimal Implements IInvTransactionView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property DateCreated As DateTime Implements IInvTransactionView.DateCreated
            Get
                Try
                    Return Convert.ToDateTime(txtDateCreated.Text)
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
            Set
                txtDateCreated.Text = Value
            End Set
        End Property

        Public Property IdNo As Int32 Implements IInvTransactionView.IdNo
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


        Public Property InvTransactionDetails As List(Of InvTransactionDetailView) Implements IInvTransactionView.InvTransactionDetails
            Get
                Return _InvTransactionDetails
            End Get
            Set
                _InvTransactionDetails = Value
                BindInvTransactionDetail()
            End Set
        End Property

        Public Property Notes As String Implements IInvTransactionView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property Posted As Boolean Implements IInvTransactionView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set(value As Boolean)
                chkPosted.Checked = value
                If value Then
                    btnPost.Enabled = False
                Else
                    btnPost.Enabled = True
                End If
            End Set
        End Property

        'Public Property SettlementDiscount As Decimal Implements IInvTransactionView.SettlementDiscount
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

        'Public Property SettlementDueDate As Date? Implements IInvTransactionView.SettlementDueDate
        '    Get
        '        Return dtpSettlementDueDate.Value
        '    End Get
        '    Set
        '        dtpSettlementDueDate.Value = Value
        '    End Set
        'End Property

        Public Property WarehouseIdNo As Int16 Implements IInvTransactionView.WarehouseIdNo
            Get
                Return cboWarehouseIdNo.GetValue(Of Int16)
            End Get
            Set
                cboWarehouseIdNo.SetValue(Value)
            End Set
        End Property

        'Public ReadOnly Property TotalCredits As Decimal Implements IInvTransactionView.TotalCredits
        '    Get
        '        Return NumParser(Of Decimal)(txtTotalCredits.Text)
        '    End Get
        'End Property

        'Public ReadOnly Property TotalDebits As Decimal Implements IInvTransactionView.TotalDebits
        '    Get
        '        Return NumParser(Of Decimal)(txtTotalDebits.Text)
        '    End Get
        'End Property

        Public Property TransactionDate As Date? Implements IInvTransactionView.TransactionDate
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

        'Public Property TransactionType As String Implements IInvTransactionView.TransactionType
        '    Get
        '        Return cboTransactionType.GetValue()
        '    End Get
        '    Set
        '        cboTransactionType.SetValue(Value)
        '    End Set
        'End Property

        Public Property Cancelled As Boolean Implements IInvTransactionView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property ReferenceNo As String Implements IInvTransactionView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property UserIdNo As Int16 Implements IInvTransactionView.UserIdNo
            Get
                Return cboUserIdNo.GetValue(Of Int16)()
            End Get
            Set(value As Short)
                cboUserIdNo.SetValue(value)
            End Set
        End Property

        Public Property InvTransTypeIdNo As Int16 Implements IInvTransactionView.InvTransTypeIdNo
            Get
                Return cboInvTransTypeIdNo.GetValue(Of Int16)
            End Get
            Set(value As Short)
                cboInvTransTypeIdNo.SetValue(value)
            End Set
        End Property

        Public Property WarehouseToIdNo As Int16? Implements IInvTransactionView.WarehouseToIdNo
            Get
                Return cboWarehouseToIdNo.GetValue(Of Int16)
            End Get
            Set(value As Int16?)
                cboWarehouseToIdNo.SetValue(value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"Amount", txtAmount},
         {"Cancelled", chkCancelled},
         {"DateCreated", txtDateCreated},
         {"IdNo", TxtIdNo},
         {"InvTransTypeIdNo", cboInvTransTypeIdNo},
         {"Notes", txtNotes},
         {"Posted", chkPosted},
         {"ReferenceNo", txtReferenceNo},
         {"TransactionDate", dtpTransactionDate},
         {"UserIdNo", cboUserIdNo},
         {"WarehouseIdNo", cboWarehouseIdNo},
         {"WarehouseToIdNo", cboWarehouseToIdNo}
        }
        End Sub

        Protected Sub InvTransactionUpdateView() Handles MyBase.AfterUpdateView
            UpdateTotals()
        End Sub

        Private Sub InvTransactionEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _footer = New DgvFooter(DataGridViewInvTransactionDetails) With {
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
            DataGridViewInvTransactionDetails.Columns("dgvExpiryDate").DefaultCellStyle.Format = "yyyy/MM"
            SetupDgvColumns()
            UpdateTotals()
            If DirectCast(cboWarehouseIdNo.DataSource, System.Data.DataTable).Rows.Count() < 2 Then
                cboWarehouseIdNo.Enabled = False
            Else
                cboWarehouseIdNo.Enabled = True
            End If
        End Sub

        Private Sub BindInvTransactionDetail()
            SuspendLayout()
            bsInvTransactionDetails.DataSource = Nothing
            DataGridViewInvTransactionDetails.Refresh()
            bsInvTransactionDetails.DataSource = InvTransactionDetails
            bsInvTransactionDetails.AllowNew = True
            'SetupDgvColumns()
            ResumeLayout()
        End Sub


        Private Sub SetupDgvColumns()
            dgvSequence.DisplayOnly = True
            dgvUnitIdNo.ValueMember = "IdNo"
            dgvUnitIdNo.DisplayMember = "Name"
            dgvUnitIdNo.DataSource = UnitsByCode
            dgvQuantity.DecimalPlaces = 0
            dgvBonusQuantity.DecimalPlaces = 0
            dgvUnitCost.DisplayOnly = True
            dgvUnitCost.SetFormat(7, 2)
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

        'Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewInvTransactionDetails.CellBeginEdit
        '    'If DataGridViewInvTransactionDetails.CurrentCell.RowIndex() = 0 Then
        '    With DataGridViewInvTransactionDetails.CurrentCell
        '        Dim cColumnName = .OwningColumn.Name()
        '        If cColumnName = $"dgvUnitIdNo" Then
        '            RaiseEvent ProductUnitSelection(DataGridViewInvTransactionDetails.CurrentRow.Cells("dgvProductIdNo").Value, bsInvTransactionDetails)
        '        End If
        '        '    Beep()
        '        '    e.Cancel = True
        '        '    DataGridViewInvTransactionDetails.EndEdit()
        '        'End If
        '    End With
        '    'ElseIf (DataGridViewInvTransactionDetails.CurrentRow.Cells("dgvPaidAmount").Value <> 0 Or DataGridViewInvTransactionDetails.CurrentRow.Cells("dgvDiscountTaken").Value <> 0) _
        '    '       And DataGridViewInvTransactionDetails.CurrentCell.OwningColumn.Name.ToLower() = $"dgvProductIdNo" Then
        '    '    Beep()
        '    '    e.Cancel = True
        '    '    DataGridViewInvTransactionDetails.EndEdit()
        '    '    Messaging.Show(True, "MsgPaymentDiscExistChangeNotAllowed")
        '    ' End If
        'End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInvTransactionDetails.CellEndEdit
            Select Case DataGridViewInvTransactionDetails.CurrentCell().OwningColumn.Name
                Case $"dgvProductCode", $"dgvProductName"
                    ' nothing to do already processed
                Case Else
                    ProcessCellEndEdit(DataGridViewInvTransactionDetails, bsInvTransactionDetails)
            End Select

            'With bsInvTransactionDetails.Current
            '    Dim gAmt As Decimal = 0
            '    Dim dAmt As Decimal = 0
            '    Dim price As Decimal = 0
            '    Dim vAmt As Decimal = 0
            '    Dim amtBefVat As Decimal = 0
            '    Dim dPerc As Decimal = 0
            '    Dim vPerc As Decimal = 0
            '    Dim nAmt As Decimal = 0
            '    If DataGridViewInvTransactionDetails.CurrentCell().OwningColumn.Name = "dgvQuantity" Then
            '        gAmt = bsInvTransactionDetails.Current.Price * bsInvTransactionDetails.Current.Quantity
            '        bsInvTransactionDetails.Current.GrossAmount = gAmt
            '        dAmt = gAmt * bsInvTransactionDetails.Current.DiscountPercent / 100
            '        bsInvTransactionDetails.Current.DiscountAmount = dAmt
            '        bsInvTransactionDetails.Current.AmtBefVat = gAmt - dAmt
            '        vAmt = (gAmt - dAmt) * bsInvTransactionDetails.Current.VatPercent / 100
            '        bsInvTransactionDetails.Current.VatAmount = vAmt
            '        bsInvTransactionDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewInvTransactionDetails.CurrentCell().OwningColumn.Name = "dgvPrice" Then
            '        gAmt = bsInvTransactionDetails.Current.Price * bsInvTransactionDetails.Current.Quantity
            '        bsInvTransactionDetails.Current.GrossAmount = gAmt
            '        dAmt = gAmt * bsInvTransactionDetails.Current.DiscountPercent / 100
            '        bsInvTransactionDetails.Current.DiscountAmount = dAmt
            '        bsInvTransactionDetails.Current.AmtBefVat = gAmt - dAmt
            '        vAmt = (gAmt - dAmt) * bsInvTransactionDetails.Current.VatPercent / 100
            '        bsInvTransactionDetails.Current.VatAmount = vAmt
            '        bsInvTransactionDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewInvTransactionDetails.CurrentCell().OwningColumn.Name = "dgvGrossAmount" Then
            '        gAmt = bsInvTransactionDetails.Current.GrossAmount
            '        price = IIf(bsInvTransactionDetails.Current.Quantity = 0, 0, gAmt / bsInvTransactionDetails.Current.Quantity)
            '        bsInvTransactionDetails.Current.Price = price
            '        dAmt = gAmt * bsInvTransactionDetails.Current.DiscountPercent / 100
            '        bsInvTransactionDetails.Current.DiscountAmount = dAmt
            '        bsInvTransactionDetails.Current.DiscountPercent = dAmt / gAmt * 100
            '        vAmt = (gAmt - dAmt) * bsInvTransactionDetails.Current.VatPercent / 100
            '        bsInvTransactionDetails.Current.VatAmount = vAmt
            '        bsInvTransactionDetails.Current.AmtBefVat = gAmt - dAmt
            '        bsInvTransactionDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewInvTransactionDetails.CurrentCell().OwningColumn.Name = "dgvVatAmount" Then
            '        gAmt = bsInvTransactionDetails.Current.GrossAmount
            '        dAmt = bsInvTransactionDetails.Current.DiscountAmount
            '        vAmt = bsInvTransactionDetails.Current.VatAmount
            '        vPerc = IIf(gAmt - dAmt = 0, 0, vAmt / (gAmt - dAmt) * 100)
            '        bsInvTransactionDetails.Current.VatPercent = vPerc
            '        bsInvTransactionDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewInvTransactionDetails.CurrentCell().OwningColumn.Name = "dgvVatPercent" Then
            '        vPerc = bsInvTransactionDetails.Current.VatPercent
            '        gAmt = bsInvTransactionDetails.Current.GrossAmount
            '        dAmt = bsInvTransactionDetails.Current.DiscountAmount
            '        vAmt = (gAmt - dAmt) * vPerc / 100
            '        bsInvTransactionDetails.Current.VatAmount = vAmt
            '        bsInvTransactionDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewInvTransactionDetails.CurrentCell().OwningColumn.Name = "dgvDiscountPercent" Then
            '        gAmt = bsInvTransactionDetails.Current.GrossAmount
            '        dAmt = gAmt * bsInvTransactionDetails.Current.DiscountPercent / 100
            '        bsInvTransactionDetails.Current.DiscountAmount = dAmt
            '        bsInvTransactionDetails.Current.AmtBefVat = gAmt - dAmt
            '        vAmt = (gAmt - dAmt) * bsInvTransactionDetails.Current.VatPercent / 100
            '        bsInvTransactionDetails.Current.VatAmount = vAmt
            '        bsInvTransactionDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewInvTransactionDetails.CurrentCell().OwningColumn.Name = "dgvDiscountAmount" Then
            '        gAmt = bsInvTransactionDetails.Current.GrossAmount
            '        dAmt = bsInvTransactionDetails.Current.DiscountAmount
            '        dPerc = IIf(gAmt = 0, 0, dAmt / gAmt * 100)
            '        bsInvTransactionDetails.Current.DiscountPercent = dPerc
            '        bsInvTransactionDetails.Current.AmtBefVat = gAmt - dAmt
            '        vAmt = (gAmt - dAmt) * bsInvTransactionDetails.Current.VatPercent / 100
            '        bsInvTransactionDetails.Current.VatAmount = vAmt
            '        bsInvTransactionDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewInvTransactionDetails.CurrentCell().OwningColumn.Name = "dgvAmtBefVat" Then
            '        amtBefVat = bsInvTransactionDetails.Current.AmtBefVat
            '        gAmt = bsInvTransactionDetails.Current.GrossAmount
            '        If amtBefVat <= gAmt Then
            '            dAmt = gAmt - amtBefVat
            '            bsInvTransactionDetails.Current.DiscountAmount = dAmt
            '            dPerc = IIf(gAmt = 0, 0, dAmt / gAmt * 100)
            '            bsInvTransactionDetails.Current.DiscountPercent = dPerc
            '            vAmt = amtBefVat * bsInvTransactionDetails.Current.VatPercent / 100
            '            bsInvTransactionDetails.Current.VatAmount = vAmt
            '            bsInvTransactionDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '        Else
            '            dAmt = bsInvTransactionDetails.Current.DiscountAmount
            '            gAmt = amtBefVat - dAmt
            '            bsInvTransactionDetails.Current.GrossAmount = gAmt
            '            price = IIf(bsInvTransactionDetails.Current.Quantity = 0, 0, gAmt / bsInvTransactionDetails.Current.Quantity)
            '            bsInvTransactionDetails.Current.Price = price
            '            dPerc = IIf(gAmt = 0, 0, dAmt / gAmt * 100)
            '            bsInvTransactionDetails.Current.DiscountPercent = dPerc
            '            vAmt = amtBefVat * bsInvTransactionDetails.Current.VatPercent / 100
            '            bsInvTransactionDetails.Current.VatAmount = vAmt
            '            bsInvTransactionDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '        End If
            '    ElseIf DataGridViewInvTransactionDetails.CurrentCell().OwningColumn.Name = "dgvNetAmount" Then
            '        nAmt = bsInvTransactionDetails.Current.NetAmount
            '        vPerc = bsInvTransactionDetails.Current.VatPercent
            '        dPerc = bsInvTransactionDetails.Current.DiscountPercent
            '        amtBefVat = nAmt / (1 + vPerc / 100)
            '        bsInvTransactionDetails.Current.AmtBefVat = amtBefVat
            '        bsInvTransactionDetails.Current.VatAmount = nAmt - amtBefVat
            '        gAmt = amtBefVat / (1 - dPerc / 100)
            '        bsInvTransactionDetails.Current.GrossAmount = gAmt
            '        bsInvTransactionDetails.Current.DiscountAmount = gAmt - amtBefVat
            '        bsInvTransactionDetails.Current.Price = IIf(bsInvTransactionDetails.Current.Quantity = 0, 0, gAmt / bsInvTransactionDetails.Current.Quantity)
            '    End If
            '    Dim totQty As Int32 = bsInvTransactionDetails.Current.Quantity + bsInvTransactionDetails.Current.BonusQuantity
            '    bsInvTransactionDetails.Current.UnitCost = IIf(totQty = 0, 0, bsInvTransactionDetails.Current.NetAmount / totQty)
            UpdateTotals()
            'End With
        End Sub

        'Private Sub OnCellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewInvTransactionDetails.CellFormatting
        '    'If e.ColumnIndex = DataGridViewInvTransactionDetails.Columns("dgvDiscountAmount").Index Then
        '    '    e.FormattingApplied = True
        '    '    Dim row As DataGridViewRow = DataGridViewInvTransactionDetails.Rows(e.RowIndex)
        '    '    e.Value = String.Format("{0,12:N2}", row.Cells("dgvGrossAmount").Value * row.Cells("dgvDiscountPercent").Value / 100)
        '    'End If
        'End Sub

        'Private Sub OnRowsAdded(ByVal sender As Object, ByVal e As DataGridViewRowsAddedEventArgs) Handles DataGridViewInvTransactionDetails.RowsAdded
        '    If DataGridViewInvTransactionDetails.CurrentRow IsNot Nothing Then
        '        For i As Integer = e.RowIndex - 1 To e.RowCount
        '            Dim row As DataGridViewRow = DataGridViewInvTransactionDetails.Rows(i)
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
        '        '    Dim row As DataGridViewRow = DataGridViewInvTransactionDetails.Rows(i)
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


        Private Sub dataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DataGridViewInvTransactionDetails.CellValidating
            If DataGridViewInvTransactionDetails.IsCurrentCellDirty() Then
                With DataGridViewInvTransactionDetails
                    Dim cColumnName = .CurrentCell.OwningColumn.Name
                    If cColumnName = $"dgvProductCode" Then
                        ValidateProductCode(DataGridViewInvTransactionDetails, e)
                    ElseIf cColumnName = $"dgvProductName" Then
                        ValidateProductName(DataGridViewInvTransactionDetails, e)
                    ElseIf cColumnName = $"dgvUnitIdNo" Then
                        '(DataGridViewInvTransactionDetails, e)
                    ElseIf cColumnName = $"dgvExpiryDate" Then
                        ValidateExpiryDate(DataGridViewInvTransactionDetails, e)
                    End If
                End With
            End If
        End Sub

        Private Sub ValidateExpiryDate(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim needsExpiryDate As Boolean = dgv.CurrentRow.Cells("dgvNeedsExpiryDate").Value
            Dim allowBlankDate As Boolean = Not needsExpiryDate
            DataGridViewInvTransactionDetails.ValidateExpiryDate(e, allowBlankDate)
        End Sub

        Private Sub ValidateProductName(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim findText = dgv.CurrentRow.Cells("dgvProductName").EditedFormattedValue
            If findText.Contains("<GS>") Then
                Dim scannedProduct As Object = New ExpandoObject
                scannedProduct = Accounts.AccountHelpers.GetScannedData(findText)
                Dim productCode As String = ""
                RaiseEvent GTinScanned(scannedProduct.GTin, bsInvTransactionDetails, productCode)
                If productCode IsNot Nothing Then
                    'Dim item As IProductView = DirectCast(product, IProductView)
                    'dgv.CurrentRow.Cells("dgvProductCode").Value = productCode
                    RaiseEvent ProductCodeChanged(productCode, bsInvTransactionDetails)
                    If scannedProduct.ExpiryDate IsNot Nothing Then
                        bsInvTransactionDetails.Current.ExpiryDate = scannedProduct.ExpiryDate
                    End If
                    If scannedProduct.BatchNo IsNot Nothing Then
                        bsInvTransactionDetails.Current.BatchNo = scannedProduct.BatchNo
                    End If
                    Dim unitIdNo As Int16 = DirectCast(bsInvTransactionDetails.Current, AATM.Accounts.PresentationLayer.Views.InvTransactionDetailView).UnitIdNo
                    If unitIdNo <= 0 Or _noOfUnits <= 1 Then
                        SendKeys.Send("{Tab}{Tab}{Tab}")
                    Else
                        SendKeys.Send("{Tab}{Tab}")
                    End If
                    bsInvTransactionDetails.ResetBindings(False)
                End If
            Else
                Dim form As New ProductFinder(findText, dgv)
                If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim product As ProductModel = form.Product
                    _noOfUnits = form.NoOfUnits
                    If product Is Nothing Then
                        Dim msg = Messaging.GetParametrizedMessage(True, "MsgInvalidValue", {"fieldValue", findText, "fieldDescription", "Product Name"})
                        Messaging.Show(msg)
                        e.Cancel = True
                        dgv.Rows(e.RowIndex).ErrorText = msg
                    Else
                        RaiseEvent ProductCodeChanged(product.ProductCode, bsInvTransactionDetails)
                        Dim unitIdNo As Int16 = DirectCast(bsInvTransactionDetails.Current, AATM.Accounts.PresentationLayer.Views.InvTransactionDetailView).UnitIdNo
                        If unitIdNo <= 0 Or _noOfUnits <= 1 Then
                            SendKeys.Send("{Tab}")
                        End If
                        bsInvTransactionDetails.ResetBindings(False)
                    End If
                Else
                    e.Cancel = True
                End If
            End If
        End Sub

        Private Sub ValidateProductCode(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim code As String = dgv.CurrentRow.Cells("dgvProductCode").EditedFormattedValue
            RaiseEvent ProductCodeChanged(code, bsInvTransactionDetails)
            Dim cProductName = dgv.CurrentRow().Cells("dgvProductName").Value
            If Not String.IsNullOrEmpty(cProductName) Then
                If dgv.CurrentRow.Cells("dgvUnitCount").Value < 2 Then
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

        'Private Sub ValidateUnit(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
        '    Dim oldUnitIdNo As Int16 = dgv.CurrentRow.Cells("dgvUnitIdNo").EditedFormattedValue
        '    Dim newUnitIdNo As Int16 = CInt(DirectCast(dgv.CurrentCell, AATM.Libraries.CBaseControlsLibrary.CtDgvComboBoxCell).CellEditingControl.EditingControlFormattedValue)
        '    If oldUnitIdNo <> newUnitIdNo Then
        '        RaiseEvent UnitChanged(oldUnitIdNo, newUnitIdNo, bsInvTransactionDetails, e.FormattedValue)
        '    End If
        '    'RaiseEvent ProductCodeChanged(code, bsInvTransactionDetails)
        '    'Dim cProductName = dgv.CurrentRow().Cells("dgvProductName").Value
        '    'If Not String.IsNullOrEmpty(cProductName) Then
        '    '    SendKeys.Send("{Tab}")
        '    '    If dgv.CurrentRow.Cells("dgvUnitCount").Value = 1 Then
        '    '        SendKeys.Send("{Tab}")
        '    '    End If
        '    'Else
        '    '    If Not String.IsNullOrEmpty(code) Then
        '    '        Messaging.ShowPmMessage(True, "MsgInvalidValue", {"fieldValue", code, "fieldDescription", "Product Code"})
        '    '        e.Cancel = True
        '    '    End If
        '    'End If
        'End Sub


        'Private Sub dataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DataGridViewInvTransactionDetails.CellValidating

        '    Me.DataGridViewInvTransactionDetails.Rows(e.RowIndex).ErrorText = ""

        '    ' Don't try to validate the 'new row' until finished 
        '    ' editing since there
        '    ' is not any point in validating its initial value.
        '    If DataGridViewInvTransactionDetails.Rows(e.RowIndex).IsNewRow Then Return
        '    With DataGridViewInvTransactionDetails
        '        Dim cColumnName = .CurrentCell.OwningColumn.Name
        '        If cColumnName = "dgvProductCode" Then
        '            If e.FormattedValue <> "" Then
        '                RaiseEvent ProductCodeChanged(e.FormattedValue, bsInvTransactionDetails)
        '                If DataGridViewInvTransactionDetails.CurrentRow().Cells("dgvProductName").Value = "" Then
        '                    Messaging.ShowPmMessage(True, "MsgInvalidCode", {"fieldName", Messaging.TranslateCaption("Product Code")})
        '                    e.Cancel = True
        '                Else
        '                    'MoveToGridView(DataGridViewInvTransactionDetails, "dgvUnitIdNo")
        '                    'DataGridViewInvTransactionDetails.CurrentCell = DataGridViewInvTransactionDetails(3, DataGridViewInvTransactionDetails.CurrentCell.RowIndex())
        '                End If
        '            End If
        '        ElseIf cColumnName = "dgvProductName" Then

        '            'With bsInvTransactionDetails
        '            '    Dim findText = DirectCast(bsInvTransactionDetails.Current, AATM.Accounts.PresentationLayer.Views.InvTransactionDetailView).ProductName
        '            '    Dim form As New ProductFinder(findText, DataGridViewInvTransactionDetails)
        '            '    If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '            '        Dim sIdNo As Int32 = form.SelectedId
        '            '        Dim sName As String = form.SelectedName
        '            '        DirectCast(bsInvTransactionDetails.Current, AATM.Accounts.PresentationLayer.Views.InvTransactionDetailView).ProductIdNo = sIdNo
        '            '        DirectCast(bsInvTransactionDetails.Current, AATM.Accounts.PresentationLayer.Views.InvTransactionDetailView).ProductName = sName
        '            '        ' Yes, so grab the values you want from the dialog here
        '            '        '. = form.SelectedId
        '            '    Else

        '            '    End If

        '            'End With

        '        End If
        '    End With

        '    'If Not Integer.TryParse(e.FormattedValue.ToString(), newInteger) OrElse newInteger < 0 Then

        '    '    e.Cancel = True
        '    '    Me.DataGridViewInvTransactionDetails.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"

        '    'End If
        'End Sub


        Private Sub CellValidated(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewInvTransactionDetails.CellValidated
            '' Clear any error messages that may have been set in cell validation.
            'DataGridViewInvTransactionDetails.Rows(e.RowIndex).ErrorText = Nothing
            'With DataGridViewInvTransactionDetails
            '    Dim cColumnName = .CurrentCell.OwningColumn.Name
            '    Dim cProductName = DataGridViewInvTransactionDetails.CurrentRow().Cells("dgvProductName").Value
            '    If cColumnName = "dgvProductCode" And Not String.IsNullOrEmpty(cProductName) Then
            '        'MoveToGridView(DataGridViewInvTransactionDetails, "dgvUnitIdNo")
            '        'ataGridViewInvTransactionDetails.CurrentCell = DataGridViewInvTransactionDetails(3, DataGridViewInvTransactionDetails.CurrentCell.RowIndex())
            '        SendKeys.Send("{Tab}")
            '        If _noOfUnits = 0 Then
            '            SendKeys.Send("{Tab}")
            '        End If
            '    End If
            'End With
        End Sub

        'Private Sub ValidateByCell(ByVal sender As Object, ByVal data As DataGridViewCellCancelEventArgs) Handles DataGridViewInvTransactionDetails.CellValidating

        '    Dim row As DataGridViewRow = DataGridViewInvTransactionDetails.Rows(data.RowIndex)
        '    Dim productCodeCell As DataGridViewCell = row.Cells(DataGridViewInvTransactionDetails.Columns("dgvProductCode").Index)
        '    Dim productNameCell As DataGridViewCell = row.Cells(DataGridViewInvTransactionDetails.Columns("dgvProductName").Index)
        '    data.Cancel = Not (IsProductCodeGood(productCodeCell) AndAlso IsProductNameGood(productNameCell))
        'End Sub

        'Private Function IsProductCodeGood(ByRef cell As DataGridViewCell) As Boolean
        '    If cell.Value IsNot Nothing Then
        '        If cell.Value.ToString().Length = 0 Then
        '            cell.ErrorText = "Please enter a product code"
        '            DataGridViewInvTransactionDetails.Rows(cell.RowIndex).ErrorText = "Please enter a product code"
        '            Return False
        '        ElseIf cell.Value.ToString().Equals("0") Then
        '            cell.ErrorText = "Zero is not a valid product code"
        '            DataGridViewInvTransactionDetails.Rows(cell.RowIndex).ErrorText = "Zero is not a valid product code"
        '            Return False
        '            'ElseIf Not Integer.TryParse(cell.Value.ToString(), New Integer()) Then
        '            '    cell.ErrorText = "A Track must be a number"
        '            '    DataGridViewInvTransactionDetails.Rows(cell.RowIndex).ErrorText =
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
        '            DataGridViewInvTransactionDetails.Rows(cell.RowIndex).ErrorText = "Please enter a product name"
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
        '    If (DataGridViewInvTransactionDetails.Rows(0).Cells("dgvPaidAmount").Value <> 0 Or DataGridViewInvTransactionDetails.Rows(0).Cells("dgvDiscountTaken").Value <> 0) Then
        '        Messaging.Show(True, "MsgPaymentDiscExistChangeNotAllowed")
        '        retVal = True
        '    End If
        '    Return retVal
        'End Function

        'Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
        '    MoveToGridView(DataGridViewInvTransactionDetails, "dgvUnitIdNo")
        'End Sub

        Private Sub UpdateTotals()
            If _footer IsNot Nothing Then
                _footer.CalculateTotals()
                Dim netAmtBefVat As Decimal = _footer.Value("dgvNetAmount")
                Dim vatAmount As Decimal = _footer.Value("dgvVatAmount")
                txtAmount.Text = (netAmtBefVat + vatAmount).ToString("n2")
                txtGrossAmount.Text = _footer.Value("dgvGrossAmount").ToString("n2")
                txtDiscountAmount.Text = _footer.Value("dgvDiscountAmount").ToString("n2")
            End If
        End Sub


        Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles DataGridViewInvTransactionDetails.UserDeletingRow
            'RaiseEvent UserDeletedRow()
            'UpdateTotals()
        End Sub

        Private Sub OnUserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewInvTransactionDetails.UserDeletedRow
            UpdateTotals()
            'UpdateInputVatAmount()
        End Sub


        'Private Sub InvTransactionEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    'TODO: This line of code loads data into the 'ISPDATADataSet.Product' table. You can move, or remove it, as needed.
        '    Me.ProductTableAdapter.Fill(Me.ISPDATADataSet.Product)

        'End Sub

        Private Sub grid_EditingControlShowing(ByVal s As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewInvTransactionDetails.EditingControlShowing
            With DataGridViewInvTransactionDetails
                Dim cColumnName = .CurrentCell.OwningColumn.Name
                If cColumnName = "dgvUnitIdNo" Then
                    Dim comboBox = TryCast(e.Control, DataGridViewComboBoxEditingControl)
                    If comboBox IsNot Nothing Then
                        RaiseEvent ProductUnitSelection(DataGridViewInvTransactionDetails.CurrentRow.Cells("dgvProductIdNo").Value, bsInvTransactionDetails)
                        comboBox.DropDownStyle = ComboBoxStyle.DropDown
                        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                        comboBox.DataSource = UnitsByProduct
                    End If
                ElseIf cColumnName = "dgvExpiryDate" Then
                    'Display the date in the editing format.
                    Dim cellValue = DataGridViewInvTransactionDetails.CurrentCell.Value
                    Dim text = If(cellValue Is DBNull.Value, "", CDate(cellValue).ToString("yyyy/MM"))
                    e.Control.Text = text
                End If
            End With
        End Sub

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewInvTransactionDetails.CellBeginEdit
            'If DataGridViewInvTransactionDetails.CurrentCell.RowIndex() = 0 Then
            With DataGridViewInvTransactionDetails.CurrentCell
                Dim cColumnName = .OwningColumn.Name()
                If cColumnName = $"dgvUnitIdNo" Then
                    RaiseEvent ProductUnitEditing(DataGridViewInvTransactionDetails.CurrentRow.Cells("dgvProductIdNo").Value)
                End If
                '    Beep()
                '    e.Cancel = True
                '    DataGridViewInvTransactionDetails.EndEdit()
                'End If
            End With
            'ElseIf (DataGridViewInvTransactionDetails.CurrentRow.Cells("dgvPaidAmount").Value <> 0 Or DataGridViewInvTransactionDetails.CurrentRow.Cells("dgvDiscountTaken").Value <> 0) _
            '       And DataGridViewInvTransactionDetails.CurrentCell.OwningColumn.Name.ToLower() = $"dgvProductIdNo" Then
            '    Beep()
            '    e.Cancel = True
            '    DataGridViewInvTransactionDetails.EndEdit()
            '    Messaging.Show(True, "MsgPaymentDiscExistChangeNotAllowed")
            ' End If
        End Sub


        'Private Sub DataGridViewInvTransaction_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInvTransactionDetails.CellValueChanged
        '    If e.RowIndex >= 0 Then
        '        Dim newDate As DateTime

        '        Select Case DataGridViewInvTransactionDetails.Columns(e.ColumnIndex).Name
        '            Case "ProductName"
        '                Dim newText As String = Me.DataGridViewInvTransactionDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        '                'Case "ColumnCombo"
        '                '    Dim newPriority As String = Me.DataGridViewInvTransaction.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        '                'Case "ColumnDate"
        '                '    DateTime.TryParse(Me.DataGridViewInvTransaction.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), newDate)
        '        End Select
        '    End If
        'End Sub


        'Private Sub DataGridViewInvTransaction_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInvTransactionDetails.CellValueChanged
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

        Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridViewInvTransactionDetails.EditingControlShowing
            If DataGridViewInvTransactionDetails.CurrentCell.OwningColumn.Name = "dgvProductName" Then
                txtQrText = CType(DataGridViewInvTransactionDetails.EditingControl, DataGridViewTextBoxEditingControl)
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


        Private Sub DataGridViewInvTransactionDetails_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInvTransactionDetails.RowEnter
            Dim dgvRow As DataGridViewRow = DataGridViewInvTransactionDetails.Rows(e.RowIndex)
            Dim prIdNo As Int32 = dgvRow.Cells("dgvProductIdNo").Value
            RaiseEvent RowChanged(prIdNo)
            CGroupBox1.Text = Messaging.TranslateCaption("InvTransaction History for ") + dgvRow.Cells("dgvProductCode").Value + "-" + dgvRow.Cells("dgvProductName").Value
        End Sub

        ' Changes how cells are displayed depending on their columns and values.
        Private Sub dgvPurDetailsFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridViewInvTransactionDetails.CellFormatting
            If e.ColumnIndex > 0 Then
                If sender.Columns(e.ColumnIndex).Name.Equals("dgvExpiryDate") Then
                    If e.Value = Date.MinValue Then
                        e.Value = String.Empty
                        e.FormattingApplied = True
                    ElseIf e.Value < DateAdd(DateInterval.Day, Today().Day * -1, Today) Then
                        e.CellStyle.BackColor = Color.Red
                    End If
                ElseIf sender.Columns(e.ColumnIndex).Name.Equals("dgvUnitSalesPrice") Then
                    Dim x = DirectCast(sender, DataGridView).Rows(e.RowIndex)
                    If x IsNot Nothing Then
                        If x.Cells("dgvProductIdNo").Value <> 0 Then
                            If e.Value Is Nothing Or e.Value <= x.Cells("dgvUnitCost").Value Then
                                e.CellStyle.BackColor = Color.Red
                            End If
                        End If
                    End If
                End If
            End If
        End Sub

        ' Changes how cells are displayed depending on their columns and values.
        Private Sub dgvPurHistoryFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
            If sender.Columns(e.ColumnIndex).Name.Equals("dgvExpiryDateH") Then
                If e.Value = Date.MinValue Then
                    e.Value = String.Empty
                    e.FormattingApplied = True
                ElseIf e.Value < DateAdd(DateInterval.Day, Today().Day * -1, Today) Then
                    e.CellStyle.BackColor = Color.Red
                End If
            End If
        End Sub

        Private Sub btnPost_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPost.ClickButtonArea
            If Not Posted Then
                Dim caption = Messaging.TranslateCaption("Please confirm.")
                Dim action As String = Messaging.TranslateCaption("post")
                Dim itemName As String = Messaging.TranslateCaption("InvTransaction transaction")
                Dim msg = Messaging.GetParametrizedMessage(True, "AskIfContinueAction", {"action", action, "itemName", itemName})
                If Messaging.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    RaiseEvent PostData(IdNo)
                End If
            End If
        End Sub
    End Class

End Namespace