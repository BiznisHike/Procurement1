namespace Procurement.Views
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lnkEmployees = new System.Windows.Forms.LinkLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblProject = new System.Windows.Forms.Label();
            this.lnkProjects = new System.Windows.Forms.LinkLabel();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pnlProjects = new System.Windows.Forms.Panel();
            this.lblProjectDesc = new System.Windows.Forms.Label();
            this.pnlEmployees = new System.Windows.Forms.Panel();
            this.lblEmployeeDesc = new System.Windows.Forms.Label();
            this.lnkUserName = new System.Windows.Forms.LinkLabel();
            this.btnLogOff = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.pnlProjects.SuspendLayout();
            this.pnlEmployees.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnkEmployees
            // 
            this.lnkEmployees.AutoSize = true;
            this.lnkEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEmployees.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkEmployees.Location = new System.Drawing.Point(72, 10);
            this.lnkEmployees.Name = "lnkEmployees";
            this.lnkEmployees.Size = new System.Drawing.Size(249, 24);
            this.lnkEmployees.TabIndex = 1;
            this.lnkEmployees.TabStop = true;
            this.lnkEmployees.Text = "Employees and Permissions";
            this.lnkEmployees.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEmployees_LinkClicked);
            this.lnkEmployees.MouseEnter += new System.EventHandler(this.pnlEmployees_MouseEnter);
            this.lnkEmployees.MouseLeave += new System.EventHandler(this.pnlEmployees_MouseLeave);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Table.bmp");
            this.imageList1.Images.SetKeyName(1, "User group.bmp");
            // 
            // lblProject
            // 
            this.lblProject.ImageKey = "Table.bmp";
            this.lblProject.ImageList = this.imageList1;
            this.lblProject.Location = new System.Drawing.Point(12, 9);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(51, 43);
            this.lblProject.TabIndex = 5;
            this.lblProject.Click += new System.EventHandler(this.lblProject_Click);
            this.lblProject.MouseEnter += new System.EventHandler(this.pnlProjects_MouseEnter);
            this.lblProject.MouseLeave += new System.EventHandler(this.pnlProjects_MouseLeave);
            // 
            // lnkProjects
            // 
            this.lnkProjects.AutoSize = true;
            this.lnkProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkProjects.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkProjects.Location = new System.Drawing.Point(72, 9);
            this.lnkProjects.Name = "lnkProjects";
            this.lnkProjects.Size = new System.Drawing.Size(171, 24);
            this.lnkProjects.TabIndex = 6;
            this.lnkProjects.TabStop = true;
            this.lnkProjects.Text = "Projects and BOMs";
            this.lnkProjects.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProjects_LinkClicked);
            this.lnkProjects.MouseEnter += new System.EventHandler(this.pnlProjects_MouseEnter);
            this.lnkProjects.MouseLeave += new System.EventHandler(this.pnlProjects_MouseLeave);
            // 
            // lblEmployee
            // 
            this.lblEmployee.ImageKey = "User group.bmp";
            this.lblEmployee.ImageList = this.imageList1;
            this.lblEmployee.Location = new System.Drawing.Point(12, 10);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(51, 43);
            this.lblEmployee.TabIndex = 7;
            this.lblEmployee.Click += new System.EventHandler(this.lblEmployee_Click);
            this.lblEmployee.MouseEnter += new System.EventHandler(this.pnlEmployees_MouseEnter);
            this.lblEmployee.MouseLeave += new System.EventHandler(this.pnlEmployees_MouseLeave);
            // 
            // pnlProjects
            // 
            this.pnlProjects.Controls.Add(this.lblProjectDesc);
            this.pnlProjects.Controls.Add(this.lblProject);
            this.pnlProjects.Controls.Add(this.lnkProjects);
            this.pnlProjects.Location = new System.Drawing.Point(44, 27);
            this.pnlProjects.Name = "pnlProjects";
            this.pnlProjects.Size = new System.Drawing.Size(400, 100);
            this.pnlProjects.TabIndex = 8;
            this.pnlProjects.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlProjects_MouseClick);
            this.pnlProjects.MouseEnter += new System.EventHandler(this.pnlProjects_MouseEnter);
            this.pnlProjects.MouseLeave += new System.EventHandler(this.pnlProjects_MouseLeave);
            // 
            // lblProjectDesc
            // 
            this.lblProjectDesc.AutoSize = true;
            this.lblProjectDesc.Location = new System.Drawing.Point(73, 35);
            this.lblProjectDesc.Name = "lblProjectDesc";
            this.lblProjectDesc.Size = new System.Drawing.Size(256, 17);
            this.lblProjectDesc.TabIndex = 7;
            this.lblProjectDesc.Text = "Create Update Delete Project and BOM";
            this.lblProjectDesc.Click += new System.EventHandler(this.lblProjectDesc_Click);
            this.lblProjectDesc.MouseEnter += new System.EventHandler(this.pnlProjects_MouseEnter);
            this.lblProjectDesc.MouseLeave += new System.EventHandler(this.pnlProjects_MouseLeave);
            // 
            // pnlEmployees
            // 
            this.pnlEmployees.Controls.Add(this.lblEmployeeDesc);
            this.pnlEmployees.Controls.Add(this.lblEmployee);
            this.pnlEmployees.Controls.Add(this.lnkEmployees);
            this.pnlEmployees.Location = new System.Drawing.Point(44, 133);
            this.pnlEmployees.Name = "pnlEmployees";
            this.pnlEmployees.Size = new System.Drawing.Size(400, 100);
            this.pnlEmployees.TabIndex = 9;
            this.pnlEmployees.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlEmployees_MouseClick);
            this.pnlEmployees.MouseEnter += new System.EventHandler(this.pnlEmployees_MouseEnter);
            this.pnlEmployees.MouseLeave += new System.EventHandler(this.pnlEmployees_MouseLeave);
            // 
            // lblEmployeeDesc
            // 
            this.lblEmployeeDesc.Location = new System.Drawing.Point(73, 36);
            this.lblEmployeeDesc.Name = "lblEmployeeDesc";
            this.lblEmployeeDesc.Size = new System.Drawing.Size(270, 40);
            this.lblEmployeeDesc.TabIndex = 8;
            this.lblEmployeeDesc.Text = "Create Update and Delete Employee\r\nSet Permissions on Employee";
            this.lblEmployeeDesc.Click += new System.EventHandler(this.lblEmployeeDesc_Click);
            this.lblEmployeeDesc.MouseEnter += new System.EventHandler(this.pnlEmployees_MouseEnter);
            this.lblEmployeeDesc.MouseLeave += new System.EventHandler(this.pnlEmployees_MouseLeave);
            // 
            // lnkUserName
            // 
            this.lnkUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUserName.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkUserName.Location = new System.Drawing.Point(719, 31);
            this.lnkUserName.Name = "lnkUserName";
            this.lnkUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lnkUserName.Size = new System.Drawing.Size(338, 24);
            this.lnkUserName.TabIndex = 8;
            this.lnkUserName.TabStop = true;
            this.lnkUserName.Text = "User Name";
            this.lnkUserName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUserName_LinkClicked);
            // 
            // btnLogOff
            // 
            this.btnLogOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOff.BackColor = System.Drawing.Color.White;
            this.btnLogOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOff.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogOff.ImageKey = "Turn off.png";
            this.btnLogOff.ImageList = this.imageList2;
            this.btnLogOff.Location = new System.Drawing.Point(1063, 23);
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.Size = new System.Drawing.Size(40, 40);
            this.btnLogOff.TabIndex = 21;
            this.btnLogOff.UseVisualStyleBackColor = false;
            this.btnLogOff.Click += new System.EventHandler(this.btnLogOff_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Turn off.png");
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1145, 613);
            this.Controls.Add(this.btnLogOff);
            this.Controls.Add(this.lnkUserName);
            this.Controls.Add(this.pnlProjects);
            this.Controls.Add(this.pnlEmployees);
            this.Name = "FrmMain";
            this.Text = "Procurement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.pnlProjects.ResumeLayout(false);
            this.pnlProjects.PerformLayout();
            this.pnlEmployees.ResumeLayout(false);
            this.pnlEmployees.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.LinkLabel lnkEmployees;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.LinkLabel lnkProjects;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel pnlProjects;
        private System.Windows.Forms.Panel pnlEmployees;
        private System.Windows.Forms.Label lblProjectDesc;
        private System.Windows.Forms.Label lblEmployeeDesc;
        private System.Windows.Forms.LinkLabel lnkUserName;
        private System.Windows.Forms.Button btnLogOff;
        private System.Windows.Forms.ImageList imageList2;
    }
}