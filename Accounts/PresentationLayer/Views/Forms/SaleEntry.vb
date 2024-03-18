Imports System.ComponentModel
Imports System.Dynamic
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class SaleEntry
        Implements ISaleView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _footer As DgvFooter
        Private _SaleDetails As List(Of SaleDetailView)
        Private _noOfUnits As Int16
        Public Event ProductCodeChanged(productCode As String, bs As BindingSource) Implements ISaleView.ProductCodeChanged
        Public Event GTinScanned(GTin As String, bs As BindingSource, ByRef productCode As String) Implements ISaleView.GTinScanned
        Public Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource) Implements ISaleView.ProductUnitSelection
        Public Event ProductUnitEditing(productIdNo As Int32, bs As BindingSource) Implements ISaleView.ProductUnitEditing
        Public Event UnitChanged(oldUnit As Int16, newUnit As Int16, bs As BindingSource, formattedValue As String) Implements ISaleView.UnitChanged
        Public Event RowChanged(productIdNo As Int32) Implements ISaleView.RowChanged
        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            _nfi.NumberDecimalDigits = 2
        End Sub

        'Private Sub JiBs_AddingNew(ByVal sender As Object, ByVal e As AddingNewEventArgs) Handles bsSaleDetails.AddingNew
        '    e.NewObject = New SaleDetailView
        '    ' work around for error on datagrid entry on lastrow please do not remove.
        '    ' The reason it works Is because On a DataGridView where AllowUserToAddRows Is True,
        '    ' it adds an empty row at the end of its rows which if bound to a list creates a null element at the end of the list.
        '    ' The code removes that element And then the AddNew in the BindingList will trigger the DataGridView to add it again
        '    If DataGridViewSaleDetails.Rows.Count = bsSaleDetails.Count Then
        '        bsSaleDetails.RemoveAt(bsSaleDetails.Count - 1)
        '    End If
        'End Sub

#Region "Fields"


        Private Property ProductsByCode Implements ISaleView.ProductsByCode
        Private Property UnitsByCode Implements ISaleView.UnitsByCode
        Private Property UnitsByProduct Implements ISaleView.UnitsByProduct

        Public Property Amount As Decimal Implements ISaleView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements ISaleView.DateCreated
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

        Public Property DueDate As Date? Implements ISaleView.DueDate
            Get
                Return dtpDueDate.Value
            End Get
            Set
                dtpDueDate.Value = Value
            End Set
        End Property

        Public Property IdNo As Int32 Implements ISaleView.IdNo
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

        Public Property SaleDetails As List(Of SaleDetailView) Implements ISaleView.SaleDetails
            Get
                Return _SaleDetails
            End Get
            Set
                _SaleDetails = Value
                BindSaleDetail()
            End Set
        End Property


        'Public Property Notes As String Implements ISaleView.Notes
        '    Get
        '        Return txtNotes.Text
        '    End Get
        '    Set
        '        txtNotes.Text = If(Value, "")
        '    End Set
        'End Property

        Public Property Posted As Boolean Implements ISaleView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set(value As Boolean)
                chkPosted.Checked = value
            End Set
        End Property

        'Public Property SettlementDiscount As Decimal Implements ISaleView.SettlementDiscount
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

        'Public Property SettlementDueDate As Date? Implements ISaleView.SettlementDueDate
        '    Get
        '        Return dtpSettlementDueDate.Value
        '    End Get
        '    Set
        '        dtpSettlementDueDate.Value = Value
        '    End Set
        'End Property

        Public Property CustomerIdNo As Int32? Implements ISaleView.CustomerIdNo
            Get
                Return cboCustomerIdNo.GetValue(Of Int32)
            End Get
            Set
                cboCustomerIdNo.SetValue(Value)
            End Set
        End Property

        Public Property WarehouseIdNo As Int16 Implements ISaleView.WarehouseIdNo
            Get
                Return cboWarehouseIdNo.GetValue(Of Int16)
            End Get
            Set
                cboWarehouseIdNo.SetValue(Value)
            End Set
        End Property

        'Public ReadOnly Property TotalCredits As Decimal Implements ISaleView.TotalCredits
        '    Get
        '        Return NumParser(Of Decimal)(txtTotalCredits.Text)
        '    End Get
        'End Property

        'Public ReadOnly Property TotalDebits As Decimal Implements ISaleView.TotalDebits
        '    Get
        '        Return NumParser(Of Decimal)(txtTotalDebits.Text)
        '    End Get
        'End Property

        Public Property TransactionDate As Date? Implements ISaleView.TransactionDate
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

        'Public Property TransactionType As String Implements ISaleView.TransactionType
        '    Get
        '        Return cboTransactionType.GetValue()
        '    End Get
        '    Set
        '        cboTransactionType.SetValue(Value)
        '    End Set
        'End Property

        Public Property VatAmount As Decimal Implements ISaleView.VatAmount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtVatAmount.Text), _nfi)
            End Get
            Set
                txtVatAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property Cancelled As Boolean Implements ISaleView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property FileNo As Int32? Implements ISaleView.FileNo
            Get
                If txtFileNo.Text <> "" Then
                    Return Convert.ToInt32(txtFileNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtFileNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property InvoiceNo As String Implements ISaleView.InvoiceNo
            Get
                Return txtInvoiceNo.Text
            End Get
            Set
                txtInvoiceNo.Text = Value
            End Set
        End Property

        Public Property PatientName As String Implements ISaleView.PatientName
            Get
                Return txtPatientName.Text
            End Get
            Set
                txtPatientName.Text = Value
            End Set
        End Property

        Public Property UserIdNo As Short Implements ISaleView.UserIdNo
            Get
                Return cboUserIdNo.GetValue(Of Int16)
            End Get
            Set
                cboUserIdNo.SetValue(Value)
            End Set
        End Property

        Public Property JournalIdNo As Integer Implements ISaleView.JournalIdNo
            Get
                Return txtJournalIdNo.Text
            End Get
            Set
                txtJournalIdNo.Text = Value
            End Set
        End Property

        Public Property NationalityCode As String Implements ISaleView.NationalityCode
            Get
                Return cboNationalityCode.GetValue(Of String)
            End Get
            Set(value As String)
                cboNationalityCode.SetValue(value)
            End Set
        End Property

        Public Property Gender As String Implements ISaleView.Gender
            Get
                Return cboGender.GetValue(Of String)
            End Get
            Set(value As String)
                cboGender.SetValue(value)
            End Set
        End Property

        Public Property Age As Short Implements ISaleView.Age
            Get
                Return txtAge.Text
            End Get
            Set
                txtAge.Text = Value
            End Set
        End Property

        Public Property AgeDmy As String Implements ISaleView.AgeDmy
            Get
                Return cboAgeYmd.GetValue(Of String)
            End Get
            Set
                cboAgeYmd.SetValue(Value)
            End Set
        End Property

        Public Property PhoneNo As String Implements ISaleView.PhoneNo
            Get
                Return txtPhoneNo.Text
            End Get
            Set
                txtPhoneNo.Text = Value
            End Set
        End Property

        Public Property DoctorIdNo As Short Implements ISaleView.DoctorIdNo
            Get
                Return cboDoctorIdNo.GetValue(Of String)
            End Get
            Set
                cboDoctorIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PatientType As String Implements ISaleView.PatientType
            Get
                Return cboPatientType.GetValue(Of String)
            End Get
            Set
                cboPatientType.SetValue(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
            {
             {"Age", txtAge},
             {"AgeYmd", cboAgeYmd},
             {"Amount", txtAmount},
             {"Cancelled", chkCancelled},
             {"CustomerIdNo", cboCustomerIdNo},
             {"DateCreated", txtDateCreated},
             {"DoctorIdNo", cboDoctorIdNo},
             {"DueDate", dtpDueDate},
             {"FileNo", txtFileNo},
             {"Gender", cboGender},
             {"IdNo", TxtIdNo},
             {"InvoiceNo", txtInvoiceNo},
             {"JournalIdNo", txtJournalIdNo},
             {"NationalityCode", cboNationalityCode},
             {"PatientIdNo", txtFileNo},
             {"PatientType", cboPatientType},
             {"Posted", chkPosted},
             {"TransactionDate", dtpTransactionDate},
             {"UserIdNo", cboUserIdNo},
             {"VatAmount", txtVatAmount},
             {"WarehouseIdNo", cboWarehouseIdNo}
            }
        End Sub

        Protected Sub SaleUpdateView() Handles MyBase.AfterUpdateView
            UpdateTotals()
        End Sub

        Private Sub SaleEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _footer = New DgvFooter(DataGridViewSaleDetails) With {
                .AutoCalc = True
            }
            _footer.ColumnToSum("dgvQuantity", 0) = True
            _footer.ColumnToSum("dgvGrossAmount") = True
            _footer.ColumnToSum("dgvDiscountAmount") = True
            _footer.ColumnToSum("dgvAmtBefVat") = True
            _footer.ColumnToSum("dgvVatAmount") = True
            _footer.ColumnToSum("dgvNetAmount") = True
            _footer.SetAlignment("dgvQuantity", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvGrossAmount", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvDiscountAmount", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvAmtBefVat", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvVatAmount", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvNetAmount", ContentAlignment.MiddleRight)
            _footer.SetText("dgvProductName", "Totals ->")
            DataGridViewSaleDetails.Columns("dgvExpiryDate").DefaultCellStyle.Format = "yyyy/MM"
            UpdateTotals()
        End Sub

        Private Sub BindSaleDetail()
            SuspendLayout()
            bsSaleDetails.DataSource = Nothing
            DataGridViewSaleDetails.Refresh()
            bsSaleDetails.DataSource = SaleDetails
            bsSaleDetails.AllowNew = True
            SetupDgvColumns()
            ResumeLayout()
        End Sub


        Private Sub SetupDgvColumns()
            dgvSequence.DisplayOnly = True
            dgvUnitIdNo.DataSource = UnitsByCode
            dgvUnitIdNo.DisplayMember = "Name"
            dgvUnitIdNo.ValueMember = "idNo"
            dgvUnitIdNo.DisplayStyleForCurrentCellOnly = True
            dgvQuantity.DecimalPlaces = 0
            dgvUnitCost.DisplayOnly = True
            dgvUnitCost.SetFormat(7, 2)
        End Sub

        Private Sub CboCustomerIdNo_Changed(sender As Object, e As EventArgs) Handles cboCustomerIdNo.Validated, cboCustomerIdNo.SelectionChangeCommitted
            Presenter.UpdateDueDate()
            'Presenter.UpdateEarlySettlementValues()
        End Sub

        Private Sub CboCustomerIdNo_Validating(sender As Object, e As CancelEventArgs)
            'If PaymentOrDiscountMade() Then
            '    ' revert to previous value
            '    cboCustomerIdNo.RevertValue()
            'End If
        End Sub

        Private Overloads Sub Dispose()
            Close()
            '_footer.Dispose()
        End Sub

        'Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewSaleDetails.CellBeginEdit
        '    'If DataGridViewSaleDetails.CurrentCell.RowIndex() = 0 Then
        '    With DataGridViewSaleDetails.CurrentCell
        '        Dim cColumnName = .OwningColumn.Name()
        '        If cColumnName = $"dgvUnitIdNo" Then
        '            RaiseEvent ProductUnitSelection(DataGridViewSaleDetails.CurrentRow.Cells("dgvProductIdNo").Value, bsSaleDetails)
        '        End If
        '        '    Beep()
        '        '    e.Cancel = True
        '        '    DataGridViewSaleDetails.EndEdit()
        '        'End If
        '    End With
        '    'ElseIf (DataGridViewSaleDetails.CurrentRow.Cells("dgvPaidAmount").Value <> 0 Or DataGridViewSaleDetails.CurrentRow.Cells("dgvDiscountTaken").Value <> 0) _
        '    '       And DataGridViewSaleDetails.CurrentCell.OwningColumn.Name.ToLower() = $"dgvProductIdNo" Then
        '    '    Beep()
        '    '    e.Cancel = True
        '    '    DataGridViewSaleDetails.EndEdit()
        '    '    Messaging.Show(True, "MsgPaymentDiscExistChangeNotAllowed")
        '    ' End If
        'End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSaleDetails.CellEndEdit
            Select Case DataGridViewSaleDetails.CurrentCell().OwningColumn.Name
                Case $"dgvProductCode", $"dgvProductName"
                    ' nothing to do already processed
                Case Else
                    ProcessCellEndEdit(DataGridViewSaleDetails, bsSaleDetails)
            End Select

            'With bsSaleDetails.Current
            '    Dim gAmt As Decimal = 0
            '    Dim dAmt As Decimal = 0
            '    Dim price As Decimal = 0
            '    Dim vAmt As Decimal = 0
            '    Dim amtBefVat As Decimal = 0
            '    Dim dPerc As Decimal = 0
            '    Dim vPerc As Decimal = 0
            '    Dim nAmt As Decimal = 0
            '    If DataGridViewSaleDetails.CurrentCell().OwningColumn.Name = "dgvQuantity" Then
            '        gAmt = bsSaleDetails.Current.Price * bsSaleDetails.Current.Quantity
            '        bsSaleDetails.Current.GrossAmount = gAmt
            '        dAmt = gAmt * bsSaleDetails.Current.DiscountPercent / 100
            '        bsSaleDetails.Current.DiscountAmount = dAmt
            '        bsSaleDetails.Current.AmtBefVat = gAmt - dAmt
            '        vAmt = (gAmt - dAmt) * bsSaleDetails.Current.VatPercent / 100
            '        bsSaleDetails.Current.VatAmount = vAmt
            '        bsSaleDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewSaleDetails.CurrentCell().OwningColumn.Name = "dgvPrice" Then
            '        gAmt = bsSaleDetails.Current.Price * bsSaleDetails.Current.Quantity
            '        bsSaleDetails.Current.GrossAmount = gAmt
            '        dAmt = gAmt * bsSaleDetails.Current.DiscountPercent / 100
            '        bsSaleDetails.Current.DiscountAmount = dAmt
            '        bsSaleDetails.Current.AmtBefVat = gAmt - dAmt
            '        vAmt = (gAmt - dAmt) * bsSaleDetails.Current.VatPercent / 100
            '        bsSaleDetails.Current.VatAmount = vAmt
            '        bsSaleDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewSaleDetails.CurrentCell().OwningColumn.Name = "dgvGrossAmount" Then
            '        gAmt = bsSaleDetails.Current.GrossAmount
            '        price = IIf(bsSaleDetails.Current.Quantity = 0, 0, gAmt / bsSaleDetails.Current.Quantity)
            '        bsSaleDetails.Current.Price = price
            '        dAmt = gAmt * bsSaleDetails.Current.DiscountPercent / 100
            '        bsSaleDetails.Current.DiscountAmount = dAmt
            '        bsSaleDetails.Current.DiscountPercent = dAmt / gAmt * 100
            '        vAmt = (gAmt - dAmt) * bsSaleDetails.Current.VatPercent / 100
            '        bsSaleDetails.Current.VatAmount = vAmt
            '        bsSaleDetails.Current.AmtBefVat = gAmt - dAmt
            '        bsSaleDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewSaleDetails.CurrentCell().OwningColumn.Name = "dgvVatAmount" Then
            '        gAmt = bsSaleDetails.Current.GrossAmount
            '        dAmt = bsSaleDetails.Current.DiscountAmount
            '        vAmt = bsSaleDetails.Current.VatAmount
            '        vPerc = IIf(gAmt - dAmt = 0, 0, vAmt / (gAmt - dAmt) * 100)
            '        bsSaleDetails.Current.VatPercent = vPerc
            '        bsSaleDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewSaleDetails.CurrentCell().OwningColumn.Name = "dgvVatPercent" Then
            '        vPerc = bsSaleDetails.Current.VatPercent
            '        gAmt = bsSaleDetails.Current.GrossAmount
            '        dAmt = bsSaleDetails.Current.DiscountAmount
            '        vAmt = (gAmt - dAmt) * vPerc / 100
            '        bsSaleDetails.Current.VatAmount = vAmt
            '        bsSaleDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewSaleDetails.CurrentCell().OwningColumn.Name = "dgvDiscountPercent" Then
            '        gAmt = bsSaleDetails.Current.GrossAmount
            '        dAmt = gAmt * bsSaleDetails.Current.DiscountPercent / 100
            '        bsSaleDetails.Current.DiscountAmount = dAmt
            '        bsSaleDetails.Current.AmtBefVat = gAmt - dAmt
            '        vAmt = (gAmt - dAmt) * bsSaleDetails.Current.VatPercent / 100
            '        bsSaleDetails.Current.VatAmount = vAmt
            '        bsSaleDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewSaleDetails.CurrentCell().OwningColumn.Name = "dgvDiscountAmount" Then
            '        gAmt = bsSaleDetails.Current.GrossAmount
            '        dAmt = bsSaleDetails.Current.DiscountAmount
            '        dPerc = IIf(gAmt = 0, 0, dAmt / gAmt * 100)
            '        bsSaleDetails.Current.DiscountPercent = dPerc
            '        bsSaleDetails.Current.AmtBefVat = gAmt - dAmt
            '        vAmt = (gAmt - dAmt) * bsSaleDetails.Current.VatPercent / 100
            '        bsSaleDetails.Current.VatAmount = vAmt
            '        bsSaleDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '    ElseIf DataGridViewSaleDetails.CurrentCell().OwningColumn.Name = "dgvAmtBefVat" Then
            '        amtBefVat = bsSaleDetails.Current.AmtBefVat
            '        gAmt = bsSaleDetails.Current.GrossAmount
            '        If amtBefVat <= gAmt Then
            '            dAmt = gAmt - amtBefVat
            '            bsSaleDetails.Current.DiscountAmount = dAmt
            '            dPerc = IIf(gAmt = 0, 0, dAmt / gAmt * 100)
            '            bsSaleDetails.Current.DiscountPercent = dPerc
            '            vAmt = amtBefVat * bsSaleDetails.Current.VatPercent / 100
            '            bsSaleDetails.Current.VatAmount = vAmt
            '            bsSaleDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '        Else
            '            dAmt = bsSaleDetails.Current.DiscountAmount
            '            gAmt = amtBefVat - dAmt
            '            bsSaleDetails.Current.GrossAmount = gAmt
            '            price = IIf(bsSaleDetails.Current.Quantity = 0, 0, gAmt / bsSaleDetails.Current.Quantity)
            '            bsSaleDetails.Current.Price = price
            '            dPerc = IIf(gAmt = 0, 0, dAmt / gAmt * 100)
            '            bsSaleDetails.Current.DiscountPercent = dPerc
            '            vAmt = amtBefVat * bsSaleDetails.Current.VatPercent / 100
            '            bsSaleDetails.Current.VatAmount = vAmt
            '            bsSaleDetails.Current.NetAmount = gAmt - dAmt + vAmt
            '        End If
            '    ElseIf DataGridViewSaleDetails.CurrentCell().OwningColumn.Name = "dgvNetAmount" Then
            '        nAmt = bsSaleDetails.Current.NetAmount
            '        vPerc = bsSaleDetails.Current.VatPercent
            '        dPerc = bsSaleDetails.Current.DiscountPercent
            '        amtBefVat = nAmt / (1 + vPerc / 100)
            '        bsSaleDetails.Current.AmtBefVat = amtBefVat
            '        bsSaleDetails.Current.VatAmount = nAmt - amtBefVat
            '        gAmt = amtBefVat / (1 - dPerc / 100)
            '        bsSaleDetails.Current.GrossAmount = gAmt
            '        bsSaleDetails.Current.DiscountAmount = gAmt - amtBefVat
            '        bsSaleDetails.Current.Price = IIf(bsSaleDetails.Current.Quantity = 0, 0, gAmt / bsSaleDetails.Current.Quantity)
            '    End If
            '    Dim totQty As Int32 = bsSaleDetails.Current.Quantity + bsSaleDetails.Current.BonusQuantity
            '    bsSaleDetails.Current.UnitCost = IIf(totQty = 0, 0, bsSaleDetails.Current.NetAmount / totQty)
            UpdateTotals()
            'End With
        End Sub

        'Private Sub OnCellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewSaleDetails.CellFormatting
        '    'If e.ColumnIndex = DataGridViewSaleDetails.Columns("dgvDiscountAmount").Index Then
        '    '    e.FormattingApplied = True
        '    '    Dim row As DataGridViewRow = DataGridViewSaleDetails.Rows(e.RowIndex)
        '    '    e.Value = String.Format("{0,12:N2}", row.Cells("dgvGrossAmount").Value * row.Cells("dgvDiscountPercent").Value / 100)
        '    'End If
        'End Sub

        'Private Sub OnRowsAdded(ByVal sender As Object, ByVal e As DataGridViewRowsAddedEventArgs) Handles DataGridViewSaleDetails.RowsAdded
        '    If DataGridViewSaleDetails.CurrentRow IsNot Nothing Then
        '        For i As Integer = e.RowIndex - 1 To e.RowCount
        '            Dim row As DataGridViewRow = DataGridViewSaleDetails.Rows(i)
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
        '        '    Dim row As DataGridViewRow = DataGridViewSaleDetails.Rows(i)
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


        Private Sub dataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DataGridViewSaleDetails.CellValidating
            If DataGridViewSaleDetails.IsCurrentCellDirty() Then
                With DataGridViewSaleDetails
                    Dim cColumnName = .CurrentCell.OwningColumn.Name
                    If cColumnName = $"dgvProductCode" Then
                        ValidateProductCode(DataGridViewSaleDetails, e)
                    ElseIf cColumnName = $"dgvProductName" Then
                        ValidateProductName(DataGridViewSaleDetails, e)
                    ElseIf cColumnName = $"dgvUnitIdNo" Then
                        ValidateUnit(DataGridViewSaleDetails, e)
                    ElseIf cColumnName = $"dgvExpiryDate" Then
                        ValidateExpiryDate(DataGridViewSaleDetails, e)
                    End If
                End With
            End If
        End Sub

        Private Sub ValidateExpiryDate(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim needsExpiryDate As Boolean = dgv.CurrentRow.Cells("dgvNeedsExpiryDate").Value
            Dim allowBlankDate As Boolean = Not needsExpiryDate
            DataGridViewSaleDetails.ValidateExpiryDate(e, allowBlankDate)
        End Sub

        Private Sub ValidateProductName(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim findText = dgv.CurrentRow.Cells("dgvProductName").EditedFormattedValue
            If findText.Contains("<GS>") Then
                Dim scannedProduct As Object = New ExpandoObject
                scannedProduct = Accounts.AccountHelpers.GetQrCodeInfo(findText)
                Dim productCode As String = ""
                RaiseEvent GTinScanned(scannedProduct.GTin, bsSaleDetails, productCode)
                If productCode IsNot Nothing Then
                    'Dim item As IProductView = DirectCast(product, IProductView)
                    'dgv.CurrentRow.Cells("dgvProductCode").Value = productCode
                    RaiseEvent ProductCodeChanged(productCode, bsSaleDetails)
                    If scannedProduct.ExpiryDate IsNot Nothing Then
                        bsSaleDetails.Current.ExpiryDate = scannedProduct.ExpiryDate
                    End If
                    If scannedProduct.BatchNo IsNot Nothing Then
                        bsSaleDetails.Current.BatchNo = scannedProduct.BatchNo
                    End If
                    Dim unitIdNo As Int16 = DirectCast(bsSaleDetails.Current, AATM.Accounts.PresentationLayer.Views.SaleDetailView).UnitIdNo
                    If unitIdNo <= 0 Or _noOfUnits <= 1 Then
                        SendKeys.Send("{Tab}{Tab}{Tab}")
                    Else
                        SendKeys.Send("{Tab}{Tab}")
                    End If
                    bsSaleDetails.ResetBindings(False)
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
                        RaiseEvent ProductCodeChanged(product.ProductCode, bsSaleDetails)
                        Dim unitIdNo As Int16 = DirectCast(bsSaleDetails.Current, AATM.Accounts.PresentationLayer.Views.SaleDetailView).UnitIdNo
                        If unitIdNo <= 0 Or _noOfUnits <= 1 Then
                            SendKeys.Send("{Tab}")
                        End If
                        bsSaleDetails.ResetBindings(False)
                    End If
                Else
                    e.Cancel = True
                End If
            End If
        End Sub

        Private Sub ValidateProductCode(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim code As String = dgv.CurrentRow.Cells("dgvProductCode").EditedFormattedValue
            RaiseEvent ProductCodeChanged(code, bsSaleDetails)
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

        Private Sub ValidateUnit(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim oldUnitIdNo As Int16 = dgv.CurrentRow.Cells("dgvUnitIdNo").Value
            Dim newUnitIdNo = DirectCast(dgv.CurrentCell, AATM.Libraries.CBaseControlsLibrary.CtComboBoxCell).CellEditingControl.SelectedValue
            If oldUnitIdNo <> newUnitIdNo Then
                RaiseEvent UnitChanged(oldUnitIdNo, newUnitIdNo, bsSaleDetails, e.FormattedValue)
            End If
            'RaiseEvent ProductCodeChanged(code, bsSaleDetails)
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


        'Private Sub dataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DataGridViewSaleDetails.CellValidating

        '    Me.DataGridViewSaleDetails.Rows(e.RowIndex).ErrorText = ""

        '    ' Don't try to validate the 'new row' until finished 
        '    ' editing since there
        '    ' is not any point in validating its initial value.
        '    If DataGridViewSaleDetails.Rows(e.RowIndex).IsNewRow Then Return
        '    With DataGridViewSaleDetails
        '        Dim cColumnName = .CurrentCell.OwningColumn.Name
        '        If cColumnName = "dgvProductCode" Then
        '            If e.FormattedValue <> "" Then
        '                RaiseEvent ProductCodeChanged(e.FormattedValue, bsSaleDetails)
        '                If DataGridViewSaleDetails.CurrentRow().Cells("dgvProductName").Value = "" Then
        '                    Messaging.ShowPmMessage(True, "MsgInvalidCode", {"fieldName", Messaging.TranslateCaption("Product Code")})
        '                    e.Cancel = True
        '                Else
        '                    'MoveToGridView(DataGridViewSaleDetails, "dgvUnitIdNo")
        '                    'DataGridViewSaleDetails.CurrentCell = DataGridViewSaleDetails(3, DataGridViewSaleDetails.CurrentCell.RowIndex())
        '                End If
        '            End If
        '        ElseIf cColumnName = "dgvProductName" Then

        '            'With bsSaleDetails
        '            '    Dim findText = DirectCast(bsSaleDetails.Current, AATM.Accounts.PresentationLayer.Views.SaleDetailView).ProductName
        '            '    Dim form As New ProductFinder(findText, DataGridViewSaleDetails)
        '            '    If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '            '        Dim sIdNo As Int32 = form.SelectedId
        '            '        Dim sName As String = form.SelectedName
        '            '        DirectCast(bsSaleDetails.Current, AATM.Accounts.PresentationLayer.Views.SaleDetailView).ProductIdNo = sIdNo
        '            '        DirectCast(bsSaleDetails.Current, AATM.Accounts.PresentationLayer.Views.SaleDetailView).ProductName = sName
        '            '        ' Yes, so grab the values you want from the dialog here
        '            '        '. = form.SelectedId
        '            '    Else

        '            '    End If

        '            'End With

        '        End If
        '    End With

        '    'If Not Integer.TryParse(e.FormattedValue.ToString(), newInteger) OrElse newInteger < 0 Then

        '    '    e.Cancel = True
        '    '    Me.DataGridViewSaleDetails.Rows(e.RowIndex).ErrorText = "the value must be a non-negative integer"

        '    'End If
        'End Sub


        Private Sub CellValidated(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewSaleDetails.CellValidated
            '' Clear any error messages that may have been set in cell validation.
            'DataGridViewSaleDetails.Rows(e.RowIndex).ErrorText = Nothing
            'With DataGridViewSaleDetails
            '    Dim cColumnName = .CurrentCell.OwningColumn.Name
            '    Dim cProductName = DataGridViewSaleDetails.CurrentRow().Cells("dgvProductName").Value
            '    If cColumnName = "dgvProductCode" And Not String.IsNullOrEmpty(cProductName) Then
            '        'MoveToGridView(DataGridViewSaleDetails, "dgvUnitIdNo")
            '        'ataGridViewSaleDetails.CurrentCell = DataGridViewSaleDetails(3, DataGridViewSaleDetails.CurrentCell.RowIndex())
            '        SendKeys.Send("{Tab}")
            '        If _noOfUnits = 0 Then
            '            SendKeys.Send("{Tab}")
            '        End If
            '    End If
            'End With
        End Sub

        'Private Sub ValidateByCell(ByVal sender As Object, ByVal data As DataGridViewCellCancelEventArgs) Handles DataGridViewSaleDetails.CellValidating

        '    Dim row As DataGridViewRow = DataGridViewSaleDetails.Rows(data.RowIndex)
        '    Dim productCodeCell As DataGridViewCell = row.Cells(DataGridViewSaleDetails.Columns("dgvProductCode").Index)
        '    Dim productNameCell As DataGridViewCell = row.Cells(DataGridViewSaleDetails.Columns("dgvProductName").Index)
        '    data.Cancel = Not (IsProductCodeGood(productCodeCell) AndAlso IsProductNameGood(productNameCell))
        'End Sub

        'Private Function IsProductCodeGood(ByRef cell As DataGridViewCell) As Boolean
        '    If cell.Value IsNot Nothing Then
        '        If cell.Value.ToString().Length = 0 Then
        '            cell.ErrorText = "Please enter a product code"
        '            DataGridViewSaleDetails.Rows(cell.RowIndex).ErrorText = "Please enter a product code"
        '            Return False
        '        ElseIf cell.Value.ToString().Equals("0") Then
        '            cell.ErrorText = "Zero is not a valid product code"
        '            DataGridViewSaleDetails.Rows(cell.RowIndex).ErrorText = "Zero is not a valid product code"
        '            Return False
        '            'ElseIf Not Integer.TryParse(cell.Value.ToString(), New Integer()) Then
        '            '    cell.ErrorText = "A Track must be a number"
        '            '    DataGridViewSaleDetails.Rows(cell.RowIndex).ErrorText =
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
        '            DataGridViewSaleDetails.Rows(cell.RowIndex).ErrorText = "Please enter a product name"
        '            Return False
        '        End If
        '    End If
        '    Return True
        'End Function

        Private Sub OnTransactionDateValidated(sender As Object, e As EventArgs) Handles dtpTransactionDate.Validated
            Presenter.UpdateDueDate()
            Presenter.UpdateEarlySettlementValues()
            Presenter.UpdateCustomerDate()
        End Sub

        'Private Function PaymentOrDiscountMade()
        '    Dim retVal As Boolean = False
        '    If (DataGridViewSaleDetails.Rows(0).Cells("dgvPaidAmount").Value <> 0 Or DataGridViewSaleDetails.Rows(0).Cells("dgvDiscountTaken").Value <> 0) Then
        '        Messaging.Show(True, "MsgPaymentDiscExistChangeNotAllowed")
        '        retVal = True
        '    End If
        '    Return retVal
        'End Function

        'Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
        '    MoveToGridView(DataGridViewSaleDetails, "dgvUnitIdNo")
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


        Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles DataGridViewSaleDetails.UserDeletingRow
            'RaiseEvent UserDeletedRow()
            'UpdateTotals()
        End Sub

        Private Sub OnUserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewSaleDetails.UserDeletedRow
            UpdateTotals()
            'UpdateInputVatAmount()
        End Sub


        'Private Sub SaleEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    'TODO: This line of code loads data into the 'ISPDATADataSet.Product' table. You can move, or remove it, as needed.
        '    Me.ProductTableAdapter.Fill(Me.ISPDATADataSet.Product)

        'End Sub


        Private Sub grid_EditingControlShowing(ByVal s As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewSaleDetails.EditingControlShowing
            With DataGridViewSaleDetails
                Dim cColumnName = .CurrentCell.OwningColumn.Name
                If cColumnName = "dgvUnitIdNo" Then
                    Dim comboBox = TryCast(e.Control, DataGridViewComboBoxEditingControl)
                    If comboBox IsNot Nothing Then
                        RaiseEvent ProductUnitEditing(DataGridViewSaleDetails.CurrentRow.Cells("dgvProductIdNo").Value, bsSaleDetails)
                        comboBox.DropDownStyle = ComboBoxStyle.DropDown
                        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                        comboBox.DataSource = UnitsByProduct
                    End If
                ElseIf cColumnName = "dgvExpiryDate" Then
                    'Display the date in the editing format.
                    Dim cellValue = DataGridViewSaleDetails.CurrentCell.Value
                    Dim text = If(cellValue Is DBNull.Value, "", CDate(cellValue).ToString("yyyy/MM"))
                    e.Control.Text = text
                End If
            End With
        End Sub

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewSaleDetails.CellBeginEdit
            'If DataGridViewSaleDetails.CurrentCell.RowIndex() = 0 Then
            With DataGridViewSaleDetails.CurrentCell
                Dim cColumnName = .OwningColumn.Name()
                If cColumnName = $"dgvUnitIdNo" Then
                    RaiseEvent ProductUnitSelection(DataGridViewSaleDetails.CurrentRow.Cells("dgvProductIdNo").Value, bsSaleDetails)
                End If
                '    Beep()
                '    e.Cancel = True
                '    DataGridViewSaleDetails.EndEdit()
                'End If
            End With
            'ElseIf (DataGridViewSaleDetails.CurrentRow.Cells("dgvPaidAmount").Value <> 0 Or DataGridViewSaleDetails.CurrentRow.Cells("dgvDiscountTaken").Value <> 0) _
            '       And DataGridViewSaleDetails.CurrentCell.OwningColumn.Name.ToLower() = $"dgvProductIdNo" Then
            '    Beep()
            '    e.Cancel = True
            '    DataGridViewSaleDetails.EndEdit()
            '    Messaging.Show(True, "MsgPaymentDiscExistChangeNotAllowed")
            ' End If
        End Sub


        'Private Sub DataGridViewSale_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSaleDetails.CellValueChanged
        '    If e.RowIndex >= 0 Then
        '        Dim newDate As DateTime

        '        Select Case DataGridViewSaleDetails.Columns(e.ColumnIndex).Name
        '            Case "ProductName"
        '                Dim newText As String = Me.DataGridViewSaleDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        '                'Case "ColumnCombo"
        '                '    Dim newPriority As String = Me.DataGridViewSale.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        '                'Case "ColumnDate"
        '                '    DateTime.TryParse(Me.DataGridViewSale.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), newDate)
        '        End Select
        '    End If
        'End Sub


        'Private Sub DataGridViewSale_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSaleDetails.CellValueChanged
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

        Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridViewSaleDetails.EditingControlShowing
            If DataGridViewSaleDetails.CurrentCell.OwningColumn.Name = "dgvProductName" Then
                txtQrText = CType(DataGridViewSaleDetails.EditingControl, DataGridViewTextBoxEditingControl)
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


        Private Sub DataGridViewSaleDetails_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSaleDetails.RowEnter
            Dim dgvRow As DataGridViewRow = DataGridViewSaleDetails.Rows(e.RowIndex)
            Dim prIdNo As Int32 = dgvRow.Cells("dgvProductIdNo").Value
            RaiseEvent RowChanged(prIdNo)
        End Sub

        ' Changes how cells are displayed depending on their columns and values.
        Private Sub dgvPurDetailsFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridViewSaleDetails.CellFormatting
            If e.ColumnIndex > 0 Then
                If sender.Columns(e.ColumnIndex).Name.Equals("dgvExpiryDate") Then
                    If e.Value = Date.MinValue Then
                        e.Value = String.Empty
                        e.FormattingApplied = True
                    ElseIf e.Value < DateAdd(DateInterval.Day, Today().Day * -1, Today) Then
                        e.CellStyle.BackColor = Color.Red
                    End If
                    'ElseIf sender.Columns(e.ColumnIndex).Name.Equals("dgvUnitSalesPrice") Then
                    '    Dim x = DirectCast(sender, DataGridView).Rows(e.RowIndex)
                    '    If x IsNot Nothing Then
                    '        If x.Cells("dgvProductIdNo").Value <> 0 Then
                    '            If e.Value Is Nothing Or e.Value <= x.Cells("dgvUnitCost").Value Then
                    '                e.CellStyle.BackColor = Color.Red
                    '            End If
                    '        End If
                    '    End If
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

    End Class

End Namespace