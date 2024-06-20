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
            this.SuspendLayout();
            // 
            // ucSearchInternationalLicenseApplication1
            // 
            this.ucSearchInternationalLicenseApplication1.Location = new System.Drawing.Point(12, 23);
            this.ucSearchInternationalLicenseApplication1.Name = "ucSearchInternationalLicenseApplication1";
            this.ucSearchInternationalLicenseApplication1.Size = new System.Drawing.Size(150, 150);
            this.ucSearchInternationalLicenseApplication1.TabIndex = 0;
            // 
            // frmAddInternationalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucSearchInternationalLicenseApplication1);
            this.Name = "frmAddInternationalLicenseApplication";
            this.Text = "frmAddInternationalLicenseApplication";
            this.Load += new System.EventHandler(this.frmAddInternationalLicenseApplication_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucSearchInternationalLicenseApplication ucSearchInternationalLicenseApplication1;
    }
}