namespace DVLD_Full_Project.Applications.Manage_Applications.Local_Driving_License_Applications
{
    partial class frmLocalDrivingLicenseApplications
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.lblRecordsNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.dgvLocalLicenseApplcations = new System.Windows.Forms.DataGridView();
            this.cmsLDLApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSechduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSechduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSechduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSechduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmIssueDrivingLicenseFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatusFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseApplcations)).BeginInit();
            this.cmsLDLApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(985, 432);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 37);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(904, 77);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 37);
            this.btnHome.TabIndex = 20;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Location = new System.Drawing.Point(264, 85);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(151, 20);
            this.txtFilterBy.TabIndex = 19;
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            // 
            // btnAddNew
            // 
            this.btnAddNew.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddNew.Location = new System.Drawing.Point(985, 77);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 37);
            this.btnAddNew.TabIndex = 18;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // lblRecordsNumber
            // 
            this.lblRecordsNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecordsNumber.AutoSize = true;
            this.lblRecordsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNumber.Location = new System.Drawing.Point(99, 442);
            this.lblRecordsNumber.Name = "lblRecordsNumber";
            this.lblRecordsNumber.Size = new System.Drawing.Size(14, 16);
            this.lblRecordsNumber.TabIndex = 17;
            this.lblRecordsNumber.Text = "?";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 442);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "#Records:";
            // 
            // cbFilters
            // 
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Location = new System.Drawing.Point(87, 85);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(171, 21);
            this.cbFilters.TabIndex = 15;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // dgvLocalLicenseApplcations
            // 
            this.dgvLocalLicenseApplcations.AllowUserToAddRows = false;
            this.dgvLocalLicenseApplcations.AllowUserToDeleteRows = false;
            this.dgvLocalLicenseApplcations.AllowUserToOrderColumns = true;
            this.dgvLocalLicenseApplcations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocalLicenseApplcations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLocalLicenseApplcations.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLocalLicenseApplcations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenseApplcations.ContextMenuStrip = this.cmsLDLApplications;
            this.dgvLocalLicenseApplcations.Location = new System.Drawing.Point(12, 120);
            this.dgvLocalLicenseApplcations.Name = "dgvLocalLicenseApplcations";
            this.dgvLocalLicenseApplcations.ReadOnly = true;
            this.dgvLocalLicenseApplcations.Size = new System.Drawing.Size(1048, 306);
            this.dgvLocalLicenseApplcations.TabIndex = 14;
            // 
            // cmsLDLApplications
            // 
            this.cmsLDLApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowApplicationDetails,
            this.toolStripSeparator1,
            this.tsmEditApplication,
            this.tsmDeleteApplication,
            this.tsmCancelApplication,
            this.toolStripSeparator2,
            this.tsmSechduleTests,
            this.toolStripSeparator3,
            this.tsmIssueDrivingLicenseFirstTime,
            this.toolStripSeparator4,
            this.tsmShowLicense,
            this.toolStripSeparator5,
            this.tsmShowPersonLicenseHistory});
            this.cmsLDLApplications.Name = "cmsLDLApplications";
            this.cmsLDLApplications.Size = new System.Drawing.Size(246, 210);
            this.cmsLDLApplications.Text = "Local Driving Licenses";
            this.cmsLDLApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLDLApplications_Opening);
            // 
            // tsmShowApplicationDetails
            // 
            this.tsmShowApplicationDetails.Name = "tsmShowApplicationDetails";
            this.tsmShowApplicationDetails.Size = new System.Drawing.Size(245, 22);
            this.tsmShowApplicationDetails.Text = "Show Application Details";
            this.tsmShowApplicationDetails.Click += new System.EventHandler(this.tsmShowApplicationDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmEditApplication
            // 
            this.tsmEditApplication.Name = "tsmEditApplication";
            this.tsmEditApplication.Size = new System.Drawing.Size(245, 22);
            this.tsmEditApplication.Text = "Edit Application";
            this.tsmEditApplication.Click += new System.EventHandler(this.tsmEditApplication_Click);
            // 
            // tsmDeleteApplication
            // 
            this.tsmDeleteApplication.Name = "tsmDeleteApplication";
            this.tsmDeleteApplication.Size = new System.Drawing.Size(245, 22);
            this.tsmDeleteApplication.Text = "Delete Application";
            this.tsmDeleteApplication.Click += new System.EventHandler(this.tsmDeleteApplication_Click);
            // 
            // tsmCancelApplication
            // 
            this.tsmCancelApplication.Name = "tsmCancelApplication";
            this.tsmCancelApplication.Size = new System.Drawing.Size(245, 22);
            this.tsmCancelApplication.Text = "Cancel Application";
            this.tsmCancelApplication.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmSechduleTests
            // 
            this.tsmSechduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSechduleVisionTest,
            this.tsmSechduleWrittenTest,
            this.tsmSechduleStreetTest});
            this.tsmSechduleTests.Name = "tsmSechduleTests";
            this.tsmSechduleTests.Size = new System.Drawing.Size(245, 22);
            this.tsmSechduleTests.Text = "Sechdule Tests";
            // 
            // tsmSechduleVisionTest
            // 
            this.tsmSechduleVisionTest.Name = "tsmSechduleVisionTest";
            this.tsmSechduleVisionTest.Size = new System.Drawing.Size(184, 22);
            this.tsmSechduleVisionTest.Text = "Sechdule Vision Test";
            this.tsmSechduleVisionTest.Click += new System.EventHandler(this.sechdulteVisionTestToolStripMenuItem_Click);
            // 
            // tsmSechduleWrittenTest
            // 
            this.tsmSechduleWrittenTest.Name = "tsmSechduleWrittenTest";
            this.tsmSechduleWrittenTest.Size = new System.Drawing.Size(184, 22);
            this.tsmSechduleWrittenTest.Text = "Sechdule WrittenTest";
            this.tsmSechduleWrittenTest.Click += new System.EventHandler(this.tsmSechduleWrittenTest_Click);
            // 
            // tsmSechduleStreetTest
            // 
            this.tsmSechduleStreetTest.Name = "tsmSechduleStreetTest";
            this.tsmSechduleStreetTest.Size = new System.Drawing.Size(184, 22);
            this.tsmSechduleStreetTest.Text = "Sechdule Street Test";
            this.tsmSechduleStreetTest.Click += new System.EventHandler(this.tsmSechduleStreetTest_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmIssueDrivingLicenseFirstTime
            // 
            this.tsmIssueDrivingLicenseFirstTime.Name = "tsmIssueDrivingLicenseFirstTime";
            this.tsmIssueDrivingLicenseFirstTime.Size = new System.Drawing.Size(245, 22);
            this.tsmIssueDrivingLicenseFirstTime.Text = "Issue Driving License (First Time)";
            this.tsmIssueDrivingLicenseFirstTime.Click += new System.EventHandler(this.tsmIssueDrivingLicenseFirstTime_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmShowLicense
            // 
            this.tsmShowLicense.Name = "tsmShowLicense";
            this.tsmShowLicense.Size = new System.Drawing.Size(245, 22);
            this.tsmShowLicense.Text = "Show License";
            this.tsmShowLicense.Click += new System.EventHandler(this.tsmShowLicense_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmShowPersonLicenseHistory
            // 
            this.tsmShowPersonLicenseHistory.Name = "tsmShowPersonLicenseHistory";
            this.tsmShowPersonLicenseHistory.Size = new System.Drawing.Size(245, 22);
            this.tsmShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmShowPersonLicenseHistory_Click);
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBy.Location = new System.Drawing.Point(24, 87);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(57, 16);
            this.lblFilterBy.TabIndex = 13;
            this.lblFilterBy.Text = "Filter by:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(241, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(591, 56);
            this.label1.TabIndex = 12;
            this.label1.Text = "Local Driving License Applications";
            // 
            // cbStatusFilter
            // 
            this.cbStatusFilter.FormattingEnabled = true;
            this.cbStatusFilter.Items.AddRange(new object[] {
            "All",
            "Completed",
            "New",
            "Cancelled"});
            this.cbStatusFilter.Location = new System.Drawing.Point(264, 85);
            this.cbStatusFilter.Name = "cbStatusFilter";
            this.cbStatusFilter.Size = new System.Drawing.Size(114, 21);
            this.cbStatusFilter.TabIndex = 22;
            this.cbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cbStatusFilter_SelectedIndexChanged);
            // 
            // frmLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1067, 472);
            this.Controls.Add(this.cbStatusFilter);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.lblRecordsNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilters);
            this.Controls.Add(this.dgvLocalLicenseApplcations);
            this.Controls.Add(this.lblFilterBy);
            this.Controls.Add(this.label1);
            this.Name = "frmLocalDrivingLicenseApplications";
            this.Text = "frmLocalDrivingLicenseApplications";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseApplcations)).EndInit();
            this.cmsLDLApplications.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label lblRecordsNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.DataGridView dgvLocalLicenseApplcations;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStatusFilter;
        private System.Windows.Forms.ContextMenuStrip cmsLDLApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmShowApplicationDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmEditApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmCancelApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmSechduleTests;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmIssueDrivingLicenseFirstTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmSechduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem tsmSechduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem tsmSechduleStreetTest;
    }
}