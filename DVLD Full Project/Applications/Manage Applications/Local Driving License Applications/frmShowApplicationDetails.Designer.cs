namespace DVLD_Full_Project.Applications.Manage_Applications.Local_Driving_License_Applications
{
    partial class frmShowApplicationDetails
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
            this.ucTestAppointments1 = new DVLD_Full_Project.ucTestAppointments();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 56);
            this.label1.TabIndex = 13;
            this.label1.Text = "Application Details";
            // 
            // ucTestAppointments1
            // 
            this.ucTestAppointments1.Location = new System.Drawing.Point(12, 59);
            this.ucTestAppointments1.Name = "ucTestAppointments1";
            this.ucTestAppointments1.Size = new System.Drawing.Size(763, 349);
            this.ucTestAppointments1.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(698, 406);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 37);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowApplicationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucTestAppointments1);
            this.Controls.Add(this.label1);
            this.Name = "frmShowApplicationDetails";
            this.Text = "frmShowApplicationDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ucTestAppointments ucTestAppointments1;
        private System.Windows.Forms.Button btnClose;
    }
}