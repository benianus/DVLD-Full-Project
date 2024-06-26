namespace DVLD_Full_Project.Licenses
{
    partial class frmShowInternationalLicenseInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.ucDriverInternationalLicenseInfos1 = new DVLD_Full_Project.ucDriverInternationalLicenseInfos();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(495, 48);
            this.label1.TabIndex = 3;
            this.label1.Text = "Driver International License Infos";
            // 
            // ucDriverInternationalLicenseInfos1
            // 
            this.ucDriverInternationalLicenseInfos1.Location = new System.Drawing.Point(2, 60);
            this.ucDriverInternationalLicenseInfos1.Name = "ucDriverInternationalLicenseInfos1";
            this.ucDriverInternationalLicenseInfos1.Size = new System.Drawing.Size(962, 293);
            this.ucDriverInternationalLicenseInfos1.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(879, 354);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 37);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowInternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 406);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucDriverInternationalLicenseInfos1);
            this.Controls.Add(this.label1);
            this.Name = "frmShowInternationalLicenseInfo";
            this.Text = "frmShowInternationalLicenseInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ucDriverInternationalLicenseInfos ucDriverInternationalLicenseInfos1;
        private System.Windows.Forms.Button btnClose;
    }
}