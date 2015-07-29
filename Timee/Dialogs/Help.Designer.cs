namespace Timee.Dialogs
{
    partial class Help
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
            this.linkNext = new System.Windows.Forms.LinkLabel();
            this.linkPrev = new System.Windows.Forms.LinkLabel();
            this.lblCurrentHint = new System.Windows.Forms.Label();
            this.chkGoAway = new System.Windows.Forms.CheckBox();
            this.wbHints = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // linkNext
            // 
            this.linkNext.AutoSize = true;
            this.linkNext.LinkColor = System.Drawing.Color.Black;
            this.linkNext.Location = new System.Drawing.Point(408, 429);
            this.linkNext.Name = "linkNext";
            this.linkNext.Size = new System.Drawing.Size(29, 13);
            this.linkNext.TabIndex = 0;
            this.linkNext.TabStop = true;
            this.linkNext.Text = "Next";
            this.linkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNext_LinkClicked);
            // 
            // linkPrev
            // 
            this.linkPrev.AutoSize = true;
            this.linkPrev.LinkColor = System.Drawing.Color.Black;
            this.linkPrev.Location = new System.Drawing.Point(314, 429);
            this.linkPrev.Name = "linkPrev";
            this.linkPrev.Size = new System.Drawing.Size(48, 13);
            this.linkPrev.TabIndex = 1;
            this.linkPrev.TabStop = true;
            this.linkPrev.Text = "Previous";
            this.linkPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPrev_LinkClicked);
            // 
            // lblCurrentHint
            // 
            this.lblCurrentHint.AutoSize = true;
            this.lblCurrentHint.Location = new System.Drawing.Point(368, 429);
            this.lblCurrentHint.Name = "lblCurrentHint";
            this.lblCurrentHint.Size = new System.Drawing.Size(34, 13);
            this.lblCurrentHint.TabIndex = 3;
            this.lblCurrentHint.Text = "1 of 6";
            // 
            // chkGoAway
            // 
            this.chkGoAway.AutoSize = true;
            this.chkGoAway.Location = new System.Drawing.Point(12, 429);
            this.chkGoAway.Name = "chkGoAway";
            this.chkGoAway.Size = new System.Drawing.Size(147, 17);
            this.chkGoAway.TabIndex = 4;
            this.chkGoAway.Text = "Don\'t show this any more.";
            this.chkGoAway.UseVisualStyleBackColor = true;
            // 
            // wbHints
            // 
            this.wbHints.Location = new System.Drawing.Point(15, 12);
            this.wbHints.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHints.Name = "wbHints";
            this.wbHints.Size = new System.Drawing.Size(842, 411);
            this.wbHints.TabIndex = 5;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(869, 458);
            this.Controls.Add(this.wbHints);
            this.Controls.Add(this.chkGoAway);
            this.Controls.Add(this.lblCurrentHint);
            this.Controls.Add(this.linkPrev);
            this.Controls.Add(this.linkNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Help";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Did you know that...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Help_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkNext;
        private System.Windows.Forms.LinkLabel linkPrev;
        private System.Windows.Forms.Label lblCurrentHint;
        private System.Windows.Forms.CheckBox chkGoAway;
        private System.Windows.Forms.WebBrowser wbHints;
    }
}