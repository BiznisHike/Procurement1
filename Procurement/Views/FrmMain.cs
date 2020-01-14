using StaticClasses;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace Procurement.Views
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            OnFormLoad();
        }
        private void OnFormLoad()
        {
            this.Visible = false;
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();

            if (LoginInfo.LoginEmployee.EmployeeTypeCode == Constants.EMPLOYEE)
            {
                pnlEmployees.Visible = false;

            }
            else
            {
                pnlEmployees.Visible = true;

            }
            lnkUserName.Text = LoginInfo.LoginEmployee.EmployeeName;
        }
        private void lnkUserName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmEmployee frmEmp = new FrmEmployee();
            frmEmp._EmployeeCode = LoginInfo.LoginEmployee.EmployeeCode;
            frmEmp.Show();
        }
        #region "Click On Panel"


        private void pnlProjects_MouseEnter(object sender, EventArgs e)
        {
            pnlProjects.BackColor = Color.WhiteSmoke;
        }

        private void pnlProjects_MouseLeave(object sender, EventArgs e)
        {
            pnlProjects.BackColor = Color.White;
        }

        private void pnlEmployees_MouseLeave(object sender, EventArgs e)
        {
            pnlEmployees.BackColor = Color.White;
        }

        private void pnlEmployees_MouseEnter(object sender, EventArgs e)
        {
            pnlEmployees.BackColor = Color.WhiteSmoke;
        }

        private void pnlEmployees_MouseClick(object sender, MouseEventArgs e) 
        {
            FrmEmployee_Show();
        }
        private void pnlProjects_MouseClick(object sender, MouseEventArgs e)
        {
            FrmBOM_Show();
        }
        private void FrmBOM_Show()
        {
            FrmBOM frmBOM = new FrmBOM();
            frmBOM.Show();

        }
        private void FrmEmployee_Show()
        {
            FrmEmployee frmEmp = new FrmEmployee();
            frmEmp.Show();
        }

        private void lnkProjects_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBOM_Show();
        }

        private void lnkEmployees_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmEmployee_Show();
        }

        private void lblProject_Click(object sender, EventArgs e)
        {
            FrmBOM_Show();
        }

        private void lblEmployee_Click(object sender, EventArgs e)
        {
            FrmEmployee_Show();
        }

        private void lblProjectDesc_Click(object sender, EventArgs e)
        {
            FrmBOM_Show();
        }

        private void lblEmployeeDesc_Click(object sender, EventArgs e)
        {
            FrmEmployee_Show();
        }


        #endregion "Click On Panel"

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "FrmMain")
                {
                    Application.OpenForms[i].Close();
                }
            }
            //this.InitializeComponent();
            OnFormLoad();
        }

        
    }
}
