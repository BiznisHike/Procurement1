﻿using System;
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
            try
            {

                if (LoginInfo.LoginEmployee.EmployeeTypeCode == Constants.EMPLOYEE)
                {

                    btnLoadBOM.Enabled = false;
                }

                ClearAll();

                _currentLoadedProject = CurrentOpenProject.CurrentProject;
                _columnNames = new List<String> { "SORef",
                                                "Sr",
                                                "ProductCategory",
                                                "Product",
                                                "CostHead",
                                                "CostSubHead",
                                                "System",
                                                "Area",
                                                "Panel",
                                                "Category",
                                                "Manufacturer",
                                                "PartNo",
                                                "Description",
                                                "Qty",
                                                "UnitCost",
                                                "ExtCost",
                                                "UnitPrice",
                                                "ExtPrice",
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

                MessageBox.Show(ex.ToString());
            }
        }
        private void loadBOMToolStripMenuItem_Click(object sender, EventArgs e)
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
                    string firstSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();



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
                    dtBOM.Columns.Add(_columnNames[0]);
                    dtBOM.Columns.Add(_columnNames[1]);
                    dtBOM.Columns.Add(_columnNames[2]);
                    dtBOM.Columns.Add(_columnNames[3]);
                    dtBOM.Columns.Add(_columnNames[4]);
                    dtBOM.Columns.Add(_columnNames[5]);
                    dtBOM.Columns.Add(_columnNames[6]);
                    dtBOM.Columns.Add(_columnNames[7]);
                    dtBOM.Columns.Add(_columnNames[8]);
                    dtBOM.Columns.Add(_columnNames[9]);
                    dtBOM.Columns.Add(_columnNames[10]);
                    dtBOM.Columns.Add(_columnNames[11]);
                    dtBOM.Columns.Add(_columnNames[12]);
                    dtBOM.Columns.Add(_columnNames[13]);
                    dtBOM.Columns.Add(_columnNames[14]);
                    dtBOM.Columns.Add(_columnNames[15]);
                    dtBOM.Columns.Add(_columnNames[16]);
                    dtBOM.Columns.Add(_columnNames[17]);

                    dataGridView1.AutoGenerateColumns = false;

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
                MessageBox.Show(ex.ToString());
            }
        }

        private void loadChageOrderToolStripMenuItem_Click(object sender, EventArgs e)
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
                    string firstSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();



                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + firstSheetName + "]", Con);



                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    DataTable dtTemp = new DataTable();
                    sda.Fill(dtTemp);
                    Con.Close();

                    //////////////////////////////////////////////////////////////

                    //_dtSalesBOM = new DataTable();
                    //_dtSalesBOM = dtTemp.Clone();


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
                            //can not add like this _dtSalesBOM.Rows.Add(dr); :(  have to add new row and then add to list
                            //newDataRow = _dtSalesBOM.NewRow();
                            //for (int i = 0; i <  dtTemp.Columns.Count; i++)
                            //{
                            //    newDataRow[i] = dr[i];

                            //}
                            //_dtSalesBOM.Rows.Add(newDataRow);

                            //dtBOM.Rows.Add(dr.ItemArray);

                            if (tabControl1.SelectedTab == tabControl1.TabPages["tabSaleBOM"])
                            {
                                _dtSalesBOM.Rows.Add(dr.ItemArray);
                                //dataGridView1.DataSource = _dtSalesBOM;
                            }
                            if (tabControl1.SelectedTab == tabControl1.TabPages["tabDesignBOM"])
                            {
                                _dtDesignBOM.Rows.Add(dr.ItemArray);
                                //dataGridView2.DataSource = _dtDesignBOM;
                            }
                            if (tabControl1.SelectedTab == tabControl1.TabPages["tabActualBOM"])
                            {
                                _dtActualBOM.Rows.Add(dr.ItemArray);
                                //dataGridView3.DataSource = _dtActualBOM;
                            }

                        }

                    }
                    //dataGridView1.DataSource = _dtSalesBOM;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //mnuCopyAllToDesignBOM.ShowDropDown();
            //contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MenuStripSaleBOM.Show(Cursor.Position);
            }
        }

        private void itmCopyAllToDesignBOM_Click(object sender, EventArgs e)
        {
            _dtDesignBOM = new DataTable();
            _dtDesignBOM = _dtSalesBOM.Copy();

            //dataGridView2.DataSource =dataGridView1.DataSource;
            dataGridView2.DataSource = _dtDesignBOM;
            tabControl1.SelectedTab = tabDesignBOM;

        }
        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            //mnuCopyAllToDesignBOM.ShowDropDown();
            //contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MenuStripDesignBOM.Show(Cursor.Position);
            }
        }
        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MenuStripActualBOM.Show(Cursor.Position);
            }
        }
        private void itmCopyAllToActualBOM_Click(object sender, EventArgs e)
        {
            _dtActualBOM = new DataTable();
            _dtActualBOM = _dtDesignBOM.Copy();

            //dataGridView2.DataSource =dataGridView1.DataSource;
            dataGridView3.DataSource = _dtActualBOM;
            tabControl1.SelectedTab = tabActualBOM;
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
            LstObjBom = FillBOMModel1(ref projModel);
            _bc = new BOMController(LstObjBom);
            _bc.SaveList(projModel.ProjectCode, 1);
            //---
            LstObjBom = FillBOMModel2(ref projModel);
            _bc = new BOMController(LstObjBom);
            _bc.SaveList(projModel.ProjectCode, 2);
            //---
            LstObjBom = FillBOMModel3(ref projModel);
            _bc = new BOMController(LstObjBom);
            _bc.SaveList(projModel.ProjectCode, 3);

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
                var cellObj = pGvr.Cells["SORef" + pBOMTypeCode];
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




        private void dataGridViewProjects_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                MenuStripProjects.Show(Cursor.Position);
            }
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

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal quantity = ReturnAppropriateValue(dataGridView3.Rows[e.RowIndex].Cells["Qty3"].Value);
            decimal rate = ReturnAppropriateValue(dataGridView3.Rows[e.RowIndex].Cells["UnitCost3"].Value);

            decimal price = quantity * rate;
            dataGridView3.Rows[e.RowIndex].Cells["ExtCost3"].Value = price.ToString();

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
                newRow["SORef"] = fields[0];
                newRow["Sr"] = fields[1];
                newRow["ProductCategory"] = fields[2];
                newRow["Product"] = fields[3];
                newRow["CostHead"] = fields[4];
                newRow["CostSubHead"] = fields[5];
                newRow["System"] = fields[6];
                newRow["Area"] = fields[7];
                newRow["Panel"] = fields[8];
                newRow["Category"] = fields[9];
                newRow["Manufacturer"] = fields[10];
                newRow["PartNo"] = fields[11];
                newRow["Description"] = fields[12];
                newRow["Qty"] = fields[13];
                newRow["UnitCost"] = fields[14];
                newRow["ExtCost"] = fields[15];
                newRow["UnitPrice"] = fields[16];
                newRow["ExtPrice"] = fields[17];
                dtRef.Rows.Add(newRow);

            }
            switch (gridviewNumber)
            {
                case 1:
                    dataGridView1.DataSource = dtRef;
                    break;
                case 2:
                    dataGridView2.DataSource = dtRef;
                    break;
                case 3:
                    dataGridView3.DataSource = dtRef;
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


    }
}