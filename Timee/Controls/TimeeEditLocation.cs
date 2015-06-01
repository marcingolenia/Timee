using System;
using System.Collections;
using System.Linq;

namespace Timee.Controls
{
    public partial class TimeeEditLocation : TimeEditLocationNonGeneric
    {
        public TimeeEditLocation()
        {
            InitializeComponent();
        }
        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            var location = new Models.UserConfigurationLocation()
            {
                Name = this.NewItemText,
                Order = this.BindingSourceList.Max(i => i.Order + 1),
                OrderSpecified = true
            };
            this.BindingSourceList.Add(location);
        }
        
    }
    /// <summary>
    /// Empty class - workaround for designer. Control normaly can inherit directly the generic class but crashes designer.
    /// </summary>
    public class TimeEditLocationNonGeneric : TimeeEditComponent<Models.UserConfigurationLocation>
    {}
}
