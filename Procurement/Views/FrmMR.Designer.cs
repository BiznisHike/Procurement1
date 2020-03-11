namespace Procurement
{
    partial class FrmMR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMR));
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.MenuStripSaleBOM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmCopyAllToDesignBOM = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripDesignBOM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmCopyAllToActualBOM = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.Sr4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNo4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCost4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtCost4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtPrice4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCopySame = new System.Windows.Forms.Button();
            this.btnCopyUserSpecified = new System.Windows.Forms.Button();
            this.MenuStripProjects = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemDeleteProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MenuStripLoad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadBOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadChageOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Select2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Category1_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category2_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category3_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SORef2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sr2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCategory2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostHead2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostSubHead2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.System2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manufacturer2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCost2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtCost2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtPrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.MenuStripSaleBOM.SuspendLayout();
            this.MenuStripDesignBOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.MenuStripProjects.SuspendLayout();
            this.MenuStripLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(1197, 684);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(162, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save and Export Excel";
            this.toolTip1.SetToolTip(this.btnSave, "Save and Export Excel");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select2,
            this.Category1_2,
            this.Category2_2,
            this.Category3_2,
            this.SORef2,
            this.Sr2,
            this.ProductCategory2,
            this.Product2,
            this.CostHead2,
            this.CostSubHead2,
            this.System2,
            this.Area2,
            this.Panel2,
            this.Category2,
            this.Manufacturer2,
            this.PartNo2,
            this.Description2,
            this.Qty2,
            this.UnitCost2,
            this.ExtCost2,
            this.UnitPrice2,
            this.ExtPrice2,
            this.Column1_2,
            this.Column2_2,
            this.Column3_2,
            this.Column4_2,
            this.Column5_2});
            this.dataGridView2.Location = new System.Drawing.Point(12, 11);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1347, 380);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellEndEdit);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.ImageKey = "Yes.bmp";
            this.btnCancel.Location = new System.Drawing.Point(1094, 684);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Close";
            this.toolTip1.SetToolTip(this.btnCancel, "Close this form");
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
            // 
            // dataGridView4
            // 
            this.dataGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView4.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sr4,
            this.PartNo4,
            this.Description4,
            this.Qty4,
            this.UnitCost4,
            this.ExtCost4,
            this.UnitPrice4,
            this.ExtPrice4});
            this.dataGridView4.Location = new System.Drawing.Point(12, 429);
            this.dataGridView4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.RowHeadersWidth = 51;
            this.dataGridView4.RowTemplate.Height = 24;
            this.dataGridView4.Size = new System.Drawing.Size(1347, 251);
            this.dataGridView4.TabIndex = 20;
            // 
            // Sr4
            // 
            this.Sr4.DataPropertyName = "Sr";
            this.Sr4.HeaderText = "Sr";
            this.Sr4.MinimumWidth = 6;
            this.Sr4.Name = "Sr4";
            this.Sr4.ReadOnly = true;
            this.Sr4.Width = 125;
            // 
            // PartNo4
            // 
            this.PartNo4.DataPropertyName = "PartNo";
            this.PartNo4.HeaderText = "PartNo";
            this.PartNo4.MinimumWidth = 6;
            this.PartNo4.Name = "PartNo4";
            this.PartNo4.ReadOnly = true;
            this.PartNo4.Width = 125;
            // 
            // Description4
            // 
            this.Description4.DataPropertyName = "Description";
            this.Description4.HeaderText = "Description";
            this.Description4.MinimumWidth = 6;
            this.Description4.Name = "Description4";
            this.Description4.ReadOnly = true;
            this.Description4.Width = 125;
            // 
            // Qty4
            // 
            this.Qty4.DataPropertyName = "Qty";
            this.Qty4.HeaderText = "Qty";
            this.Qty4.MinimumWidth = 6;
            this.Qty4.Name = "Qty4";
            this.Qty4.ReadOnly = true;
            this.Qty4.Width = 125;
            // 
            // UnitCost4
            // 
            this.UnitCost4.DataPropertyName = "UnitCost";
            this.UnitCost4.HeaderText = "UnitCost";
            this.UnitCost4.MinimumWidth = 6;
            this.UnitCost4.Name = "UnitCost4";
            this.UnitCost4.ReadOnly = true;
            this.UnitCost4.Width = 125;
            // 
            // ExtCost4
            // 
            this.ExtCost4.DataPropertyName = "ExtCost";
            this.ExtCost4.HeaderText = "ExtCost";
            this.ExtCost4.MinimumWidth = 6;
            this.ExtCost4.Name = "ExtCost4";
            this.ExtCost4.ReadOnly = true;
            this.ExtCost4.Width = 125;
            // 
            // UnitPrice4
            // 
            this.UnitPrice4.DataPropertyName = "UnitPrice";
            this.UnitPrice4.HeaderText = "UnitPrice";
            this.UnitPrice4.MinimumWidth = 6;
            this.UnitPrice4.Name = "UnitPrice4";
            this.UnitPrice4.ReadOnly = true;
            this.UnitPrice4.Width = 125;
            // 
            // ExtPrice4
            // 
            this.ExtPrice4.DataPropertyName = "ExtPrice";
            this.ExtPrice4.HeaderText = "ExtPrice";
            this.ExtPrice4.MinimumWidth = 6;
            this.ExtPrice4.Name = "ExtPrice4";
            this.ExtPrice4.ReadOnly = true;
            this.ExtPrice4.Width = 125;
            // 
            // btnCopySame
            // 
            this.btnCopySame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopySame.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCopySame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopySame.ForeColor = System.Drawing.Color.Black;
            this.btnCopySame.ImageKey = "Yes.bmp";
            this.btnCopySame.Location = new System.Drawing.Point(12, 395);
            this.btnCopySame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCopySame.Name = "btnCopySame";
            this.btnCopySame.Size = new System.Drawing.Size(209, 30);
            this.btnCopySame.TabIndex = 18;
            this.btnCopySame.Text = "Copy Same Qty";
            this.btnCopySame.UseVisualStyleBackColor = false;
            this.btnCopySame.Click += new System.EventHandler(this.btnCopySame_Click);
            // 
            // btnCopyUserSpecified
            // 
            this.btnCopyUserSpecified.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyUserSpecified.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCopyUserSpecified.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyUserSpecified.ForeColor = System.Drawing.Color.Black;
            this.btnCopyUserSpecified.ImageKey = "Yes.bmp";
            this.btnCopyUserSpecified.Location = new System.Drawing.Point(227, 395);
            this.btnCopyUserSpecified.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCopyUserSpecified.Name = "btnCopyUserSpecified";
            this.btnCopyUserSpecified.Size = new System.Drawing.Size(209, 30);
            this.btnCopyUserSpecified.TabIndex = 19;
            this.btnCopyUserSpecified.Text = "Copy with user Specified Qty";
            this.btnCopyUserSpecified.UseVisualStyleBackColor = false;
            this.btnCopyUserSpecified.Click += new System.EventHandler(this.btnCopyUserSpecified_Click);
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
            // 
            // MenuStripLoad
            // 
            this.MenuStripLoad.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStripLoad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadBOMToolStripMenuItem,
            this.loadChageOrderToolStripMenuItem});
            this.MenuStripLoad.Name = "MenuStripLoad";
            this.MenuStripLoad.Size = new System.Drawing.Size(163, 52);
            // 
            // loadBOMToolStripMenuItem
            // 
            this.loadBOMToolStripMenuItem.Name = "loadBOMToolStripMenuItem";
            this.loadBOMToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.loadBOMToolStripMenuItem.Text = "BOM";
            // 
            // loadChageOrderToolStripMenuItem
            // 
            this.loadChageOrderToolStripMenuItem.Name = "loadChageOrderToolStripMenuItem";
            this.loadChageOrderToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.loadChageOrderToolStripMenuItem.Text = "Chage Order";
            // 
            // Select2
            // 
            this.Select2.HeaderText = " ";
            this.Select2.MinimumWidth = 6;
            this.Select2.Name = "Select2";
            this.Select2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Select2.Width = 30;
            // 
            // Category1_2
            // 
            this.Category1_2.DataPropertyName = "Category1";
            this.Category1_2.HeaderText = "Category 1";
            this.Category1_2.MinimumWidth = 6;
            this.Category1_2.Name = "Category1_2";
            this.Category1_2.Width = 125;
            // 
            // Category2_2
            // 
            this.Category2_2.DataPropertyName = "Category2";
            this.Category2_2.HeaderText = "Category 2";
            this.Category2_2.MinimumWidth = 6;
            this.Category2_2.Name = "Category2_2";
            this.Category2_2.Width = 125;
            // 
            // Category3_2
            // 
            this.Category3_2.DataPropertyName = "Category3";
            this.Category3_2.HeaderText = "Category 3";
            this.Category3_2.MinimumWidth = 6;
            this.Category3_2.Name = "Category3_2";
            this.Category3_2.Width = 125;
            // 
            // SORef2
            // 
            this.SORef2.DataPropertyName = "SORef";
            this.SORef2.HeaderText = "SO Ref";
            this.SORef2.MinimumWidth = 6;
            this.SORef2.Name = "SORef2";
            this.SORef2.Width = 125;
            // 
            // Sr2
            // 
            this.Sr2.DataPropertyName = "Sr";
            this.Sr2.HeaderText = "Sr";
            this.Sr2.MinimumWidth = 6;
            this.Sr2.Name = "Sr2";
            this.Sr2.Width = 125;
            // 
            // ProductCategory2
            // 
            this.ProductCategory2.DataPropertyName = "ProductCategory";
            this.ProductCategory2.HeaderText = "Product Category";
            this.ProductCategory2.MinimumWidth = 6;
            this.ProductCategory2.Name = "ProductCategory2";
            this.ProductCategory2.Width = 125;
            // 
            // Product2
            // 
            this.Product2.DataPropertyName = "Product";
            this.Product2.HeaderText = "Product";
            this.Product2.MinimumWidth = 6;
            this.Product2.Name = "Product2";
            this.Product2.Width = 125;
            // 
            // CostHead2
            // 
            this.CostHead2.DataPropertyName = "CostHead";
            this.CostHead2.HeaderText = "Cost Head";
            this.CostHead2.MinimumWidth = 6;
            this.CostHead2.Name = "CostHead2";
            this.CostHead2.Width = 125;
            // 
            // CostSubHead2
            // 
            this.CostSubHead2.DataPropertyName = "CostSubHead";
            this.CostSubHead2.HeaderText = "Cost Sub-Head";
            this.CostSubHead2.MinimumWidth = 6;
            this.CostSubHead2.Name = "CostSubHead2";
            this.CostSubHead2.Width = 125;
            // 
            // System2
            // 
            this.System2.DataPropertyName = "System";
            this.System2.HeaderText = "System";
            this.System2.MinimumWidth = 6;
            this.System2.Name = "System2";
            this.System2.Width = 125;
            // 
            // Area2
            // 
            this.Area2.DataPropertyName = "Area";
            this.Area2.HeaderText = "Area";
            this.Area2.MinimumWidth = 6;
            this.Area2.Name = "Area2";
            this.Area2.Width = 125;
            // 
            // Panel2
            // 
            this.Panel2.DataPropertyName = "Panel";
            this.Panel2.HeaderText = "Panel";
            this.Panel2.MinimumWidth = 6;
            this.Panel2.Name = "Panel2";
            this.Panel2.Width = 125;
            // 
            // Category2
            // 
            this.Category2.DataPropertyName = "Category";
            this.Category2.HeaderText = "Category";
            this.Category2.MinimumWidth = 6;
            this.Category2.Name = "Category2";
            this.Category2.Width = 125;
            // 
            // Manufacturer2
            // 
            this.Manufacturer2.DataPropertyName = "Manufacturer";
            this.Manufacturer2.HeaderText = "Manufacturer";
            this.Manufacturer2.MinimumWidth = 6;
            this.Manufacturer2.Name = "Manufacturer2";
            this.Manufacturer2.Width = 125;
            // 
            // PartNo2
            // 
            this.PartNo2.DataPropertyName = "PartNo";
            this.PartNo2.HeaderText = "PartNo";
            this.PartNo2.MinimumWidth = 6;
            this.PartNo2.Name = "PartNo2";
            this.PartNo2.Width = 125;
            // 
            // Description2
            // 
            this.Description2.DataPropertyName = "Description";
            this.Description2.HeaderText = "Description";
            this.Description2.MinimumWidth = 6;
            this.Description2.Name = "Description2";
            this.Description2.Width = 125;
            // 
            // Qty2
            // 
            this.Qty2.DataPropertyName = "Qty";
            this.Qty2.HeaderText = "Qty";
            this.Qty2.MinimumWidth = 6;
            this.Qty2.Name = "Qty2";
            this.Qty2.Width = 125;
            // 
            // UnitCost2
            // 
            this.UnitCost2.DataPropertyName = "UnitCost";
            this.UnitCost2.HeaderText = "UnitCost";
            this.UnitCost2.MinimumWidth = 6;
            this.UnitCost2.Name = "UnitCost2";
            this.UnitCost2.Width = 125;
            // 
            // ExtCost2
            // 
            this.ExtCost2.DataPropertyName = "ExtCost";
            this.ExtCost2.HeaderText = "ExtCost";
            this.ExtCost2.MinimumWidth = 6;
            this.ExtCost2.Name = "ExtCost2";
            this.ExtCost2.Width = 125;
            // 
            // UnitPrice2
            // 
            this.UnitPrice2.DataPropertyName = "UnitPrice";
            this.UnitPrice2.HeaderText = "UnitPrice";
            this.UnitPrice2.MinimumWidth = 6;
            this.UnitPrice2.Name = "UnitPrice2";
            this.UnitPrice2.Width = 125;
            // 
            // ExtPrice2
            // 
            this.ExtPrice2.DataPropertyName = "ExtPrice";
            this.ExtPrice2.HeaderText = "ExtPrice";
            this.ExtPrice2.MinimumWidth = 6;
            this.ExtPrice2.Name = "ExtPrice2";
            this.ExtPrice2.Width = 125;
            // 
            // Column1_2
            // 
            this.Column1_2.DataPropertyName = "Column1";
            this.Column1_2.HeaderText = "Column 1";
            this.Column1_2.MinimumWidth = 6;
            this.Column1_2.Name = "Column1_2";
            this.Column1_2.Width = 125;
            // 
            // Column2_2
            // 
            this.Column2_2.DataPropertyName = "Column2";
            this.Column2_2.HeaderText = "Column 2";
            this.Column2_2.MinimumWidth = 6;
            this.Column2_2.Name = "Column2_2";
            this.Column2_2.Width = 125;
            // 
            // Column3_2
            // 
            this.Column3_2.DataPropertyName = "Column3";
            this.Column3_2.HeaderText = "Column 3";
            this.Column3_2.MinimumWidth = 6;
            this.Column3_2.Name = "Column3_2";
            this.Column3_2.Width = 125;
            // 
            // Column4_2
            // 
            this.Column4_2.DataPropertyName = "Column4";
            this.Column4_2.HeaderText = "Column 4";
            this.Column4_2.MinimumWidth = 6;
            this.Column4_2.Name = "Column4_2";
            this.Column4_2.Width = 125;
            // 
            // Column5_2
            // 
            this.Column5_2.DataPropertyName = "Column5";
            this.Column5_2.HeaderText = "Column 5";
            this.Column5_2.MinimumWidth = 6;
            this.Column5_2.Name = "Column5_2";
            this.Column5_2.Width = 125;
            // 
            // FrmMR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1371, 750);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCopySame);
            this.Controls.Add(this.btnCopyUserSpecified);
            this.Controls.Add(this.btnSave);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Material Request";
            this.Load += new System.EventHandler(this.FrmBOM_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBOM_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.MenuStripSaleBOM.ResumeLayout(false);
            this.MenuStripDesignBOM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.MenuStripProjects.ResumeLayout(false);
            this.MenuStripLoad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip MenuStripSaleBOM;
        private System.Windows.Forms.ToolStripMenuItem itmCopyAllToDesignBOM;
        private System.Windows.Forms.ContextMenuStrip MenuStripDesignBOM;
        private System.Windows.Forms.ToolStripMenuItem itmCopyAllToActualBOM;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip MenuStripProjects;
        private System.Windows.Forms.ToolStripMenuItem itemDeleteProject;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip MenuStripLoad;
        private System.Windows.Forms.ToolStripMenuItem loadBOMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadChageOrderToolStripMenuItem;
        private System.Windows.Forms.Button btnCopyUserSpecified;
        private System.Windows.Forms.Button btnCopySame;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sr4;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNo4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty4;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCost4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtCost4;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtPrice4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category1_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category2_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category3_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SORef2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sr2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCategory2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostHead2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostSubHead2;
        private System.Windows.Forms.DataGridViewTextBoxColumn System2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCost2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtCost2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtPrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5_2;
    }
}

