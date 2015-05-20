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

    {
        public BindingList<T> BindingSource {get;set;}

        public TimeeEditComponent()
        {
            InitializeComponent();
        }
    }
}
