using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procurement.Views
{
    public partial class FrmGetQty : Form
    {
        public string gPartNo = "";
        public string gQty = "";
        public FrmGetQty()
        {
            InitializeComponent();
        }
        private void FrmGetQty_Load(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            label1.Text = "Enter Qty for part no " + gPartNo; 
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            gQty = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            gQty = string.Empty;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        
    }
}
