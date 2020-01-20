namespace Procurement
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.pnlProjects = new System.Windows.Forms.Panel();
            this.lblProjectDesc = new System.Windows.Forms.Label();
            this.lnkProjects = new System.Windows.Forms.LinkLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblProject = new System.Windows.Forms.Label();
            this.pnlProjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProjects
            // 
            this.pnlProjects.Controls.Add(this.lblProject);
            this.pnlProjects.Controls.Add(this.lblProjectDesc);
            this.pnlProjects.Controls.Add(this.lnkProjects);
            this.pnlProjects.Location = new System.Drawing.Point(7, 4);
            this.pnlProjects.Margin = new System.Windows.Forms.Padding(2);
            this.pnlProjects.Name = "pnlProjects";
            this.pnlProjects.Size = new System.Drawing.Size(300, 75);
            this.pnlProjects.TabIndex = 2;
            this.pnlProjects.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlProjects_Paint);
            // 
            // lblProjectDesc
            // 
            this.lblProjectDesc.AutoSize = true;
            this.lblProjectDesc.Location = new System.Drawing.Point(55, 28);
            this.lblProjectDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProjectDesc.Name = "lblProjectDesc";
            this.lblProjectDesc.Size = new System.Drawing.Size(194, 13);
            this.lblProjectDesc.TabIndex = 7;
            this.lblProjectDesc.Text = "Create Update Delete Project and BOM";
            this.lblProjectDesc.Click += new System.EventHandler(this.lblProjectDesc_Click);
            // 
            // lnkProjects
            // 
            this.lnkProjects.AutoSize = true;
            this.lnkProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkProjects.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkProjects.Location = new System.Drawing.Point(54, 7);
            this.lnkProjects.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkProjects.Name = "lnkProjects";
            this.lnkProjects.Size = new System.Drawing.Size(138, 18);
            this.lnkProjects.TabIndex = 6;
            this.lnkProjects.TabStop = true;
            this.lnkProjects.Text = "Projects and BOMs";
            this.lnkProjects.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProjects_LinkClicked);
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
            this.lblProject.Location = new System.Drawing.Point(12, 10);
            this.lblProject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(38, 35);
            this.lblProject.TabIndex = 8;
            this.lblProject.Click += new System.EventHandler(this.lblProject_Click_1);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlProjects);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(307, 81);
            this.pnlProjects.ResumeLayout(false);
            this.pnlProjects.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlProjects;
        private System.Windows.Forms.Label lblProjectDesc;
        private System.Windows.Forms.LinkLabel lnkProjects;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblProject;
    }
}
