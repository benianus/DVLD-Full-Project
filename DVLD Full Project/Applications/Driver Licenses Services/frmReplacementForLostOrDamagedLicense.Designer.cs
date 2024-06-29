namespace DVLD_Full_Project.Applications.Driver_Licenses_Services
{
    partial class frmReplacementForLostOrDamagedLicense
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
            this.ucReplacementForLostOrDamaged = new DVLD_Full_Project.UserConrols.ucReplacementForLostOrDamaged();
            this.lblReplacementTitle = new System.Windows.Forms.Label();
            this.lklShowLicensesInfos = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblLRApplicationID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lklShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.gbReplacementIssue = new System.Windows.Forms.GroupBox();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.gbReplacementIssue.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucReplacementForLostOrDamaged
            // 
            this.ucReplacementForLostOrDamaged.Location = new System.Drawing.Point(1, 68);
            this.ucReplacementForLostOrDamaged.Name = "ucReplacementForLostOrDamaged";
            this.ucReplacementForLostOrDamaged.Size = new System.Drawing.Size(1029, 463);
            this.ucReplacementForLostOrDamaged.TabIndex = 0;
            this.ucReplacementForLostOrDamaged.onClickSearch += new System.Action<int>(this.ucReplacementForLostOrDamaged1_onClickSearch);
            // 
            // lblReplacementTitle
            // 
            this.lblReplacementTitle.AutoSize = true;
            this.lblReplacementTitle.Font = new System.Drawing.Font("Poppins Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacementTitle.Location = new System.Drawing.Point(217, 14);
            this.lblReplacementTitle.Name = "lblReplacementTitle";
            this.lblReplacementTitle.Size = new System.Drawing.Size(602, 56);
            this.lblReplacementTitle.TabIndex = 12;
            this.lblReplacementTitle.Text = "Replacement for Damaged License";
            // 
            // lklShowLicensesInfos
            // 
            this.lklShowLicensesInfos.AutoSize = true;
            this.lklShowLicensesInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklShowLicensesInfos.Location = new System.Drawing.Point(209, 681);
            this.lklShowLicensesInfos.Name = "lklShowLicensesInfos";
            this.lklShowLicensesInfos.Size = new System.Drawing.Size(156, 20);
            this.lklShowLicensesInfos.TabIndex = 24;
            this.lklShowLicensesInfos.TabStop = true;
            this.lklShowLicensesInfos.Text = "Show Licenses Infos";
            this.lklShowLicensesInfos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklShowLicensesInfos_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCreatedBy);
            this.groupBox1.Controls.Add(this.lblOldLicenseID);
            this.groupBox1.Controls.Add(this.lblReplacedLicenseID);
            this.groupBox1.Controls.Add(this.lblApplicationFees);
            this.groupBox1.Controls.Add(this.lblApplicationDate);
            this.groupBox1.Controls.Add(this.lblLRApplicationID);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 526);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1010, 140);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application New License info";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(647, 99);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(27, 20);
            this.lblCreatedBy.TabIndex = 20;
            this.lblCreatedBy.Text = "??";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.Location = new System.Drawing.Point(647, 62);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(27, 20);
            this.lblOldLicenseID.TabIndex = 18;
            this.lblOldLicenseID.Text = "??";
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.AutoSize = true;
            this.lblReplacedLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(647, 25);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(27, 20);
            this.lblReplacedLicenseID.TabIndex = 17;
            this.lblReplacedLicenseID.Text = "??";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(190, 99);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(27, 20);
            this.lblApplicationFees.TabIndex = 15;
            this.lblApplicationFees.Text = "??";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(190, 62);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(27, 20);
            this.lblApplicationDate.TabIndex = 13;
            this.lblApplicationDate.Text = "??";
            // 
            // lblLRApplicationID
            // 
            this.lblLRApplicationID.AutoSize = true;
            this.lblLRApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLRApplicationID.Location = new System.Drawing.Point(190, 25);
            this.lblLRApplicationID.Name = "lblLRApplicationID";
            this.lblLRApplicationID.Size = new System.Drawing.Size(27, 20);
            this.lblLRApplicationID.TabIndex = 12;
            this.lblLRApplicationID.Text = "??";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(527, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "Created By:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(498, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Old License ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(449, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Replaced License ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Application Fees:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Application Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "L.R.Application ID:";
            // 
            // lklShowLicensesHistory
            // 
            this.lklShowLicensesHistory.AutoSize = true;
            this.lklShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklShowLicensesHistory.Location = new System.Drawing.Point(19, 681);
            this.lklShowLicensesHistory.Name = "lklShowLicensesHistory";
            this.lklShowLicensesHistory.Size = new System.Drawing.Size(169, 20);
            this.lklShowLicensesHistory.TabIndex = 23;
            this.lklShowLicensesHistory.TabStop = true;
            this.lklShowLicensesHistory.Text = "Show Licenses History";
            this.lklShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklShowLicensesHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(882, 676);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 33);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(955, 676);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(67, 33);
            this.btnReplace.TabIndex = 21;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // gbReplacementIssue
            // 
            this.gbReplacementIssue.Controls.Add(this.rbLost);
            this.gbReplacementIssue.Controls.Add(this.rbDamaged);
            this.gbReplacementIssue.Location = new System.Drawing.Point(782, 77);
            this.gbReplacementIssue.Name = "gbReplacementIssue";
            this.gbReplacementIssue.Size = new System.Drawing.Size(240, 71);
            this.gbReplacementIssue.TabIndex = 25;
            this.gbReplacementIssue.TabStop = false;
            this.gbReplacementIssue.Text = "Replacement Reason";
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLost.Location = new System.Drawing.Point(23, 41);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(58, 24);
            this.rbLost.TabIndex = 1;
            this.rbLost.TabStop = true;
            this.rbLost.Text = "Lost";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.rbLost_CheckedChanged);
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDamaged.Location = new System.Drawing.Point(23, 17);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(97, 24);
            this.rbDamaged.TabIndex = 0;
            this.rbDamaged.TabStop = true;
            this.rbDamaged.Text = "Damaged";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.rbDamaged_CheckedChanged);
            // 
            // frmReplacementForLostOrDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 720);
            this.Controls.Add(this.gbReplacementIssue);
            this.Controls.Add(this.lklShowLicensesInfos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lklShowLicensesHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.lblReplacementTitle);
            this.Controls.Add(this.ucReplacementForLostOrDamaged);
            this.Name = "frmReplacementForLostOrDamagedLicense";
            this.Text = "frmReplacementForLostOrDamagedLicense";
            this.Load += new System.EventHandler(this.frmReplacementForLostOrDamagedLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbReplacementIssue.ResumeLayout(false);
            this.gbReplacementIssue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserConrols.ucReplacementForLostOrDamaged ucReplacementForLostOrDamaged;
        private System.Windows.Forms.Label lblReplacementTitle;
        private System.Windows.Forms.LinkLabel lklShowLicensesInfos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblLRApplicationID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lklShowLicensesHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.GroupBox gbReplacementIssue;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.RadioButton rbDamaged;
    }
}