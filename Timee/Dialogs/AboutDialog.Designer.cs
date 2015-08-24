namespace Timee.Dialogs
{
    partial class AboutDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.picTimee = new System.Windows.Forms.PictureBox();
            this.linkToProject = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkHints = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTimee)).BeginInit();
            this.SuspendLayout();
            // 
            // picTimee
            // 
            this.picTimee.Image = global::Timee.Properties.Resources.TimeeTransparent;
            this.picTimee.InitialImage = null;
            this.picTimee.Location = new System.Drawing.Point(12, 12);
            this.picTimee.Name = "picTimee";
            this.picTimee.Size = new System.Drawing.Size(210, 228);
            this.picTimee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTimee.TabIndex = 0;
            this.picTimee.TabStop = false;
            // 
            // linkToProject
            // 
            this.linkToProject.AutoSize = true;
            this.linkToProject.Location = new System.Drawing.Point(10, 265);
            this.linkToProject.Name = "linkToProject";
            this.linkToProject.Size = new System.Drawing.Size(199, 13);
            this.linkToProject.TabIndex = 1;
            this.linkToProject.TabStop = true;
            this.linkToProject.Text = "https://github.com/marcingolenia/Timee";
            this.linkToProject.Click += new System.EventHandler(this.linkToProject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time monitoring application.";
            // 
            // chkHints
            // 
            this.chkHints.AutoSize = true;
            this.chkHints.Location = new System.Drawing.Point(12, 284);
            this.chkHints.Name = "chkHints";
            this.chkHints.Size = new System.Drawing.Size(80, 17);
            this.chkHints.TabIndex = 3;
            this.chkHints.Text = "Show Hints";
            this.chkHints.UseVisualStyleBackColor = true;
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 306);
            this.Controls.Add(this.chkHints);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkToProject);
            this.Controls.Add(this.picTimee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AboutDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTimee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AboutDialog_FormClosing);
        }
        #endregion

        private System.Windows.Forms.PictureBox picTimee;
        private System.Windows.Forms.LinkLabel linkToProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkHints;
    }
}