using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using Repository.DAL;
using Procurement.Controllers;
using System.Reflection;
using StaticClasses;
using Procurement.Views;

namespace Procurement
{
    public partial class FrmNewProject : Form
    {
        ProjectController _pc;
        BOMController _bc;
        ProjectEmployeeDetailController _pedc;
        decimal _projectCode;
        public bool _newMode;
        Project _currentLoadedProject;

        //SingleTon 
        private static FrmNewProject instance = null;
        private FrmNewProject()
        {
            InitializeComponent();

        }
        public static FrmNewProject Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {

                    instance = new FrmNewProject();
                }


                return instance;
            }
        }
        //End SingleTon

        private void FrmBOM_Load(object sender, EventArgs e)
        {
            try
            {

                if (LoginInfo.LoginEmployee.EmployeeTypeCode == Constants.EMPLOYEE)
                {
                    txtProjectName.Enabled = false;
                    txtProjectCustomerName.Enabled = false;
                    txtProjectEndUser.Enabled = false;


                }
                _pc = new ProjectController();

                

                if (_newMode == true)
                {
                    SettingsForNewProject();

                    //_newMode = true;
                    
                }
                else
                {
                    _currentLoadedProject = CurrentOpenProject.CurrentProject;

                    txtProjectCode.Text = _currentLoadedProject.ProjectCode.ToString();
                    txtProjectName.Text = _currentLoadedProject.ProjectName;
                    txtProjectCustomerName.Text = _currentLoadedProject.Customer;
                    txtProjectEndUser.Text = _currentLoadedProject.EndUser;

                    //_newMode = false;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;
            this.Enabled = false;
            Project projModel;
            ProjectEmployeeDetail ped;
            if (_newMode == true)
            {
                //SaveData();
                projModel = FillProjectModel();
                projModel.CreatedBy = LoginInfo.LoginEmployee.EmployeeCode;
                projModel.CreatedDate = DateTime.Now;
                _pc = new ProjectController(projModel);
                _pc.Save();

                ped = new ProjectEmployeeDetail();
                ped.EmployeeCode = LoginInfo.LoginEmployee.EmployeeCode;//_EmployeeCode;
                ped.ProjectCode = projModel.ProjectCode;//(decimal)row1["ProjectCode"];

                _pedc = new ProjectEmployeeDetailController(ped);
                _pedc.Save();
                //-------------------


                _newMode = false;
            }
            else
            {
                //UpdateData();
                projModel = FillProjectModel();
                projModel.CreatedBy = _currentLoadedProject.CreatedBy;
                projModel.CreatedDate = _currentLoadedProject.CreatedDate;
                projModel.UpdatedBy = LoginInfo.LoginEmployee.EmployeeCode;
                projModel.UpdateDate = DateTime.Now;
                _pc = new ProjectController(projModel);
                _pc.UpdateModel(projModel);

            }

            this.Enabled = true;
            //////////////update shared object///////////////////
            //_pc = new ProjectController();

            //CurrentOpenProject.CurrentProject = _pc.GetModelByID(projModel.ProjectCode);
            //FrmMDI.Instance.Text = " Project Code: '" + projModel.ProjectCode +
            //            "' Project Name: '" + projModel.ProjectName +
            //            "' Project Customer: '" + projModel.Customer +
            //            "' Project End User: '" + projModel.EndUser + "'";

            
            //for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            //{
            //    if (Application.OpenForms[i].Name != "FrmMDI" && Application.OpenForms[i].Name != "FrmProject")
            //        Application.OpenForms[i].Close();
            //}

            ////////////
            this.Close();
            
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                
                if (Application.OpenForms[i].Name == "FrmProjects")
                {
                    StaticClasses.NewProjectOpened.ClosePreviousProjectFormsWithOutConfirmation = true;
                    Application.OpenForms[i].Close();
                    StaticClasses.NewProjectOpened.ClosePreviousProjectFormsWithOutConfirmation = false;
                }
            }
            
            FrmProjects_Show();
        }
        private void FrmProjects_Show()
        {
            FrmProjects.Instance.MdiParent = FrmMDI.Instance; //this;
            if (!FrmProjects.Instance.Visible)
            {
                FrmProjects.Instance.Show();
            }
            else
            {
                if (FrmProjects.Instance.WindowState == FormWindowState.Minimized)
                {
                    FrmProjects.Instance.WindowState = FormWindowState.Normal;
                }
                else
                {
                    FrmProjects.Instance.BringToFront();
                }

            }
            // FrmBOM_Show();

            //FrmBOM frmBOM = FrmBOM.Instance;
            //frmBOM.Show();
            // FrmBOM.Instance.Show();

        }

        private Project FillProjectModel()
        {
            Project lObjProj = new Project();
            //if (_newMode == false) lObjProj.ProjectCode = decimal.Parse(txtProjectCode.Text);
            lObjProj.ProjectCode = decimal.Parse(txtProjectCode.Text);
            lObjProj.ProjectName = txtProjectName.Text;
            lObjProj.EndUser = txtProjectEndUser.Text;
            lObjProj.Customer = txtProjectCustomerName.Text;
            return lObjProj;

        }


        private void SettingsForNewProject()
        {

            //int maxId = db.Customers.DefaultIfEmpty().Max(p => p == null ? 0 : p.Id);
            decimal maxCode = _pc.GetMaxProjectCode();
            txtProjectCode.Text = maxCode.ToString();

            txtProjectName.Text = "New Project " + maxCode;
            txtProjectCustomerName.Text = "New Customer " + maxCode;
            txtProjectEndUser.Text = "New EndUser " + maxCode;

            //_pc.GetModels
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Close this window?", "Confirmation", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.No) return;
            this.Close();
        }





        private void FrmBOM_Activated(object sender, EventArgs e)
        {
            txtProjectName.Focus();
        }

        private void FrmBOM_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.Close();
            //}
        }

        private void FrmNewProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.BringToFront();
            if (StaticClasses.NewProjectOpened.ClosePreviousProjectFormsWithOutConfirmation == true) return;
            DialogResult dialogResult = MessageBox.Show("Close this window?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) e.Cancel = true;
        }
    }
}