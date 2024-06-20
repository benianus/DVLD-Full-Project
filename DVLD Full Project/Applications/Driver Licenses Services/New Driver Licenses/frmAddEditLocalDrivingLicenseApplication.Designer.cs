namespace DVLD_Full_Project.Applications.Driver_Licenses_Services.New_Driver_Licenses
{
    partial class frmAddEditLocalDrivingLicenseApplication
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
            this.components = new System.ComponentModel.Container();
            this.epAddUpdateUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.ucAddUpdateUser1 = new DVLD_Full_Project.ucAddUpdateUser();
            this.btnNext = new System.Windows.Forms.Button();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.lblNewLocalDrivingLicense = new System.Windows.Forms.Label();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.tpPeronalApplicationInfo = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDLApplicationiD = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblApplicatonFees = new System.Windows.Forms.Label();
            this.lblCreateBy = new System.Windows.Forms.Label();
            this.cbLicsenseClass = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.epAddUpdateUser)).BeginInit();
            this.tpPersonalInfo.SuspendLayout();
            this.tpApplicationInfo.SuspendLayout();
            this.tpPeronalApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // epAddUpdateUser
            // 
            this.epAddUpdateUser.ContainerControl = this;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(625, 569);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 38);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(733, 569);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 38);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(720, 423);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(102, 38);
            this.btnPrevious.TabIndex = 9;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // ucAddUpdateUser1
            // 
            this.ucAddUpdateUser1.Location = new System.Drawing.Point(8, 8);
            this.ucAddUpdateUser1.Name = "ucAddUpdateUser1";
            this.ucAddUpdateUser1.Size = new System.Drawing.Size(849, 422);
            this.ucAddUpdateUser1.TabIndex = 2;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(720, 432);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(102, 38);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.Controls.Add(this.ucAddUpdateUser1);
            this.tpPersonalInfo.Controls.Add(this.btnNext);
            this.tpPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInfo.Size = new System.Drawing.Size(867, 476);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Personal info";
            this.tpPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // lblNewLocalDrivingLicense
            // 
            this.lblNewLocalDrivingLicense.AutoSize = true;
            this.lblNewLocalDrivingLicense.Font = new System.Drawing.Font("Poppins Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewLocalDrivingLicense.Location = new System.Drawing.Point(106, 7);
            this.lblNewLocalDrivingLicense.Name = "lblNewLocalDrivingLicense";
            this.lblNewLocalDrivingLicense.Size = new System.Drawing.Size(670, 56);
            this.lblNewLocalDrivingLicense.TabIndex = 9;
            this.lblNewLocalDrivingLicense.Text = "New Local Driving Licsense Application";
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.Controls.Add(this.cbLicsenseClass);
            this.tpApplicationInfo.Controls.Add(this.lblCreateBy);
            this.tpApplicationInfo.Controls.Add(this.lblApplicatonFees);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tpApplicationInfo.Controls.Add(this.lblDLApplicationiD);
            this.tpApplicationInfo.Controls.Add(this.label5);
            this.tpApplicationInfo.Controls.Add(this.label4);
            this.tpApplicationInfo.Controls.Add(this.label3);
            this.tpApplicationInfo.Controls.Add(this.label2);
            this.tpApplicationInfo.Controls.Add(this.label1);
            this.tpApplicationInfo.Controls.Add(this.btnPrevious);
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplicationInfo.Size = new System.Drawing.Size(867, 476);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "Application info";
            this.tpApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // tpPeronalApplicationInfo
            // 
            this.tpPeronalApplicationInfo.Controls.Add(this.tpPersonalInfo);
            this.tpPeronalApplicationInfo.Controls.Add(this.tpApplicationInfo);
            this.tpPeronalApplicationInfo.Location = new System.Drawing.Point(9, 61);
            this.tpPeronalApplicationInfo.Name = "tpPeronalApplicationInfo";
            this.tpPeronalApplicationInfo.SelectedIndex = 0;
            this.tpPeronalApplicationInfo.Size = new System.Drawing.Size(875, 502);
            this.tpPeronalApplicationInfo.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "D.L.Application ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Application Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "License Class:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Application Fees:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(101, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "Created By:";
            // 
            // lblDLApplicationiD
            // 
            this.lblDLApplicationiD.AutoSize = true;
            this.lblDLApplicationiD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLApplicationiD.Location = new System.Drawing.Point(237, 64);
            this.lblDLApplicationiD.Name = "lblDLApplicationiD";
            this.lblDLApplicationiD.Size = new System.Drawing.Size(30, 24);
            this.lblDLApplicationiD.TabIndex = 15;
            this.lblDLApplicationiD.Text = "??";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(237, 108);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(30, 24);
            this.lblApplicationDate.TabIndex = 16;
            this.lblApplicationDate.Text = "??";
            // 
            // lblApplicatonFees
            // 
            this.lblApplicatonFees.AutoSize = true;
            this.lblApplicatonFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicatonFees.Location = new System.Drawing.Point(237, 196);
            this.lblApplicatonFees.Name = "lblApplicatonFees";
            this.lblApplicatonFees.Size = new System.Drawing.Size(30, 24);
            this.lblApplicatonFees.TabIndex = 17;
            this.lblApplicatonFees.Text = "??";
            // 
            // lblCreateBy
            // 
            this.lblCreateBy.AutoSize = true;
            this.lblCreateBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateBy.Location = new System.Drawing.Point(237, 240);
            this.lblCreateBy.Name = "lblCreateBy";
            this.lblCreateBy.Size = new System.Drawing.Size(30, 24);
            this.lblCreateBy.TabIndex = 18;
            this.lblCreateBy.Text = "??";
            // 
            // cbLicsenseClass
            // 
            this.cbLicsenseClass.FormattingEnabled = true;
            this.cbLicsenseClass.Location = new System.Drawing.Point(237, 154);
            this.cbLicsenseClass.Name = "cbLicsenseClass";
            this.cbLicsenseClass.Size = new System.Drawing.Size(215, 21);
            this.cbLicsenseClass.TabIndex = 19;
            // 
            // frmAddNewLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 617);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblNewLocalDrivingLicense);
            this.Controls.Add(this.tpPeronalApplicationInfo);
            this.Name = "frmAddNewLocalDrivingLicenseApplication";
            this.Text = "frmAddNewLocalDrivingLicense";
            this.Load += new System.EventHandler(this.frmAddNewLocalDrivingLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epAddUpdateUser)).EndInit();
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpApplicationInfo.ResumeLayout(false);
            this.tpApplicationInfo.PerformLayout();
            this.tpPeronalApplicationInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider epAddUpdateUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblNewLocalDrivingLicense;
        private System.Windows.Forms.TabControl tpPeronalApplicationInfo;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private ucAddUpdateUser ucAddUpdateUser1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.ComboBox cbLicsenseClass;
        private System.Windows.Forms.Label lblCreateBy;
        private System.Windows.Forms.Label lblApplicatonFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblDLApplicationiD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}