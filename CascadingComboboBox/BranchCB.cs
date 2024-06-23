using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadingComboboBox
{
    internal class BranchCB
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }

        public static BranchCB BlankBranch
        {
            get
            {
                return new BranchCB { BranchID = 0, BranchName = "" };
            }
        }

        public override string ToString()
        {
            return "BranchID: " + BranchID + " Name: " + BranchName;
        }
    }
}
