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
    public partial class employee : UserControl
    {
        public employee()
        {
            InitializeComponent();
        }

        private void lnkEmployees_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!FrmEmployee.InsEmp.Visible)
            {
                FrmEmployee.InsEmp.Show();
            }
            else
            {
                if (FrmEmployee.InsEmp.WindowState == FormWindowState.Minimized)
                {
                    FrmEmployee.InsEmp.WindowState = FormWindowState.Normal;
                }
                else
                {
                    FrmEmployee.InsEmp.BringToFront();
                }

            }
            // FrmEmployee_Show();

        }

        private void lblEmployeeDesc_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (!FrmEmployee.InsEmp.Visible)
            {
                FrmEmployee.InsEmp.Show();
            }
            else
            {
                if (FrmEmployee.InsEmp.WindowState == FormWindowState.Minimized)
                {
                    FrmEmployee.InsEmp.WindowState = FormWindowState.Normal;
                }
                else
                {
                    FrmEmployee.InsEmp.BringToFront();
                }

            }
            // FrmEmployee_Show();

        }
    }
    }

