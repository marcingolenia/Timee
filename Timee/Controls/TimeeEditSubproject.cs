
using System;
using System.Linq;

namespace Timee.Controls
{
    public partial class TimeeEditSubproject : TimeeEditSubprojectNonGeneric
    {
        public TimeeEditSubproject()
        {
            InitializeComponent();
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.BindingSourceList.Where(i => i.Name == this.NewItemText).Count() == 0)
            {
                var subProject = new Models.UserConfigurationSubproject()
                {
                    Name = this.NewItemText,
                    Order = this.BindingSourceList.Max(i => i.Order + 1),
                    OrderSpecified = true
                };
                this.BindingSourceList.Add(subProject);
            }
        }
    }

    /// <summary>
    /// Empty class - workaround for designer. Control normaly can inherit directly the generic class but crashes designer.
    /// </summary>
    public class TimeeEditSubprojectNonGeneric : TimeeEditComponent<Models.UserConfigurationSubproject>
    { }
}
