namespace Timee.Dialogs
{
    partial class AlarmDialog
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblAlarmDuration = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpAlarmDuration = new System.Windows.Forms.DateTimePicker();
            this.grbAlarmOptions = new System.Windows.Forms.GroupBox();
            this.chkSound = new System.Windows.Forms.CheckBox();
            this.chkMessage = new System.Windows.Forms.CheckBox();
            this.cbPlugins = new System.Windows.Forms.ComboBox();
            this.chkPlugin = new System.Windows.Forms.CheckBox();
            this.grbAlarmOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(95, 70);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(185, 20);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.Text = "Time to go home!";
            // 
            // lblAlarmDuration
            // 
            this.lblAlarmDuration.AutoSize = true;
            this.lblAlarmDuration.Location = new System.Drawing.Point(12, 40);
            this.lblAlarmDuration.Name = "lblAlarmDuration";
            this.lblAlarmDuration.Size = new System.Drawing.Size(77, 13);
            this.lblAlarmDuration.TabIndex = 3;
            this.lblAlarmDuration.Text = "Alarm duration:";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 73);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(73, 13);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Message text:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(10, 226);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(205, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpAlarmDuration
            // 
            this.dtpAlarmDuration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAlarmDuration.Location = new System.Drawing.Point(95, 40);
            this.dtpAlarmDuration.Name = "dtpAlarmDuration";
            this.dtpAlarmDuration.ShowUpDown = true;
            this.dtpAlarmDuration.Size = new System.Drawing.Size(85, 20);
            this.dtpAlarmDuration.TabIndex = 7;
            // 
            // grbAlarmOptions
            // 
            this.grbAlarmOptions.Controls.Add(this.chkPlugin);
            this.grbAlarmOptions.Controls.Add(this.chkSound);
            this.grbAlarmOptions.Controls.Add(this.chkMessage);
            this.grbAlarmOptions.Location = new System.Drawing.Point(44, 120);
            this.grbAlarmOptions.Name = "grbAlarmOptions";
            this.grbAlarmOptions.Size = new System.Drawing.Size(200, 100);
            this.grbAlarmOptions.TabIndex = 8;
            this.grbAlarmOptions.TabStop = false;
            this.grbAlarmOptions.Text = "Alarm Options";
            // 
            // chkSound
            // 
            this.chkSound.AutoSize = true;
            this.chkSound.Location = new System.Drawing.Point(6, 42);
            this.chkSound.Name = "chkSound";
            this.chkSound.Size = new System.Drawing.Size(80, 17);
            this.chkSound.TabIndex = 1;
            this.chkSound.Text = "Play Sound";
            this.chkSound.UseVisualStyleBackColor = true;
            // 
            // chkMessage
            // 
            this.chkMessage.AutoSize = true;
            this.chkMessage.Checked = true;
            this.chkMessage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMessage.Location = new System.Drawing.Point(6, 19);
            this.chkMessage.Name = "chkMessage";
            this.chkMessage.Size = new System.Drawing.Size(99, 17);
            this.chkMessage.TabIndex = 0;
            this.chkMessage.Text = "Show Message";
            this.chkMessage.UseVisualStyleBackColor = true;
            // 
            // cbPlugins
            // 
            this.cbPlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlugins.FormattingEnabled = true;
            this.cbPlugins.Location = new System.Drawing.Point(159, 105);
            this.cbPlugins.Name = "cbPlugins";
            this.cbPlugins.Size = new System.Drawing.Size(121, 21);
            this.cbPlugins.TabIndex = 2;
            // 
            // chkPlugin
            // 
            this.chkPlugin.AutoSize = true;
            this.chkPlugin.Location = new System.Drawing.Point(6, 65);
            this.chkPlugin.Name = "chkPlugin";
            this.chkPlugin.Size = new System.Drawing.Size(80, 17);
            this.chkPlugin.TabIndex = 2;
            this.chkPlugin.Text = "Start Plugin";
            this.chkPlugin.UseVisualStyleBackColor = true;
            // 
            // AlarmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cbPlugins);
            this.Controls.Add(this.grbAlarmOptions);
            this.Controls.Add(this.dtpAlarmDuration);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblAlarmDuration);
            this.Controls.Add(this.txtMessage);
            this.Name = "AlarmDialog";
            this.Text = "AlarmDialog";
            this.Load += new System.EventHandler(this.AlarmDialog_Load);
            this.grbAlarmOptions.ResumeLayout(false);
            this.grbAlarmOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblAlarmDuration;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpAlarmDuration;
        private System.Windows.Forms.GroupBox grbAlarmOptions;
        private System.Windows.Forms.CheckBox chkSound;
        private System.Windows.Forms.CheckBox chkMessage;
        private System.Windows.Forms.ComboBox cbPlugins;
        private System.Windows.Forms.CheckBox chkPlugin;
    }
}