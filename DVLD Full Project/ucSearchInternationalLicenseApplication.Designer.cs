namespace DVLD_Full_Project
{
    partial class ucSearchInternationalLicenseApplication
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
            this.gbLicenseFilter = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLiceneseID = new System.Windows.Forms.TextBox();
            this.btnLicenseSearch = new System.Windows.Forms.Button();
            this.ucDriverLicenseInfo1 = new DVLD_Full_Project.ucDriverLicenseInfo();
            this.gbLicenseFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLicenseFilter
            // 
            this.gbLicenseFilter.Controls.Add(this.btnLicenseSearch);
            this.gbLicenseFilter.Controls.Add(this.txtLiceneseID);
            this.gbLicenseFilter.Controls.Add(this.label1);
            this.gbLicenseFilter.Location = new System.Drawing.Point(7, 3);
            this.gbLicenseFilter.Name = "gbLicenseFilter";
            this.gbLicenseFilter.Size = new System.Drawing.Size(945, 71);
            this.gbLicenseFilter.TabIndex = 0;
            this.gbLicenseFilter.TabStop = false;
            this.gbLicenseFilter.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "License ID:";
            // 
            // txtLiceneseID
            // 
            this.txtLiceneseID.Location = new System.Drawing.Point(171, 27);
            this.txtLiceneseID.Name = "txtLiceneseID";
            this.txtLiceneseID.Size = new System.Drawing.Size(384, 20);
            this.txtLiceneseID.TabIndex = 1;
            // 
            // btnLicenseSearch
            // 
            this.btnLicenseSearch.Location = new System.Drawing.Point(615, 16);
            this.btnLicenseSearch.Name = "btnLicenseSearch";
            this.btnLicenseSearch.Size = new System.Drawing.Size(75, 42);
            this.btnLicenseSearch.TabIndex = 2;
            this.btnLicenseSearch.Text = "Search";
            this.btnLicenseSearch.UseVisualStyleBackColor = true;
            // 
            // ucDriverLicenseInfo1
            // 
            this.ucDriverLicenseInfo1.Location = new System.Drawing.Point(7, 80);
            this.ucDriverLicenseInfo1.Name = "ucDriverLicenseInfo1";
            this.ucDriverLicenseInfo1.Size = new System.Drawing.Size(954, 373);
            this.ucDriverLicenseInfo1.TabIndex = 1;
            this.ucDriverLicenseInfo1.Load += new System.EventHandler(this.ucDriverLicenseInfo1_Load);
            // 
            // ucSearchInternationalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLicenseFilter);
            this.Controls.Add(this.ucDriverLicenseInfo1);
            this.Name = "ucSearchInternationalLicenseApplication";
            this.Size = new System.Drawing.Size(962, 459);
            this.Load += new System.EventHandler(this.ucSearchInternationalLicenseApplication_Load);
            this.gbLicenseFilter.ResumeLayout(false);
            this.gbLicenseFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucDriverLicenseInfo ucDriverLicenseInfo1;
        private System.Windows.Forms.GroupBox gbLicenseFilter;
        private System.Windows.Forms.Button btnLicenseSearch;
        private System.Windows.Forms.TextBox txtLiceneseID;
        private System.Windows.Forms.Label label1;
    }
}
