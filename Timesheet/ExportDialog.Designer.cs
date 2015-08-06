namespace Timesheet
{
    partial class ExportDialog
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
            this.lblCreative = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbCreative = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCreative
            // 
            this.lblCreative.AutoSize = true;
            this.lblCreative.Location = new System.Drawing.Point(25, 42);
            this.lblCreative.Name = "lblCreative";
            this.lblCreative.Size = new System.Drawing.Size(57, 13);
            this.lblCreative.TabIndex = 0;
            this.lblCreative.Text = "IsCreative:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(25, 81);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status:";
            // 
            // cbCreative
            // 
            this.cbCreative.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCreative.FormattingEnabled = true;
            this.cbCreative.Location = new System.Drawing.Point(114, 39);
            this.cbCreative.Name = "cbCreative";
            this.cbCreative.Size = new System.Drawing.Size(121, 21);
            this.cbCreative.TabIndex = 2;
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(114, 73);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(197, 112);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ExportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 147);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbCreative);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCreative);
            this.Name = "ExportDialog";
            this.Text = "ExportDialog";
            this.Load += new System.EventHandler(this.ExportDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCreative;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbCreative;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnOk;
    }
}