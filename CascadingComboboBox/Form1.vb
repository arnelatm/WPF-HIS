Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Text

Namespace CascadingComboboBox
    Public Partial Class Form1
        Inherits Windows.Forms.Form
        Private rand As Random = New Random()
        Private Banks As BindingList(Of BankCB)
        Private Branches As BindingList(Of BranchCB)
        Private Customers As BindingList(Of Customer)
        Private SelectedCombo As Windows.Forms.ComboBox

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Setup_10_BanksWithRandomNumberOfBranches()
            Branches = New BindingList(Of BranchCB)()
            Branches.Add(BranchCB.BlankBranch)
            For numOfBranches = 1 To 50
                Branches.Add(New BranchCB With {
                    .BranchID = numOfBranches,
                    .BranchName = "Branch " & numOfBranches.ToString()
                })
            Next
            Banks = New BindingList(Of BankCB)()
            Dim tempBranches As BindingList(Of BranchCB)
            Dim curBranch As BranchCB
            Dim totBranches As Integer
            For numOfBank = 1 To 10
                tempBranches = New BindingList(Of BranchCB)()
                tempBranches.Add(BranchCB.BlankBranch)
                totBranches = rand.Next(0, 11)
                For i = 0 To totBranches - 1
                    curBranch = Branches(rand.Next(0, 50))
                    If Not tempBranches.Contains(curBranch) Then
                        tempBranches.Add(curBranch)
                    End If
                Next
                tempBranches = New BindingList(Of BranchCB)(tempBranches.OrderBy(Function(x) x.BranchID).ToList())
                Banks.Add(New BankCB With {
                    .BankID = numOfBank,
                    .BankName = "Bank " & numOfBank.ToString(),
                    .Branches = tempBranches
                })
            Next
            For Each bank In Banks
                Debug.WriteLine(bank)
            Next
        End Sub

        Private Sub btnNewData_Click(ByVal sender As Object, ByVal e As EventArgs)
            SetNewData()
        End Sub

        Private Sub AddColumns()
            dataGridView1.Columns.Add(GetTextBoxColumn("CustomerID", "Customer ID", "CustomerID"))
            dataGridView1.Columns.Add(GetTextBoxColumn("CustomerName", "Customer Name", "CustomerName"))
            Dim col = GetComboBoxColumn("BankID", "BankName", "BankID", "Banks", "Banks")
            col.DataSource = Banks
            dataGridView1.Columns.Add(col)
            col = GetComboBoxColumn("BranchID", "BranchName", "BranchID", "Branches", "Branches")
            col.DataSource = Branches
            dataGridView1.Columns.Add(col)
        End Sub

        Private Function GetComboBoxColumn(ByVal dataPropertyName As String, ByVal displayMember As String, ByVal valueMember As String, ByVal headerText As String, ByVal name As String) As Windows.Forms.DataGridViewComboBoxColumn
            Dim cbCol As Windows.Forms.DataGridViewComboBoxColumn = New Windows.Forms.DataGridViewComboBoxColumn()
            cbCol.DataPropertyName = dataPropertyName
            cbCol.DisplayMember = displayMember
            cbCol.ValueMember = valueMember
            cbCol.HeaderText = headerText
            cbCol.Name = name
            Return cbCol
        End Function

        Private Function GetTextBoxColumn(ByVal dataPropertyName As String, ByVal headerText As String, ByVal name As String) As Windows.Forms.DataGridViewTextBoxColumn
            Dim txtCol As Windows.Forms.DataGridViewTextBoxColumn = New Windows.Forms.DataGridViewTextBoxColumn()
            txtCol.DataPropertyName = dataPropertyName
            txtCol.HeaderText = headerText
            txtCol.Name = name
            Return txtCol
        End Function

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            'Setup_10_BanksWithRandomNumberOfBranches();
            'AddColumns();
            'dataGridView1.CellLeave += new DataGridViewCellEventHandler(dataGridView1_CellLeave);
            'dataGridView1.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridView1_DefaultValuesNeeded);


            'dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
            'dataGridView1.CellLeave += new DataGridViewCellEventHandler(dataGridView1_CellLeave);
            'dataGridView1.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridView1_DefaultValuesNeeded); Setup_10_BanksWithRandomNumberOfBranches();

            'Setup_10_BanksWithRandomNumberOfBranches();
            'AddColumns();
            'Customers = GetCustomers();
            'dataGridView1.DataSource = Customers;

            'dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            'dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
            'dataGridView1.CellLeave += new DataGridViewCellEventHandler(dataGridView1_CellLeave);
            'dataGridView1.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridView1_DefaultValuesNeeded);
            'Setup_10_BanksWithRandomNumberOfBranches();
            'AddColumns();
            'Customers = GetCustomers();
            'CheckDataForBadComboBoxValues();
            'dataGridView1.DataSource = Customers;

            dataGridView1.EditMode = Windows.Forms.DataGridViewEditMode.EditOnEnter
            dataGridView1.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            AddHandler dataGridView1.EditingControlShowing, New Windows.Forms.DataGridViewEditingControlShowingEventHandler(AddressOf dataGridView1_EditingControlShowing)
            AddHandler dataGridView1.CellLeave, New Windows.Forms.DataGridViewCellEventHandler(AddressOf dataGridView1_CellLeave)
            AddHandler dataGridView1.DefaultValuesNeeded, New Windows.Forms.DataGridViewRowEventHandler(AddressOf dataGridView1_DefaultValuesNeeded)
            SetNewData()

        End Sub

        Private Sub SetNewData()
            dataGridView1.Columns.Clear()
            'Setup_10_BanksWithRandomNumberOfBranches();
            Setup_10_BanksWith5BranchesNoDuplicates()
            AddColumns()
            Customers = GetCustomers()
            CheckDataForBadComboBoxValues()
            dataGridView1.DataSource = Customers
            SetAllBranchComboCellsDataSource()
        End Sub

        Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As Windows.Forms.DataGridViewEditingControlShowingEventArgs)
            If Equals(dataGridView1.Columns(dataGridView1.CurrentCell.ColumnIndex).Name, "Banks") Then
                SelectedCombo = TryCast(e.Control, Windows.Forms.ComboBox)
                If SelectedCombo IsNot Nothing Then
                    RemoveHandler SelectedCombo.SelectedIndexChanged, New EventHandler(AddressOf ComboBox_SelectedIndexChanged)
                    AddHandler SelectedCombo.SelectedIndexChanged, New EventHandler(AddressOf ComboBox_SelectedIndexChanged)
                End If
            End If
        End Sub

        Private Sub ComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            If SelectedCombo.SelectedValue IsNot Nothing Then
                Dim selectedBank = CType(SelectedCombo.SelectedItem, BankCB)
                Dim branchCell = CType(dataGridView1.CurrentRow.Cells("Branches"), Windows.Forms.DataGridViewComboBoxCell)
                branchCell.DataSource = selectedBank.Branches
                branchCell.Value = selectedBank.Branches(0).BranchID
            End If
        End Sub

        Private Sub dataGridView1_CellLeave(ByVal sender As Object, ByVal e As Windows.Forms.DataGridViewCellEventArgs)
            If Equals(dataGridView1.Columns(e.ColumnIndex).Name, "Banks") Then
                RemoveHandler SelectedCombo.SelectedIndexChanged, New EventHandler(AddressOf ComboBox_SelectedIndexChanged)
            End If
        End Sub

        Private Sub dataGridView1_DefaultValuesNeeded(ByVal sender As Object, ByVal e As Windows.Forms.DataGridViewRowEventArgs)
            Dim newCustID = 1
            If Customers IsNot Nothing Then
                newCustID = Customers.Count
            End If
            e.Row.Cells("CustomerID").Value = newCustID
            Dim cbCell = CType(e.Row.Cells("Banks"), Windows.Forms.DataGridViewComboBoxCell)
            cbCell.DataSource = Banks
            cbCell.Value = Banks(0).BankID
            cbCell = CType(e.Row.Cells("Branches"), Windows.Forms.DataGridViewComboBoxCell)
            cbCell.DataSource = Banks(0).Branches
            cbCell.Value = Banks(0).Branches(0).BranchID
        End Sub

        Private Function GetCustomers() As BindingList(Of Customer)
            Dim customers As BindingList(Of Customer) = New BindingList(Of Customer)()
            Dim curBank As BankCB
            Dim curBranchID As BranchCB
            For i = 1 To 15
                curBank = Banks(rand.Next(0, Banks.Count))
                If curBank.Branches.Count > 0 Then
                    curBranchID = curBank.Branches(rand.Next(0, curBank.Branches.Count))
                    customers.Add(New Customer With {
                        .CustomerID = i,
                        .CustomerName = "Cust " & i.ToString(),
                        .BankID = curBank.BankID,
                        .BranchID = curBranchID.BranchID
                    })
                Else
                    customers.Add(New Customer With {
                        .CustomerID = i,
                        .CustomerName = "Cust " & i.ToString(),
                        .BankID = curBank.BankID,
                        .BranchID = BranchCB.BlankBranch.BranchID
                    })
                End If
            Next
            customers.Add(New Customer With {
                .CustomerID = 16,
                .CustomerName = "Bad Cust 16",
                .BankID = 22,
                .BranchID = 1
            })
            customers.Add(New Customer With {
                .CustomerID = 17,
                .CustomerName = "Bad Cust 17",
                .BankID = 3,
                .BranchID = 55
            })
            customers.Add(New Customer With {
                .CustomerID = 18,
                .CustomerName = "Bad Cust 18",
                .BankID = 3,
                .BranchID = 1
            })
            Return customers
        End Function

        Private Sub CheckDataForBadComboBoxValues()
            Dim sb As StringBuilder = New StringBuilder()
            For Each cust In Customers
                sb.Clear()
                Dim targetBank As List(Of BankCB) = Banks.Where(Function(x) x.BankID = cust.BankID).ToList()
                If targetBank.Count > 0 Then
                    Dim curBank = targetBank(0)
                    Dim targetBranch = curBank.Branches.Where(Function(x) x.BranchID = cust.BranchID).ToList()
                    If targetBranch.Count > 0 Then
                        sb.AppendLine("Valid bank and branch")
                        Call Debug.Write(sb.ToString())
                    Else
                        sb.AppendLine("Invalid Branch ID ----")
                        sb.AppendLine("CutomerID: " & cust.CustomerID.ToString() & " Name: " & cust.CustomerName)
                        sb.AppendLine("BankID: " & cust.BankID.ToString() & " BranchID: " & cust.BranchID.ToString())
                        sb.AppendLine("Setting Bank to : " & cust.BankID.ToString() & " setting branch to empty branch")
                        Call Windows.Forms.MessageBox.Show(sb.ToString(), "Invalid Branch ID!", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                        Call Debug.WriteLine(sb.ToString())
                        If curBank.Branches.Count > 0 Then
                            cust.BranchID = curBank.Branches(0).BranchID
                        End If
                    End If
                Else
                    sb.AppendLine("Invalid Bank ID ----")
                    sb.AppendLine("CutomerID: " & cust.CustomerID.ToString() & " Name: " & cust.CustomerName)
                    sb.AppendLine("BankID: " & cust.BankID.ToString() & " BranchID: " & cust.BranchID.ToString())
                    sb.AppendLine("Setting Bank to first bank, setting branch to empty branch")
                    Call Windows.Forms.MessageBox.Show(sb.ToString(), "Invalid Bank ID!", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    Call Debug.WriteLine(sb.ToString())
                    cust.BankID = Banks(0).BankID
                    If Banks(0).Branches.Count > 0 Then
                        cust.BranchID = Banks(0).Branches(0).BranchID
                    Else
                        cust.BranchID = BranchCB.BlankBranch.BranchID
                    End If
                End If
            Next
        End Sub

        Private Sub SetAllBranchComboCellsDataSource()
            Dim curCust As Customer
            For Each row As Windows.Forms.DataGridViewRow In dataGridView1.Rows
                If Not row.IsNewRow Then
                    curCust = CType(row.DataBoundItem, Customer)
                    Dim bank As BankCB = CType(Banks.Where(Function(x) x.BankID = curCust.BankID).FirstOrDefault(), BankCB)
                    ' since we already checked for valid Bank values, we know the bank id is a valid bank id
                    Dim cbCell = CType(row.Cells("Branches"), Windows.Forms.DataGridViewComboBoxCell)
                    cbCell.DataSource = bank.Branches
                End If
            Next
        End Sub

        Private Sub Setup_10_BanksWith5BranchesNoDuplicates()
            Branches = New BindingList(Of BranchCB)()
            Branches.Add(BranchCB.BlankBranch)
            For numOfBranches = 1 To 50
                Branches.Add(New BranchCB With {
                    .BranchID = numOfBranches,
                    .BranchName = "Branch " & numOfBranches.ToString()
                })
            Next
            Banks = New BindingList(Of BankCB)()
            Dim tempBranches As BindingList(Of BranchCB)
            Dim curBranch As BranchCB
            Dim branchIndex = 1
            For numOfBank = 1 To 10
                tempBranches = New BindingList(Of BranchCB)()
                tempBranches.Add(BranchCB.BlankBranch)
                For i = 0 To 4
                    If branchIndex < Branches.Count Then
                        curBranch = Branches(Math.Min(Threading.Interlocked.Increment(branchIndex), branchIndex - 1))
                        tempBranches.Add(curBranch)
                    Else
                        Exit For
                    End If
                Next
                tempBranches = New BindingList(Of BranchCB)(tempBranches.OrderBy(Function(x) x.BranchID).ToList())
                Banks.Add(New BankCB With {
                    .BankID = numOfBank,
                    .BankName = "Bank " & numOfBank.ToString(),
                    .Branches = tempBranches
                })
            Next
        End Sub

    End Class
End Namespace
