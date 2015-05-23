using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timee.Controls
{
    public partial class TimeeEditComponent<T> : UserControl
        where T : class
    {
        public BindingList<T> BindingSourceList { get; set; }
        public TimeeEditComponent()
        {
            InitializeComponent();
            grdComponents.ColumnHeadersVisible = false;
            grdComponents.RowHeadersVisible = false;
        }
        public void BindData(BindingList<T> list, string displayMember)
        {
            this.BindingSourceList = list;
            this.grdComponents.DataSource = BindingSourceList;
            foreach (DataGridViewColumn c in grdComponents.Columns)
            {
                if (c.Name != displayMember)
                {
                    c.Visible = false;
                }
            }
        }

        protected virtual void btnAdd_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var mostTopCell = this.grdComponents.SelectedCells.Cast<DataGridViewCell>()
                                                    .OrderBy(c => c.RowIndex)
                                                    .FirstOrDefault();
            var mostBottomCell = this.grdComponents.SelectedCells.Cast<DataGridViewCell>()
                                        .OrderByDescending(c => c.RowIndex)
                                        .FirstOrDefault();

            if (mostTopCell != null && mostTopCell.RowIndex > 0)
            {
                foreach (DataGridViewCell c in this.grdComponents.SelectedCells
                                                                .Cast<DataGridViewCell>()
                                                                .OrderBy(c => c.RowIndex))
                {
                    var row = c.OwningRow;
                    var i = row.Index;
                    this.BindingSourceList.Swap(i, i - 1);
                }
                this.grdComponents.Rows[mostTopCell.RowIndex - 1].Cells[mostTopCell.ColumnIndex].Selected = true;
                mostBottomCell.Selected = false;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            var mostTopCell = this.grdComponents.SelectedCells.Cast<DataGridViewCell>()
                                                     .OrderBy(c => c.RowIndex)
                                                     .FirstOrDefault();
            var mostBottomCell = this.grdComponents.SelectedCells.Cast<DataGridViewCell>()
                                        .OrderByDescending(c => c.RowIndex)
                                        .FirstOrDefault();

            if (mostBottomCell != null && mostBottomCell.RowIndex < this.BindingSourceList.Count-1)
            {
                foreach (DataGridViewCell c in this.grdComponents.SelectedCells
                                                                .Cast<DataGridViewCell>()
                                                                .OrderByDescending(c => c.RowIndex))
                {
                    var row = c.OwningRow;
                    var i = row.Index;
                    this.BindingSourceList.Swap(i, i + 1);
                }
                this.grdComponents.Rows[mostBottomCell.RowIndex + 1].Cells[mostTopCell.ColumnIndex].Selected = true;
                mostTopCell.Selected = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewCell c in grdComponents.SelectedCells)
            {
                this.grdComponents.Rows.Remove(c.OwningRow);
            }
        }


    }
}
