namespace DVLD_Full_Project
{
    partial class frmUserInfo
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
            this.ucPersonLoginInfo1 = new DVLD_Full_Project.ucPersonLoginInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucPersonLoginInfo1
            // 
            this.ucPersonLoginInfo1.Location = new System.Drawing.Point(3, 2);
            this.ucPersonLoginInfo1.Name = "ucPersonLoginInfo1";
            this.ucPersonLoginInfo1.Size = new System.Drawing.Size(825, 406);
            this.ucPersonLoginInfo1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(724, 414);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(840, 462);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucPersonLoginInfo1);
            this.Name = "frmUserInfo";
            this.Text = "frmUserInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private ucPersonLoginInfo ucPersonLoginInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}