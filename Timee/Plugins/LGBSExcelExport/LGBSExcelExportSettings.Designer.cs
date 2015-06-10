namespace Timee.Plugins.LGBSExcelExport
{
    partial class ExcelExportSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelExportSettings));
            this.txtPerson = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbIsCreative = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPerson
            // 
            this.txtPerson.Location = new System.Drawing.Point(99, 56);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(161, 20);
            this.txtPerson.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Additional columns constant values for excel export";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Person: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Is creative:";
            // 
            // cmbIsCreative
            // 
            this.cmbIsCreative.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsCreative.FormattingEnabled = true;
            this.cmbIsCreative.Location = new System.Drawing.Point(99, 82);
            this.cmbIsCreative.Name = "cmbIsCreative";
            this.cmbIsCreative.Size = new System.Drawing.Size(161, 21);
            this.cmbIsCreative.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 123);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ExcelExportSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 158);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbIsCreative);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPerson);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcelExportSettings";
            this.Text = "Excel export settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPerson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbIsCreative;
        private System.Windows.Forms.Button btnOk;
    }
}