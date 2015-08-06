namespace Timesheet
{
    partial class ImportDialog
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
            this.chlProjects = new System.Windows.Forms.CheckedListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkSelected = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chlProjects
            // 
            this.chlProjects.FormattingEnabled = true;
            this.chlProjects.Location = new System.Drawing.Point(25, 58);
            this.chlProjects.Name = "chlProjects";
            this.chlProjects.Size = new System.Drawing.Size(229, 154);
            this.chlProjects.Sorted = true;
            this.chlProjects.TabIndex = 0;
            this.chlProjects.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chlProjects_ItemCheck);
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(82, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(2, 39);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(74, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Project Name:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(210, 238);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkSelected
            // 
            this.chkSelected.AutoSize = true;
            this.chkSelected.Location = new System.Drawing.Point(187, 32);
            this.chkSelected.Name = "chkSelected";
            this.chkSelected.Size = new System.Drawing.Size(98, 17);
            this.chkSelected.TabIndex = 4;
            this.chkSelected.Text = "Show Selected";
            this.chkSelected.UseVisualStyleBackColor = true;
            this.chkSelected.CheckedChanged += new System.EventHandler(this.chkSelected_CheckedChanged);
            // 
            // ImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.chkSelected);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.chlProjects);
            this.Name = "ImportDialog";
            this.Text = "ImportDialog";
            this.Load += new System.EventHandler(this.ImportDialog_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImportDialog_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion

        private System.Windows.Forms.CheckedListBox chlProjects;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkSelected;
    }
}