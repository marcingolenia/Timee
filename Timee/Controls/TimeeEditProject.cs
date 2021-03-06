﻿using System;
using System.Linq;

namespace Timee.Controls
{
    public partial class TimeeEditProject : TimeeEditProjectNonGeneric
    {
        public TimeeEditProject()
        {
            InitializeComponent();        
        }
        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.BindingSourceList.Where(i => i.Name == this.NewItemText).Count() == 0)
            {
                var project = new Models.UserConfigurationProject()
                {
                    Name = this.NewItemText,
                    Order = this.BindingSourceList.Count > 0 ? this.BindingSourceList.Max(i => i.Order + 1) : 1,
                    OrderSpecified = true
                };
                this.BindingSourceList.Add(project);
            }
        }
    }

    /// <summary>
    /// Empty class - workaround for designer. Control normaly can inherit directly the generic class but crashes designer.
    /// </summary>
    public class TimeeEditProjectNonGeneric : TimeeEditComponent<Models.UserConfigurationProject>
    {}
}
