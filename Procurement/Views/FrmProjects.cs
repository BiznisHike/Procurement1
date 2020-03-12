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
    public partial class FrmProjects : Form
    {
        ProjectController _pc;
        List<Project> _LstProjects;
        DataTable _dtProjects;
        
        decimal _projectCode;
        bool _newMode;
        Project _currentLoadedProject;

        //SingleTon 
        private static FrmProjects instance = null;
        private FrmProjects()
        {
            InitializeComponent();

        }
        public static FrmProjects Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {

                    instance = new FrmProjects();
                }


                return instance;
            }
        }
        //End SingleTon

        private void FrmBOM_Load(object sender, EventArgs e)
        {
            dataGridViewProjects.AllowUserToDeleteRows = false;
            try
            {
                
               
                _pc = new ProjectController();
                _LstProjects = _pc.GetModels();


                //foreach (Project project in _LstProjects)
                //{
                //    //project.BOMs = new List<BOM>();
                //    //project.ProjectEmployeeDetails = new List<ProjectEmployeeDetail>();
                //    //project.MRVersions = new List<MRVersion>();

                //    foreach (BOM bom in project.BOMs.ToList<BOM>())
                //    {
                //        project.BOMs.Remove(bom);
                //    }
                //    foreach (ProjectEmployeeDetail ped in project.ProjectEmployeeDetails.ToList<ProjectEmployeeDetail>())
                //    {
                //        project.ProjectEmployeeDetails.Remove(ped);
                //    }
                //    foreach (MRVersion mrv in project.MRVersions.ToList<MRVersion>())
                //    {
                //        project.MRVersions.Remove(mrv);
                //    }

                //}

                //for (int i = 0; i <= _LstProjects.Count - 1; i++)
                //{
                //    _LstProjects[i].BOMs= new List<BOM>();
                //    _LstProjects[i].ProjectEmployeeDetails = new List<ProjectEmployeeDetail>();
                //    _LstProjects[i].MRVersions = new List<MRVersion>();
                //}



                _dtProjects = ToDataTable<Project>(_LstProjects);
                //_dtProjects.Columns.Remove("BOMs");
                //_dtProjects.Columns.Remove("ProjectEmployeeDetails");
                //_dtProjects.Columns.Remove("MRVersions");
                _dtProjects.Columns.Remove("CreatedBy");
                _dtProjects.Columns.Remove("UpdatedBy");
                DataView dv = _dtProjects.DefaultView;
                dv.Sort = "ProjectCode desc";
                _dtProjects = dv.ToTable();

                dataGridViewProjects.DataSource = _dtProjects;

                

                if (_LstProjects.Count == 0)
                {

                    _newMode = true;
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
      
        private void dataGridViewProjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProjects.SelectedCells.Count > 0 && dataGridViewProjects.SelectedCells[0].Value != DBNull.Value)
            {
                int selectedrowindex = dataGridViewProjects.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewProjects.Rows[selectedrowindex];
                _projectCode = Convert.ToDecimal(selectedRow.Cells["ProjectCode"].Value);
                
            }

        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                if (prop.Name == "BOMs" || prop.Name == "ProjectEmployeeDetails" || prop.Name == "MRVersions") continue;

                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length-3];
                for (int i = 0; i < Props.Length; i++)
                {
                    if (Props[i].Name == "BOMs" || Props[i].Name == "ProjectEmployeeDetails" || Props[i].Name == "MRVersions") continue;
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void dataGridViewProjects_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // Add this
                dataGridViewProjects.CurrentCell = dataGridViewProjects.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Can leave these here - doesn't hurt
                dataGridViewProjects.Rows[e.RowIndex].Selected = true;
                dataGridViewProjects.Focus();


            }
        }
        private void dataGridViewProjects_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                MenuStripProjects.Show(Cursor.Position);
            }
        }

        private void itemDeleteProject_Click(object sender, EventArgs e)
        {
            if (dataGridViewProjects.Rows.Count > 0 && dataGridViewProjects.SelectedRows.Count > 0)
            {

                // int selectedrowindex = dataGridViewProjects.SelectedCells[0].RowIndex;
                // DataGridViewRow selectedRow = dataGridViewProjects.Rows[selectedrowindex];
                // _projectCode = Convert.ToDecimal(selectedRow.Cells["ProjectCode"].Value);

                //// _dtProjects.Rows.Remove(selectedRow);
                // dataGridViewProjects.DataSource = _dtProjects;

                foreach (DataGridViewRow sr in this.dataGridViewProjects.SelectedRows)
                {

                    //Project project = (Project)item.DataBoundItem;
                    decimal pc = Convert.ToDecimal(sr.Cells[0].Value);
                    Project proj = _LstProjects.Where(x => x.ProjectCode == pc).FirstOrDefault();
                    if (proj != null) _LstProjects.Remove(proj);
                    _dtProjects.Rows.RemoveAt(sr.Index);
                    //_LstProjects.RemoveAt()
                    _pc.DeleteModel(proj.ProjectCode);

                    DataView dv = _dtProjects.DefaultView;
                    dv.Sort = "ProjectCode desc";
                    _dtProjects = dv.ToTable();
                    dataGridViewProjects.DataSource = _dtProjects;

                    if (_dtProjects.Rows.Count == 0)
                    {
                        
                        _pc.ReseedPk();
                        _newMode = true;
                    }


                    //dataGridViewProjects.Refresh();
                }
            }
            else
            {
                
            }
        }

        private void btnOpenProject_Click(object sender, EventArgs e)
        {

            OpenProject();
        }
        private void dataGridViewProjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenProject();
        }

        void OpenProject()
        {
            _pc = new ProjectController();
            _currentLoadedProject = _pc.GetModelByID(_projectCode);

            CurrentOpenProject.CurrentProject = _currentLoadedProject;
            FrmMDI.Instance.Text = " Project Code: '" + _currentLoadedProject.ProjectCode +
                        "' Project Name: '" + _currentLoadedProject.ProjectName +
                        "' Project Customer: '" + _currentLoadedProject.Customer +
                        "' Project End User: '" + _currentLoadedProject.EndUser + "'";


            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "FrmMDI" && Application.OpenForms[i].Name != "FrmProjects")
                    Application.OpenForms[i].Close();
            }

            MessageBox.Show("Project Opened Successfully");
            //toolTip1.Show("Project Opened Successfully",dataGridViewProjects,Cursor.Position,5000);
            
            


        }

        private void FrmBOM_Show()
        {
            FrmBOM.Instance.MdiParent = FrmMDI.Instance;
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

        }

        private void FrmProjects_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.Close();
            //}
        }

        private void linkAddNewProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmNewProject_Show();
            this.Close();
        }
        private void FrmNewProject_Show()
        {
            FrmNewProject.Instance.MdiParent = FrmMDI.Instance; //this;
            FrmNewProject.Instance._newMode = true;
            if (!FrmNewProject.Instance.Visible)
            {
                FrmNewProject.Instance.Show();
            }
            else
            {
                if (FrmNewProject.Instance.WindowState == FormWindowState.Minimized)
                {
                    FrmNewProject.Instance.WindowState = FormWindowState.Normal;
                }
                else
                {
                    FrmNewProject.Instance.BringToFront();
                }

            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pc = new ProjectController();
            _currentLoadedProject = _pc.GetModelByID(_projectCode);

            CurrentOpenProject.CurrentProject = _currentLoadedProject;
           
            //for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            //{
            //    if (Application.OpenForms[i].Name != "FrmMDI" && Application.OpenForms[i].Name != "FrmProjects")
            //        Application.OpenForms[i].Close();
            //}

            this.Close();

            ////////////////

            FrmEditProject_Show();
        }
        private void FrmEditProject_Show()
        {
            FrmNewProject.Instance.MdiParent = FrmMDI.Instance; //this;
            FrmNewProject.Instance._newMode = false;
            if (!FrmNewProject.Instance.Visible)
            {
                FrmNewProject.Instance.Show();
            }
            else
            {
                if (FrmNewProject.Instance.WindowState == FormWindowState.Minimized)
                {
                    FrmNewProject.Instance.WindowState = FormWindowState.Normal;
                }
                else
                {
                    FrmNewProject.Instance.BringToFront();
                }

            }

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProjects_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Close this window?", "Confirmation", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.No) e.Cancel = true;
        }
    }
}