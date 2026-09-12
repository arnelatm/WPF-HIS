Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.ServiceLayer

Namespace PresentationLayer.Views.Forms
    Public Class CashFlowSetupForm
        Inherits Form

        Private ReadOnly _service As New CashFlowService()
        Private ReadOnly _grid As New DataGridView()
        Private ReadOnly _save As New Button()
        Private ReadOnly _add As New Button()
        Private ReadOnly _newAccount As New ComboBox()
        Private ReadOnly _newClassification As New ComboBox()
        Private ReadOnly _newCategory As New ComboBox()
        Private ReadOnly _status As New Label()
        Private _rules As BindingList(Of CashFlowRuleModel)

        Public Sub New()
            Text = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, "إعداد التدفقات النقدية", "Cash Flow Setup")
            ClientSize = New Size(1050, 620) : StartPosition = FormStartPosition.CenterParent
            RightToLeft = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, RightToLeft.Yes, RightToLeft.No)
            RightToLeftLayout = RightToLeft = RightToLeft.Yes
            _grid.Dock = DockStyle.Fill : _grid.ReadOnly = False : _grid.AllowUserToAddRows = False : _grid.AutoGenerateColumns = False
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect : _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            _grid.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "Code", .DataPropertyName = "AccountCode", .ReadOnly = True})
            _grid.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "Account", .DataPropertyName = "AccountName", .ReadOnly = True})
            Dim classification = New DataGridViewComboBoxColumn With {.HeaderText = "Classification", .DataPropertyName = "ClassificationCode", .Name = "Classification"}
            classification.DataSource = _service.GetClassifications()
            _grid.Columns.Add(classification)
            Dim category = New DataGridViewComboBoxColumn With {.HeaderText = "Detailed category", .DataPropertyName = "CategoryCode", .Name = "Category"}
            category.DataSource = _service.GetClassifications()
            _grid.Columns.Add(category)
            _grid.Columns.Add(New DataGridViewCheckBoxColumn With {.HeaderText = "Cash Equivalent", .DataPropertyName = "IsCashEquivalent", .Name = "CashEquivalent"})
            _save.Text = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, "حفظ", "Save provisional rule") : _save.Dock = DockStyle.Left : _save.Width = 180 : _save.Height = 34
            AddHandler _save.Click, AddressOf SaveRule
            Dim addPanel As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 42, .Padding = New Padding(8)}
            _newAccount.Width = 240 : _newAccount.DisplayMember = "DisplayName" : _newAccount.DataSource = _service.GetAllAccounts()
            _newClassification.Width = 160 : _newClassification.DataSource = _service.GetClassifications()
            _newCategory.Width = 180 : _newCategory.DataSource = CategoriesFor(Convert.ToString(_newClassification.SelectedItem))
            AddHandler _newClassification.SelectedIndexChanged, AddressOf ClassificationChanged
            AddHandler _grid.CellBeginEdit, AddressOf GridCellBeginEdit
            _add.Text = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, "إضافة قاعدة", "Add account rule") : _add.Width = 150 : _add.Height = 28
            addPanel.Controls.Add(_newAccount) : addPanel.Controls.Add(_newClassification) : addPanel.Controls.Add(_newCategory) : addPanel.Controls.Add(_add)
            AddHandler _add.Click, AddressOf AddRule
            _status.Dock = DockStyle.Fill : _status.Text = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, "التغييرات مؤقتة ولا تعدل القيود.", "Changes are provisional and do not modify journal entries.") : _status.TextAlign = ContentAlignment.MiddleLeft
            Dim footer As New Panel With {.Dock = DockStyle.Bottom, .Height = 42, .Padding = New Padding(8)} : footer.Controls.Add(_status) : footer.Controls.Add(_save)
            Controls.Add(_grid) : Controls.Add(footer) : Controls.Add(addPanel)
            LoadRules()
        End Sub

        Private Sub LoadRules()
            _rules = New BindingList(Of CashFlowRuleModel)(_service.GetAccountRules())
            _grid.DataSource = _rules
        End Sub

        Private Sub SaveRule(sender As Object, e As EventArgs)
            If _grid.CurrentRow Is Nothing Then Return
            Dim rule = TryCast(_grid.CurrentRow.DataBoundItem, CashFlowRuleModel)
            If rule Is Nothing Then Return
            If Not ValidateRule(rule) Then Return
            Try
                _service.SaveAccountRule(rule)
                _status.Text = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, "تم حفظ القاعدة المؤقتة.", "Provisional rule saved.")
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Private Sub ClassificationChanged(sender As Object, e As EventArgs)
            Dim selected = Convert.ToString(_newClassification.SelectedItem)
            _newCategory.DataSource = CategoriesFor(selected)
        End Sub

        Private Shared Function ValidateRule(rule As CashFlowRuleModel) As Boolean
            If String.IsNullOrWhiteSpace(rule.ClassificationCode) OrElse String.IsNullOrWhiteSpace(rule.CategoryCode) Then
                Return False
            End If
            Dim isCash = String.Equals(rule.ClassificationCode, "CashEquivalent", StringComparison.OrdinalIgnoreCase)
            If rule.IsCashEquivalent <> isCash Then
                rule.IsCashEquivalent = isCash
            End If
            Return True
        End Function

        Private Sub GridCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse _grid.Columns(e.ColumnIndex).Name <> "Category" Then Return
            Dim rule = TryCast(_grid.Rows(e.RowIndex).DataBoundItem, CashFlowRuleModel)
            If rule Is Nothing Then Return
            Dim cell = TryCast(_grid.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewComboBoxCell)
            If cell IsNot Nothing Then cell.DataSource = CategoriesFor(rule.ClassificationCode)
        End Sub

        Private Shared Function CategoriesFor(classification As String) As List(Of String)
            Select Case classification
                Case "CashEquivalent" : Return New List(Of String) From {"CashEquivalent"}
                Case "OperatingAsset" : Return New List(Of String) From {"AccountsReceivable", "Inventory", "OtherCurrentAssets", "PrepaidExpenses"}
                Case "OperatingLiability" : Return New List(Of String) From {"AccountsPayable", "VATPayable", "AccruedExpenses"}
                Case "NonCashAdjustment" : Return New List(Of String) From {"Depreciation"}
                Case "InvestingAsset" : Return New List(Of String) From {"Buildings", "Land", "FurnitureFixtures", "ElectricalEquipment", "AirConditioning", "MedicalEquipment", "Vehicles", "AdvertisingBoards", "SmallTools", "ComputersIT"}
                Case "FinancingLiability" : Return New List(Of String) From {"BankLoans", "OtherLoans"}
                Case "FinancingEquity" : Return New List(Of String) From {"OwnerCapital", "OwnerWithdrawals"}
                Case "Excluded" : Return New List(Of String) From {"Excluded"}
                Case "RequiresReview" : Return New List(Of String) From {"RequiresReview"}
                Case Else : Return New List(Of String) From {classification}
            End Select
        End Function

        Private Sub AddRule(sender As Object, e As EventArgs)
            Dim account = TryCast(_newAccount.SelectedItem, CashFlowAccountModel)
            If account Is Nothing Then
                MessageBox.Show(Me, "Select an account first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            If _newClassification.SelectedItem Is Nothing OrElse _newCategory.SelectedItem Is Nothing Then
                MessageBox.Show(Me, "Select a classification and detailed category.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            Dim classification = Convert.ToString(_newClassification.SelectedItem)
            Dim rule As New CashFlowRuleModel With {.AccountIdNo = account.IdNo, .AccountCode = account.AccountCode, .AccountName = account.AccountName, .ClassificationCode = classification, .CategoryCode = Convert.ToString(_newCategory.SelectedItem), .IsCashEquivalent = String.Equals(classification, "CashEquivalent", StringComparison.OrdinalIgnoreCase)}
            Try
                _service.SaveAccountRule(rule)
                LoadRules()
                _status.Text = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, "تمت إضافة القاعدة المؤقتة.", "Provisional account rule added.")
                MessageBox.Show(Me, "The provisional account rule was added and the grid was refreshed.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub
    End Class
End Namespace
