Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class PurchaseEntry
        Implements IPurchaseView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _footer As DgvFooter
        Private _PurchaseDetails As List(Of PurchaseDetailView)
        Public Event ProductCodeChanged() Implements IPurchaseView.ProductCodeChanged

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
                dtpInvoiceDate.Value = Value
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

        'Private Sub PurchaseEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    _footer = New DgvFooter(DataGridViewPurchaseDetails) With {
        '        .AutoCalc = True
        '    }
        '    _footer.ColumnToSum("dgvNetAmount") = True
        '    _footer.ColumnToSum("dgvVatAmount") = True
        '    _footer.SetAlignment("dgvNetAmount", ContentAlignment.MiddleRight)
        '    _footer.SetAlignment("dgvVatAmount", ContentAlignment.MiddleRight)
        '    '_footer.SetText("dgvProductIdNo", "Totals ->")
        '    'UpdateTotals()
        'End Sub

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
            UpdateInputVatAmount()
        End Sub

        Private Sub UpdateInputVatAmount()
            VatAmount = Presenter.UpdateInputVatAmount(PurchaseDetails)
        End Sub

        Private Overloads Sub Dispose()
            Close()
            '_footer.Dispose()
        End Sub

        'Private Sub NeedUpdateFirstLine(sender As Object, e As EventArgs) Handles cboTransactionType.Validated, txtAmount.Validated, cboTransactionType.SelectionChangeCommitted
        '    Presenter.UpdateFirstLine()
        '    UpdateTotals()
        '    DataGridViewPurchaseDetails.Refresh()
        'End Sub

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) _
            Handles DataGridViewPurchaseDetails.CellBeginEdit
            If DataGridViewPurchaseDetails.CurrentCell.RowIndex() = 0 Then
                With DataGridViewPurchaseDetails.CurrentCell
                    Dim cColumnName = .OwningColumn.Name.ToLower()
                    If cColumnName = $"dgvProductIdNo" Then

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
            End If
        End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPurchaseDetails.CellEndEdit
            'If DataGridViewPurchaseDetails.CurrentCell.RowIndex = 0 Then
            With DataGridViewPurchaseDetails.CurrentCell
                Dim cColumnName = .OwningColumn.Name
                If cColumnName = $"dgvProductName" Then 'Or cColumnName = $"dgvdebit" Or cColumnName = $"dgvcredit" Then
                    With bsPurchaseDetails
                        Dim findText = DirectCast(bsPurchaseDetails.Current, AATM.Accounts.PresentationLayer.Views.PurchaseDetailView).ProductName
                        Dim form As New ProductFinder(findText, DataGridViewPurchaseDetails)
                        If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            Dim sIdNo As Int32 = form.SelectedId
                            Dim sName As String = form.SelectedName
                            DirectCast(bsPurchaseDetails.Current, AATM.Accounts.PresentationLayer.Views.PurchaseDetailView).ProductIdNo = sIdNo
                            DirectCast(bsPurchaseDetails.Current, AATM.Accounts.PresentationLayer.Views.PurchaseDetailView).ProductName = sName
                            ' Yes, so grab the values you want from the dialog here
                            '. = form.SelectedId
                        Else

                        End If

                    End With
                ElseIf cColumnName = $"dgvProductCode" Then
                    RaiseEvent ProductCodeChanged()
                End If
            End With
            'End If
        End Sub

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

        'Private Sub UpdateTotals()
        '    If _footer IsNot Nothing Then
        '        _footer.CalculateTotals()
        '        'txtTotalDebits.Text = _footer.Value("dgvNetAmount")
        '        'txtTotalCredits.Text = _footer.Value("dgvVatAmount")
        '    End If
        'End Sub

        Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) _
                Handles DataGridViewPurchaseDetails.UserDeletingRow
            Dim PurchaseDetailRow As DataGridViewRow = DataGridViewPurchaseDetails.Rows(0)
            If DataGridViewPurchaseDetails.SelectedRows.Contains(PurchaseDetailRow) Then
                ' Do not allow the user to delete the first row.
                Messaging.Show(True, "MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
                ' Cancel the deletion
                e.Cancel = True
            ElseIf Presenter.EditMode Then
                Dim jiIdNo As Integer
                jiIdNo = DataGridViewPurchaseDetails.CurrentRow.Cells("dgvIdNo").Value
                If Presenter.ApPaymentExists("AP", jiIdNo) Then
                    'ElseIf
                    ' Do not allow the user to delete items with existing payments/discounts (prevent orphaned records)
                    Messaging.Show(True, "MsgDeletePaidEntryNotAllowed")
                    ' Cancel the deletion
                    e.Cancel = True
                End If
            End If
        End Sub

        Private Sub PurchaseEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            'TODO: This line of code loads data into the 'ISPDATADataSet.Product' table. You can move, or remove it, as needed.
            Me.ProductTableAdapter.Fill(Me.ISPDATADataSet.Product)

        End Sub


        Private Sub grid_EditingControlShowing(ByVal s As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewPurchaseDetails.EditingControlShowing
            Dim comboBox = TryCast(e.Control, DataGridViewComboBoxEditingControl)
            If comboBox IsNot Nothing Then
                comboBox.DropDownStyle = ComboBoxStyle.DropDown
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End If
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


        Private Sub DataGridViewPurchase_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPurchaseDetails.CellValueChanged
            If e.RowIndex >= 0 Then
                Select Case DataGridViewPurchaseDetails.Columns(e.ColumnIndex).Name
                    Case "ProductName"
                        Dim newText As String = Me.DataGridViewPurchaseDetails.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()

                        'dgvProductIdNo.DataSource = ProductsByCode
                        'dgvProductIdNo.DisplayMember = "Name"
                        'dgvProductIdNo.ValueMember = "IdNO"



                        'Case "ColumnCombo"
                        '    Dim newPriority As String = Me.DataGridViewPurchase.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
                        'Case "ColumnDate"
                        '    DateTime.TryParse(Me.DataGridViewPurchase.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString(), newDate)
                End Select
            End If
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

        '<System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, Flags:=System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)>
        'Protected Overrides Function ProcessDataGridViewKey(ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean

        '    ' Handle the ENTER key as if it were a RIGHT ARROW key. 
        '    If e.KeyCode = Keys.Enter Then
        '        Return Me.ProcessRightKey(e.KeyData)
        '    End If

        '    Return MyBase.ProcessDataGridViewKey(e)

        'End Function

    End Class

End Namespace