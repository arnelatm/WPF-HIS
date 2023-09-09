Imports System.ComponentModel
Imports System.Dynamic
Imports System.Globalization
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class InvTransactionEntry
        Implements IInvTransactionView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _footer As DgvFooter
        Private _invTransactionDetails As List(Of InvTransactionDetailView)

        Public Event ProductCodeChanged(productCode As String, bs As BindingSource) Implements IInvTransactionView.ProductCodeChanged
        Public Event GTinScanned(GTin As String, bs As BindingSource, ByRef productCode As String) Implements IInvTransactionView.GTinScanned
        Public Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource) Implements IInvTransactionView.ProductUnitSelection
        Public Event ProductUnitEditing(productIdNo As Int32) Implements IInvTransactionView.ProductUnitEditing
        Public Event RowChanged(productIdNo As Int32) Implements IInvTransactionView.RowChanged
        Public Event PostData(idNo As Int32) Implements IInvTransactionView.PostData
        Public Event InvTransactionTypeChanged(invTransTypeIdNo As Int16) Implements IInvTransactionView.InvTransactionTypeChanged
        Private Event ProductCodeValidating(productCode As String, control As Windows.Forms.Control) Implements IInvTransactionView.ProductCodeValidating
        Private Event ProductNameValidating(productName As String, control As Windows.Forms.Control) Implements IInvTransactionView.ProductNameValidating
        Public Property NumberOfUnits As Int16 Implements IInvTransactionView.NumberOfUnits
        Public Property ProductCodeIsValid As Boolean Implements IInvTransactionView.ProductCodeIsValid
        Public Property ProductNameIsValid As Boolean Implements IInvTransactionView.ProductNameIsValid
        Public Property ProductsByCode As DataTable Implements IInvTransactionView.ProductsByCode
        Public Property UnitsByCode As Object Implements IInvTransactionView.UnitsByCode
        Public Property UnitsByProduct As Object Implements IInvTransactionView.UnitsByProduct
        Public Property ProductInInventory As Boolean Implements IInvTransactionView.ProductInInventory
        Public Property ValidationErrorText As String Implements IInvTransactionView.ValidationErrorText

        'Public Property UnitsByProduct As DataTable Implements IInvTransactionView.UnitsByProduct
        'Public Property UnitsByCode As DataTable Implements IInvTransactionView.UnitsByCode
        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboInvTransTypeIdNo
            ' Add any initialization after the InitializeComponent() call.
            _nfi.NumberDecimalDigits = 2
        End Sub

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
                Return _invTransactionDetails
            End Get
            Set
                _invTransactionDetails = Value
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

        Public Property WarehouseIdNo As Int16 Implements IInvTransactionView.WarehouseIdNo
            Get
                Return cboWarehouseIdNo.GetValue(Of Int16)
            End Get
            Set
                cboWarehouseIdNo.SetValue(Value)
            End Set
        End Property

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
            Set(value As Int16)
                cboUserIdNo.SetValue(value)
            End Set
        End Property

        Public Property InvTransTypeIdNo As Int16 Implements IInvTransactionView.InvTransTypeIdNo
            Get
                Return cboInvTransTypeIdNo.GetValue(Of Int16)
            End Get
            Set(value As Short)
                cboInvTransTypeIdNo.SetValue(value)
                RaiseEvent InvTransactionTypeChanged(value)
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

        Public Property InventoryAction As String Implements IInvTransactionView.InventoryAction

        Private Property InvTransactionDetailsBs As BindingSource Implements IInvTransactionView.InvTransactionDetailsBs

        Public WriteOnly Property WarehouseToIdNoEnabled As Boolean Implements IInvTransactionView.WarehouseToIdNoEnabled
            Set(value As Boolean)
                cboWarehouseToIdNo.Visible = value
                lblWarehouseToIdNo.Visible = value
                floInventoryHeader.SetFlowBreak(cboWarehouseIdNo, Not value)
            End Set
        End Property

#End Region
        Private _inventoryManager As Boolean = False

        Public Property InventoryManager As Boolean Implements IInvTransactionView.InventoryManager
            Get
                Return _inventoryManager
            End Get
            Set(value As Boolean)
                _inventoryManager = value
                If value Then
                    dtpTransactionDate.DisplayOnly = False
                Else
                    dtpTransactionDate.DisplayOnly = True
                End If
            End Set
        End Property

        Public Property DefaultUserWarehouseIdNo As Short Implements IInvTransactionView.DefaultUserWarehouseIdNo

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
            _footer.ColumnToSum("dgvNetAmount") = True
            _footer.SetAlignment("dgvQuantity", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvNetAmount", ContentAlignment.MiddleRight)
            _footer.SetText("dgvProductName", "Totals ->")
            DataGridViewInvTransactionDetails.Columns("dgvExpiryDate").DefaultCellStyle.Format = "yyyy/MM/dd"
            SetupDgvColumns()
            UpdateTotals()
            If DirectCast(cboWarehouseIdNo.DataSource, System.Data.DataTable).Rows.Count() < 2 Then
                cboWarehouseIdNo.Enabled = False
            Else
                cboWarehouseIdNo.Enabled = True
            End If
            UpdateDgvColumns()
            dgvNetAmount.DisplayOnly = True
            If InventoryManager Then
                dtpTransactionDate.Enabled = True
            Else
                dtpTransactionDate.Enabled = False
            End If
        End Sub


        Private Sub BindInvTransactionDetail()
            SuspendLayout()
            bsInvTransactionDetails.DataSource = Nothing
            DataGridViewInvTransactionDetails.Refresh()
            bsInvTransactionDetails.DataSource = InvTransactionDetails
            bsInvTransactionDetails.AllowNew = True
            InvTransactionDetailsBs = bsInvTransactionDetails
            ResumeLayout()
        End Sub


        Private Sub SetupDgvColumns()
            dgvSequence.DisplayOnly = True
            dgvUnitIdNo.ValueMember = "IdNo"
            dgvUnitIdNo.DisplayMember = "Name"
            dgvUnitIdNo.DataSource = UnitsByCode
            dgvUnitIdNo.DisplayStyleForCurrentCellOnly = True
            dgvQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvUnitCost.SetFormat(12, 4)
        End Sub

        Private Overloads Sub Dispose()
            Close()
            '_footer.Dispose()
        End Sub

        Private Sub dataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DataGridViewInvTransactionDetails.CellValidating
            If DataGridViewInvTransactionDetails.IsCurrentCellDirty() Then
                With DataGridViewInvTransactionDetails
                    Dim cColumnName = .CurrentCell.OwningColumn.Name
                    If cColumnName = $"dgvProductCode" Then
                        Dim dgv As CtDataGridView = DataGridViewInvTransactionDetails
                        Dim pnt = dgv.PointToScreen(dgv.Location)
                        If Not ValidateProductCode(DataGridViewInvTransactionDetails, e) Then
                            e.Cancel = True
                            .Rows(e.RowIndex).ErrorText = ValidationErrorText
                            'DataGridViewInvTransactionDetails(e.RowIndex, e.ColumnIndex).ErrorText = ValidationErrorText
                        Else
                            .Rows(e.RowIndex).ErrorText = String.Empty
                        End If
                    ElseIf cColumnName = $"dgvProductName" Then
                        If Not ValidateProductName(DataGridViewInvTransactionDetails, e) Then
                            e.Cancel = True
                            ' Set error text to why the cell validating failed.
                            .Rows(e.RowIndex).ErrorText = ValidationErrorText
                            'DataGridViewInvTransactionDetails(e.RowIndex, e.ColumnIndex).ErrorText = ValidationErrorText
                            '.EndEdit()
                        Else
                            .Rows(e.RowIndex).ErrorText = String.Empty
                        End If
                    ElseIf cColumnName = $"dgvUnitIdNo" Then
                        '(DataGridViewInvTransactionDetails, e)
                    ElseIf cColumnName = $"dgvExpiryDate" Then
                        ValidateExpiryDate(DataGridViewInvTransactionDetails, e)
                        If .CurrentRow.Cells("dgvInventoryIdNo").Value <> 0 Then
                            Messaging.ShowPmMessage(True, "MsgCannotEditInvItems", {"fieldName", Messaging.TranslateCaption("expiry date")})
                            e.Cancel = True
                            .CurrentRow.Cells("dgvExpiryDate").Value = DataGridViewInvTransactionDetails.OldCellValue
                        End If
                    ElseIf cColumnName = $"dgvBatchNo" Then
                        If .CurrentRow.Cells("dgvInventoryIdNo").Value <> 0 Then
                            Messaging.ShowPmMessage(True, "MsgCannotEditInvItems", {"fieldName", Messaging.TranslateCaption("batch number")})
                            e.Cancel = True
                            .CurrentRow.Cells("dgvBatchNo").Value = DataGridViewInvTransactionDetails.OldCellValue
                        End If
                    ElseIf cColumnName = $"dgvUnitCost" Then
                        If .CurrentRow.Cells("dgvInventoryIdNo").Value <> 0 Then
                            Messaging.ShowPmMessage(True, "MsgCannotEditInvItems", {"fieldName", Messaging.TranslateCaption("unit cost")})
                            e.Cancel = True
                            .CurrentRow.Cells("dgvUnitCost").Value = DataGridViewInvTransactionDetails.OldCellValue
                        End If
                    End If
                End With
            End If
        End Sub

        Private Sub ValidateExpiryDate(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim needsExpiryDate As Boolean = dgv.CurrentRow.Cells("dgvNeedsExpiryDate").Value
            Dim allowBlankDate As Boolean = Not needsExpiryDate
            DataGridViewInvTransactionDetails.ValidateExpiryDate(e, allowBlankDate)
        End Sub

        Private Function ValidateProductName(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs) As Boolean
            Dim valid As Boolean = True
            Dim findText = dgv.CurrentRow.Cells("dgvProductName").EditedFormattedValue
            RaiseEvent ProductNameValidating(findText, DataGridViewInvTransactionDetails.EditingControl)
            If ProductNameIsValid Then
                valid = True
                If InventoryAction = EnumToCode(InventoryActionSelection.PurchaseOrder) Or
                   InventoryAction = EnumToCode(InventoryActionSelection.Request) Then
                    'just go to the next field, in this case go to the quantity field
                    'Purchase Order/Request Items are always valid no check needed
                Else
                    'Product must be in the inventory, so check for existence on inventory
                    If ProductInInventory Then
                        If dgv.CurrentRow.Cells("dgvUnitIdNo").Value <= 0 Or NumberOfUnits <= 1 Then
                            SendKeys.Send("{Tab}{Tab}")
                        Else
                            SendKeys.Send("{Tab}")
                        End If
                    Else
                        'just move to the next field
                    End If
                End If
            Else
                e.Cancel = True
                valid = False
            End If
            Return valid
        End Function

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInvTransactionDetails.CellEndEdit
            ProcessCellEndEdit(sender, bsInvTransactionDetails)
            UpdateTotals()
        End Sub


        Private Function ValidateProductCode(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim valid As Boolean
            Dim code As String = dgv.CurrentRow.Cells("dgvProductCode").EditedFormattedValue
            RaiseEvent ProductCodeValidating(code, DataGridViewInvTransactionDetails.EditingControl)
            If ProductCodeIsValid Then
                If code Is Nothing Or code = "" Then
                    ' go to next cell (which is the productname)
                ElseIf ProductInInventory Then
                    SendKeys.Send("{Tab}{Tab}{Tab}")
                Else
                    SendKeys.Send("{Tab}")
                End If
                valid = True
            Else
                valid = False
                e.Cancel = True
            End If
            Return valid
        End Function


        Private Sub UpdateTotals()
            If _footer IsNot Nothing Then
                _footer.CalculateTotals()
                Dim netAmount As Decimal = _footer.Value("dgvNetAmount")
                txtAmount.Text = netAmount.ToString("n2")
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
                    Dim text = If(cellValue Is DBNull.Value, "", CDate(cellValue).ToString("yyyy/MM/dd"))
                    e.Control.Text = text
                End If
            End With
        End Sub

        'Private _oldCellValue As Object

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewInvTransactionDetails.CellBeginEdit
            '_oldCellValue = DataGridViewInvTransactionDetails.CurrentCell.Value
            With DataGridViewInvTransactionDetails.CurrentCell
                Dim cColumnName = .OwningColumn.Name()
                If cColumnName = $"dgvUnitIdNo" Then
                    RaiseEvent ProductUnitEditing(DataGridViewInvTransactionDetails.CurrentRow.Cells("dgvProductIdNo").Value)
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

            End Select
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

        Private Sub cboInvTransTypeIdNo_Validating(sender As Object, e As CancelEventArgs) Handles cboInvTransTypeIdNo.Validating
            If cboInvTransTypeIdNo.SelectedValue Is Nothing Then
                Messaging.ShowPmMessage(True, "MsgMustSelectFromList", {"selectionName", Messaging.TranslateCaption("Inventory Transaction Type")})
                e.Cancel = True
            End If
        End Sub

        Private Sub cboInvTransTypeIdNo_Validated(sender As Object, e As EventArgs) Handles cboInvTransTypeIdNo.Validated
            RaiseEvent InvTransactionTypeChanged(sender.SelectedValue)
            UpdateDgvColumns()
        End Sub

        Private Sub btnPost_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPost.ClickButtonArea
            If InventoryAction = EnumToCode(InventoryActionSelection.Add) Or
                    InventoryAction = EnumToCode(InventoryActionSelection.Deduct) Or
                    InventoryAction = EnumToCode(InventoryActionSelection.Transfer) Then
                Dim caption = Messaging.TranslateCaption("Please confirm.")
                Dim action As String = Messaging.TranslateCaption("post")
                Dim itemName As String = Messaging.TranslateCaption("InvTransaction transaction")
                Dim msg = Messaging.GetParametrizedMessage(True, "AskIfContinueAction", {"action", action, "itemName", itemName})
                If Messaging.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    RaiseEvent PostData(IdNo)
                End If
            Else
                Messaging.Show(True, "MsgNonPostableEntry")
            End If
        End Sub



        Private Sub cboInvTransTypeIdNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboInvTransTypeIdNo.SelectedIndexChanged
            UpdateDgvColumns()
        End Sub



        Private Sub UpdateDgvColumns()
            If InventoryAction = EnumToCode(InventoryActionSelection.PurchaseOrder) Then
                dgvBatchNo.Visible = False
                dgvExpiryDate.Visible = False
                dgvBatchNo.DisplayOnly = False
                dgvExpiryDate.DisplayOnly = False
                dgvUnitCost.DisplayOnly = False
            ElseIf InventoryAction = EnumToCode(InventoryActionSelection.Deduct) Or
                InventoryAction = EnumToCode(InventoryActionSelection.Transfer) Then
                dgvBatchNo.Visible = True
                dgvExpiryDate.Visible = True
                dgvBatchNo.DisplayOnly = True
                dgvExpiryDate.DisplayOnly = True
                dgvUnitCost.DisplayOnly = True
            ElseIf InventoryAction = EnumToCode(InventoryActionSelection.Add) Or
                InventoryAction = EnumToCode(InventoryActionSelection.Request) Then
                dgvBatchNo.Visible = True
                dgvExpiryDate.Visible = True
                dgvBatchNo.DisplayOnly = False
                dgvExpiryDate.DisplayOnly = False
                dgvUnitCost.DisplayOnly = False
            End If
            dgvBatchNo.UpdateDisplayOnlyControl()
            dgvExpiryDate.UpdateDisplayOnlyControl()
            dgvUnitCost.UpdateDisplayOnlyControl()

            'If DataGridViewInvTransactionDetails.EditingMode Then
            '    If InventoryAction = EnumToCode(InventoryActionSelection.PurchaseOrder) Then
            '        dgvBatchNo.ReadOnly = False
            '        dgvExpiryDate.ReadOnly = False
            '        dgvUnitCost.ReadOnly = False
            '    ElseIf InventoryAction = EnumToCode(InventoryActionSelection.Deduct) Or
            '           InventoryAction = EnumToCode(InventoryActionSelection.Transfer) Then
            '        dgvBatchNo.ReadOnly = True
            '        dgvExpiryDate.ReadOnly = True
            '        dgvUnitCost.ReadOnly = True
            '    ElseIf InventoryAction = EnumToCode(InventoryActionSelection.Add) Or
            '           InventoryAction = EnumToCode(InventoryActionSelection.Request) Then
            '        dgvBatchNo.ReadOnly = False
            '        dgvExpiryDate.ReadOnly = False
            '        dgvUnitCost.ReadOnly = False
            '    End If
            'Else
            '    If InventoryAction = EnumToCode(InventoryActionSelection.PurchaseOrder) Then
            '        dgvBatchNo.DisplayOnly = False
            '        dgvExpiryDate.DisplayOnly = False
            '        dgvUnitCost.DisplayOnly = False
            '    ElseIf InventoryAction = EnumToCode(InventoryActionSelection.Deduct) Or
            '           InventoryAction = EnumToCode(InventoryActionSelection.Transfer) Then
            '        dgvBatchNo.DisplayOnly = True
            '        dgvExpiryDate.DisplayOnly = True
            '        dgvUnitCost.DisplayOnly = True
            '    ElseIf InventoryAction = EnumToCode(InventoryActionSelection.Add) Or
            '           InventoryAction = EnumToCode(InventoryActionSelection.Request) Then
            '        dgvBatchNo.DisplayOnly = False
            '        dgvExpiryDate.DisplayOnly = False
            '        dgvUnitCost.DisplayOnly = False
            '    End If
            'End If
        End Sub

        Private Sub DataGridViewInvTransactionDetails_ChangesMade(sender As Object, e As EventArgs) Handles DataGridViewInvTransactionDetails.ChangesMade

        End Sub
    End Class

End Namespace