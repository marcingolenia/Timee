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
            ((System.ComponentModel.ISupportInitialize)(this.picTimee)).BeginInit();
            this.SuspendLayout();
            // 
            // picTimee
            // 
            this.picTimee.Image = global::Timee.Properties.Resources.TimeeTransparent;
            this.picTimee.InitialImage = null;
            this.picTimee.Location = new System.Drawing.Point(16, 15);
            this.picTimee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picTimee.Name = "picTimee";
            this.picTimee.Size = new System.Drawing.Size(280, 280);
            this.picTimee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTimee.TabIndex = 0;
            this.picTimee.TabStop = false;
            // 
            // linkToProject
            // 
            this.linkToProject.AutoSize = true;
            this.linkToProject.Location = new System.Drawing.Point(13, 326);
            this.linkToProject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkToProject.Name = "linkToProject";
            this.linkToProject.Size = new System.Drawing.Size(255, 17);
            this.linkToProject.TabIndex = 1;
            this.linkToProject.TabStop = true;
            this.linkToProject.Text = "https://github.com/marcingolenia/Timee";
            this.linkToProject.Click += new System.EventHandler(this.linkToProject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 299);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time monitoring application.";
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 354);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkToProject);
            this.Controls.Add(this.picTimee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "AboutDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.picTimee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picTimee;
        private System.Windows.Forms.LinkLabel linkToProject;
        private System.Windows.Forms.Label label1;
    }
}