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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void lblProject_Click(object sender, EventArgs e)
        {

        }

        private void pnlProjects_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlProjects_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pnlProjects_MouseEnter(object sender, EventArgs e)
        {
            pnlProjects.BackColor = Color.WhiteSmoke;
        }

        private void pnlProjects_MouseLeave(object sender, EventArgs e)
        {
            pnlProjects.BackColor = Color.White;
        }

        private void lnkProjects_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!FrmBOM.Instance.Visible)
            {
                FrmBOM.Instance.Show();
            }
            else
            {
                if (FrmBOM.Instance.WindowState == FormWindowState.Minimized)
                {
                    FrmBOM.Instance.WindowState = FormWindowState.Normal;
                }
                else
                {
                    FrmBOM.Instance.BringToFront();
                }

            }

            // FrmBOM_Show();


        }

        private void lblProject_Click_1(object sender, EventArgs e)
        {
            if (!FrmBOM.Instance.Visible)
            {
                FrmBOM.Instance.Show();
            }
            else
            {
                if (FrmBOM.Instance.WindowState == FormWindowState.Minimized)
                {
                    FrmBOM.Instance.WindowState = FormWindowState.Normal;
                }
                else
                {
                    FrmBOM.Instance.BringToFront();
                }

            }
            // FrmBOM_Show();

        
    }

        private void lblProjectDesc_Click(object sender, EventArgs e)
        {

        }
    }
}
