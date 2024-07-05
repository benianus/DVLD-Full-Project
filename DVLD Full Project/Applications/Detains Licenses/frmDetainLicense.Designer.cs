namespace DVLD_Full_Project.Applications.Detains_Licenses
{
    partial class frmDetainLicense
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lklShowLicensesInfos = new System.Windows.Forms.LinkLabel();
            this.gbDetainInfos = new System.Windows.Forms.GroupBox();
            this.txtFineFees = new System.Windows.Forms.TextBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lklShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.ucDetainLicense = new DVLD_Full_Project.UserConrols.ucDetainLicense();
            this.gbDetainInfos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Poppins Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(342, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(267, 56);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Detain License";
            // 
            // lklShowLicensesInfos
            // 
            this.lklShowLicensesInfos.AutoSize = true;
            this.lklShowLicensesInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklShowLicensesInfos.Location = new System.Drawing.Point(209, 669);
            this.lklShowLicensesInfos.Name = "lklShowLicensesInfos";
            this.lklShowLicensesInfos.Size = new System.Drawing.Size(156, 20);
            this.lklShowLicensesInfos.TabIndex = 29;
            this.lklShowLicensesInfos.TabStop = true;
            this.lklShowLicensesInfos.Text = "Show Licenses Infos";
            this.lklShowLicensesInfos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklShowLicensesInfos_LinkClicked);
            // 
            // gbDetainInfos
            // 
            this.gbDetainInfos.Controls.Add(this.txtFineFees);
            this.gbDetainInfos.Controls.Add(this.lblCreatedBy);
            this.gbDetainInfos.Controls.Add(this.lblLicenseID);
            this.gbDetainInfos.Controls.Add(this.lblDetainDate);
            this.gbDetainInfos.Controls.Add(this.lblDetainID);
            this.gbDetainInfos.Controls.Add(this.label10);
            this.gbDetainInfos.Controls.Add(this.label7);
            this.gbDetainInfos.Controls.Add(this.label4);
            this.gbDetainInfos.Controls.Add(this.label2);
            this.gbDetainInfos.Controls.Add(this.label1);
            this.gbDetainInfos.Location = new System.Drawing.Point(14, 512);
            this.gbDetainInfos.Name = "gbDetainInfos";
            this.gbDetainInfos.Size = new System.Drawing.Size(946, 140);
            this.gbDetainInfos.TabIndex = 25;
            this.gbDetainInfos.TabStop = false;
            this.gbDetainInfos.Text = "Detain Infos";
            // 
            // txtFineFees
            // 
            this.txtFineFees.Location = new System.Drawing.Point(139, 98);
            this.txtFineFees.Name = "txtFineFees";
            this.txtFineFees.Size = new System.Drawing.Size(172, 20);
            this.txtFineFees.TabIndex = 21;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(648, 62);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(27, 20);
            this.lblCreatedBy.TabIndex = 20;
            this.lblCreatedBy.Text = "??";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.Location = new System.Drawing.Point(647, 25);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(27, 20);
            this.lblLicenseID.TabIndex = 17;
            this.lblLicenseID.Text = "??";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.Location = new System.Drawing.Point(137, 62);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(27, 20);
            this.lblDetainDate.TabIndex = 13;
            this.lblDetainDate.Text = "??";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainID.Location = new System.Drawing.Point(137, 25);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(27, 20);
            this.lblDetainID.TabIndex = 12;
            this.lblDetainID.Text = "??";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(528, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "Created By:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(531, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "License ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fine Fees:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Detain Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detain ID:";
            // 
            // lklShowLicensesHistory
            // 
            this.lklShowLicensesHistory.AutoSize = true;
            this.lklShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklShowLicensesHistory.Location = new System.Drawing.Point(19, 669);
            this.lklShowLicensesHistory.Name = "lklShowLicensesHistory";
            this.lklShowLicensesHistory.Size = new System.Drawing.Size(169, 20);
            this.lklShowLicensesHistory.TabIndex = 28;
            this.lklShowLicensesHistory.TabStop = true;
            this.lklShowLicensesHistory.Text = "Show Licenses History";
            this.lklShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklShowLicensesHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(815, 660);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 33);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.Location = new System.Drawing.Point(888, 660);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(67, 33);
            this.btnDetain.TabIndex = 26;
            this.btnDetain.Text = "Detain";
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // ucDetainLicense
            // 
            this.ucDetainLicense.Location = new System.Drawing.Point(2, 56);
            this.ucDetainLicense.Name = "ucDetainLicense";
            this.ucDetainLicense.Size = new System.Drawing.Size(967, 464);
            this.ucDetainLicense.TabIndex = 0;
            this.ucDetainLicense.onClickSearch += new System.Action<int>(this.ucDetainLicense1_onClickSearch);
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(976, 701);
            this.Controls.Add(this.lklShowLicensesInfos);
            this.Controls.Add(this.gbDetainInfos);
            this.Controls.Add(this.lklShowLicensesHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ucDetainLicense);
            this.Name = "frmDetainLicense";
            this.Text = "frmDetainLicnese";
            this.Load += new System.EventHandler(this.frmDetainLicnese_Load);
            this.gbDetainInfos.ResumeLayout(false);
            this.gbDetainInfos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserConrols.ucDetainLicense ucDetainLicense;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel lklShowLicensesInfos;
        private System.Windows.Forms.GroupBox gbDetainInfos;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lklShowLicensesHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFineFees;
    }
}