Imports System.ComponentModel
Imports System.Dynamic
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class PurchaseEntry
        Implements IPurchaseView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _footer As DgvFooter
        Private _purchaseDetails As List(Of PurchaseDetailView)
        Private _purchaseHistory As List(Of PurchaseHistoryView)
        Private _noOfUnits As Int16

        Public Event ProductCodeChanged(productCode As String, bs As BindingSource) Implements IPurchaseView.ProductCodeChanged
        Public Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource) Implements IPurchaseView.ProductUnitSelection
        Public Event ProductUnitEditing(productIdNo As Int32) Implements IPurchaseView.ProductUnitEditing
        Public Event RowChanged(productIdNo As Int32) Implements IPurchaseView.RowChanged
        Public Event PostData(idNo As Int32) Implements IPurchaseView.PostData
        Public Event ProductCodeValidating(productCode As String, control As Control) Implements IPurchaseView.ProductCodeValidating
        Public Event ProductNameValidating(productName As String, control As Control) Implements IPurchaseView.ProductNameValidating

        Public Property NumberOfUnits As Int16 Implements IPurchaseView.NumberOfUnits
        Public Property ProductCodeIsValid As Boolean Implements IPurchaseView.ProductCodeIsValid
        Public Property ProductNameIsValid As Boolean Implements IPurchaseView.ProductNameIsValid
        Public Property ProductsByCode As DataTable Implements IPurchaseView.ProductsByCode
        Public Property UnitsByCode As Object Implements IPurchaseView.UnitsByCode
        Public Property UnitsByProduct As Object Implements IPurchaseView.UnitsByProduct
        Public Property PurchaseOrder As Boolean Implements IPurchaseView.PurchaseOrder

        'Public Property UnitsByCode As DataTable Implements IPurchaseView.UnitsByCode
        'Public Property UnitsByProduct As DataTable Implements IPurchaseView.UnitsByProduct

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Public Sub New(PurOrder As Boolean)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            PurchaseOrder = PurOrder
            FirstControl = cboSupplierIdNo
            ' Add any initialization after the InitializeComponent() call.
            _nfi.NumberDecimalDigits = 2
        End Sub


#Region "Fields"

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
                Return _purchaseDetails
            End Get
            Set
                _purchaseDetails = Value
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

        Public Property Posted As Boolean Implements IPurchaseView.Posted
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
                Return cboSupplierIdNo.GetValue(Of Int32)
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

        Public Property ReferenceNo As String Implements IPurchaseView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property UserIdNo As Int16 Implements IPurchaseView.UserIdNo
            Get
                Return cboUserIdNo.GetValue(Of Int16)()
            End Get
            Set(value As Short)
                cboUserIdNo.SetValue(value)
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
         {"UserIdNo", cboUserIdNo},
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
            DataGridViewPurchaseDetails.Columns("dgvExpiryDate").DefaultCellStyle.Format = "yyyy/MM/dd"
            DataGridViewPurchaseHistory.Columns("dgvExpiryDateH").DefaultCellStyle.Format = "yyyy/MM/dd"
            SetupDgvColumns()
            UpdateTotals()
            If DirectCast(cboWarehouseIdNo.DataSource, System.Data.DataTable).Rows.Count() < 2 Then
                cboWarehouseIdNo.Enabled = False
            Else
                cboWarehouseIdNo.Enabled = True
            End If
            If PurchaseOrder Then
                chkApproved.Visible = True
                chkDisapproved.Visible = True
                chkPosted.Visible = False
                txtInvoiceNo.Visible = False
                lblInvoiceNo.Visible = False
                lblInvoiceDate.Visible = False
                dtpDueDate.Visible = False
                lblDueDate.Visible = False
                dtpInvoiceDate.Visible = False
                lblInvoiceDate.Visible = False
                txtNotes.Visible = True
                lblNotes.Visible = True
                dgvBatchNo.Visible = False
                dgvExpiryDate.Visible = False
                dgvUnitSalesPrice.Visible = False
                dgvUnitCost.Visible = False
                Text = "Purchase Order Entry"
                btnPost.Visible = False
            Else
                chkApproved.Visible = False
                chkDisapproved.Visible = False
                chkPosted.Visible = True
                txtInvoiceNo.Visible = True
                lblInvoiceNo.Visible = True
                lblInvoiceDate.Visible = True
                dtpDueDate.Visible = True
                lblDueDate.Visible = True
                dtpInvoiceDate.Visible = True
                lblInvoiceDate.Visible = True
                txtNotes.Visible = False
                lblNotes.Visible = False
                dgvBatchNo.Visible = True
                dgvExpiryDate.Visible = True
                dgvUnitCost.Visible = True
                Text = "Purchase Entry"
                btnPost.Visible = True
            End If
        End Sub

        Public Property PurchaseDetailsBs As BindingSource Implements IPurchaseView.PurchaseDetailsBs

        Public Property Disapproved As Boolean Implements IPurchaseView.Disapproved
            Get
                Return chkDisapproved.Checked
            End Get
            Set(value As Boolean)
                chkDisapproved.Checked = value
                'If value Then
                '    btnPost.Enabled = False
                'Else
                '    btnPost.Enabled = True
                'End If
            End Set
        End Property

        Public Property Approved As Boolean Implements IPurchaseView.Approved
            Get
                Return chkApproved.Checked
            End Get
            Set(value As Boolean)
                chkApproved.Checked = value
                'If value Then
                '    btnPost.Enabled = False
                'Else
                '    btnPost.Enabled = True
                'End If
            End Set
        End Property

        Private Sub BindPurchaseDetail()
            SuspendLayout()
            bsPurchaseDetails.DataSource = Nothing
            DataGridViewPurchaseDetails.Refresh()
            bsPurchaseDetails.DataSource = PurchaseDetails
            bsPurchaseDetails.AllowNew = True
            PurchaseDetailsBs = bsPurchaseDetails
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
            dgvUnitIdNo.ValueMember = "IdNo"
            dgvUnitIdNo.DisplayMember = "Name"
            dgvUnitIdNo.DataSource = UnitsByCode
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

        Private Sub dataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DataGridViewPurchaseDetails.CellValidating
            If DataGridViewPurchaseDetails.IsCurrentCellDirty() Then
                With DataGridViewPurchaseDetails
                    Dim cColumnName = .CurrentCell.OwningColumn.Name
                    If cColumnName = $"dgvProductCode" Then
                        Dim dgv As CtDataGridView = DataGridViewPurchaseDetails
                        Dim pnt = dgv.PointToScreen(dgv.Location)
                        If Not ValidateProductCode(DataGridViewPurchaseDetails, e) Then
                            e.Cancel = True
                        End If
                    ElseIf cColumnName = $"dgvProductName" Then
                        ValidateProductName(DataGridViewPurchaseDetails, e)
                    ElseIf cColumnName = $"dgvUnitIdNo" Then
                        '(DataGridViewPurchaseDetails, e)
                    ElseIf cColumnName = $"dgvExpiryDate" Then
                        ValidateExpiryDate(DataGridViewPurchaseDetails, e)
                    End If
                End With
            End If
        End Sub

        Private Sub ValidateExpiryDate(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim needsExpiryDate As Boolean = dgv.CurrentRow.Cells("dgvNeedsExpiryDate").Value
            Dim allowBlankDate As Boolean = Not needsExpiryDate
            DataGridViewPurchaseDetails.ValidateExpiryDate(e, allowBlankDate)
        End Sub

        Private Function ValidateProductName(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim retVal As Boolean = False
            Dim findText = dgv.CurrentRow.Cells("dgvProductName").EditedFormattedValue
            RaiseEvent ProductNameValidating(findText, dgv)
            If ProductNameIsValid Then
                retVal = True
                If dgv.CurrentRow.Cells("dgvUnitIdNo").Value <= 0 Or NumberOfUnits <= 1 Then
                    SendKeys.Send("{Tab}{Tab}{Tab}")
                Else
                    SendKeys.Send("{Tab}{Tab}")
                End If
            Else
                Dim msg = Messaging.GetParametrizedMessage(True, "MsgInvalidValue", {"fieldValue", findText, "fieldDescription", "Product Name"})
                Messaging.Show(msg)
                e.Cancel = True
                dgv.Rows(e.RowIndex).ErrorText = msg
            End If
            Return retVal
        End Function

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPurchaseDetails.CellEndEdit
            ProcessCellEndEdit(DataGridViewPurchaseDetails, bsPurchaseDetails)
            UpdateTotals()
        End Sub

        Private Function ValidateProductCode(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim valid As Boolean = False
            Dim code As String = dgv.CurrentRow.Cells("dgvProductCode").EditedFormattedValue
            Dim pnt As New Point(dgv.Location)
            Dim xpnt As Point = dgv.PointToClient(dgv.Location)
            Dim startPoint = dgv.PointToScreen(dgv.Location)
            If Not (code Is Nothing OrElse code = "") Then
                RaiseEvent ProductCodeValidating(code, DataGridViewPurchaseDetails.EditingControl)
                If Not ProductCodeIsValid Then
                    e.Cancel = True
                    Messaging.ShowPmMessage(True, "MsgInvalidValue", {"fieldValue", code, "fieldDescription", "Product Code"})
                Else
                    Dim cProductName = dgv.CurrentRow().Cells("dgvProductName").Value
                    If Not String.IsNullOrEmpty(cProductName) Then
                        SendKeys.Send("{Tab}{Tab}{Tab}")
                        valid = True
                    Else
                        If Not String.IsNullOrEmpty(code) Then
                            e.Cancel = True
                            Messaging.ShowPmMessage(True, "MsgInvalidValue", {"fieldValue", code, "fieldDescription", "Product Code"})
                        End If
                    End If
                End If
            Else
                ' allow empty product code they can always enter by name.
                valid = True
            End If
            Return valid
        End Function

        Private Sub UpdateTotals()
            If _footer IsNot Nothing Then
                _footer.CalculateTotals()
                Dim netAmtBefVat As Decimal = _footer.Value("dgvNetAmount")
                Dim vatAmount As Decimal = _footer.Value("dgvVatAmount")
                txtVatAmount.Text = vatAmount.ToString("n2")
                txtAmount.Text = (netAmtBefVat + vatAmount).ToString("n2")
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

        Private Sub grid_EditingControlShowing(ByVal s As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewPurchaseDetails.EditingControlShowing
            With DataGridViewPurchaseDetails
                Dim cColumnName = .CurrentCell.OwningColumn.Name
                If cColumnName = "dgvUnitIdNo" Then
                    Dim comboBox = TryCast(e.Control, DataGridViewComboBoxEditingControl)
                    'Dim comboBox = TryCast(e.Control, CDgvComboBoxEditingControl)
                    If ComboBox IsNot Nothing Then
                        RaiseEvent ProductUnitSelection(DataGridViewPurchaseDetails.CurrentRow.Cells("dgvProductIdNo").Value, bsPurchaseDetails)
                        ComboBox.DropDownStyle = ComboBoxStyle.DropDown
                        ComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                        ComboBox.DataSource = UnitsByProduct
                    End If
                ElseIf cColumnName = "dgvExpiryDate" Then
                    'Display the date in the editing format.
                    Dim cellValue = DataGridViewPurchaseDetails.CurrentCell.Value
                    Dim text = If(cellValue Is DBNull.Value, "", CDate(cellValue).ToString("yyyy/MM/dd"))
                    e.Control.Text = text
                End If
            End With
        End Sub

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewPurchaseDetails.CellBeginEdit
            With DataGridViewPurchaseDetails.CurrentCell
                Dim cColumnName = .OwningColumn.Name()
                If cColumnName = $"dgvUnitIdNo" Then
                    RaiseEvent ProductUnitEditing(DataGridViewPurchaseDetails.CurrentRow.Cells("dgvProductIdNo").Value)
                End If
            End With
        End Sub

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

            End Select
        End Sub

        ' Changes how cells are displayed depending on their columns and values.
        Private Sub dgvPurDetailsFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridViewPurchaseDetails.CellFormatting
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

        Private Sub btnPost_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPost.ClickButtonArea
            If Not Posted Then
                Dim caption = Messaging.TranslateCaption("Please confirm.")
                Dim action As String = Messaging.TranslateCaption("post")
                Dim itemName As String = Messaging.TranslateCaption("purchase transaction")
                Dim msg = Messaging.GetParametrizedMessage(True, "AskIfContinueAction", {"action", action, "itemName", itemName})
                If Messaging.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    RaiseEvent PostData(IdNo)
                End If
            End If
        End Sub

        ' Changes how cells are displayed depending on their columns and values.
        Private Sub dgvPurHistoryFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridViewPurchaseHistory.CellFormatting
            If sender.Columns(e.ColumnIndex).Name.Equals("dgvExpiryDateH") Then
                If e.Value = Date.MinValue Then
                    e.Value = String.Empty
                    e.FormattingApplied = True
                ElseIf e.Value < DateAdd(DateInterval.Day, Today().Day * -1, Today) Then
                    e.CellStyle.BackColor = Color.Red
                End If
            End If
        End Sub

        Private Sub DataGridViewPurchaseDetails_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPurchaseDetails.RowEnter
            Dim dgvRow As DataGridViewRow = DataGridViewPurchaseDetails.Rows(e.RowIndex)
            Dim prIdNo As Int32 = dgvRow.Cells("dgvProductIdNo").Value
            RaiseEvent RowChanged(prIdNo)
            bsPurchaseHistory.ResetBindings(False)
            CGroupBox1.Text = Messaging.TranslateCaption("Purchase History for ") + dgvRow.Cells("dgvProductCode").Value + "-" + dgvRow.Cells("dgvProductName").Value
        End Sub

        Private Sub OnTransactionDateValidated(sender As Object, e As EventArgs) Handles dtpTransactionDate.Validated
            Presenter.UpdateDueDate()
            Presenter.UpdateEarlySettlementValues()
            Presenter.UpdateSupplierDate()
        End Sub

    End Class

End Namespace