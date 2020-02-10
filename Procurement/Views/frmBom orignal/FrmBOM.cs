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
    public partial class FrmBOM : Form
    {
        ProjectController _pc;
        BOMController _bc;
        List<Project> _LstProjects;
        ProjectEmployeeDetailController _pedc;
        DataTable _dtProjects;
        DataTable _dtSalesBOM;
        DataTable _dtDesignBOM;
        DataTable _dtActualBOM;
        decimal _projectCode;
        bool _newMode;
        Project _currentLoadedProject;

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
                    txtProjectName.Enabled = false;
                    txtProjectCustomerName.Enabled = false;
                    txtProjectEndUser.Enabled = false;

                    btnNewProject.Enabled = false;
                    btnLoadBOM.Enabled = false;
                }

                _pc = new ProjectController();
                _LstProjects = _pc.GetModels();
                //insert into the list

                //list.Where(x => x.BOMTypeCode == 1).Select(x => new
                //{
                //    x.SORef,
                //    x.Sr,
                //    x.ProductCategory,
                //    x.Product,
                //    x.CostHead,
                //    x.CostSubHead,
                //    x.System,
                //    x.Area,
                //    x.Panel,
                //    x.Category,
                //    x.Manufacturer,
                //    x.PartNo,
                //    x.Description,
                //    x.Qty,
                //    x.UnitCost,
                //    x.ExtCost,
                //    x.UnitPrice,
                //    x.ExtPrice
                //});


                _dtProjects = ToDataTable<Project>(_LstProjects);
                _dtProjects.Columns.Remove("BOMs");
                _dtProjects.Columns.Remove("ProjectEmployeeDetails");

                DataView dv = _dtProjects.DefaultView;
                dv.Sort = "ProjectCode desc";
                _dtProjects = dv.ToTable();

                dataGridViewProjects.DataSource = _dtProjects;

                if (_LstProjects.Count == 0)
                {

                    _newMode = true;
                    //_pc.ReseedProjectPk();
                    //txtProjectCode.Text = (1).ToString();
                    ClearAll();
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
                    DataTable dtBOM = new DataTable();
                    dtBOM = dtTemp.Clone();
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
        private void itmCopyAllToActualBOM_Click(object sender, EventArgs e)
        {
            _dtActualBOM = new DataTable();
            _dtActualBOM = _dtDesignBOM.Copy();

            //dataGridView2.DataSource =dataGridView1.DataSource;
            dataGridView3.DataSource = _dtActualBOM;
            tabControl1.SelectedTab = tabActualBOM;

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
                //------------------


                DataRow NewRow = _dtProjects.NewRow();
                NewRow[0] = projModel.ProjectCode;//decimal.Parse(txtProjectCode.Text);
                NewRow[1] = projModel.ProjectName;//txtProjectName.Text;
                NewRow[2] = projModel.Customer;//txtProjectCustomerName.Text;
                NewRow[3] = projModel.EndUser;//txtProjectEndUser.Text;

                _dtProjects.Rows.Add(NewRow);

                DataView dv = _dtProjects.DefaultView;
                dv.Sort = "ProjectCode desc";
                _dtProjects = dv.ToTable();

                dataGridViewProjects.DataSource = _dtProjects;
                _LstProjects.Add(projModel);

                //------------------

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
                Project proj = _LstProjects.Where(x => x.ProjectCode == projModel.ProjectCode).FirstOrDefault();
                _LstProjects.Remove(proj);
                _LstProjects.Add(projModel);

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


        }
        private void SaveToRepository()
        {







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
        int cntr = -1;
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
                cntr += 1;
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

        private void dataGridViewProjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProjects.SelectedCells.Count > 0 && dataGridViewProjects.SelectedCells[0].Value != DBNull.Value)
            {
                int selectedrowindex = dataGridViewProjects.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewProjects.Rows[selectedrowindex];
                _projectCode = Convert.ToDecimal(selectedRow.Cells["ProjectCode"].Value);
                //MessageBox.Show(a);
                if (!string.IsNullOrEmpty(txtProjectCode.Text) && _projectCode == decimal.Parse(txtProjectCode.Text)) return;

                _pc = new ProjectController();
                _currentLoadedProject = _pc.GetModelByID(_projectCode);
                if (_currentLoadedProject == null) return;
                txtProjectCode.Text = _currentLoadedProject.ProjectCode.ToString();
                txtProjectName.Text = _currentLoadedProject.ProjectName;
                txtProjectCustomerName.Text = _currentLoadedProject.Customer;
                txtProjectEndUser.Text = _currentLoadedProject.Customer;

                //var source1 = new BindingSource();
                //List<BOM> list = new List<BOM> { new MyStruct("fff", "b"), new MyStruct("c", "d") };
                if (_newMode == true)
                {
                    var a = "123";
                }
                if (_newMode == false)
                {
                    //List<BOM> allList = _bc.GetModels().Where(x => x.ProjectCode == _projectCode).ToList();
                    //List<BOM> list1 = allList.Where(x => x.BOMTypeCode == 1).ToList();

                    ////TO Handle just added. so that not loading agin and again.
                    //if (_LstProjects.Where(x => x.ProjectCode == _projectCode).FirstOrDefault() == null) 
                    //{
                    //    //ClearAll();
                    //    return;
                    //}

                    List<BOM> list1 = _LstProjects.Where(x => x.ProjectCode == _projectCode).FirstOrDefault().BOMs.Where(y => y.BOMTypeCode == 1).ToList();
                    _dtSalesBOM = ToDataTable<BOM>(list1);
                    //_dtSalesBOM.Columns.Remove("ProjectCode");
                    //_dtSalesBOM.Columns.Remove("RowAuto");
                    //_dtSalesBOM.Columns.Remove("BomTypeCode");
                    //_dtSalesBOM.Columns.Remove("BOMType");
                    //_dtSalesBOM.Columns.Remove("Project");
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = _dtSalesBOM;
                    //dataGridView1.DataBind();

                    //source1.DataSource = list.Where(x => x.BOMTypeCode == 1).Select(x => new
                    //{
                    //    x.SORef,
                    //    x.Sr,
                    //    x.ProductCategory,
                    //    x.Product,
                    //    x.CostHead,
                    //    x.CostSubHead,
                    //    x.System,
                    //    x.Area,
                    //    x.Panel,
                    //    x.Category,
                    //    x.Manufacturer,
                    //    x.PartNo,
                    //    x.Description,
                    //    x.Qty,
                    //    x.UnitCost,
                    //    x.ExtCost,
                    //    x.UnitPrice,
                    //    x.ExtPrice
                    //});
                    //dataGridView1.DataSource = source1;
                    //this.dataGridView1.AllowUserToAddRows = true;


                    //List<BOM> list2 = allList.Where(x => x.BOMTypeCode == 2).ToList();
                    List<BOM> list2 = _LstProjects.Where(x => x.ProjectCode == _projectCode).FirstOrDefault().BOMs.Where(y => y.BOMTypeCode == 2).ToList();
                    _dtDesignBOM = ToDataTable<BOM>(list2);
                    //_dtDesignBOM.Columns.Remove("ProjectCode");
                    //_dtDesignBOM.Columns.Remove("RowAuto");
                    //_dtDesignBOM.Columns.Remove("BomTypeCode");
                    //_dtDesignBOM.Columns.Remove("BOMType");
                    //_dtDesignBOM.Columns.Remove("Project");
                    dataGridView2.AutoGenerateColumns = false;
                    dataGridView2.DataSource = _dtDesignBOM;

                    //List<BOM> list3 = allList.Where(x => x.BOMTypeCode == 3).ToList();
                    List<BOM> list3 = _LstProjects.Where(x => x.ProjectCode == _projectCode).FirstOrDefault().BOMs.Where(y => y.BOMTypeCode == 3).ToList();
                    _dtActualBOM = ToDataTable<BOM>(list3);
                    //_dtActualBOM.Columns.Remove("ProjectCode");
                    //_dtActualBOM.Columns.Remove("RowAuto");
                    //_dtActualBOM.Columns.Remove("BomTypeCode");
                    //_dtActualBOM.Columns.Remove("BOMType");
                    //_dtActualBOM.Columns.Remove("Project");
                    dataGridView3.AutoGenerateColumns = false;
                    dataGridView3.DataSource = _dtActualBOM;
                }
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

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            txtProjectCode.Text = string.Empty;
            ClearAll();
            _newMode = true;
        }

        private void ClearAll()
        {
            if (_dtSalesBOM != null) _dtSalesBOM.Rows.Clear();
            if (_dtDesignBOM != null) _dtDesignBOM.Rows.Clear();
            if (_dtActualBOM != null) _dtActualBOM.Rows.Clear();

            //preReq

            //int maxId = db.Customers.DefaultIfEmpty().Max(p => p == null ? 0 : p.Id);
            decimal maxCode = _pc.GetMaxProjectCode();
            txtProjectCode.Text = maxCode.ToString();

            txtProjectName.Text = "New Project " + maxCode;
            txtProjectCustomerName.Text = "New Customer " + maxCode;
            txtProjectEndUser.Text = "New EndUser " + maxCode;
            txtBOMFilePath.Text = string.Empty;
            //_pc.GetModels
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (splitContainer1.SplitterDistance < 51)
            {
                splitContainer1.SplitterDistance = 400;
            }
            else
            {
                splitContainer1.SplitterDistance = 49;
            }


        }

        //private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        //{
        //    //mnuCopyAllToDesignBOM.ShowDropDown();
        //    //contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        //    if (e.Button == System.Windows.Forms.MouseButtons.Right)
        //    {
        //        MenuStripDesignBOM.Show(Cursor.Position);
        //    }
        //}
        //private void mnuCopyAllToActualBOM_Click(object sender, EventArgs e)
        //{
        //    DataTable dtActualBOM = new DataTable();
        //    dtActualBOM = _dtDesignBOM.Copy();

        //    //dataGridView2.DataSource =dataGridView1.DataSource;
        //    dataGridView3.DataSource = dtActualBOM;
        //    tabControl1.SelectedTab = tabActualBOM;

        //}
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
                        ClearAll();
                        _pc.ReseedPk();
                        _newMode = true;
                    }


                    //dataGridViewProjects.Refresh();
                }
            }
            else
            {
                ClearAll();
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
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabSaleBOM"])
            {
                //btnCopySame.Visible= false;
                //btnCopyUserSpecified.Visible = false;
                panel4.Visible = false;
                //dataGridView1.Size = new System.Drawing.Size(568, 1149);

                //tabControl1.Height = 491;//597;
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabDesignBOM"])
            {
                //btnCopySame.Visible = true ;
                //btnCopyUserSpecified.Visible = true;
                panel4.Visible = true;
                //tabControl1.Height = 239;//294;
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabActualBOM"])
            {
                //btnCopySame.Visible = false;
                //btnCopyUserSpecified.Visible = false;
                panel4.Visible = false;
                //dataGridView3.Size = new System.Drawing.Size(568, 1149);
                //tabControl1.Height = 491;
            }


















        }
    }
}