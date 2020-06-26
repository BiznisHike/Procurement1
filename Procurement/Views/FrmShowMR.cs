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
    public partial class FrmShowMR : Form
    {
        ProjectController _pc;
        MRController _mrc;
        MRVersionController _mrvc;
        ProjectEmployeeDetailController _pedc;
        decimal _maxMRVersion;

        DataTable _dtDesignBOM;
        
        decimal _projectCode;
        bool _newMode;
        Project _currentLoadedProject;
        public decimal _currentMRVersion;
        //SingleTon 
        //private static FrmShowMR instance = null;
        public FrmShowMR()
        {
            InitializeComponent();

        }
        //public static FrmShowMR Instance
        //{
        //    get
        //    {
        //        if (instance == null || instance.IsDisposed)
        //        {

        //            instance = new FrmShowMR();
        //        }


        //        return instance;
        //    }
        //}
        //End SingleTon

        private void FrmBOM_Load(object sender, EventArgs e)
        {
            dataGridView4.AllowUserToDeleteRows = false;
            try
            {
                

                if (LoginInfo.LoginEmployee.EmployeeTypeCode == Constants.EMPLOYEE)
                {

                }
                _currentLoadedProject = CurrentOpenProject.CurrentProject;

                //List<BOM> list2 = _currentLoadedProject.BOMs.Where(y => y.BOMTypeCode == 2).ToList();
                List<MR> list2 = _currentLoadedProject.MRVersions.FirstOrDefault(x => x.Id == _currentMRVersion).MRs.ToList<MR>();
                _dtDesignBOM = ToDataTable<MR>(list2);
                //_dtDesignBOM.Columns.Remove("ProjectCode");
                //_dtDesignBOM.Columns.Remove("RowAuto");
                //_dtDesignBOM.Columns.Remove("BomTypeCode");
                //_dtDesignBOM.Columns.Remove("BOMType");
                //_dtDesignBOM.Columns.Remove("Project");
                dataGridView4.AutoGenerateColumns = false;
                dataGridView4.DataSource = _dtDesignBOM;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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

       
        private void ClearAll()
        {
            
            if (_dtDesignBOM != null) _dtDesignBOM.Rows.Clear();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        
        
        private void FrmBOM_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.Close();
            //}
        }
        private void LoadBOM_Click(object sender, EventArgs e)
        {
            MenuStripLoad.Show(Cursor.Position);
        }
        private void btnLoadBOM_Enter(object sender, EventArgs e)
        {
            MenuStripLoad.Show(Cursor.Position);
        }
        private void btnLoadBOM_MouseEnter(object sender, EventArgs e)
        {
            MenuStripLoad.Show(Cursor.Position);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        
        
    }
}