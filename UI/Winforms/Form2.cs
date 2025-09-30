using AATM.Contracts.Interfaces.Dtos;
using AATM.UI.Winforms.BaseControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AATM.UI.Winforms
{
    public partial class Form2 : BaseGridCrudForm<DesignTimeDto>
    {
        public Form2()
        {
            InitializeComponent();
        }
    }

    // Minimal concrete DTO for designer support
    public class DesignTimeDto : IEntityDto
    {
        public int ID { get; set; }
    }
}
