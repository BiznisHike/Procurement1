namespace Procurement
{
    partial class FrmEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmployee));
            this.btnSave = new System.Windows.Forms.Button();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.MenuStripSaleBOM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmCopyAllToDesignBOM = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripDesignBOM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmCopyAllToActualBOM = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnResize = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnNewEmployee = new System.Windows.Forms.Button();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewSelectProjects = new System.Windows.Forms.DataGridView();
            this.cmbManagers = new System.Windows.Forms.ComboBox();
            this.cmbEmployeeType = new System.Windows.Forms.ComboBox();
            this.lblManager = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.MenuStripProjects = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemDeleteProject = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.MenuStripSaleBOM.SuspendLayout();
            this.MenuStripDesignBOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectProjects)).BeginInit();
            this.MenuStripProjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(760, 593);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 32);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(174, 125);
            this.txtEmployeeName.Multiline = true;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(198, 30);
            this.txtEmployeeName.TabIndex = 14;
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(174, 63);
            this.txtEmployeeCode.Multiline = true;
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.ReadOnly = true;
            this.txtEmployeeCode.Size = new System.Drawing.Size(101, 30);
            this.txtEmployeeCode.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(689, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Project";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Employee Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Employee Code";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.ImageKey = "Yes.bmp";
            this.btnCancel.Location = new System.Drawing.Point(657, 594);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 30);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MenuStripSaleBOM
            // 
            this.MenuStripSaleBOM.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStripSaleBOM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmCopyAllToDesignBOM});
            this.MenuStripSaleBOM.Name = "contextMenuStrip1";
            this.MenuStripSaleBOM.Size = new System.Drawing.Size(240, 28);
            // 
            // itmCopyAllToDesignBOM
            // 
            this.itmCopyAllToDesignBOM.Name = "itmCopyAllToDesignBOM";
            this.itmCopyAllToDesignBOM.Size = new System.Drawing.Size(239, 24);
            this.itmCopyAllToDesignBOM.Text = "Copy All to Design BOM";
            // 
            // MenuStripDesignBOM
            // 
            this.MenuStripDesignBOM.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStripDesignBOM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmCopyAllToActualBOM});
            this.MenuStripDesignBOM.Name = "contextMenuStrip1";
            this.MenuStripDesignBOM.Size = new System.Drawing.Size(236, 28);
            // 
            // itmCopyAllToActualBOM
            // 
            this.itmCopyAllToActualBOM.Name = "itmCopyAllToActualBOM";
            this.itmCopyAllToActualBOM.Size = new System.Drawing.Size(235, 24);
            this.itmCopyAllToActualBOM.Text = "Copy All to Actual BOM";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnResize);
            this.splitContainer1.Panel1.Controls.Add(this.btnNewEmployee);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewEmployees);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnShowPassword);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.txtPassword);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewSelectProjects);
            this.splitContainer1.Panel2.Controls.Add(this.cmbManagers);
            this.splitContainer1.Panel2.Controls.Add(this.cmbEmployeeType);
            this.splitContainer1.Panel2.Controls.Add(this.lblManager);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.cmbProjects);
            this.splitContainer1.Panel2.Controls.Add(this.txtEmployeeCode);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txtEmployeeName);
            this.splitContainer1.Size = new System.Drawing.Size(1582, 853);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.TabIndex = 20;
            // 
            // btnResize
            // 
            this.btnResize.BackColor = System.Drawing.Color.White;
            this.btnResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResize.ForeColor = System.Drawing.Color.Transparent;
            this.btnResize.ImageKey = "Left-right.bmp";
            this.btnResize.ImageList = this.imageList1;
            this.btnResize.Location = new System.Drawing.Point(14, 6);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(40, 40);
            this.btnResize.TabIndex = 21;
            this.btnResize.UseVisualStyleBackColor = false;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "3d bar chart.bmp");
            this.imageList1.Images.SetKeyName(1, "Abort.bmp");
            this.imageList1.Images.SetKeyName(2, "About.bmp");
            this.imageList1.Images.SetKeyName(3, "Add.bmp");
            this.imageList1.Images.SetKeyName(4, "Anchor.bmp");
            this.imageList1.Images.SetKeyName(5, "Application.bmp");
            this.imageList1.Images.SetKeyName(6, "Apply.bmp");
            this.imageList1.Images.SetKeyName(7, "Back.bmp");
            this.imageList1.Images.SetKeyName(8, "Bad mark.bmp");
            this.imageList1.Images.SetKeyName(9, "Blue key.bmp");
            this.imageList1.Images.SetKeyName(10, "Blue tag.bmp");
            this.imageList1.Images.SetKeyName(11, "Boss.bmp");
            this.imageList1.Images.SetKeyName(12, "Bottom.bmp");
            this.imageList1.Images.SetKeyName(13, "Calculator.bmp");
            this.imageList1.Images.SetKeyName(14, "Calendar.bmp");
            this.imageList1.Images.SetKeyName(15, "Car key.bmp");
            this.imageList1.Images.SetKeyName(16, "CD.bmp");
            this.imageList1.Images.SetKeyName(17, "Clipboard.bmp");
            this.imageList1.Images.SetKeyName(18, "Clock.bmp");
            this.imageList1.Images.SetKeyName(19, "Close.bmp");
            this.imageList1.Images.SetKeyName(20, "Compass.bmp");
            this.imageList1.Images.SetKeyName(21, "Component.bmp");
            this.imageList1.Images.SetKeyName(22, "Copy.bmp");
            this.imageList1.Images.SetKeyName(23, "Create.bmp");
            this.imageList1.Images.SetKeyName(24, "Cut.bmp");
            this.imageList1.Images.SetKeyName(25, "Danger.bmp");
            this.imageList1.Images.SetKeyName(26, "Database.bmp");
            this.imageList1.Images.SetKeyName(27, "Delete.bmp");
            this.imageList1.Images.SetKeyName(28, "Delivery.bmp");
            this.imageList1.Images.SetKeyName(29, "Dial.bmp");
            this.imageList1.Images.SetKeyName(30, "Disaster.bmp");
            this.imageList1.Images.SetKeyName(31, "Dollar.bmp");
            this.imageList1.Images.SetKeyName(32, "Down.bmp");
            this.imageList1.Images.SetKeyName(33, "Download.bmp");
            this.imageList1.Images.SetKeyName(34, "Eject.bmp");
            this.imageList1.Images.SetKeyName(35, "E-mail.bmp");
            this.imageList1.Images.SetKeyName(36, "Erase.bmp");
            this.imageList1.Images.SetKeyName(37, "Error.bmp");
            this.imageList1.Images.SetKeyName(38, "Euro.bmp");
            this.imageList1.Images.SetKeyName(39, "Exit.bmp");
            this.imageList1.Images.SetKeyName(40, "Fall.bmp");
            this.imageList1.Images.SetKeyName(41, "Fast-forward.bmp");
            this.imageList1.Images.SetKeyName(42, "Favourites.bmp");
            this.imageList1.Images.SetKeyName(43, "Female.bmp");
            this.imageList1.Images.SetKeyName(44, "Filter.bmp");
            this.imageList1.Images.SetKeyName(45, "Find.bmp");
            this.imageList1.Images.SetKeyName(46, "First record.bmp");
            this.imageList1.Images.SetKeyName(47, "First.bmp");
            this.imageList1.Images.SetKeyName(48, "Flag.bmp");
            this.imageList1.Images.SetKeyName(49, "Folder.bmp");
            this.imageList1.Images.SetKeyName(50, "Forbidden.bmp");
            this.imageList1.Images.SetKeyName(51, "Forward.bmp");
            this.imageList1.Images.SetKeyName(52, "Free bsd.bmp");
            this.imageList1.Images.SetKeyName(53, "Go back.bmp");
            this.imageList1.Images.SetKeyName(54, "Go forward.bmp");
            this.imageList1.Images.SetKeyName(55, "Go.bmp");
            this.imageList1.Images.SetKeyName(56, "Good-mark.bmp");
            this.imageList1.Images.SetKeyName(57, "Green tag.bmp");
            this.imageList1.Images.SetKeyName(58, "Heart.bmp");
            this.imageList1.Images.SetKeyName(59, "Help book 3d.bmp");
            this.imageList1.Images.SetKeyName(60, "Help book.bmp");
            this.imageList1.Images.SetKeyName(61, "Help.bmp");
            this.imageList1.Images.SetKeyName(62, "Hint.bmp");
            this.imageList1.Images.SetKeyName(63, "Home.bmp");
            this.imageList1.Images.SetKeyName(64, "How-to.bmp");
            this.imageList1.Images.SetKeyName(65, "Hungup.bmp");
            this.imageList1.Images.SetKeyName(66, "Info.bmp");
            this.imageList1.Images.SetKeyName(67, "Key.bmp");
            this.imageList1.Images.SetKeyName(68, "Last recor.bmp");
            this.imageList1.Images.SetKeyName(69, "Last.bmp");
            this.imageList1.Images.SetKeyName(70, "Left-right.bmp");
            this.imageList1.Images.SetKeyName(71, "Lightning.bmp");
            this.imageList1.Images.SetKeyName(72, "Linux.bmp");
            this.imageList1.Images.SetKeyName(73, "List.bmp");
            this.imageList1.Images.SetKeyName(74, "Load.bmp");
            this.imageList1.Images.SetKeyName(75, "Lock.bmp");
            this.imageList1.Images.SetKeyName(76, "Low rating.bmp");
            this.imageList1.Images.SetKeyName(77, "Mail.bmp");
            this.imageList1.Images.SetKeyName(78, "Male.bmp");
            this.imageList1.Images.SetKeyName(79, "Medium rating.bmp");
            this.imageList1.Images.SetKeyName(80, "Message.bmp");
            this.imageList1.Images.SetKeyName(81, "Mobile-phone.bmp");
            this.imageList1.Images.SetKeyName(82, "Modify.bmp");
            this.imageList1.Images.SetKeyName(83, "Movie.bmp");
            this.imageList1.Images.SetKeyName(84, "Music.bmp");
            this.imageList1.Images.SetKeyName(85, "New document.bmp");
            this.imageList1.Images.SetKeyName(86, "New.bmp");
            this.imageList1.Images.SetKeyName(87, "Next track.bmp");
            this.imageList1.Images.SetKeyName(88, "Next.bmp");
            this.imageList1.Images.SetKeyName(89, "No.bmp");
            this.imageList1.Images.SetKeyName(90, "No-entry.bmp");
            this.imageList1.Images.SetKeyName(91, "Notes.bmp");
            this.imageList1.Images.SetKeyName(92, "OK.bmp");
            this.imageList1.Images.SetKeyName(93, "Paste.bmp");
            this.imageList1.Images.SetKeyName(94, "Pause.bmp");
            this.imageList1.Images.SetKeyName(95, "People.bmp");
            this.imageList1.Images.SetKeyName(96, "Person.bmp");
            this.imageList1.Images.SetKeyName(97, "Phone number.bmp");
            this.imageList1.Images.SetKeyName(98, "Pie chart.bmp");
            this.imageList1.Images.SetKeyName(99, "Pinion.bmp");
            this.imageList1.Images.SetKeyName(100, "Play.bmp");
            this.imageList1.Images.SetKeyName(101, "Playback.bmp");
            this.imageList1.Images.SetKeyName(102, "Play-music.bmp");
            this.imageList1.Images.SetKeyName(103, "Previous record.bmp");
            this.imageList1.Images.SetKeyName(104, "Previous.bmp");
            this.imageList1.Images.SetKeyName(105, "Problem.bmp");
            this.imageList1.Images.SetKeyName(106, "Question.bmp");
            this.imageList1.Images.SetKeyName(107, "Raise.bmp");
            this.imageList1.Images.SetKeyName(108, "Record.bmp");
            this.imageList1.Images.SetKeyName(109, "Red mark.bmp");
            this.imageList1.Images.SetKeyName(110, "Red star.bmp");
            this.imageList1.Images.SetKeyName(111, "Red tag.bmp");
            this.imageList1.Images.SetKeyName(112, "Redo.bmp");
            this.imageList1.Images.SetKeyName(113, "Refresh.bmp");
            this.imageList1.Images.SetKeyName(114, "Remove.bmp");
            this.imageList1.Images.SetKeyName(115, "Repair.bmp");
            this.imageList1.Images.SetKeyName(116, "Report.bmp");
            this.imageList1.Images.SetKeyName(117, "Retort.bmp");
            this.imageList1.Images.SetKeyName(118, "Rewind.bmp");
            this.imageList1.Images.SetKeyName(119, "Sad.bmp");
            this.imageList1.Images.SetKeyName(120, "Save.bmp");
            this.imageList1.Images.SetKeyName(121, "Search.bmp");
            this.imageList1.Images.SetKeyName(122, "Shopping cart.bmp");
            this.imageList1.Images.SetKeyName(123, "Smile.bmp");
            this.imageList1.Images.SetKeyName(124, "Sound.bmp");
            this.imageList1.Images.SetKeyName(125, "Stop sign.bmp");
            this.imageList1.Images.SetKeyName(126, "Stop.bmp");
            this.imageList1.Images.SetKeyName(127, "Sync.bmp");
            this.imageList1.Images.SetKeyName(128, "Table.bmp");
            this.imageList1.Images.SetKeyName(129, "Target.bmp");
            this.imageList1.Images.SetKeyName(130, "Taxi.bmp");
            this.imageList1.Images.SetKeyName(131, "Terminate.bmp");
            this.imageList1.Images.SetKeyName(132, "Text preview.bmp");
            this.imageList1.Images.SetKeyName(133, "Text.bmp");
            this.imageList1.Images.SetKeyName(134, "Thumbs down.bmp");
            this.imageList1.Images.SetKeyName(135, "Thumbs up.bmp");
            this.imageList1.Images.SetKeyName(136, "Top.bmp");
            this.imageList1.Images.SetKeyName(137, "Turn off.bmp");
            this.imageList1.Images.SetKeyName(138, "Undo.bmp");
            this.imageList1.Images.SetKeyName(139, "Unlock.bmp");
            this.imageList1.Images.SetKeyName(140, "Up.bmp");
            this.imageList1.Images.SetKeyName(141, "Update.bmp");
            this.imageList1.Images.SetKeyName(142, "Up-down.bmp");
            this.imageList1.Images.SetKeyName(143, "Upload.bmp");
            this.imageList1.Images.SetKeyName(144, "User group.bmp");
            this.imageList1.Images.SetKeyName(145, "View.bmp");
            this.imageList1.Images.SetKeyName(146, "Warning.bmp");
            this.imageList1.Images.SetKeyName(147, "Wrench.bmp");
            this.imageList1.Images.SetKeyName(148, "Yes.bmp");
            this.imageList1.Images.SetKeyName(149, "Zoom.bmp");
            this.imageList1.Images.SetKeyName(150, "show.png");
            this.imageList1.Images.SetKeyName(151, "hide.png");
            // 
            // btnNewEmployee
            // 
            this.btnNewEmployee.BackColor = System.Drawing.Color.White;
            this.btnNewEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewEmployee.ForeColor = System.Drawing.Color.Transparent;
            this.btnNewEmployee.ImageKey = "Create.bmp";
            this.btnNewEmployee.ImageList = this.imageList1;
            this.btnNewEmployee.Location = new System.Drawing.Point(60, 6);
            this.btnNewEmployee.Name = "btnNewEmployee";
            this.btnNewEmployee.Size = new System.Drawing.Size(40, 40);
            this.btnNewEmployee.TabIndex = 20;
            this.btnNewEmployee.UseVisualStyleBackColor = false;
            this.btnNewEmployee.Click += new System.EventHandler(this.btnNewEmployee_Click);
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.AllowUserToAddRows = false;
            this.dataGridViewEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmployees.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(12, 52);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.RowHeadersVisible = false;
            this.dataGridViewEmployees.RowHeadersWidth = 51;
            this.dataGridViewEmployees.RowTemplate.Height = 24;
            this.dataGridViewEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(201, 751);
            this.dataGridViewEmployees.TabIndex = 0;
            this.dataGridViewEmployees.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewEmployees_CellMouseDown);
            this.dataGridViewEmployees.SelectionChanged += new System.EventHandler(this.dataGridViewEmployees_SelectionChanged);
            this.dataGridViewEmployees.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewEmployees_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Permitted Projects";
            // 
            // dataGridViewSelectProjects
            // 
            this.dataGridViewSelectProjects.AllowUserToAddRows = false;
            this.dataGridViewSelectProjects.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewSelectProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectProjects.Location = new System.Drawing.Point(174, 289);
            this.dataGridViewSelectProjects.Name = "dataGridViewSelectProjects";
            this.dataGridViewSelectProjects.RowHeadersVisible = false;
            this.dataGridViewSelectProjects.RowHeadersWidth = 51;
            this.dataGridViewSelectProjects.RowTemplate.Height = 24;
            this.dataGridViewSelectProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSelectProjects.Size = new System.Drawing.Size(683, 286);
            this.dataGridViewSelectProjects.TabIndex = 27;
            // 
            // cmbManagers
            // 
            this.cmbManagers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManagers.FormattingEnabled = true;
            this.cmbManagers.Location = new System.Drawing.Point(467, 233);
            this.cmbManagers.Name = "cmbManagers";
            this.cmbManagers.Size = new System.Drawing.Size(198, 24);
            this.cmbManagers.TabIndex = 26;
            this.cmbManagers.Visible = false;
            // 
            // cmbEmployeeType
            // 
            this.cmbEmployeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployeeType.FormattingEnabled = true;
            this.cmbEmployeeType.Location = new System.Drawing.Point(174, 233);
            this.cmbEmployeeType.Name = "cmbEmployeeType";
            this.cmbEmployeeType.Size = new System.Drawing.Size(198, 24);
            this.cmbEmployeeType.TabIndex = 25;
            this.cmbEmployeeType.SelectedIndexChanged += new System.EventHandler(this.cmbEmployeeType_SelectedIndexChanged);
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.Location = new System.Drawing.Point(397, 233);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(64, 17);
            this.lblManager.TabIndex = 23;
            this.lblManager.Text = "Manager";
            this.lblManager.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Employee Type";
            // 
            // cmbProjects
            // 
            this.cmbProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(747, 230);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(198, 24);
            this.cmbProjects.TabIndex = 20;
            this.cmbProjects.Visible = false;
            // 
            // MenuStripProjects
            // 
            this.MenuStripProjects.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStripProjects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemDeleteProject});
            this.MenuStripProjects.Name = "contextMenuStrip1";
            this.MenuStripProjects.Size = new System.Drawing.Size(123, 28);
            // 
            // itemDeleteProject
            // 
            this.itemDeleteProject.Name = "itemDeleteProject";
            this.itemDeleteProject.Size = new System.Drawing.Size(122, 24);
            this.itemDeleteProject.Text = "Delete";
            this.itemDeleteProject.Click += new System.EventHandler(this.itemDeleteProject_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(174, 178);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(198, 30);
            this.txtPassword.TabIndex = 30;
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.BackColor = System.Drawing.Color.White;
            this.btnShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPassword.ForeColor = System.Drawing.Color.Transparent;
            this.btnShowPassword.ImageKey = "show.png";
            this.btnShowPassword.ImageList = this.imageList1;
            this.btnShowPassword.Location = new System.Drawing.Point(373, 174);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(40, 40);
            this.btnShowPassword.TabIndex = 22;
            this.btnShowPassword.UseVisualStyleBackColor = false;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // FrmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employees";
            this.Load += new System.EventHandler(this.FrmEmployees_Load);
            this.MenuStripSaleBOM.ResumeLayout(false);
            this.MenuStripDesignBOM.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectProjects)).EndInit();
            this.MenuStripProjects.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip MenuStripSaleBOM;
        private System.Windows.Forms.ToolStripMenuItem itmCopyAllToDesignBOM;
        private System.Windows.Forms.ContextMenuStrip MenuStripDesignBOM;
        private System.Windows.Forms.ToolStripMenuItem itmCopyAllToActualBOM;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.Button btnNewEmployee;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip MenuStripProjects;
        private System.Windows.Forms.ToolStripMenuItem itemDeleteProject;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEmployeeType;
        private System.Windows.Forms.ComboBox cmbManagers;
        private System.Windows.Forms.DataGridView dataGridViewSelectProjects;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnShowPassword;
    }
}

