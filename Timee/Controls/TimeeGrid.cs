using System;
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

    }
}
