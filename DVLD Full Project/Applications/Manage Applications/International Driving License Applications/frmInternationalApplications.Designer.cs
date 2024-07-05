namespace DVLD_Full_Project.Applications.Manage_Applications.International_Driving_License_Applications
{
    partial class frmInternationalApplications
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
            this.dgvInternationlLicenseApplcations = new System.Windows.Forms.DataGridView();
            this.cmsInternationalApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationlLicenseApplcations)).BeginInit();
            this.cmsInternationalApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(985, 442);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 37);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(904, 87);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 37);
            this.btnHome.TabIndex = 31;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Location = new System.Drawing.Point(264, 95);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(151, 20);
            this.txtFilterBy.TabIndex = 30;
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            // 
            // btnAddNew
            // 
            this.btnAddNew.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddNew.Location = new System.Drawing.Point(985, 87);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 37);
            this.btnAddNew.TabIndex = 29;
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
            this.lblRecordsNumber.Location = new System.Drawing.Point(99, 452);
            this.lblRecordsNumber.Name = "lblRecordsNumber";
            this.lblRecordsNumber.Size = new System.Drawing.Size(14, 16);
            this.lblRecordsNumber.TabIndex = 28;
            this.lblRecordsNumber.Text = "?";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "#Records:";
            // 
            // cbFilters
            // 
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Location = new System.Drawing.Point(87, 95);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(171, 21);
            this.cbFilters.TabIndex = 26;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // dgvInternationlLicenseApplcations
            // 
            this.dgvInternationlLicenseApplcations.AllowUserToAddRows = false;
            this.dgvInternationlLicenseApplcations.AllowUserToDeleteRows = false;
            this.dgvInternationlLicenseApplcations.AllowUserToOrderColumns = true;
            this.dgvInternationlLicenseApplcations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInternationlLicenseApplcations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInternationlLicenseApplcations.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInternationlLicenseApplcations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationlLicenseApplcations.ContextMenuStrip = this.cmsInternationalApplications;
            this.dgvInternationlLicenseApplcations.Location = new System.Drawing.Point(12, 130);
            this.dgvInternationlLicenseApplcations.Name = "dgvInternationlLicenseApplcations";
            this.dgvInternationlLicenseApplcations.ReadOnly = true;
            this.dgvInternationlLicenseApplcations.Size = new System.Drawing.Size(1053, 306);
            this.dgvInternationlLicenseApplcations.TabIndex = 25;
            // 
            // cmsInternationalApplications
            // 
            this.cmsInternationalApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPersonDetails,
            this.tsLicenseDetails,
            this.tsLicenseHistory});
            this.cmsInternationalApplications.Name = "cmsInternationalApplications";
            this.cmsInternationalApplications.Size = new System.Drawing.Size(226, 70);
            // 
            // tsPersonDetails
            // 
            this.tsPersonDetails.Name = "tsPersonDetails";
            this.tsPersonDetails.Size = new System.Drawing.Size(225, 22);
            this.tsPersonDetails.Text = "Show Person Details";
            this.tsPersonDetails.Click += new System.EventHandler(this.tsPersonDetails_Click);
            // 
            // tsLicenseDetails
            // 
            this.tsLicenseDetails.Name = "tsLicenseDetails";
            this.tsLicenseDetails.Size = new System.Drawing.Size(225, 22);
            this.tsLicenseDetails.Text = "Show License Details";
            this.tsLicenseDetails.Click += new System.EventHandler(this.tsLicenseDetails_Click);
            // 
            // tsLicenseHistory
            // 
            this.tsLicenseHistory.Name = "tsLicenseHistory";
            this.tsLicenseHistory.Size = new System.Drawing.Size(225, 22);
            this.tsLicenseHistory.Text = "Show Person License History";
            this.tsLicenseHistory.Click += new System.EventHandler(this.tsLicenseHistory_Click);
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBy.Location = new System.Drawing.Point(24, 97);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(57, 16);
            this.lblFilterBy.TabIndex = 24;
            this.lblFilterBy.Text = "Filter by:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(175, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(727, 56);
            this.label1.TabIndex = 23;
            this.label1.Text = "International Driving License Applications";
            // 
            // frmInternationalApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1077, 488);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.lblRecordsNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilters);
            this.Controls.Add(this.dgvInternationlLicenseApplcations);
            this.Controls.Add(this.lblFilterBy);
            this.Controls.Add(this.label1);
            this.Name = "frmInternationalApplications";
            this.Text = "frmInternationalApplications";
            this.Load += new System.EventHandler(this.frmInternationalApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationlLicenseApplcations)).EndInit();
            this.cmsInternationalApplications.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dgvInternationlLicenseApplcations;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalApplications;
        private System.Windows.Forms.ToolStripMenuItem tsPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem tsLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem tsLicenseHistory;
    }
}