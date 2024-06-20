namespace DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses
{
    partial class frmAddInternationalLicenseApplication
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
            this.ucSearchInternationalLicenseApplication1 = new DVLD_Full_Project.ucSearchInternationalLicenseApplication();
            this.ucInternationaApplicationInfos1 = new DVLD_Full_Project.ucInternationaApplicationInfos();
            this.lblNewLocalDrivingLicense = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucSearchInternationalLicenseApplication1
            // 
            this.ucSearchInternationalLicenseApplication1.Location = new System.Drawing.Point(11, 64);
            this.ucSearchInternationalLicenseApplication1.Name = "ucSearchInternationalLicenseApplication1";
            this.ucSearchInternationalLicenseApplication1.Size = new System.Drawing.Size(960, 457);
            this.ucSearchInternationalLicenseApplication1.TabIndex = 0;
            // 
            // ucInternationaApplicationInfos1
            // 
            this.ucInternationaApplicationInfos1.Location = new System.Drawing.Point(16, 527);
            this.ucInternationaApplicationInfos1.Name = "ucInternationaApplicationInfos1";
            this.ucInternationaApplicationInfos1.Size = new System.Drawing.Size(775, 239);
            this.ucInternationaApplicationInfos1.TabIndex = 1;
            // 
            // lblNewLocalDrivingLicense
            // 
            this.lblNewLocalDrivingLicense.AutoSize = true;
            this.lblNewLocalDrivingLicense.Font = new System.Drawing.Font("Poppins Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewLocalDrivingLicense.Location = new System.Drawing.Point(202, 9);
            this.lblNewLocalDrivingLicense.Name = "lblNewLocalDrivingLicense";
            this.lblNewLocalDrivingLicense.Size = new System.Drawing.Size(579, 56);
            this.lblNewLocalDrivingLicense.TabIndex = 10;
            this.lblNewLocalDrivingLicense.Text = "International License Application";
            // 
            // btnIssue
            // 
            this.btnIssue.Location = new System.Drawing.Point(821, 545);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(126, 44);
            this.btnIssue.TabIndex = 11;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(821, 607);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 44);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddInternationalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 768);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.lblNewLocalDrivingLicense);
            this.Controls.Add(this.ucInternationaApplicationInfos1);
            this.Controls.Add(this.ucSearchInternationalLicenseApplication1);
            this.Name = "frmAddInternationalLicenseApplication";
            this.Text = "frmAddInternationalLicenseApplication";
            this.Load += new System.EventHandler(this.frmAddInternationalLicenseApplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucSearchInternationalLicenseApplication ucSearchInternationalLicenseApplication1;
        private ucInternationaApplicationInfos ucInternationaApplicationInfos1;
        private System.Windows.Forms.Label lblNewLocalDrivingLicense;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
    }
}