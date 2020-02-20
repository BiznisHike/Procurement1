namespace Procurement.Views
{
    partial class FrmMDI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bOMsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBOMsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaterialRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialRequestListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createMaterialRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyMaterialRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectsToolStripMenuItem,
            this.bOMsToolStripMenuItem,
            this.MaterialRequestToolStripMenuItem,
            this.employeesToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.userToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projectsToolStripMenuItem
            // 
            this.projectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.projectsListToolStripMenuItem});
            this.projectsToolStripMenuItem.Name = "projectsToolStripMenuItem";
            this.projectsToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.projectsToolStripMenuItem.Text = "Projects";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // projectsListToolStripMenuItem
            // 
            this.projectsListToolStripMenuItem.Name = "projectsListToolStripMenuItem";
            this.projectsListToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.projectsListToolStripMenuItem.Text = "Open Project";
            this.projectsListToolStripMenuItem.Click += new System.EventHandler(this.projectsListToolStripMenuItem_Click);
            // 
            // bOMsToolStripMenuItem
            // 
            this.bOMsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBOMsToolStripMenuItem});
            this.bOMsToolStripMenuItem.Name = "bOMsToolStripMenuItem";
            this.bOMsToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.bOMsToolStripMenuItem.Text = "BOMs";
            // 
            // openBOMsToolStripMenuItem
            // 
            this.openBOMsToolStripMenuItem.Name = "openBOMsToolStripMenuItem";
            this.openBOMsToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.openBOMsToolStripMenuItem.Text = "Open BOMs";
            this.openBOMsToolStripMenuItem.Click += new System.EventHandler(this.openBOMsToolStripMenuItem_Click);
            // 
            // MaterialRequestToolStripMenuItem
            // 
            this.MaterialRequestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materialRequestListToolStripMenuItem,
            this.createMaterialRequestToolStripMenuItem,
            this.modifyMaterialRequestToolStripMenuItem});
            this.MaterialRequestToolStripMenuItem.Name = "MaterialRequestToolStripMenuItem";
            this.MaterialRequestToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.MaterialRequestToolStripMenuItem.Text = "Material Request";
            // 
            // materialRequestListToolStripMenuItem
            // 
            this.materialRequestListToolStripMenuItem.Name = "materialRequestListToolStripMenuItem";
            this.materialRequestListToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.materialRequestListToolStripMenuItem.Text = "Material Request List";
            this.materialRequestListToolStripMenuItem.Click += new System.EventHandler(this.mRListToolStripMenuItem_Click);
            // 
            // createMaterialRequestToolStripMenuItem
            // 
            this.createMaterialRequestToolStripMenuItem.Name = "createMaterialRequestToolStripMenuItem";
            this.createMaterialRequestToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.createMaterialRequestToolStripMenuItem.Text = "Create Material Request";
            this.createMaterialRequestToolStripMenuItem.Click += new System.EventHandler(this.openMaterialRequestToolStripMenuItem_Click);
            // 
            // modifyMaterialRequestToolStripMenuItem
            // 
            this.modifyMaterialRequestToolStripMenuItem.Name = "modifyMaterialRequestToolStripMenuItem";
            this.modifyMaterialRequestToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.modifyMaterialRequestToolStripMenuItem.Text = "Modify Material Request";
            this.modifyMaterialRequestToolStripMenuItem.Click += new System.EventHandler(this.modifyMaterialRequestToolStripMenuItem_Click);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.employeesToolStripMenuItem.Text = "Employees";
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.employeesToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // FrmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procurement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMDI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectsListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bOMsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBOMsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MaterialRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createMaterialRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialRequestListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyMaterialRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    }
}