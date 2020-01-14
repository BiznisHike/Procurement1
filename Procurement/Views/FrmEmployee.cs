using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using Repository.DAL;
using Procurement.Controllers;
using System.Reflection;
using StaticClasses;

namespace Procurement
{
    public partial class FrmEmployee : Form
    {
        EmployeeController _ec;
        EmployeeTypeController _etc;
        ProjectController _pc;
        ProjectEmployeeDetailController _pedc;

        List<Employee> _LstEmployees;
        List<EmployeeType> _LstEmployeeTypes;
        List<Project> _LstProjects;
        DataTable _dtEmployees;
        DataTable _dtProjects;
        public decimal _EmployeeCode;
        decimal _maxEmpCode;
        bool _newMode;
        Employee _currentLoadedEmployee;
        public FrmEmployee()
        {
            InitializeComponent();
        }
        #region "Load On Start"
        public FrmEmployee(decimal pEmployeeCode)
        {
            _EmployeeCode = pEmployeeCode;
        }


        private void FrmEmployees_Load(object sender, EventArgs e)
        {
            try
            {
                _ec = new EmployeeController();
                _etc = new EmployeeTypeController();
                _pc = new ProjectController();
                Employee emp = new Employee();
                if (_EmployeeCode > 0)
                {// if employee viewing then this code will run... _EmployeeCode value is comming from FrmMain.
                    emp = _ec.GetModelByID(_EmployeeCode);
                    _LstEmployees = new List<Employee>();
                    _LstEmployees.Add(emp);
                    //disable controls for employee
                    btnNewEmployee.Visible = false;
                    btnResize.Visible = false;
                    splitContainer1.SplitterDistance = 0;
                    dataGridViewEmployees.Visible = false;
                    cmbEmployeeType.Enabled = false;
                    dataGridViewSelectProjects.Enabled = false;
                    this.Text = emp.EmployeeName;
                }
                else
                {//for manager view
                    _LstEmployees = _ec.GetModelsByCreatedBy();

                }

                _LstEmployeeTypes = _etc.GetModels();
                _LstProjects = _pc.GetModels();

               


                _dtEmployees = ToDataTable<Employee>(_LstEmployees);
                _dtProjects = ToDataTable<Project>(_LstProjects);

                //var bindingSource1 = new BindingSource();
                //bindingSource1.DataSource = _LstProjects.OrderByDescending(x=>x.ProjectCode).ToList();
                //cmbProjects.DataSource = bindingSource1.DataSource;
                //cmbProjects.DisplayMember = "ProjectName";
                //cmbProjects.ValueMember = "ProjectCode";

                //FillCmbManagers();

                _dtProjects.Columns.Remove("BOMs");
                _dtProjects.Columns.Remove("ProjectEmployeeDetails");
                _dtProjects.Columns.Add("Select Projects", typeof(Boolean)).SetOrdinal(0);

                dataGridViewSelectProjects.DataSource = _dtProjects;
                //dataGridViewSelectProjects.Columns["Select Projects"].Width = 30;

                var bindingSource3 = new BindingSource();
                bindingSource3.DataSource = _LstEmployeeTypes;
                cmbEmployeeType.DataSource = bindingSource3.DataSource;
                cmbEmployeeType.DisplayMember = "EmployeeType1";
                cmbEmployeeType.ValueMember = "EmployeeTypeCode";
                cmbEmployeeType.SelectedIndex = 1;



                /////////////////
                //_dtEmployees.Columns.Add("Employee Type");
                //_dtEmployees.Columns.Add("Project Name");
                //foreach (DataRow dr in _dtEmployees.Rows) // search whole table
                //{
                //    if (dr["Manager"] == null) dr["Manager"] = DBNull.Value;
                //    if (dr["ProjectCode"] == null) dr["ProjectCode"] = DBNull.Value;
                //    EmployeeType et = (EmployeeType) dr["EmployeeType"];
                //    dr["Employee Type"] = et.EmployeeType1.ToString();

                //    if (dr["Project"] != DBNull.Value)
                //    {
                //        Project proj = (Project)dr["Project"];
                //        dr["Project Name"] = proj.ProjectName.ToString();
                //    }
                //}

                _dtEmployees.Columns.Remove("EmployeeTypeCode");
                _dtEmployees.Columns.Remove("EmployeeType");
                _dtEmployees.Columns.Remove("ProjectCode");
                _dtEmployees.Columns.Remove("Manager");
                _dtEmployees.Columns.Remove("Password");
                _dtEmployees.Columns.Remove("ProjectEmployeeDetails");

                ////////////////////
                DataView dv = _dtEmployees.DefaultView;
                dv.Sort = "EmployeeCode desc";
                _dtEmployees = dv.ToTable();

                dataGridViewEmployees.DataSource = _dtEmployees;


                if (_LstEmployees.Count == 0)
                {

                    _newMode = true;
                    _ec.ReseedPk();
                    //txtProjectCode.Text = (1).ToString();
                    SetForNew();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        //private void FillCmbManagers()
        //{
        //    var bindingSource2 = new BindingSource();
        //    bindingSource2.DataSource = _LstEmployees.Where(x => x.EmployeeTypeCode == 1).OrderBy(y => y.EmployeeName).ToList();
        //    cmbManagers.DataSource = bindingSource2.DataSource;
        //    cmbManagers.DisplayMember = "EmployeeName";
        //    cmbManagers.ValueMember = "EmployeeCode";
        //}
        private void cmbEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbEmployeeType.SelectedValue.ToString() == 1.ToString())
            //{
            //    cmbManagers.Enabled = false;
            //    lblManager.Enabled = false;
            //}
            //else
            //{
            //    cmbManagers.Enabled = true;
            //    lblManager.Enabled = true;
            //}
        }

        #endregion "Load On Start"



        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Employee empModel;
            List<ProjectEmployeeDetail> LstPed;
            if (_newMode == true)
            {
                //SaveData();
                empModel = FillEmployeeModel();
                empModel.CreatedBy = LoginInfo.LoginEmployee.EmployeeCode;
                empModel.CreatedDate = DateTime.Now;

                _ec = new EmployeeController(empModel);
                _ec.Save();
                _EmployeeCode = empModel.EmployeeCode;
                //------------------
                LstPed = FillProjectEmployeeDetailModel();
                _pedc = new ProjectEmployeeDetailController(LstPed);
                _pedc.SaveList(empModel.EmployeeCode);
                //-------------------
                DataRow NewRow = _dtEmployees.NewRow();
                NewRow[0] = empModel.EmployeeCode;
                NewRow[1] = empModel.EmployeeName;
                //NewRow[2] = empModel.EmployeeTypeCode;
                //NewRow[3] = empModel.ProjectCode;
                //if (empModel.ProjectCode == null) { NewRow[3] = DBNull.Value; } else { NewRow[3] = empModel.ProjectCode; }
                //if (empModel.Manager == null){ NewRow[4] = DBNull.Value; } else { NewRow[4] = empModel.Manager; }

                //TO DO
                //if (empModel.ProjectCode == null) { NewRow[5] = DBNull.Value; } else { NewRow[5] = empModel.EmployeeType.EmployeeType1; }
                //if (empModel.Manager == null) { NewRow[6] = DBNull.Value; } else { NewRow[6] = empModel.Project.ProjectName; }




                _dtEmployees.Rows.Add(NewRow);

                DataView dv = _dtEmployees.DefaultView;
                dv.Sort = "EmployeeCode desc";
                _dtEmployees = dv.ToTable();

                dataGridViewEmployees.DataSource = _dtEmployees;
                _LstEmployees.Add(empModel);
                _newMode = false;
            }
            else
            {
                //UpdateData();
                empModel = FillEmployeeModel();
                empModel.CreatedBy = _currentLoadedEmployee.CreatedBy;
                empModel.CreatedDate = _currentLoadedEmployee.CreatedDate;
                empModel.UpdatedBy = LoginInfo.LoginEmployee.EmployeeCode;
                empModel.UpdateDate = DateTime.Now;
                _ec = new EmployeeController(empModel);
                _ec.UpdateModel(empModel);

                LstPed = FillProjectEmployeeDetailModel();
                _pedc = new ProjectEmployeeDetailController(LstPed);
                _pedc.SaveList(empModel.EmployeeCode);

                Employee emp = _LstEmployees.Where(x => x.EmployeeCode == empModel.EmployeeCode).FirstOrDefault();
                _LstEmployees.Remove(emp);
                _LstEmployees.Add(empModel);


                foreach (DataRow dr in _dtEmployees.Rows) // search whole table
                {
                    if (decimal.Parse(dr["EmployeeCode"].ToString()) == empModel.EmployeeCode) // if id==2
                    {
                        dr["EmployeeName"] = empModel.EmployeeName;
                        //dr["EmployeeTypeCode"] = empModel.EmployeeTypeCode;
                        //if (empModel.Manager == null){ dr["Manager"] = DBNull.Value; } else { dr["Manager"] = empModel.Manager; }
                        //if (empModel.ProjectCode == null) { dr["ProjectCode"] = DBNull.Value; } else { dr["ProjectCode"] = empModel.ProjectCode; }


                        break;
                    }
                }
            }


            //FillCmbManagers();
            //_LstProjects
            this.Enabled = true;


        }



        private Employee FillEmployeeModel()
        {
            Employee lObjEmp = new Employee();
            //if (_newMode == false) lObjEmp.EmployeeCode = decimal.Parse(txtEmployeeCode.Text);
            lObjEmp.EmployeeCode = decimal.Parse(txtEmployeeCode.Text);
            lObjEmp.EmployeeName = txtEmployeeName.Text;
            lObjEmp.EmployeeTypeCode = (short)cmbEmployeeType.SelectedValue;
            lObjEmp.Password = txtPassword.Text;
            
            //if ((short)cmbEmployeeType.SelectedValue == 1)
            //{
            //    lObjEmp.Manager = decimal.Parse(txtEmployeeCode.Text);//_maxEmpCode;
            //}
            //else 
            //{
            //    if (cmbMangers.SelectedValue == null)
            //    {
            //        lObjEmp.Manager = null;
            //    }
            //    else
            //    {
            //        lObjEmp.Manager = (decimal)(cmbMangers.SelectedValue);

            //    }

            //}
            ////////////////////////////////////////////////////

            //if (cmbProjects.SelectedValue == null)
            //{
            //    lObjEmp.ProjectCode = null;
            //}
            //else
            //{
            //    lObjEmp.ProjectCode = (decimal)(cmbProjects.SelectedValue);

            //}


            return lObjEmp;

        }
        private List<ProjectEmployeeDetail> FillProjectEmployeeDetailModel()
        {
            List<ProjectEmployeeDetail> LstPed = new List<ProjectEmployeeDetail>();
            ProjectEmployeeDetail ped;
            foreach (DataRow row1 in _dtProjects.Rows)
            {
                if (row1[0] != DBNull.Value && (bool)row1[0] == true)
                {
                    ped = new ProjectEmployeeDetail();
                    ped.EmployeeCode = _EmployeeCode;
                    ped.ProjectCode = (decimal)row1["ProjectCode"];
                    LstPed.Add(ped);
                }

            }
            return LstPed;
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        private void dataGridViewEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedCells.Count > 0 && dataGridViewEmployees.SelectedCells[0].Value != DBNull.Value)
            {
                int selectedrowindex = dataGridViewEmployees.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewEmployees.Rows[selectedrowindex];
                _EmployeeCode = Convert.ToDecimal(selectedRow.Cells["EmployeeCode"].Value);

                if (!string.IsNullOrEmpty(txtEmployeeCode.Text) && _EmployeeCode == decimal.Parse(txtEmployeeCode.Text)) return;

                _ec = new EmployeeController();
                _currentLoadedEmployee = _ec.GetModelByID(_EmployeeCode);
                if (_currentLoadedEmployee == null) return;
                txtEmployeeCode.Text = _currentLoadedEmployee.EmployeeCode.ToString();
                txtEmployeeName.Text = _currentLoadedEmployee.EmployeeName;
                txtPassword.Text = _currentLoadedEmployee.Password;
                cmbEmployeeType.SelectedValue = _currentLoadedEmployee.EmployeeTypeCode;


                if (_currentLoadedEmployee != null && _currentLoadedEmployee.EmployeeCode == LoginInfo.LoginEmployee.EmployeeCode)
                { btnShowPassword.Visible = true; }
                else
                { btnShowPassword.Visible = false; }


                //if (employee.Manager != null)
                //{cmbManagers.SelectedValue = employee.Manager;}
                //else
                //{cmbManagers.SelectedIndex = -1;}

                if (_currentLoadedEmployee.ProjectCode != null)
                { cmbProjects.SelectedValue = _currentLoadedEmployee.ProjectCode; }
                else
                { cmbProjects.SelectedIndex = -1; }

                //foreach (DataGridViewRow sr in this.dataGridViewEmployees.SelectedRows)
                //{

                //}

                _dtProjects.Rows.OfType<DataRow>().ToList().ForEach(r => r["Select Projects"] = false);


                foreach (DataRow dr in _dtProjects.Rows) // search whole table
                {

                    if (_currentLoadedEmployee.ProjectEmployeeDetails.Where(x => x.ProjectCode == (decimal)dr["ProjectCode"]).FirstOrDefault() != null)
                    {
                        dr["Select Projects"] = true;
                    }
                }


                //_LstProjectEmployeeDetail = _pedc.GetModels(_EmployeeCode);

                //if (_newMode == true)
                //{
                //    var a = "123";
                //}
                //if (_newMode == false)
                //{


                //}
            }

        }
        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            txtEmployeeCode.Text = string.Empty;
            SetForNew();
            _newMode = true;
        }

        private void SetForNew()
        {


            _maxEmpCode = _ec.GetMaxCode();
            txtEmployeeCode.Text = _maxEmpCode.ToString();
            txtPassword.Text = string.Empty;
            cmbEmployeeType.SelectedIndex = -1;
            txtEmployeeName.Text = "New Employee " + _maxEmpCode;
            _dtProjects.Rows.OfType<DataRow>().ToList().ForEach(r => r["Select Projects"] = false);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (splitContainer1.SplitterDistance < 51)
            {
                splitContainer1.SplitterDistance = 200;
            }
            else
            {
                splitContainer1.SplitterDistance = 49;
            }


        }

        private void dataGridViewEmployees_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // Add this
                dataGridViewEmployees.CurrentCell = dataGridViewEmployees.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Can leave these here - doesn't hurt
                dataGridViewEmployees.Rows[e.RowIndex].Selected = true;
                dataGridViewEmployees.Focus();


            }
        }
        private void dataGridViewEmployees_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                MenuStripProjects.Show(Cursor.Position);
            }
        }

        private void itemDeleteProject_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.Rows.Count > 0 && dataGridViewEmployees.SelectedRows.Count > 0)
            {

                // int selectedrowindex = dataGridViewProjects.SelectedCells[0].RowIndex;
                // DataGridViewRow selectedRow = dataGridViewProjects.Rows[selectedrowindex];
                // _projectCode = Convert.ToDecimal(selectedRow.Cells["EmployeeCode"].Value);

                //// _dtProjects.Rows.Remove(selectedRow);
                // dataGridViewProjects.DataSource = _dtProjects;

                foreach (DataGridViewRow sr in this.dataGridViewEmployees.SelectedRows)
                {

                    //Employee project = (Employee)item.DataBoundItem;
                    decimal pc = Convert.ToDecimal(sr.Cells[0].Value);
                    Employee emp = _LstEmployees.Where(x => x.EmployeeCode == pc).FirstOrDefault();
                    if (emp != null) _LstEmployees.Remove(emp);
                    _dtEmployees.Rows.RemoveAt(sr.Index);
                    //_LstProjects.RemoveAt()
                    _ec.DeleteModel(emp.EmployeeCode);

                    DataView dv = _dtEmployees.DefaultView;
                    dv.Sort = "EmployeeCode desc";
                    _dtEmployees = dv.ToTable();
                    dataGridViewEmployees.DataSource = _dtEmployees;

                    if (_dtEmployees.Rows.Count == 0)
                    {
                        SetForNew();
                        _ec.ReseedPk();
                        _newMode = true;
                    }


                    //dataGridViewProjects.Refresh();
                }
            }
            else
            {
                SetForNew();
            }
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (btnShowPassword.ImageKey == "show.png")
            {
                btnShowPassword.ImageKey = "hide.png";
                txtPassword.PasswordChar = '\0';

            }
            else
            {
                btnShowPassword.ImageKey = "show.png";
                txtPassword.PasswordChar = '●';

            }
        }
    }
}
