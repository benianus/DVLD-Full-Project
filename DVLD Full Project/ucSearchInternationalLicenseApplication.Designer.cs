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
            this.ucDriverLicenseInfo1 = new DVLD_Full_Project.ucDriverLicenseInfo();
            this.SuspendLayout();
            // 
            // ucDriverLicenseInfo1
            // 
            this.ucDriverLicenseInfo1.Location = new System.Drawing.Point(7, 96);
            this.ucDriverLicenseInfo1.Name = "ucDriverLicenseInfo1";
            this.ucDriverLicenseInfo1.Size = new System.Drawing.Size(954, 373);
            this.ucDriverLicenseInfo1.TabIndex = 0;
            // 
            // ucSearchInternationalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucDriverLicenseInfo1);
            this.Name = "ucSearchInternationalLicenseApplication";
            this.Size = new System.Drawing.Size(965, 559);
            this.ResumeLayout(false);

        }

        #endregion

        private ucDriverLicenseInfo ucDriverLicenseInfo1;
    }
}
