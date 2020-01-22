using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procurement
{
    public partial class UserPanel : UserControl
    {
        public UserPanel()
        {
            InitializeComponent();
        }
        private string _titile;
        private string _description;
        private Image _Icon;

      
        [Category("Custom Props")]
        public string Title
        {
            get { return _titile; }
            set { _titile = value;linkLabel1.Text = value; }
        }


        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set { _description = value;label1.Text = value; }
        }


        [Category("Custom Props")]
        public Image Icon
        {
            get { return _Icon; }
            set { _Icon = value; pictureBox1.Image = value; }
        }

        private void UserPanel_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
