using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIS_UI.UserControls
{
    public partial class UC_Booking : UserControl
    {
        public UC_Booking()
        {
            InitializeComponent();
        }

        private void btnViewTimeTable_Click(object sender, EventArgs e)
        {
            fTimeTable f = new fTimeTable();
            f.ShowDialog();
        }
    }
}
