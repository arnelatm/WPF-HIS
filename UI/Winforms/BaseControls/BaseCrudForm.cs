#if DEBUG
#define DESIGN_TIME_SAFE
#endif
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AATM.UI.Winforms.BaseControls
{
    public abstract partial class BaseCrudForm : Form 
    {
        public BaseCrudForm()
        {
            InitializeComponent();
        }
    }
}
