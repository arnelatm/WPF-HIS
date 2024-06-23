using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace CascadingComboboBox
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        BindingList<BankCB> Banks;
        BindingList<BranchCB> Branches;
        BindingList<Customer> Customers;
        ComboBox SelectedCombo;

        public Form1()
        {
            InitializeComponent();
        }

        private void Setup_10_BanksWithRandomNumberOfBranches()
        {
            Branches = new BindingList<BranchCB>();
            Branches.Add(BranchCB.BlankBranch);
            for (int numOfBranches = 1; numOfBranches <= 50; numOfBranches++)
            {
                Branches.Add(new BranchCB { BranchID = numOfBranches, BranchName = "Branch " + numOfBranches });
            }
            Banks = new BindingList<BankCB>();
            BindingList<BranchCB> tempBranches;
            BranchCB curBranch;
            int totBranches;
            for (int numOfBank = 1; numOfBank <= 10; numOfBank++)
            {
                tempBranches = new BindingList<BranchCB>();
                tempBranches.Add(BranchCB.BlankBranch);
                totBranches = rand.Next(0, 11);
                for (int i = 0; i < totBranches; i++)
                {
                    curBranch = Branches[rand.Next(0, 50)];
                    if (!tempBranches.Contains(curBranch))
                    {
                        tempBranches.Add(curBranch);
                    }
                }
                tempBranches = new BindingList<BranchCB>(tempBranches.OrderBy(x => x.BranchID).ToList());
                Banks.Add(new BankCB { BankID = numOfBank, BankName = "Bank " + numOfBank, Branches = tempBranches });
            }
            foreach (BankCB bank in Banks)
            {
                Debug.WriteLine(bank);
            }
        }

        private void btnNewData_Click(object sender, EventArgs e)
        {
            SetNewData();
        }

        private void AddColumns()
        {
            dataGridView1.Columns.Add(GetTextBoxColumn("CustomerID", "Customer ID", "CustomerID"));
            dataGridView1.Columns.Add(GetTextBoxColumn("CustomerName", "Customer Name", "CustomerName"));
            DataGridViewComboBoxColumn col = GetComboBoxColumn("BankID", "BankName", "BankID", "Banks", "Banks");
            col.DataSource = Banks;
            dataGridView1.Columns.Add(col);
            col = GetComboBoxColumn("BranchID", "BranchName", "BranchID", "Branches", "Branches");
            col.DataSource = Branches;
            dataGridView1.Columns.Add(col);
        }

        private DataGridViewComboBoxColumn GetComboBoxColumn(string dataPropertyName, string displayMember, string valueMember, string headerText, string name)
        {
            DataGridViewComboBoxColumn cbCol = new DataGridViewComboBoxColumn();
            cbCol.DataPropertyName = dataPropertyName;
            cbCol.DisplayMember = displayMember;
            cbCol.ValueMember = valueMember;
            cbCol.HeaderText = headerText;
            cbCol.Name = name;
            return cbCol;
        }

        private DataGridViewTextBoxColumn GetTextBoxColumn(string dataPropertyName, string headerText, string name)
        {
            DataGridViewTextBoxColumn txtCol = new DataGridViewTextBoxColumn();
            txtCol.DataPropertyName = dataPropertyName;
            txtCol.HeaderText = headerText;
            txtCol.Name = name;
            return txtCol;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setup_10_BanksWithRandomNumberOfBranches();
            //AddColumns();
            //dataGridView1.CellLeave += new DataGridViewCellEventHandler(dataGridView1_CellLeave);
            //dataGridView1.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridView1_DefaultValuesNeeded);


            //dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
            //dataGridView1.CellLeave += new DataGridViewCellEventHandler(dataGridView1_CellLeave);
            //dataGridView1.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridView1_DefaultValuesNeeded); Setup_10_BanksWithRandomNumberOfBranches();

            //Setup_10_BanksWithRandomNumberOfBranches();
            //AddColumns();
            //Customers = GetCustomers();
            //dataGridView1.DataSource = Customers;

            //dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            //dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
            //dataGridView1.CellLeave += new DataGridViewCellEventHandler(dataGridView1_CellLeave);
            //dataGridView1.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridView1_DefaultValuesNeeded);
            //Setup_10_BanksWithRandomNumberOfBranches();
            //AddColumns();
            //Customers = GetCustomers();
            //CheckDataForBadComboBoxValues();
            //dataGridView1.DataSource = Customers;

            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
            dataGridView1.CellLeave += new DataGridViewCellEventHandler(dataGridView1_CellLeave);
            dataGridView1.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridView1_DefaultValuesNeeded);
            SetNewData();

        }

        private void SetNewData()
        {
            dataGridView1.Columns.Clear();
            //Setup_10_BanksWithRandomNumberOfBranches();
            Setup_10_BanksWith5BranchesNoDuplicates();
            AddColumns();
            Customers = GetCustomers();
            CheckDataForBadComboBoxValues();
            dataGridView1.DataSource = Customers;
            SetAllBranchComboCellsDataSource();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name == "Banks")
            {
                SelectedCombo = e.Control as ComboBox;
                if (SelectedCombo != null)
                {
                    SelectedCombo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                    SelectedCombo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
                }
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedCombo.SelectedValue != null)
            {
                BankCB selectedBank = (BankCB)SelectedCombo.SelectedItem;
                DataGridViewComboBoxCell branchCell = (DataGridViewComboBoxCell)(dataGridView1.CurrentRow.Cells["Branches"]);
                branchCell.DataSource = selectedBank.Branches;
                branchCell.Value = selectedBank.Branches[0].BranchID;
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Banks")
            {
                SelectedCombo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            int newCustID = 1;
            if (Customers != null)
            {
                newCustID = Customers.Count;
            }
            e.Row.Cells["CustomerID"].Value = newCustID;
            DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)e.Row.Cells["Banks"];
            cbCell.DataSource = Banks;
            cbCell.Value = Banks[0].BankID;
            cbCell = (DataGridViewComboBoxCell)e.Row.Cells["Branches"];
            cbCell.DataSource = Banks[0].Branches;
            cbCell.Value = Banks[0].Branches[0].BranchID;
        }

        private BindingList<Customer> GetCustomers()
        {
            BindingList<Customer> customers = new BindingList<Customer>();
            BankCB curBank;
            BranchCB curBranchID;
            for (int i = 1; i <= 15; i++)
            {
                curBank = Banks[rand.Next(0, Banks.Count)];
                if (curBank.Branches.Count > 0)
                {
                    curBranchID = curBank.Branches[rand.Next(0, curBank.Branches.Count)];
                    customers.Add(new Customer { CustomerID = i, CustomerName = "Cust " + i, BankID = curBank.BankID, BranchID = curBranchID.BranchID });
                }
                else
                {
                    customers.Add(new Customer { CustomerID = i, CustomerName = "Cust " + i, BankID = curBank.BankID, BranchID = BranchCB.BlankBranch.BranchID });
                }
            }
            customers.Add(new Customer { CustomerID = 16, CustomerName = "Bad Cust 16", BankID = 22, BranchID = 1 });
            customers.Add(new Customer { CustomerID = 17, CustomerName = "Bad Cust 17", BankID = 3, BranchID = 55 });
            customers.Add(new Customer { CustomerID = 18, CustomerName = "Bad Cust 18", BankID = 3, BranchID = 1 });
            return customers;
        }

        private void CheckDataForBadComboBoxValues()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Customer cust in Customers)
            {
                sb.Clear();
                List<BankCB> targetBank = Banks.Where(x => x.BankID == cust.BankID).ToList();
                if (targetBank.Count > 0)
                {
                    BankCB curBank = targetBank[0];
                    var targetBranch = curBank.Branches.Where(x => x.BranchID == cust.BranchID).ToList();
                    if (targetBranch.Count > 0)
                    {
                        sb.AppendLine("Valid bank and branch");
                        Debug.Write(sb.ToString());
                    }
                    else
                    {
                        sb.AppendLine("Invalid Branch ID ----");
                        sb.AppendLine("CutomerID: " + cust.CustomerID + " Name: " + cust.CustomerName);
                        sb.AppendLine("BankID: " + cust.BankID + " BranchID: " + cust.BranchID);
                        sb.AppendLine("Setting Bank to : " + cust.BankID + " setting branch to empty branch");
                        MessageBox.Show(sb.ToString(), "Invalid Branch ID!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Debug.WriteLine(sb.ToString());
                        if (curBank.Branches.Count > 0)
                        {
                            cust.BranchID = curBank.Branches[0].BranchID;
                        }
                    }
                }
                else
                {
                    sb.AppendLine("Invalid Bank ID ----");
                    sb.AppendLine("CutomerID: " + cust.CustomerID + " Name: " + cust.CustomerName);
                    sb.AppendLine("BankID: " + cust.BankID + " BranchID: " + cust.BranchID);
                    sb.AppendLine("Setting Bank to first bank, setting branch to empty branch");
                    MessageBox.Show(sb.ToString(), "Invalid Bank ID!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Debug.WriteLine(sb.ToString());
                    cust.BankID = Banks[0].BankID;
                    if (Banks[0].Branches.Count > 0)
                    {
                        cust.BranchID = Banks[0].Branches[0].BranchID;
                    }
                    else
                    {
                        cust.BranchID = BranchCB.BlankBranch.BranchID;
                    }
                }
            }
        }

        private void SetAllBranchComboCellsDataSource()
        {
            Customer curCust;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    curCust = (Customer)row.DataBoundItem;
                    BankCB bank = (BankCB)Banks.Where(x => x.BankID == curCust.BankID).FirstOrDefault();
                    // since we already checked for valid Bank values, we know the bank id is a valid bank id
                    DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)row.Cells["Branches"];
                    cbCell.DataSource = bank.Branches;
                }
            }
        }

        private void Setup_10_BanksWith5BranchesNoDuplicates()
        {
            Branches = new BindingList<BranchCB>();
            Branches.Add(BranchCB.BlankBranch);
            for (int numOfBranches = 1; numOfBranches <= 50; numOfBranches++)
            {
                Branches.Add(new BranchCB { BranchID = numOfBranches, BranchName = "Branch " + numOfBranches });
            }
            Banks = new BindingList<BankCB>();
            BindingList<BranchCB> tempBranches;
            BranchCB curBranch;
            int branchIndex = 1;
            for (int numOfBank = 1; numOfBank <= 10; numOfBank++)
            {
                tempBranches = new BindingList<BranchCB>();
                tempBranches.Add(BranchCB.BlankBranch);
                for (int i = 0; i < 5; i++)
                {
                    if (branchIndex < Branches.Count)
                    {
                        curBranch = Branches[branchIndex++];
                        tempBranches.Add(curBranch);
                    }
                    else
                    {
                        break;
                    }
                }
                tempBranches = new BindingList<BranchCB>(tempBranches.OrderBy(x => x.BranchID).ToList());
                Banks.Add(new BankCB { BankID = numOfBank, BankName = "Bank " + numOfBank, Branches = tempBranches });
            }
        }

    }
}