using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace CascadingComboboBox
{
    internal class BankCB
    {
        public int BankID { get; set; }
        public string BankName { get; set; }
        public BindingList<BranchCB> Branches { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------------------------");
            sb.AppendLine("BankID: " + BankID + " Name: " + BankName + " Branches:...");
            if (Branches.Count > 1)
            {
                foreach (BranchCB branch in Branches)
                {
                    if (branch.BranchID != 0)
                    {
                        sb.AppendLine(branch.ToString());
                    }
                }
            }
            else
            {
                sb.AppendLine("No Branches");
            }
            return sb.ToString();
        }
    }
}
