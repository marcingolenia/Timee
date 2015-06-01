namespace Timee.Controls
{
    partial class TimeeEditComponent<T>
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdComponents = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtNewItemName = new System.Windows.Forms.TextBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // grdComponents
            // 
            this.grdComponents.AllowUserToAddRows = false;
            this.grdComponents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdComponents.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grdComponents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdComponents.Location = new System.Drawing.Point(87, 38);
            this.grdComponents.Name = "grdComponents";
            this.grdComponents.Size = new System.Drawing.Size(267, 174);
            this.grdComponents.TabIndex = 14;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(321, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 21);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtNewItemName
            // 
            this.txtNewItemName.Location = new System.Drawing.Point(87, 11);
            this.txtNewItemName.Name = "txtNewItemName";
            this.txtNewItemName.Size = new System.Drawing.Size(228, 20);
            this.txtNewItemName.TabIndex = 12;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(37, 134);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(44, 53);
            this.btnDown.TabIndex = 9;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(37, 47);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(44, 52);
            this.btnUp.TabIndex = 8;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(37, 105);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(44, 23);
            this.btnRemove.TabIndex = 15;
            this.btnRemove.Text = "Del.";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // TimeeEditComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.grdComponents);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNewItemName);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Name = "TimeeEditComponent";
            this.Size = new System.Drawing.Size(391, 215);
            ((System.ComponentModel.ISupportInitialize)(this.grdComponents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtNewItemName;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.DataGridView grdComponents;
        private System.Windows.Forms.Button btnRemove;
    }
}
