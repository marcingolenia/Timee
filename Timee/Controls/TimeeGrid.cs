﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timee.Controls
{
    public class TimeeGrid: DataGridView
    {
        public event EventHandler<DataGridViewCellEventArgs> btnDeleteRowClicked;
        public event EventHandler<DataGridViewCellEventArgs> btnSaveRowClicked;
        public TimeeGrid()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // TimeeGrid
            // 
            this.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TimeeGrid_CellContentClick);
            this.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.TimeeGrid_DataError);
            this.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.TimeeGrid_EditingControlShowing);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void TimeeGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void TimeeGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.CurrentCell.OwningColumn.CellType == typeof(DataGridViewComboBoxCell))
            {
                ComboBox cmb = e.Control as ComboBox;

                if (cmb == null)
                    return;
                cmb.DropDownStyle = ComboBoxStyle.DropDown;
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmb.PreviewKeyDown -= new PreviewKeyDownEventHandler(GridCmb_KeyPress);
                cmb.PreviewKeyDown += new PreviewKeyDownEventHandler(GridCmb_KeyPress);
            }
        }
        /// <summary>
        /// Handling editable comboboxes - Tab key.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridCmb_KeyPress(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.EndEdit();
                this.CurrentCell.Value = ((DataGridViewComboBoxEditingControl)sender).EditingControlFormattedValue;
            }
        }
        /// <summary>
        /// check with icon were clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeeGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Columns[e.ColumnIndex].Name == "Remove")
            {
                btnDeleteRowClicked(sender, e);
            }
            else if (this.Columns[e.ColumnIndex].Name == "Save")
            {
                btnSaveRowClicked(sender, e);
            }
        }
        /// <summary>
        /// Replace Enter action with Tab (used in grdWorkSummary
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Enter)
            {
                if (this.CurrentCell.ColumnIndex < ColumnCount - 1)
                {
                    this.CurrentCell = this.Rows[this.CurrentCell.RowIndex].Cells[this.CurrentCell.ColumnIndex + 1];
                    return true;
                }
                else
                {
                    try
                    {
                        this.CurrentCell = this.Rows[this.CurrentCell.RowIndex + 1].Cells[0];
                        return true;
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        return true;
                    }

                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
