namespace Procurement
{
    partial class FrmNewProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewProject));
            this.btnSave = new System.Windows.Forms.Button();
            this.txtProjectEndUser = new System.Windows.Forms.TextBox();
            this.txtProjectCustomerName = new System.Windows.Forms.TextBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.txtProjectCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.MenuStripSaleBOM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmCopyAllToDesignBOM = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripDesignBOM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmCopyAllToActualBOM = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.MenuStripProjects = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemDeleteProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MenuStripLoad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadBOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadChageOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripSaleBOM.SuspendLayout();
            this.MenuStripDesignBOM.SuspendLayout();
            this.MenuStripProjects.SuspendLayout();
            this.MenuStripLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(322, 301);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.toolTip1.SetToolTip(this.btnSave, "Save project");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtProjectEndUser
            // 
            this.txtProjectEndUser.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.txtProjectEndUser.Location = new System.Drawing.Point(33, 244);
            this.txtProjectEndUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtProjectEndUser.Name = "txtProjectEndUser";
            this.txtProjectEndUser.Size = new System.Drawing.Size(386, 28);
            this.txtProjectEndUser.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtProjectEndUser, "Enter End User");
            // 
            // txtProjectCustomerName
            // 
            this.txtProjectCustomerName.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F);
            this.txtProjectCustomerName.Location = new System.Drawing.Point(33, 178);
            this.txtProjectCustomerName.Margin = new System.Windows.Forms.Padding(2);
            this.txtProjectCustomerName.Name = "txtProjectCustomerName";
            this.txtProjectCustomerName.Size = new System.Drawing.Size(386, 28);
            this.txtProjectCustomerName.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtProjectCustomerName, "Enter Customer Name");
            // 
            // txtProjectName
            // 
            this.txtProjectName.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectName.Location = new System.Drawing.Point(34, 108);
            this.txtProjectName.Margin = new System.Windows.Forms.Padding(2);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(385, 28);
            this.txtProjectName.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtProjectName, "Enter Project Name");
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(33, 46);
            this.txtProjectCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtProjectCode.Multiline = true;
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.ReadOnly = true;
            this.txtProjectCode.Size = new System.Drawing.Size(169, 25);
            this.txtProjectCode.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 224);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "End User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Customer Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Project Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Project Code";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.ImageKey = "Yes.bmp";
            this.btnCancel.Location = new System.Drawing.Point(219, 301);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.btnCancel, "Press Close button to exit the FormBOM ");
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
            // FrmNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(448, 360);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtProjectCode);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtProjectEndUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.txtProjectCustomerName);
            this.Controls.Add(this.label4);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmNewProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Project";
            this.Activated += new System.EventHandler(this.FrmBOM_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNewProject_FormClosing);
            this.Load += new System.EventHandler(this.FrmBOM_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBOM_KeyDown);
            this.MenuStripSaleBOM.ResumeLayout(false);
            this.MenuStripDesignBOM.ResumeLayout(false);
            this.MenuStripProjects.ResumeLayout(false);
            this.MenuStripLoad.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtProjectEndUser;
        private System.Windows.Forms.TextBox txtProjectCustomerName;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.TextBox txtProjectCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
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
    }
}

