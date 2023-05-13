Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
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
        Private _noOfUnits As Int16
        Public Event ProductCodeChanged(productCode As String, bs As BindingSource) Implements IPurchaseView.ProductCodeChanged
        'Public Event ProductNameChanged(productName As String, bs As BindingSource) Implements IPurchaseView.ProductNameChanged
        Public Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource) Implements IPurchaseView.ProductUnitSelection
        Public Event ProductUnitEditing(productIdNo As Int32, bs As BindingSource) Implements IPurchaseView.ProductUnitEditing
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
         {"ReferenceNo", txtReferenceNo},
         {"SupplierIdNo", cboSupplierIdNo},
         {"TransactionDate", dtpTransactionDate},
         {"TransactionType", cboTransactionType},
         {"VatAmount", txtVatAmount},
         {"VatNumber", txtVatNumber}
        }
        End Sub

        'Protected Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
        '    'UpdateTotals()
        'End Sub

        Private Sub PurchaseEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _footer = New DgvFooter(DataGridViewPurchaseDetails) With {
                .AutoCalc = True
            }
            _footer.ColumnToSum("dgvGrossAmount") = True
            _footer.ColumnToSum("dgvDiscountAmount") = True
            _footer.ColumnToSum("dgvAmtBefVat") = True
            _footer.ColumnToSum("dgvVatAmount") = True
            _footer.ColumnToSum("dgvNetAmount") = True
            _footer.SetAlignment("dgvGrossAmount", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvVatAmount", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvVatAmount", ContentAlignment.MiddleRight)
            _footer.SetText("dgvProductName", "Totals ->")
            'UpdateTotals()
        End Sub

        Private Sub BindPurchaseDetail()
            SuspendLayout()
            bsPurchaseDetails.DataSource = Nothing
            DataGridViewPurchaseDetails.Refresh()
            bsPurchaseDetails.DataSource = PurchaseDetails
            bsPurchaseDetails.AllowNew = True
            With DataGridViewPurchaseDetails.Columns
                dgvSequence.DisplayOnly = True
                dgvUnitIdNo.DataSource = UnitsByCode
                dgvUnitIdNo.DisplayMember = "Name"
                dgvUnitIdNo.ValueMember = "idNo"
                dgvUnitIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
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

        Private Sub DataGridViewPurchaseDetails_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewPurchaseDetails.UserDeletedRow
            'UpdateTotals()
            'UpdateInputVatAmount()
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
            With bsPurchaseDetails.Current
                Dim gAmt As Decimal = 0
                Dim dAmt As Decimal = 0
                Dim price As Decimal = 0
                Dim vAmt As Decimal = 0
                If DataGridViewPurchaseDetails.CurrentCell().OwningColumn.Name = "dgvGrossAmount" Then
                    gAmt = bsPurchaseDetails.Current.GrossAmount
                    dAmt = gAmt * bsPurchaseDetails.Current.DiscountPercent / 100
                    vAmt = (gAmt - dAmt) * bsPurchaseDetails.Current.VatPercent / 100
                    price = IIf(bsPurchaseDetails.Current.Quantity = 0, 0, gAmt / bsPurchaseDetails.Current.Quantity)
                    bsPurchaseDetails.Current.Price = price
                    bsPurchaseDetails.Current.VatAmount = vAmt
                ElseIf DataGridViewPurchaseDetails.CurrentCell().OwningColumn.Name = "dgvVatAmount" Then
                    gAmt = bsPurchaseDetails.Current.GrossAmount
                    dAmt = bsPurchaseDetails.Current.DiscountAmount
                    vAmt = bsPurchaseDetails.Current.VatAmount
                    Dim vPerc = IIf(gAmt - dAmt = 0, 0, vAmt / (gAmt - dAmt) * 100)
                    bsPurchaseDetails.Current.VatPercent = vPerc
                ElseIf DataGridViewPurchaseDetails.CurrentCell().OwningColumn.Name = "dgvDiscountAmount" Then
                    gAmt = bsPurchaseDetails.Current.GrossAmount
                    dAmt = bsPurchaseDetails.Current.DiscountAmount
                    vAmt = (gAmt - dAmt) * bsPurchaseDetails.Current.VatPercent / 100
                    Dim dPerc = IIf(gAmt = 0, 0, dAmt / gAmt * 100)
                    bsPurchaseDetails.Current.DiscountPercent = dPerc
                Else 'If DataGridViewPurchaseDetails.CurrentCell().OwningColumn.Name = "dgvNetAmount" Then
                    bsPurchaseDetails.Current.GrossAmount = bsPurchaseDetails.Current.Quantity * bsPurchaseDetails.Current.Price
                    gAmt = bsPurchaseDetails.Current.GrossAmount
                    dAmt = bsPurchaseDetails.Current.GrossAmount * bsPurchaseDetails.Current.DiscountPercent / 100
                    vAmt = (gAmt - dAmt) * bsPurchaseDetails.Current.VatPercent / 100
                    bsPurchaseDetails.Current.DiscountAmount = dAmt
                    bsPurchaseDetails.Current.VatAmount = vAmt
                End If
                bsPurchaseDetails.Current.AmtBefVat = gAmt - dAmt
                bsPurchaseDetails.Current.NetAmount = gAmt - dAmt + vAmt
            End With
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
                    If cColumnName = $"dgvProductName" Then
                        ValidateProductName(DataGridViewPurchaseDetails, e)
                    ElseIf cColumnName = $"dgvProductCode" Then
                        ValidateProductCode(DataGridViewPurchaseDetails, e)
                    End If
                End With
            End If
        End Sub

        Private Sub ValidateProductName(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim findText = dgv.CurrentRow.Cells("dgvProductName").EditedFormattedValue
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
        End Sub

        Private Sub ValidateProductCode(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim code As String = dgv.CurrentRow.Cells("dgvProductCode").EditedFormattedValue
            RaiseEvent ProductCodeChanged(code, bsPurchaseDetails)
            Dim cProductName = dgv.CurrentRow().Cells("dgvProductName").Value
            If Not String.IsNullOrEmpty(cProductName) Then
                SendKeys.Send("{Tab}")
                If dgv.CurrentRow.Cells("dgvUnitCount").Value = 1 Then
                    SendKeys.Send("{Tab}")
                End If
            Else
                e.Cancel = True
            End If
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
                'txtTotalDebits.Text = _footer.Value("dgvNetAmount")
                'txtTotalCredits.Text = _footer.Value("dgvVatAmount")
            End If
        End Sub


        Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles DataGridViewPurchaseDetails.UserDeletingRow
            'Dim PurchaseDetailRow As DataGridViewRow = DataGridViewPurchaseDetails.Rows(0)
            'If DataGridViewPurchaseDetails.SelectedRows.Contains(PurchaseDetailRow) Then
            '    ' Do not allow the user to delete the first row.
            '    Messaging.Show(True, "MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
            '    ' Cancel the deletion
            '    e.Cancel = True
            'ElseIf Presenter.EditMode Then
            '    Dim jiIdNo As Integer
            '    jiIdNo = DataGridViewPurchaseDetails.CurrentRow.Cells("dgvIdNo").Value
            '    If Presenter.ApPaymentExists("AP", jiIdNo) Then
            '        'ElseIf
            '        ' Do not allow the user to delete items with existing payments/discounts (prevent orphaned records)
            '        Messaging.Show(True, "MsgDeletePaidEntryNotAllowed")
            '        ' Cancel the deletion
            '        e.Cancel = True
            '    End If
            'End If
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

        Private Sub txtNumeric_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtQrText.KeyPress
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

            End Select
        End Sub


        Private Function ExtractGTin(cText As String) As String
            Dim dataLength = Len(cText)
            Dim i As Int16 = 0
            Dim ai As String = Mid(cText, 1, 2)
            Dim lastPosition As Int16 = 2
            Dim _cGTin As String = Nothing
            Dim _cSerializationNo As String = Nothing
            Dim _cBatchNo As String = Nothing
            Dim _cExpiry As String = Nothing
            Dim _cManufacture As String = Nothing
            While lastPosition < dataLength
                Select Case ai
                    Case "01" 'GTIN
                        _cGTin = Mid(cText, lastPosition + 1, 14)
                        lastPosition += 14
                    Case "17" 'Expiry Date
                        _cExpiry = Mid(cText, lastPosition + 1, 6)
                        If _cExpiry.Right(2) = "00" Then
                            _cExpiry = Mid(_cExpiry, 1, 4) + "01"
                        End If
                        lastPosition += 6
                    Case "11" 'manufacture date
                        _cManufacture = Mid(cText, lastPosition + 1, 6)
                        lastPosition += 6
                    Case "10" ' Batch Number
                        For i = lastPosition + 1 To dataLength
                            If Mid(cText, i, 4) = "<GS>" Or Mid(cText, i, 1) = ChrW(13) Or i >= dataLength Then ' separator
                                If i >= dataLength Then
                                    _cBatchNo = Mid(cText, lastPosition + 1)
                                Else
                                    _cBatchNo = Mid(cText, lastPosition + 1, i - lastPosition - 1)
                                End If
                                lastPosition = i + 3
                                Exit For
                            End If
                        Next
                    Case "21" ' Serialization No.
                        For i = lastPosition + 1 To dataLength
                            If Mid(cText, i, 4) = "<GS>" Or Mid(cText, i, 1) = ChrW(13) Or i >= dataLength Then
                                If i >= dataLength Then
                                    _cSerializationNo = Mid(cText, lastPosition + 1)
                                Else
                                    _cSerializationNo = Mid(cText, lastPosition + 1, i - lastPosition - 1)
                                End If
                                lastPosition = i + 3
                                Exit For
                            End If
                        Next
                End Select
                If lastPosition >= dataLength Then
                    Exit While
                Else
                    ai = Mid(cText, lastPosition + 1, 2)
                    If ai = vbLf Or ai = vbCrLf Or ai = vbLf & vbCr Then
                        Exit While
                    End If
                    lastPosition += 2
                End If
            End While
            Return _cGTin
        End Function

    End Class

End Namespace