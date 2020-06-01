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
using System.Text.RegularExpressions;
using System.Text;
using System.Drawing;
using System.IO;
using ExcelDataReader;

namespace Procurement
{
    public partial class FrmBOM : Form
    {
        ProjectController _pc;
        BOMController _bc;
        ProjectEmployeeDetailController _pedc;
        DataTable _dtSalesBOM;
        DataTable _dtDesignBOM;
        DataTable _dtActualBOM;
        decimal _projectCode;
        bool _newMode;
        Project _currentLoadedProject;
        List<string> _columnNames;
        bool IsGridView1Changed;
        bool IsGridView2Changed;
        bool IsGridView3Changed;
        //SingleTon 
        private static FrmBOM instance = null;
        private FrmBOM()
        {
            InitializeComponent();

        }
        public static FrmBOM Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {

                    instance = new FrmBOM();
                }


                return instance;
            }
        }
        //End SingleTon

        private void FrmBOM_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            try
            {

                if (LoginInfo.LoginEmployee.EmployeeTypeCode == Constants.EMPLOYEE)
                {

                    btnLoadBOM.Enabled = false;
                }

                ClearAll();

                _currentLoadedProject = CurrentOpenProject.CurrentProject;
                _columnNames = new List<String> {"Category1","Category2","Category3", "SORef",
                                                "Sr","ProductCategory","Product","CostHead",
                                                "CostSubHead","System","Area","Panel",
                                                "Category","Manufacturer","PartNo","Description",
                                                "Qty","UnitCost","ExtCost","UnitPrice","ExtPrice",
                                                "Column1","Column2","Column3","Column4","Column5",
                                            };
                if (_currentLoadedProject == null)
                {
                    _newMode = true;
                    return;
                }
                else
                {
                    _newMode = false;

                    List<BOM> list1 = _currentLoadedProject.BOMs.Where(y => y.BOMTypeCode == 1).ToList();
                    _dtSalesBOM = ToDataTable<BOM>(list1);
                    _dtSalesBOM.Columns.Remove("ProjectCode");
                    _dtSalesBOM.Columns.Remove("RowAuto");
                    _dtSalesBOM.Columns.Remove("BomTypeCode");
                    _dtSalesBOM.Columns.Remove("BOMType");
                    _dtSalesBOM.Columns.Remove("Project");
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = _dtSalesBOM;

                    List<BOM> list2 = _currentLoadedProject.BOMs.Where(y => y.BOMTypeCode == 2).ToList();
                    _dtDesignBOM = ToDataTable<BOM>(list2);
                    _dtDesignBOM.Columns.Remove("ProjectCode");
                    _dtDesignBOM.Columns.Remove("RowAuto");
                    _dtDesignBOM.Columns.Remove("BomTypeCode");
                    _dtDesignBOM.Columns.Remove("BOMType");
                    _dtDesignBOM.Columns.Remove("Project");
                    dataGridView2.AutoGenerateColumns = false;
                    dataGridView2.DataSource = _dtDesignBOM;

                    List<BOM> list3 = _currentLoadedProject.BOMs.Where(y => y.BOMTypeCode == 3).ToList();
                    _dtActualBOM = ToDataTable<BOM>(list3);
                    _dtActualBOM.Columns.Remove("ProjectCode");
                    _dtActualBOM.Columns.Remove("RowAuto");
                    _dtActualBOM.Columns.Remove("BomTypeCode");
                    _dtActualBOM.Columns.Remove("BOMType");
                    _dtActualBOM.Columns.Remove("Project");
                    dataGridView3.AutoGenerateColumns = false;
                    dataGridView3.DataSource = _dtActualBOM;
                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //DataTableCollection tableCollection;

        private void LoadExcelNewMethod()
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel File|*.xls;*.xlsx;*.xlsm" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        DataSet tempDataSet;
                        txtBOMFilePath.Text = openFileDialog.FileName;
                        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                tempDataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                                //tableCollection = result.Tables;
                                //dataGridView1.DataSource = result.Tables[0];//tableCollection[0];
                            }
                        }

                        DataTable dtBOM = new DataTable("dtBOM");
                        //dtBOM = dtTemp.Clone();
                        dtBOM.Columns.Add(_columnNames[0], typeof(string));
                        dtBOM.Columns.Add(_columnNames[1], typeof(string));
                        dtBOM.Columns.Add(_columnNames[2], typeof(string));
                        dtBOM.Columns.Add(_columnNames[3], typeof(string));
                        dtBOM.Columns.Add(_columnNames[4], typeof(decimal));
                        dtBOM.Columns.Add(_columnNames[5], typeof(string));
                        dtBOM.Columns.Add(_columnNames[6], typeof(string));
                        dtBOM.Columns.Add(_columnNames[7], typeof(string));
                        dtBOM.Columns.Add(_columnNames[8], typeof(string));
                        dtBOM.Columns.Add(_columnNames[9], typeof(string));
                        dtBOM.Columns.Add(_columnNames[10], typeof(string));
                        dtBOM.Columns.Add(_columnNames[11], typeof(string));
                        dtBOM.Columns.Add(_columnNames[12], typeof(string));
                        dtBOM.Columns.Add(_columnNames[13], typeof(string));
                        dtBOM.Columns.Add(_columnNames[14], typeof(string));
                        dtBOM.Columns.Add(_columnNames[15], typeof(string));
                        dtBOM.Columns.Add(_columnNames[16], typeof(decimal));
                        dtBOM.Columns.Add(_columnNames[17], typeof(decimal));
                        dtBOM.Columns.Add(_columnNames[18], typeof(decimal));
                        dtBOM.Columns.Add(_columnNames[19], typeof(decimal));
                        dtBOM.Columns.Add(_columnNames[20], typeof(decimal));
                        dtBOM.Columns.Add(_columnNames[21], typeof(string));
                        dtBOM.Columns.Add(_columnNames[22], typeof(string));
                        dtBOM.Columns.Add(_columnNames[23], typeof(string));
                        dtBOM.Columns.Add(_columnNames[24], typeof(string));
                        dtBOM.Columns.Add(_columnNames[25], typeof(string));

                        dataGridView1.AutoGenerateColumns = false;

                        foreach (DataRow dr in tempDataSet.Tables[0].Rows)
                        {
                            //string colName=gvr.Cells[0].OwningColumn.HeaderText;

                            bool isAdd = false;
                            for (int i = 0; i < tempDataSet.Tables[0].Columns.Count; i++)
                            {
                                //if (dr[i] == null || dr[i] == DBNull.Value || String.IsNullOrWhiteSpace(dr[i].ToString()))
                                if (dr[i] == DBNull.Value)
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
                                //can not add like this dtBOM.Rows.Add(dr); :(  have to add new row and then add to list
                                //newDataRow = dtBOM.NewRow();
                                //for (int i = 0; i <  dtTemp.Columns.Count; i++)
                                //{
                                //    newDataRow[i] = dr[i];

                                //}
                                //dtBOM.Rows.Add(newDataRow);

                                dtBOM.Rows.Add(dr.ItemArray);
                            }

                        }
                        if (tabControl1.SelectedTab == tabControl1.TabPages["tabSaleBOM"])
                        {
                            _dtSalesBOM = dtBOM;
                            dataGridView1.DataSource = _dtSalesBOM;
                            IsGridView1Changed = true;
                        }
                        if (tabControl1.SelectedTab == tabControl1.TabPages["tabDesignBOM"])
                        {
                            _dtDesignBOM = dtBOM;
                            dataGridView2.DataSource = _dtDesignBOM;
                            IsGridView2Changed = true;
                        }
                        if (tabControl1.SelectedTab == tabControl1.TabPages["tabActualBOM"])
                        {
                            _dtActualBOM = dtBOM;
                            dataGridView3.DataSource = _dtActualBOM;
                            IsGridView3Changed = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                switch (ex.HResult)
                {
                    case -2147024864:
                        MessageBox.Show(ex.Message);
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }

                
            }
        }
        private void loadBOMToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Method1();
            LoadExcelNewMethod();

        }

        private void loadChageOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel File|*.xls;*.xlsx;*.xlsm" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        DataSet tempDataSet;
                        txtBOMFilePath.Text = openFileDialog.FileName;
                        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                tempDataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                                //tableCollection = result.Tables;
                                //dataGridView1.DataSource = result.Tables[0];//tableCollection[0];
                            }
                        }

                        foreach (DataRow dr in tempDataSet.Tables[0].Rows)
                        {
                            //string colName=gvr.Cells[0].OwningColumn.HeaderText;

                            bool isAdd = false;
                            for (int i = 0; i < tempDataSet.Tables[0].Columns.Count; i++)
                            {
                                //if (dr[i] == null || dr[i] == DBNull.Value || String.IsNullOrWhiteSpace(dr[i].ToString()))
                                if (dr[i] == DBNull.Value)
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
                                //can not add like this dtBOM.Rows.Add(dr); :(  have to add new row and then add to list
                                //newDataRow = dtBOM.NewRow();
                                //for (int i = 0; i <  dtTemp.Columns.Count; i++)
                                //{
                                //    newDataRow[i] = dr[i];

                                //}
                                //dtBOM.Rows.Add(newDataRow);



                                if (tabControl1.SelectedTab == tabControl1.TabPages["tabSaleBOM"])
                                {
                                    _dtSalesBOM.Rows.Add(dr.ItemArray);
                                    IsGridView1Changed = true;
                                }
                                if (tabControl1.SelectedTab == tabControl1.TabPages["tabDesignBOM"])
                                {
                                    _dtDesignBOM.Rows.Add(dr.ItemArray);
                                    IsGridView2Changed = true;
                                }
                                if (tabControl1.SelectedTab == tabControl1.TabPages["tabActualBOM"])
                                {
                                    _dtActualBOM.Rows.Add(dr.ItemArray);
                                    IsGridView3Changed = true;
                                }
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //mnuCopyAllToDesignBOM.ShowDropDown();
            //contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            if (e.RowIndex >= 0 && e.ColumnIndex == -1)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    MenuStripDelete.Show(Cursor.Position);

                }
            }

            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    flowLayoutPanel1.Location = new Point(Cursor.Position.X, Cursor.Position.Y - 50);
                    //flowLayoutPanel1.Show();
                    flowLayoutPanel1.Visible = true;

                }
            }

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MenuStripSaleBOM.Show(Cursor.Position);
            }


        }
        private void itmCopyAllToDesignBOM_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("All data from Bid BOM will copy to Planned BOM... Sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _dtDesignBOM = new DataTable();
                _dtDesignBOM = _dtSalesBOM.Copy();

                //dataGridView2.DataSource =dataGridView1.DataSource;
                dataGridView2.DataSource = _dtDesignBOM;
                tabControl1.SelectedTab = tabDesignBOM;
                IsGridView2Changed = true;
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == -1)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    MenuStripDelete.Show(Cursor.Position);

                }
            }
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    flowLayoutPanel1.Location = new Point(Cursor.Position.X, Cursor.Position.Y - 50);
                    //flowLayoutPanel1.Show();
                    flowLayoutPanel1.Visible = true;

                }
            }

            //mnuCopyAllToDesignBOM.ShowDropDown();
            //contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MenuStripDesignBOM.Show(Cursor.Position);
            }
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == -1)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    MenuStripDelete.Show(Cursor.Position);

                }
            }
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    flowLayoutPanel1.Location = new Point(Cursor.Position.X, Cursor.Position.Y - 50);
                    //flowLayoutPanel1.Show();
                    flowLayoutPanel1.Visible = true;

                }
            }

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MenuStripActualBOM.Show(Cursor.Position);
            }
        }
        private void itmCopyAllToActualBOM_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("All data from Planned BOM will copy to Actual BOM... Sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _dtActualBOM = new DataTable();
                _dtActualBOM = _dtDesignBOM.Copy();

                //dataGridView2.DataSource =dataGridView1.DataSource;
                dataGridView3.DataSource = _dtActualBOM;
                tabControl1.SelectedTab = tabActualBOM;
                IsGridView3Changed = true;
            }
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Save?", "Confirmation", MessageBoxButtons.YesNo);
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

            List<BOM> LstObjBom;
            if (IsGridView1Changed == true)
            {
                LstObjBom = FillBOMModel1(ref projModel);
                _bc = new BOMController(LstObjBom);
                _bc.SaveList(projModel.ProjectCode, 1);
                IsGridView1Changed = false;
            }
            //---
            if (IsGridView2Changed == true)
            {
                LstObjBom = FillBOMModel2(ref projModel);
                _bc = new BOMController(LstObjBom);
                _bc.SaveList(projModel.ProjectCode, 2);
                IsGridView2Changed = false;
            }
            //---
            if (IsGridView3Changed == true)
            {
                LstObjBom = FillBOMModel3(ref projModel);
                _bc = new BOMController(LstObjBom);
                _bc.SaveList(projModel.ProjectCode, 3);
                IsGridView3Changed = false;
            }
            //Project proj = _LstProjects.Where(x => x.ProjectCode == projModel.ProjectCode).FirstOrDefault();

            //if (proj == null)
            //{
            //    _LstProjects.Add(projModel);
            //}
            //else
            //{
            //    _LstProjects.Remove(proj);
            //    _LstProjects.Add(projModel);
            //}


            //_LstProjects
            this.Enabled = true;

            //////////////update shared object///////////////////

            _pc = new ProjectController();
            CurrentOpenProject.CurrentProject = _pc.GetModelByID(projModel.ProjectCode);
            ////////////
            MessageBox.Show("Data Saved Successfully");
            this.Close();
        }

        private List<BOM> FillBOMModel1(ref Project pProjectModel)
        {
            List<BOM> LstObjBom = new List<BOM>();
            foreach (DataGridViewRow gvr in dataGridView1.Rows)
            {
                FillBOMModelSub(ref pProjectModel, ref LstObjBom, gvr, 1);
            }
            return LstObjBom;

        }

        private List<BOM> FillBOMModel2(ref Project pProjectModel)
        {
            List<BOM> LstObjBom = new List<BOM>();
            foreach (DataGridViewRow gvr in dataGridView2.Rows)
            {
                FillBOMModelSub(ref pProjectModel, ref LstObjBom, gvr, 2);
            }
            return LstObjBom;

        }
        private List<BOM> FillBOMModel3(ref Project pProjectModel)
        {
            List<BOM> LstObjBom = new List<BOM>();
            foreach (DataGridViewRow gvr in dataGridView3.Rows)
            {
                FillBOMModelSub(ref pProjectModel, ref LstObjBom, gvr, 3);
            }
            return LstObjBom;

        }
        //int cntr = -1;
        private void FillBOMModelSub(ref Project pProjectModel, ref List<BOM> pLstObjBom, DataGridViewRow pGvr, short pBOMTypeCode)
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
                BOM lObjBom = new BOM();
                //lObjBom.BOMCode = (string)pGvr.Cells[0].Value;
                lObjBom.BOMTypeCode = pBOMTypeCode;//(string)pGvr.Cells[0].Value;
                lObjBom.ProjectCode = pProjectModel.ProjectCode;

                //for (int i = 0; i < 18; i++)
                //{
                //    MessageBox.Show(dataGridView1.Columns[i].Name);
                //}
                //cntr += 1;
                //MessageBox.Show(dataGridView1.Columns[cntr].Name);
                //string columnName = dataGridView1.Columns[cntr].Name;
                var cellObj = pGvr.Cells["Category1_" + pBOMTypeCode];
                lObjBom.Category1 = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Category2_" + pBOMTypeCode];
                lObjBom.Category2 = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Category3_" + pBOMTypeCode];
                lObjBom.Category3 = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["SORef" + pBOMTypeCode];
                lObjBom.SORef = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Sr" + pBOMTypeCode];
                lObjBom.Sr = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["ProductCategory" + pBOMTypeCode];
                lObjBom.ProductCategory = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Product" + pBOMTypeCode];
                lObjBom.Product = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["CostHead" + pBOMTypeCode];
                lObjBom.CostHead = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["CostSubHead" + pBOMTypeCode];
                lObjBom.CostSubHead = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["System" + pBOMTypeCode];
                lObjBom.System = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Area" + pBOMTypeCode];
                lObjBom.Area = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Panel" + pBOMTypeCode];
                lObjBom.Panel = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Category" + pBOMTypeCode];
                lObjBom.Category = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Manufacturer" + pBOMTypeCode];
                lObjBom.Manufacturer = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

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

                cellObj = pGvr.Cells["Column1_" + pBOMTypeCode];
                lObjBom.Column1 = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Column2_" + pBOMTypeCode];
                lObjBom.Column2 = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Column3_" + pBOMTypeCode];
                lObjBom.Column3 = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Column4_" + pBOMTypeCode];
                lObjBom.Column4 = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

                cellObj = pGvr.Cells["Column5_" + pBOMTypeCode];
                lObjBom.Column5 = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();






                pLstObjBom.Add(lObjBom);
                pProjectModel.BOMs.Add(lObjBom);

            }

            //return null;
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
            if (_dtSalesBOM != null) _dtSalesBOM.Rows.Clear();
            if (_dtDesignBOM != null) _dtDesignBOM.Rows.Clear();
            if (_dtActualBOM != null) _dtActualBOM.Rows.Clear();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmBOM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (StaticClasses.NewProjectOpened.ClosePreviousProjectFormsWithOutConfirmation == true) return;
            DialogResult dialogResult = MessageBox.Show("Close this window?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) e.Cancel = true;
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            IsGridView1Changed = true;
        }
        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            IsGridView2Changed = true;
            decimal quantity = ReturnAppropriateValue(dataGridView2.Rows[e.RowIndex].Cells["Qty2"].Value);
            decimal rate = ReturnAppropriateValue(dataGridView2.Rows[e.RowIndex].Cells["UnitCost2"].Value);

            //if (decimal.TryParse(dataGridView2.Rows[e.RowIndex].Cells["Qty"].Value.ToString(), out quantity) && decimal.TryParse(dataGridView2.Rows[e.RowIndex].Cells["UnitCost"].Value.ToString(), out rate))
            //{
            decimal price = quantity * rate;
            //dataGridView2.Rows[e.RowIndex].Cells[15].Value = price.ToString();
            dataGridView2.Rows[e.RowIndex].Cells["ExtCost2"].Value = price.ToString();

            //}
        }
        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Sr2" ||
                dataGridView2.Columns[e.ColumnIndex].Name == "Qty2" ||
                dataGridView2.Columns[e.ColumnIndex].Name == "UnitCost2" ||
                dataGridView2.Columns[e.ColumnIndex].Name == "UnitPrice2" ||
                dataGridView2.Columns[e.ColumnIndex].Name == "ExtPrice2")
            {
                decimal parsedValue;
                if (!String.IsNullOrEmpty(e.FormattedValue.ToString()) && decimal.TryParse(e.FormattedValue.ToString(), out parsedValue) == false)
                {
                    MessageBox.Show("Only numeric values are allowed");
                    e.Cancel = true;
                }
            }
        }
        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            IsGridView3Changed = true;
            decimal quantity = ReturnAppropriateValue(dataGridView3.Rows[e.RowIndex].Cells["Qty3"].Value);
            decimal rate = ReturnAppropriateValue(dataGridView3.Rows[e.RowIndex].Cells["UnitCost3"].Value);

            decimal price = quantity * rate;
            dataGridView3.Rows[e.RowIndex].Cells["ExtCost3"].Value = price.ToString();

        }
        private void dataGridView3_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex].Name == "Sr3" ||
            dataGridView3.Columns[e.ColumnIndex].Name == "Qty3" ||
            dataGridView3.Columns[e.ColumnIndex].Name == "UnitCost3" ||
            dataGridView3.Columns[e.ColumnIndex].Name == "UnitPrice3" ||
            dataGridView3.Columns[e.ColumnIndex].Name == "ExtPrice3")
            {
                decimal parsedValue;
                if (!String.IsNullOrEmpty(e.FormattedValue.ToString()) && decimal.TryParse(e.FormattedValue.ToString(), out parsedValue) == false)
                {
                    MessageBox.Show("Only numeric values are allowed");
                    e.Cancel = true;
                }
            }
        }

        private decimal ReturnAppropriateValue(object ObjValue)
        {
            //lObjBom.PartNo = (cellObj.Value == null) ? string.Empty : cellObj.Value.ToString();

            //decimal decimalValue = Convert.ToDecimal(string.IsNullOrEmpty(ObjValue.ToString()) ? "0" : ObjValue);

            if (ObjValue == null || ObjValue == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(ObjValue);
            }

            //decimal decimalValue = Convert.ToDecimal((ObjValue == null) ? "0" : ObjValue);

            //return decimalValue;

            //if (decimal.TryParse(ObjValue.ToString(), out returnDecimalValue))

            //if (Convert.ToDecimal(string.IsNullOrEmpty(ObjValue.ToString()) ? "0" : ObjValue))
            //{
            //    return returnDecimalValue;
            //}
            //else
            //{
            //    return 0;
            //}
        }

        private void FrmBOM_Activated(object sender, EventArgs e)
        {
            txtBOMFilePath.Focus();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

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

        private void copyFromExcelToSaleBOMToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PasteFromExcel(ref _dtSalesBOM, 1);
        }
        private void copyFromExcelToDesignBOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteFromExcel(ref _dtDesignBOM, 2);
        }
        private void copyFromExcelToActualBOM_Click(object sender, EventArgs e)
        {
            PasteFromExcel(ref _dtActualBOM, 3);
        }

        private void PasteFromExcel(ref DataTable dtRef, int gridviewNumber)
        {

            string excelData = Clipboard.GetText();
            List<string> Rows = excelData.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList<string>();

            //mytab.Split(new[] { "\r\n" }, StringSplitOptions.None);
            //string[] lines = excelData.Replace("\n", "").Split('\r');
            //string[] lines = Regex.Split(s.TrimEnd("\r\n".ToCharArray()), "\r\n");
            string[] fields;


            int rowCounter = 0;
            bool IsCopyData = true;
            foreach (string row in Rows.ToList<string>())
            {
                rowCounter += 1;
                fields = row.Split('\t');

                if (fields.Count() == 1 && fields[0] == string.Empty)
                {
                    Rows.Remove(row);
                    continue;

                }

                if (fields.Count() < 18)
                {
                    MessageBox.Show("Data not copied. Please remove 'enter' after '" + fields.Last() + "' in column " + _columnNames[fields.Count() - 1] + " from Row number " + rowCounter);
                    IsCopyData = false;
                    break;
                }
            }
            if (IsCopyData == false) return;
            foreach (string row in Rows)
            {
                fields = row.Split('\t');
                DataRow newRow = dtRef.NewRow();
                newRow["Category1"] = fields[0];
                newRow["Category2"] = fields[1];
                newRow["Category3"] = fields[2];
                newRow["SORef"] = fields[3];
                newRow["Sr"] = fields[4];
                newRow["ProductCategory"] = fields[5];
                newRow["Product"] = fields[6];
                newRow["CostHead"] = fields[7];
                newRow["CostSubHead"] = fields[8];
                newRow["System"] = fields[9];
                newRow["Area"] = fields[10];
                newRow["Panel"] = fields[11];
                newRow["Category"] = fields[12];
                newRow["Manufacturer"] = fields[13];
                newRow["PartNo"] = fields[14];
                newRow["Description"] = fields[15];
                newRow["Qty"] = fields[16];
                newRow["UnitCost"] = fields[17];
                newRow["ExtCost"] = fields[18];
                newRow["UnitPrice"] = fields[19];
                newRow["ExtPrice"] = fields[20];
                newRow["Column1"] = fields[21];
                newRow["Column2"] = fields[22];
                newRow["Column3"] = fields[23];
                newRow["Column4"] = fields[24];
                newRow["Column5"] = fields[25];


                dtRef.Rows.Add(newRow);

            }
            switch (gridviewNumber)
            {
                case 1:
                    dataGridView1.DataSource = dtRef;
                    IsGridView1Changed = true;
                    break;
                case 2:
                    dataGridView2.DataSource = dtRef;
                    IsGridView2Changed = true;
                    break;
                case 3:
                    dataGridView3.DataSource = dtRef;
                    IsGridView3Changed = true;
                    break;
            }


            //foreach (string stringRow in stringRows)
            //{
            //    dtRef.Rows.Add(new DataRow(stringRow));
            //}


            //DataRow newRow = dtRef.NewRow();
            //newRow["Sr"] = gvr.Cells["Sr2"].Value;
            //newRow["PartNo"] = gvr.Cells["PartNo2"].Value;
            //newRow["Description"] = gvr.Cells["Description2"].Value;
            //newRow["Qty"] = gvr.Cells["Qty2"].Value;
            //newRow["UnitCost"] = gvr.Cells["UnitCost2"].Value;
            //newRow["ExtCost"] = gvr.Cells["ExtCost2"].Value;
            //newRow["UnitPrice"] = gvr.Cells["UnitPrice2"].Value;
            //newRow["ExtPrice"] = gvr.Cells["ExtPrice2"].Value;
            //dtMR.Rows.Add(newRow);










            //dtRef.Rows.Add(myRows.Count - 1);
            //string[] fields;
            //int row = 0;
            //int col = 0;

            //foreach (string item in myRows)
            //{
            //    fields = item.Split('\t');
            //    foreach (string f in fields)
            //    {
            //        //Console.WriteLine(f);
            //        dtRef[col, row].Value = f;
            //        col++;
            //    }
            //    row++;
            //    col = 0;
            //}
        }

        private void pasteMe_Click(object sender, EventArgs e)
        {
            string s = Clipboard.GetText();

            string[] lines = s.Replace("\n", "").Split('\r');

            dataGridView2.Rows.Add(lines.Length - 1);
            string[] fields;
            int row = 0;
            int col = 0;

            foreach (string item in lines)
            {
                fields = item.Split('\t');
                foreach (string f in fields)
                {
                    Console.WriteLine(f);
                    dataGridView2[col, row].Value = f;
                    col++;
                }
                row++;
                col = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
        }
        #region "Show Hide Columns"
        private void cbArea_CheckedChanged(object sender, EventArgs e)
        {
            if (cbArea.Checked == true)
            {
                Area1.Visible = true;
                Area2.Visible = true;
                Area3.Visible = true;
            }
            else
            {
                Area1.Visible = false;
                Area2.Visible = false;
                Area3.Visible = false;

            }
        }

        private void cbCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCategory.Checked == true)
            {
                Category1.Visible = true;
                Category2.Visible = true;
                Category3.Visible = true;
            }
            else
            {
                Category1.Visible = false;
                Category2.Visible = false;
                Category3.Visible = false;

            }
        }

        private void cbCategory1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCategory1.Checked == true)
            {
                Category1_1.Visible = true;
                Category1_2.Visible = true;
                Category1_3.Visible = true;
            }
            else
            {
                Category1_1.Visible = false;
                Category1_2.Visible = false;
                Category1_3.Visible = false;

            }
        }

        private void cbCategory2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCategory2.Checked == true)
            {
                Category2_1.Visible = true;
                Category2_2.Visible = true;
                Category2_3.Visible = true;
            }
            else
            {
                Category2_1.Visible = false;
                Category2_2.Visible = false;
                Category2_3.Visible = false;

            }
        }

        private void cbCategory3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCategory3.Checked == true)
            {
                Category3_1.Visible = true;
                Category3_2.Visible = true;
                Category3_3.Visible = true;
            }
            else
            {
                Category3_1.Visible = false;
                Category3_2.Visible = false;
                Category3_3.Visible = false;

            }
        }

        private void cbColumn1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbColumn1.Checked == true)
            {
                Column1_1.Visible = true;
                Column1_2.Visible = true;
                Column1_3.Visible = true;
            }
            else
            {
                Column1_1.Visible = false;
                Column1_2.Visible = false;
                Column1_3.Visible = false;

            }
        }

        private void cbColumn2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbColumn2.Checked == true)
            {
                Column2_1.Visible = true;
                Column2_2.Visible = true;
                Column2_3.Visible = true;
            }
            else
            {
                Column2_1.Visible = false;
                Column2_2.Visible = false;
                Column2_3.Visible = false;

            }
        }

        private void cbColumn3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbColumn3.Checked == true)
            {
                Column3_1.Visible = true;
                Column3_2.Visible = true;
                Column3_3.Visible = true;
            }
            else
            {
                Column3_1.Visible = false;
                Column3_2.Visible = false;
                Column3_3.Visible = false;

            }
        }

        private void cbColumn4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbColumn4.Checked == true)
            {
                Column4_1.Visible = true;
                Column4_2.Visible = true;
                Column4_3.Visible = true;
            }
            else
            {
                Column4_1.Visible = false;
                Column4_2.Visible = false;
                Column4_3.Visible = false;

            }
        }

        private void cbColumn5_CheckedChanged(object sender, EventArgs e)
        {
            if (cbColumn5.Checked == true)
            {
                Column5_1.Visible = true;
                Column5_2.Visible = true;
                Column5_3.Visible = true;
            }
            else
            {
                Column5_1.Visible = false;
                Column5_2.Visible = false;
                Column5_3.Visible = false;

            }
        }

        private void cbCostHead_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCostHead.Checked == true)
            {
                CostHead1.Visible = true;
                CostHead2.Visible = true;
                CostHead3.Visible = true;
            }
            else
            {
                CostHead1.Visible = false;
                CostHead2.Visible = false;
                CostHead3.Visible = false;

            }
        }

        private void cbCostSubHead_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCostSubHead.Checked == true)
            {
                CostSubHead1.Visible = true;
                CostSubHead2.Visible = true;
                CostSubHead3.Visible = true;
            }
            else
            {
                CostSubHead1.Visible = false;
                CostSubHead2.Visible = false;
                CostSubHead3.Visible = false;

            }
        }

        private void cbDescription_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDescription.Checked == true)
            {
                Description1.Visible = true;
                Description2.Visible = true;
                Description3.Visible = true;
            }
            else
            {
                Description1.Visible = false;
                Description2.Visible = false;
                Description3.Visible = false;

            }
        }

        private void cbExtCost_CheckedChanged(object sender, EventArgs e)
        {
            if (cbExtCost.Checked == true)
            {
                ExtCost1.Visible = true;
                ExtCost2.Visible = true;
                ExtCost3.Visible = true;
            }
            else
            {
                ExtCost1.Visible = false;
                ExtCost2.Visible = false;
                ExtCost3.Visible = false;

            }
        }

        private void cbExtPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (cbExtPrice.Checked == true)
            {
                ExtPrice1.Visible = true;
                ExtPrice2.Visible = true;
                ExtPrice3.Visible = true;
            }
            else
            {
                ExtPrice1.Visible = false;
                ExtPrice2.Visible = false;
                ExtPrice3.Visible = false;

            }
        }

        private void cbManufacturer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbManufacturer.Checked == true)
            {
                Manufacturer1.Visible = true;
                Manufacturer2.Visible = true;
                Manufacturer3.Visible = true;
            }
            else
            {
                Manufacturer1.Visible = false;
                Manufacturer2.Visible = false;
                Manufacturer3.Visible = false;

            }
        }

        private void cbPanel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPanel.Checked == true)
            {
                Panel1.Visible = true;
                Panel2.Visible = true;
                Panel3.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;

            }
        }

        private void cbPartNo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPartNo.Checked == true)
            {
                PartNo1.Visible = true;
                PartNo2.Visible = true;
                PartNo3.Visible = true;
            }
            else
            {
                PartNo1.Visible = false;
                PartNo2.Visible = false;
                PartNo3.Visible = false;

            }
        }

        private void cbProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProduct.Checked == true)
            {
                Product1.Visible = true;
                Product2.Visible = true;
                Product3.Visible = true;
            }
            else
            {
                Product1.Visible = false;
                Product2.Visible = false;
                Product3.Visible = false;

            }
        }

        private void cbProductCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProductCategory.Checked == true)
            {
                ProductCategory1.Visible = true;
                ProductCategory2.Visible = true;
                ProductCategory3.Visible = true;
            }
            else
            {
                ProductCategory1.Visible = false;
                ProductCategory2.Visible = false;
                ProductCategory3.Visible = false;

            }
        }

        private void cbQty_CheckedChanged(object sender, EventArgs e)
        {
            if (cbQty.Checked == true)
            {
                Qty1.Visible = true;
                Qty2.Visible = true;
                Qty3.Visible = true;
            }
            else
            {
                Qty1.Visible = false;
                Qty2.Visible = false;
                Qty3.Visible = false;

            }
        }

        private void cbSORef_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSORef.Checked == true)
            {
                SORef1.Visible = true;
                SORef2.Visible = true;
                SORef3.Visible = true;
            }
            else
            {
                SORef1.Visible = false;
                SORef2.Visible = false;
                SORef3.Visible = false;

            }
        }

        private void cbSr_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSr.Checked == true)
            {
                Sr1.Visible = true;
                Sr2.Visible = true;
                Sr3.Visible = true;
            }
            else
            {
                Sr1.Visible = false;
                Sr2.Visible = false;
                Sr3.Visible = false;

            }
        }

        private void cbSystem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSystem.Checked == true)
            {
                System1.Visible = true;
                System2.Visible = true;
                System3.Visible = true;
            }
            else
            {
                System1.Visible = false;
                System2.Visible = false;
                System3.Visible = false;

            }
        }

        private void cbUnitCost_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnitCost.Checked == true)
            {
                UnitCost1.Visible = true;
                UnitCost2.Visible = true;
                UnitCost3.Visible = true;
            }
            else
            {
                UnitCost1.Visible = false;
                UnitCost2.Visible = false;
                UnitCost3.Visible = false;

            }
        }

        private void cbUnitPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnitPrice.Checked == true)
            {
                UnitPrice1.Visible = true;
                UnitPrice2.Visible = true;
                UnitPrice3.Visible = true;
            }
            else
            {
                UnitPrice1.Visible = false;
                UnitPrice2.Visible = false;
                UnitPrice3.Visible = false;

            }
        }

        #endregion "Show Hide Columns"

        //private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    if (showDeleteConfirmation == true)
        //    {
        //        DialogResult dialogResult = MessageBox.Show("Do you want to delete row(s)?", "Confirmation", MessageBoxButtons.YesNo);
        //        if (dialogResult == DialogResult.No)
        //        {
        //            e.Cancel = true;
        //            answervalue = true;
        //            showDeleteConfirmation = false;

        //        }

        //    }
        //    else
        //    {
        //        e.Cancel = answervalue;
        //    }

        //}
        //bool answervalue = false;
        //bool showDeleteConfirmation = true;
        private void itemDeleteProject_Click(object sender, EventArgs e)
        {
            //showDeleteConfirmation = false;
            DialogResult dialogResult = MessageBox.Show("Do you want to delete row(s)?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            if (tabControl1.SelectedTab == tabControl1.TabPages["tabSaleBOM"])
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabDesignBOM"])
            {
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    dataGridView2.Rows.RemoveAt(row.Index);
                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabActualBOM"])
            {
                foreach (DataGridViewRow row in dataGridView3.SelectedRows)
                {
                    dataGridView3.Rows.RemoveAt(row.Index);
                }
            }

            //showDeleteConfirmation = true;
        }



        //private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex > -1)
        //    {
        //        IsGridView1Changed = true;
        //    }


        //}

        //private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex > -1)
        //    {
        //        IsGridView2Changed = true;
        //    }

        //}

        //private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex > -1)
        //    {
        //        IsGridView3Changed = true;
        //    }

        //}
        private void LoadExcelOldMethod()
        {
            try
            {
                OpenFileDialog dlg_im = new OpenFileDialog();
                dlg_im.Filter = "Excel File|*.xls;*.xlsx;*.xlsm";
                //dlg_im.Filter = "Excel File|*.xlsx";

                if (dlg_im.ShowDialog() == DialogResult.OK)
                {
                    //dataGridView1.Rows.Clear();
                    txtBOMFilePath.Text = dlg_im.FileName;


                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtBOMFilePath.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                    OleDbConnection Con = new OleDbConnection(constr);

                    Con.Open();

                    // Get the name of the first worksheet:
                    DataTable dbSchema = Con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dbSchema == null || dbSchema.Rows.Count < 1)
                    {
                        throw new Exception("Error: Could not determine the name of the first worksheet.");
                    }

                    //foreach (DataRow item in dbSchema.Rows)
                    //{
                    //    listBoxWorkSheets.Items.Add(item["TABLE_NAME"].ToString());
                    //}

                    //return;

                    string firstSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();

                    //firstSheetName = "BOM$";

                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + firstSheetName + "]", Con);



                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    DataTable dtTemp = new DataTable();

                    sda.Fill(dtTemp);
                    Con.Close();

                    //DataRow newDataRow;
                    //////////////////////////////////////////////////////////////
                    //if (!(tabControl1.SelectedTab == tabControl1.TabPages["tabSaleBOM"]))
                    //if (tabControl1.SelectedTab == tabControl1.TabPages["tabDesignBOM"])
                    //{
                    //    DataColumn Col = dtTemp.Columns.Add("Select2", System.Type.GetType("System.Boolean"));
                    //    //Col.SetOrdinal(0);// to put the column in position 0;

                    //}
                    DataTable dtBOM = new DataTable("dtBOM");
                    //dtBOM = dtTemp.Clone();
                    dtBOM.Columns.Add(_columnNames[0], typeof(string));
                    dtBOM.Columns.Add(_columnNames[1], typeof(string));
                    dtBOM.Columns.Add(_columnNames[2], typeof(string));
                    dtBOM.Columns.Add(_columnNames[3], typeof(string));
                    dtBOM.Columns.Add(_columnNames[4], typeof(decimal));
                    dtBOM.Columns.Add(_columnNames[5], typeof(string));
                    dtBOM.Columns.Add(_columnNames[6], typeof(string));
                    dtBOM.Columns.Add(_columnNames[7], typeof(string));
                    dtBOM.Columns.Add(_columnNames[8], typeof(string));
                    dtBOM.Columns.Add(_columnNames[9], typeof(string));
                    dtBOM.Columns.Add(_columnNames[10], typeof(string));
                    dtBOM.Columns.Add(_columnNames[11], typeof(string));
                    dtBOM.Columns.Add(_columnNames[12], typeof(string));
                    dtBOM.Columns.Add(_columnNames[13], typeof(string));
                    dtBOM.Columns.Add(_columnNames[14], typeof(string));
                    dtBOM.Columns.Add(_columnNames[15], typeof(string));
                    dtBOM.Columns.Add(_columnNames[16], typeof(decimal));
                    dtBOM.Columns.Add(_columnNames[17], typeof(decimal));
                    dtBOM.Columns.Add(_columnNames[18], typeof(decimal));
                    dtBOM.Columns.Add(_columnNames[19], typeof(decimal));
                    dtBOM.Columns.Add(_columnNames[20], typeof(decimal));
                    dtBOM.Columns.Add(_columnNames[21], typeof(string));
                    dtBOM.Columns.Add(_columnNames[22], typeof(string));
                    dtBOM.Columns.Add(_columnNames[23], typeof(string));
                    dtBOM.Columns.Add(_columnNames[24], typeof(string));
                    dtBOM.Columns.Add(_columnNames[25], typeof(string));

                    dataGridView1.AutoGenerateColumns = false;

                    //}
                    //for (int j = 0; j < dtBOM.Columns.Count; j++)
                    //{
                    //    MessageBox.Show(dtBOM.Columns[j].ColumnName +"----" + dtBOM.Columns[j].DataType.Name.ToString());
                    //}
                    foreach (DataRow dr in dtTemp.Rows)
                    {
                        //string colName=gvr.Cells[0].OwningColumn.HeaderText;

                        bool isAdd = false;
                        for (int i = 0; i < dtTemp.Columns.Count; i++)
                        {
                            //if (dr[i] == null || dr[i] == DBNull.Value || String.IsNullOrWhiteSpace(dr[i].ToString()))
                            if (dr[i] == DBNull.Value)
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
                            //can not add like this dtBOM.Rows.Add(dr); :(  have to add new row and then add to list
                            //newDataRow = dtBOM.NewRow();
                            //for (int i = 0; i <  dtTemp.Columns.Count; i++)
                            //{
                            //    newDataRow[i] = dr[i];

                            //}
                            //dtBOM.Rows.Add(newDataRow);

                            dtBOM.Rows.Add(dr.ItemArray);
                        }

                    }
                    if (tabControl1.SelectedTab == tabControl1.TabPages["tabSaleBOM"])
                    {
                        _dtSalesBOM = dtBOM;
                        dataGridView1.DataSource = _dtSalesBOM;
                    }
                    if (tabControl1.SelectedTab == tabControl1.TabPages["tabDesignBOM"])
                    {
                        _dtDesignBOM = dtBOM;
                        dataGridView2.DataSource = _dtDesignBOM;
                    }
                    if (tabControl1.SelectedTab == tabControl1.TabPages["tabActualBOM"])
                    {
                        _dtActualBOM = dtBOM;
                        dataGridView3.DataSource = _dtActualBOM;
                    }




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}