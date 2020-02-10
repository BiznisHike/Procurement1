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
            try
            {
                

                if (LoginInfo.LoginEmployee.EmployeeTypeCode == Constants.EMPLOYEE)
                {

                }
                _currentLoadedProject = CurrentOpenProject.CurrentProject;

                //List<BOM> list2 = _currentLoadedProject.BOMs.Where(y => y.BOMTypeCode == 2).ToList();
                List<MR> list2 = _currentLoadedProject.MRs.Where(y => y.Version == _currentMRVersion).ToList();
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

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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

            //fill MR Verion first
            _mrvc = new MRVersionController();
            _maxMRVersion = _mrvc.GetMaxMRVersionCode();
            MRVersion mrvModel = new MRVersion();
            //mrvModel.ProjectCode = _currentLoadedProject.ProjectCode;
            mrvModel.Version = _maxMRVersion;
            mrvModel.Description = mrvModel.Version.ToString();

            _mrvc = new MRVersionController(mrvModel);
            _mrvc.Save();
            //

            List<MR> LstObjBom;
            
            LstObjBom = FillBOMModel2(ref projModel);
            
            _mrc = new MRController(LstObjBom);
            _mrc.SaveList(projModel.ProjectCode, _maxMRVersion);
            
            this.Enabled = true;

        }
      
        private List<MR> FillBOMModel2(ref Project pProjectModel)
        {
            List<MR> LstObjBom = new List<MR>();
            foreach (DataGridViewRow gvr in dataGridView4.Rows)
            {
                FillBOMModelSub(ref pProjectModel, ref LstObjBom, gvr, 4);
            }
            return LstObjBom;

        }
        private void FillBOMModelSub(ref Project pProjectModel, ref List<MR> pLstObjBom, DataGridViewRow pGvr, short pBOMTypeCode)
        {
            //string colName=pGvr.Cells[0].OwningColumn.HeaderText;

            bool isAdd = false;
            for (int i = 0; i < pGvr.Cells.Count; i++)
            {
                //if (pGvr.Cells[i].Value == null || pGvr.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(pGvr.Cells[i].Value.ToString()))
                if (pGvr.Cells[i].Value == null)
                {
                    isAdd = false;
                }
                else
                {
                    isAdd = true;
                    break;
                }
            }
            if (isAdd == true)
            {
                MR lObjBom = new MR();
                //lObjBom.BOMCode = (string)pGvr.Cells[0].Value;
                
                lObjBom.Version = _maxMRVersion;
                lObjBom.ProjectCode = _currentLoadedProject.ProjectCode;

                var cellObj= pGvr.Cells["Sr" + pBOMTypeCode];
                lObjBom.Sr = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["PartNo" + pBOMTypeCode];
                lObjBom.PartNo = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Description" + pBOMTypeCode];
                lObjBom.Description = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Qty" + pBOMTypeCode];
                lObjBom.Qty = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["UnitCost" + pBOMTypeCode];
                lObjBom.UnitCost = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["ExtCost" + pBOMTypeCode];
                lObjBom.ExtCost = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["UnitPrice" + pBOMTypeCode];
                lObjBom.UnitPrice = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["ExtPrice" + pBOMTypeCode];
                lObjBom.ExtPrice = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                pLstObjBom.Add(lObjBom);
                pProjectModel.MRs.Add(lObjBom);

            }

            //return null;
        }
        private Project FillProjectModel()
        {
            Project lObjProj = new Project();
            //if (_newMode == false) lObjProj.ProjectCode = decimal.Parse(txtProjectCode.Text);
            lObjProj.ProjectCode = _currentLoadedProject.ProjectCode;
            lObjProj.ProjectName = _currentLoadedProject.ProjectName;
            lObjProj.EndUser = _currentLoadedProject.EndUser;
            lObjProj.Customer = _currentLoadedProject.Customer;
            return lObjProj;

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
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
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