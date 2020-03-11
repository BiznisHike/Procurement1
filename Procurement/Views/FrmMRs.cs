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
    public partial class FrmMRs : Form
    {
        MRVersionController _mrvc;
        List<MRVersion> _LstMRVs;
        DataTable _dtMRVs;

        decimal _MRVersion;
        bool _newMode;
        Project _currentLoadedProject;

        //SingleTon 
        private static FrmMRs instance = null;
        private FrmMRs()
        {
            InitializeComponent();

        }
        public static FrmMRs Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {

                    instance = new FrmMRs();
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

                _mrvc = new MRVersionController();
                _LstMRVs = _mrvc.GetModels();

                _dtMRVs = ToDataTable<MRVersion>(_LstMRVs);
                _dtMRVs.Columns.Remove("Project");
                _dtMRVs.Columns.Remove("MRs");
                //_dtProjects.Columns.Remove("ProjectEmployeeDetails");
                //_dtProjects.Columns.Remove("CreatedBy");
                //_dtProjects.Columns.Remove("UpdatedBy");

                DataView dv = _dtMRVs.DefaultView;
                dv.Sort = "Version desc";
                _dtMRVs = dv.ToTable();

                dataGridViewProjects.DataSource = _dtMRVs;

                if (_LstMRVs.Count == 0)
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
                _MRVersion = Convert.ToDecimal(selectedRow.Cells["Version"].Value);

            }

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



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridViewProjects_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
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
                    decimal version = Convert.ToDecimal(sr.Cells[0].Value);
                    MRVersion mrv = _LstMRVs.Where(x => x.Version == version).FirstOrDefault();
                    if (mrv != null) _LstMRVs.Remove(mrv);
                    _dtMRVs.Rows.RemoveAt(sr.Index);
                    //_LstProjects.RemoveAt()
                    _mrvc.DeleteModel(mrv.Version);

                    DataView dv = _dtMRVs.DefaultView;
                    dv.Sort = "ProjectCode desc";
                    _dtMRVs = dv.ToTable();
                    dataGridViewProjects.DataSource = _dtMRVs;

                    if (_dtMRVs.Rows.Count == 0)
                    {

                        //_mrc.ReseedPk();
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
            //_mrvc = new MRVersionController();

            //CurrentOpenProject.CurrentProject = _currentLoadedProject;
            //FrmMDI.Instance.Text = " Project Code: '" + _currentLoadedProject.ProjectCode +
            //            "' Project Name: '" + _currentLoadedProject.ProjectName +
            //            "' Project Customer: '" + _currentLoadedProject.Customer +
            //            "' Project End User: '" + _currentLoadedProject.EndUser + "'";


            //for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            //{
            //    if (Application.OpenForms[i].Name != "FrmMDI" && Application.OpenForms[i].Name != "FrmMRs")
            //        Application.OpenForms[i].Close();
            //}
            //this.Close();     

            //FrmShowMR_Show();

            if (_MRVersion > 0)
            {
                FrmShowMR frmShowMR = new FrmShowMR();
                frmShowMR._currentMRVersion = _MRVersion;
                frmShowMR.ShowDialog();
            }
        }

        //private void FrmShowMR_Show()
        //{
        //    FrmBOM.Instance.MdiParent = FrmMDI.Instance;
        //    if (!FrmBOM.Instance.Visible)
        //    {
        //        FrmBOM.Instance.Show();
        //    }
        //    else
        //    {
        //        if (FrmBOM.Instance.WindowState == FormWindowState.Minimized)
        //        {
        //            FrmBOM.Instance.WindowState = FormWindowState.Normal;
        //        }
        //        else
        //        {
        //            FrmBOM.Instance.BringToFront();
        //        }

        //    }

        //}

        private void FrmMRs_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.Close();
            //}
        }

        private void linkAddNewProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmNewMR_Show();
        }
        private void FrmNewMR_Show()
        {
            FrmMR.Instance.MdiParent = FrmMDI.Instance; //this;

            if (!FrmMR.Instance.Visible)
            {
                FrmMR.Instance.Show();
            }
            else
            {
                if (FrmMR.Instance.WindowState == FormWindowState.Minimized)
                {
                    FrmMR.Instance.WindowState = FormWindowState.Normal;
                }
                else
                {
                    FrmMR.Instance.BringToFront();
                }

            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mrvc = new MRVersionController();
            //_currentLoadedProject = _mrc.GetModelByID(_projectCode);

            CurrentOpenProject.CurrentProject = _currentLoadedProject;

            //for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            //{
            //    if (Application.OpenForms[i].Name != "FrmMDI" && Application.OpenForms[i].Name != "FrmMRs")
            //        Application.OpenForms[i].Close();
            //}

            this.Close();

            ////////////////

            FrmEditProject_Show();
        }
        private void FrmEditProject_Show()
        {
            FrmNewProject.Instance.MdiParent = FrmMDI.Instance; //this;

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

        private void dataGridViewProjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOpenProject_Click(null, null);
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

            this.Close();
        }

        private void FrmMRs_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Close this window?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) e.Cancel = true;
        }
    }
}