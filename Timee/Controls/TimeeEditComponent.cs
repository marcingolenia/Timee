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
                if(c.Name != displayMember)
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
            //TODO: It was only for testing - to be finished
            this.BindingSourceList.Insert(0, BindingSourceList.Last());
            this.BindingSourceList.RemoveAt(BindingSourceList.Count-1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
        }
    }
}
