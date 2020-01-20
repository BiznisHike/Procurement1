namespace Procurement
{
    partial class employee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(employee));
            this.lblEmployeeDesc = new System.Windows.Forms.Label();
            this.lnkEmployees = new System.Windows.Forms.LinkLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEmployeeDesc
            // 
            this.lblEmployeeDesc.Location = new System.Drawing.Point(45, 26);
            this.lblEmployeeDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmployeeDesc.Name = "lblEmployeeDesc";
            this.lblEmployeeDesc.Size = new System.Drawing.Size(202, 32);
            this.lblEmployeeDesc.TabIndex = 11;
            this.lblEmployeeDesc.Text = "Create Update and Delete Employee\r\nSet Permissions on Employee";
            this.lblEmployeeDesc.Click += new System.EventHandler(this.lblEmployeeDesc_Click);
            // 
            // lnkEmployees
            // 
            this.lnkEmployees.AutoSize = true;
            this.lnkEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEmployees.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkEmployees.Location = new System.Drawing.Point(44, 5);
            this.lnkEmployees.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkEmployees.Name = "lnkEmployees";
            this.lnkEmployees.Size = new System.Drawing.Size(197, 18);
            this.lnkEmployees.TabIndex = 10;
            this.lnkEmployees.TabStop = true;
            this.lnkEmployees.Text = "Employees and Permissions";
            this.lnkEmployees.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEmployees_LinkClicked);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Table.bmp");
            this.imageList1.Images.SetKeyName(1, "User group.bmp");
            // 
            // label1
            // 
            this.label1.ImageKey = "User group.bmp";
            this.label1.ImageList = this.imageList1;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 35);
            this.label1.TabIndex = 12;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEmployeeDesc);
            this.Controls.Add(this.lnkEmployees);
            this.Name = "employee";
            this.Size = new System.Drawing.Size(242, 61);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmployeeDesc;
        private System.Windows.Forms.LinkLabel lnkEmployees;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
    }
}
