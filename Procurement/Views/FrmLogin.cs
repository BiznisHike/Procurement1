using Procurement.Controllers;
using Repository.DAL;
using StaticClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Procurement
{
    public partial class FrmLogin : Form
    {
        EmployeeController _ec;
        List<Employee> _LstEmployees;
        public FrmLogin()
        {
            InitializeComponent();


        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.OpenForms["FrmMDI"].Close();
            //this.Close();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            //base.OnFormClosed(e);
            //Application.Exit();

            //Application.OpenForms["FrmMDI"].Close();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            _ec = new EmployeeController();
            _LstEmployees = _ec.GetModels();

            Employee employee = _LstEmployees.Where(x => x.EmployeeName == txtLogin.Text).FirstOrDefault();
            if (employee != null)
            {
                if (employee.Password == txtPwd.Text)
                {
                    //FrmMDI frm = new FrmMDI();
                    //frm.Show();
                    //this.Hide();
                    this.Close();
                    Application.OpenForms["FrmMDI"].Visible = true;
                    //Application.Run(new FrmMDI());
                    LoginInfo.LoginEmployee = employee;
                }
                else
                {
                    lblMsg.Text = "Password is invalid";
                }

            }
            else
            {
                lblMsg.Text = "Username is invalid";
            }


        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.Close();
            //}
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }
    }
}
