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
using System.IO;
using System.Diagnostics;

namespace Procurement
{
    public partial class FrmMR : Form
    {
        ProjectController _pc;
        MRController _mrc;
        MRVersionController _mrvc;
        ProjectEmployeeDetailController _pedc;
        decimal _maxMRVersionAutoRowId;

        DataTable _dtDesignBOM;
        DataTable _dtExportMRtoExcel;

        decimal _projectCode;
        bool _newMode;
        Project _currentLoadedProject;
        List<MR> _LstObjBoms;
        //SingleTon 
        private static FrmMR instance = null;
        private FrmMR()
        {
            InitializeComponent();

        }
        public static FrmMR Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {

                    instance = new FrmMR();
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

                }

                _currentLoadedProject = CurrentOpenProject.CurrentProject;

                List<BOM> list3 = _currentLoadedProject.BOMs.Where(y => y.BOMTypeCode == 3).ToList();
                if (list3.Count == 0) { MessageBox.Show("Please first create BOM"); btnSave.Enabled=false; return; }
                _dtDesignBOM = ToDataTable<BOM>(list3);
                _dtDesignBOM.Columns.Remove("ProjectCode");
                _dtDesignBOM.Columns.Remove("RowAuto");
                _dtDesignBOM.Columns.Remove("BomTypeCode");
                _dtDesignBOM.Columns.Remove("BOMType");
                _dtDesignBOM.Columns.Remove("Project");
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = _dtDesignBOM;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            string datetime = DateTime.Now.ToString();
            datetime = datetime.Replace(":", "");

            savefile.FileName = "Material Request " + datetime + ".xlsx";
            // set filters - this can be done in properties as well
            savefile.Filter = "Excel Workbook (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
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
                _maxMRVersionAutoRowId = _mrvc.GetMaxMRVersionAutoRowId();
                
                MRVersion mrvModel = new MRVersion();
                mrvModel.ProjectCode = _currentLoadedProject.ProjectCode;
                //mrvModel.Version = _maxMRVersion;
                mrvModel.VersionNo = _mrvc.GetMaxMRVersionNo();
                mrvModel.Description = _currentLoadedProject.ProjectCode.ToString();//mrvModel.VersionNo.ToString();//mrvModel.Version.ToString();

                _mrvc = new MRVersionController(mrvModel);
                _mrvc.Save();
                //

                _LstObjBoms = new List<MR>();
                FillBOMModel2();

                _mrc = new MRController(_LstObjBoms);
                _mrc.SaveList(projModel.ProjectCode, _maxMRVersionAutoRowId);


                ///////////////export to excel/////////////////
                // Here is main process
                Microsoft.Office.Interop.Excel.Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
                objexcelapp.Application.Workbooks.Add(Type.Missing);
                objexcelapp.Columns.AutoFit();


                for (int i = _dtExportMRtoExcel.Columns.Count - 1; i >= 0; i--)
                {
                    if (!(_dtExportMRtoExcel.Columns[i].ColumnName == "PartNo" || _dtExportMRtoExcel.Columns[i].ColumnName == "Qty"))
                    {
                        _dtExportMRtoExcel.Columns.RemoveAt(i);
                    }

                }

                for (int i = 1; i < _dtExportMRtoExcel.Columns.Count + 1; i++)
                {
                    if (_dtExportMRtoExcel.Columns[i - 1].ColumnName == "PartNo" || _dtExportMRtoExcel.Columns[i - 1].ColumnName == "Qty")
                    {
                        Microsoft.Office.Interop.Excel.Range xlRange = (Microsoft.Office.Interop.Excel.Range)objexcelapp.Cells[1, i];
                        xlRange.Font.Bold = -1;
                        xlRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        xlRange.Borders.Weight = 1d;
                        xlRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        objexcelapp.Cells[1, i] = _dtExportMRtoExcel.Columns[i - 1].ColumnName;
                    }
                }
                /*For storing Each row and column value to excel sheet*/
                for (int i = 0; i < _dtExportMRtoExcel.Rows.Count; i++)
                {
                    for (int j = 0; j < _dtExportMRtoExcel.Columns.Count; j++)
                    {
                        if (_dtExportMRtoExcel.Columns[j].ColumnName == "PartNo" || _dtExportMRtoExcel.Columns[j].ColumnName == "Qty")
                        {
                            if (_dtExportMRtoExcel.Rows[i][j] != null)
                            {
                                Microsoft.Office.Interop.Excel.Range xlRange = (Microsoft.Office.Interop.Excel.Range)objexcelapp.Cells[i + 2, j + 1];
                                xlRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                xlRange.Borders.Weight = 1d;
                                objexcelapp.Cells[i + 2, j + 1] = _dtExportMRtoExcel.Rows[i][j].ToString();
                            }
                        }
                    }
                }
                objexcelapp.Columns.AutoFit(); // Auto fix the columns size
                System.Windows.Forms.Application.DoEvents();
                //if (Directory.Exists("C:\\CTR_Data\\")) // Folder dic
                //{
                //    objexcelapp.ActiveWorkbook.SaveCopyAs("C:\\CTR_Data\\" + "excelFilename" + ".xlsx");
                //}
                //else
                //{
                //    Directory.CreateDirectory("C:\\CTR_Data\\");
                //    objexcelapp.ActiveWorkbook.SaveCopyAs("C:\\CTR_Data\\" + "excelFilename" + ".xlsx");
                //}
                objexcelapp.ActiveWorkbook.SaveCopyAs(savefile.FileName);
                objexcelapp.ActiveWorkbook.Saved = true;
                System.Windows.Forms.Application.DoEvents();
                foreach (Process proc in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
                {
                    proc.Kill();
                }

                /////
                
                System.Diagnostics.Process.Start(savefile.FileName);

                //////////////update shared object///////////////////
                _pc = new ProjectController();
                CurrentOpenProject.CurrentProject = _pc.GetModelByID(CurrentOpenProject.CurrentProject.ProjectCode);
                //////////////
                this.Enabled = true;
                this.Close();
            }
        }

        private void FillBOMModel2()
        {
            
            foreach (DataGridViewRow gvr in dataGridView4.Rows)
            {
                FillBOMModelSub(gvr, 4);
            }
            

        }
        private void FillBOMModelSub(DataGridViewRow pGvr, short pBOMTypeCode)
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

                lObjBom.Version = _maxMRVersionAutoRowId;
                //lObjBom.ProjectCode = _currentLoadedProject.ProjectCode;

                var cellObj = pGvr.Cells["Sr" + pBOMTypeCode];
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

                _LstObjBoms.Add(lObjBom);
                

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


        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal quantity = ReturnAppropriateValue(dataGridView2.Rows[e.RowIndex].Cells["Qty2"].Value);
            decimal rate = ReturnAppropriateValue(dataGridView2.Rows[e.RowIndex].Cells["UnitCost2"].Value);

            //if (decimal.TryParse(dataGridView2.Rows[e.RowIndex].Cells["Qty"].Value.ToString(), out quantity) && decimal.TryParse(dataGridView2.Rows[e.RowIndex].Cells["UnitCost"].Value.ToString(), out rate))
            //{
            decimal price = quantity * rate;
            //dataGridView2.Rows[e.RowIndex].Cells[15].Value = price.ToString();
            dataGridView2.Rows[e.RowIndex].Cells["ExtCost2"].Value = price.ToString();

            //}
        }

        private decimal ReturnAppropriateValue(object ObjValue)
        {
            if (ObjValue == null) return 0;
            decimal returnDecimalValue;
            if (decimal.TryParse(ObjValue.ToString(), out returnDecimalValue))
            {
                return returnDecimalValue;
            }
            else
            {
                return 0;
            }
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

        private void btnCopySame_Click(object sender, EventArgs e)
        {

            DataTable dtMR = new DataTable();
            dtMR.Columns.Add("Sr");
            dtMR.Columns.Add("PartNo");
            dtMR.Columns.Add("Description");
            dtMR.Columns.Add("Qty");
            dtMR.Columns.Add("UnitCost");
            dtMR.Columns.Add("ExtCost");
            dtMR.Columns.Add("UnitPrice");
            dtMR.Columns.Add("ExtPrice");

            foreach (DataGridViewRow gvr in dataGridView2.Rows)
            {
                if (gvr.Cells["Select2"].Value != null && (bool)gvr.Cells["Select2"].Value == true)
                {

                    DataRow newRow = dtMR.NewRow();
                    newRow["Sr"] = gvr.Cells["Sr2"].Value;
                    newRow["PartNo"] = gvr.Cells["PartNo2"].Value;
                    newRow["Description"] = gvr.Cells["Description2"].Value;
                    newRow["Qty"] = gvr.Cells["Qty2"].Value;
                    newRow["UnitCost"] = gvr.Cells["UnitCost2"].Value;
                    newRow["ExtCost"] = gvr.Cells["ExtCost2"].Value;
                    newRow["UnitPrice"] = gvr.Cells["UnitPrice2"].Value;
                    newRow["ExtPrice"] = gvr.Cells["ExtPrice2"].Value;
                    dtMR.Rows.Add(newRow);

                }


            }
            dataGridView4.DataSource = dtMR;
            _dtExportMRtoExcel = dtMR.Copy();
        }

        private void btnCopyUserSpecified_Click(object sender, EventArgs e)
        {
            DataTable dtMR = new DataTable();
            dtMR.Columns.Add("Sr");
            dtMR.Columns.Add("PartNo");
            dtMR.Columns.Add("Description");
            dtMR.Columns.Add("Qty");
            dtMR.Columns.Add("UnitCost");
            dtMR.Columns.Add("ExtCost");
            dtMR.Columns.Add("UnitPrice");
            dtMR.Columns.Add("ExtPrice");

            FrmGetQty frmGetQty = new FrmGetQty();

            foreach (DataGridViewRow gvr in dataGridView2.Rows)
            {
                if (gvr.Cells["Select2"].Value != null && (bool)gvr.Cells["Select2"].Value == true)
                {
                    DataRow newRow = dtMR.NewRow();
                    newRow["Sr"] = gvr.Cells["Sr2"].Value;
                    newRow["PartNo"] = gvr.Cells["PartNo2"].Value;
                    frmGetQty.gPartNo = gvr.Cells["PartNo2"].Value.ToString();
                    newRow["Description"] = gvr.Cells["Description2"].Value;

                    var result = frmGetQty.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //newRow["Qty"] = gvr.Cells["Qty2"].Value;
                        newRow["Qty"] = frmGetQty.gQty;

                    }

                    decimal unitCost = decimal.Parse(gvr.Cells["UnitCost2"].Value.ToString());
                    //decimal qty = decimal.Parse ( frmGetQty.gQty);
                    decimal qty = Convert.ToDecimal(string.IsNullOrEmpty(frmGetQty.gQty) ? "0" : frmGetQty.gQty);

                    newRow["UnitCost"] = gvr.Cells["UnitCost2"].Value;
                    newRow["ExtCost"] = unitCost * qty; //gvr.Cells["ExtCost2"].Value;
                    newRow["UnitPrice"] = gvr.Cells["UnitPrice2"].Value;
                    newRow["ExtPrice"] = gvr.Cells["ExtPrice2"].Value;
                    dtMR.Rows.Add(newRow);

                }


            }
            dataGridView4.DataSource = dtMR;
            _dtExportMRtoExcel = dtMR.Copy();
        }


    }
}