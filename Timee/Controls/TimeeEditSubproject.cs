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
    public partial class TimeeEditSubproject : TimeeEditSubprojectNonGeneric
    {
        public TimeeEditSubproject()
        {
            InitializeComponent();
        }
    }

    /// <summary>
    /// Empty class - workaround for designer. Control normaly can inherit directly the generic class but crashes designer.
    /// </summary>
    public class TimeeEditSubprojectNonGeneric : TimeeEditComponent<Models.UserConfigurationSubproject>
    { }
}
