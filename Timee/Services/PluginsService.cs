using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timee.Models;

namespace Timee.Services
{
    class PluginsService
    {
        [ImportMany(typeof(TimeeBridge.IPlugins))]
        IEnumerable<Lazy<TimeeBridge.IPlugins, TimeeBridge.IMetaData>> _plugins;

        private TimeeMain main;
        private TimeeContext context;
        private StringReader xml;
        /// <summary>
        /// Settings Plugins directory
        /// </summary>
        /// <param name="main"></param>
        /// <param name="predefine"></param>
        public PluginsService(TimeeMain main, TimeeContext context)
        {
            DirectoryCatalog dirCatalog = new DirectoryCatalog("Plugins");
            CompositionContainer container = new CompositionContainer(dirCatalog);
            container.SatisfyImportsOnce(this);
            this.main = main;
            this.context = context;
        }
        /// <summary>
        /// Create menu for plugins
        /// </summary>
        /// <param name="menu"></param>
        public void InitializeMenu(MenuStrip menu)
        {
            ToolStripMenuItem plugins = new ToolStripMenuItem("Plugins");
            menu.Items.Add(plugins);
            
            

            foreach (Lazy<TimeeBridge.IPlugins, TimeeBridge.IMetaData> plugin in _plugins)
            {
                ToolStripMenuItem menuPlugin = new ToolStripMenuItem(plugin.Metadata.Group);

                  if (plugins.DropDownItems
                      .Cast<ToolStripMenuItem>()
                     .Any(x => x.Text == plugin.Metadata.Group))
                 {
                     var newMenu = from ToolStripMenuItem mnu in plugins.DropDownItems.Cast<ToolStripMenuItem>()
                                   where mnu.Text == plugin.Metadata.Group
                                   select mnu;
                     menuPlugin = newMenu.First();
                 }
                  else
                  {
                      plugins.DropDownItems.Add(menuPlugin);
                  }
                ToolStripMenuItem pluginMenuItem = new ToolStripMenuItem(plugin.Metadata.Name);
                pluginMenuItem.Name = plugin.Metadata.Name;
                pluginMenuItem.Click += new EventHandler(menuPluginClick);

                menuPlugin.DropDownItems.Add(pluginMenuItem);
            }
        }
        /// <summary>
        /// Determine which plugin were clicked, and set output for plugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuPluginClick(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            var action = from plugin in _plugins
                         where plugin.Metadata.Name == item.Name
                         select plugin;

            TimeeBridge.TimeeValues.MainTasks = main.timeeDataSet.Tables[0];
            TimeeBridge.TimeeValues.MainTasksXml = main.timeeDataSet.GetXml();
            TimeeBridge.TimeeValues.PredefineTasks = context.PredefinedTasks.Tables[0];
            TimeeBridge.TimeeValues.PredefineTasksXml = context.PredefinedTasks.GetXml();
            TimeeBridge.TimeeValues.MainTasksDataSet = main.timeeDataSet;


            action.First().Value.Start();
            switch (action.First().Metadata.Return)  
            {
                case "MainTasks":
                    {
                        this.main.timeeDataSet.Tables[0].Merge(TimeeBridge.TimeeValues.MainTasks);
                        break;
                    }
                case "PredefineTasks":
                    {
                        this.main.timeeDataSet.Tables[0].Merge(TimeeBridge.TimeeValues.MainTasks);
                        break;
                    }
                case "MainTasksXml":
                    {
                        xml = new StringReader(TimeeBridge.TimeeValues.MainTasksXml);
                        this.main.timeeDataSet.ReadXml(xml);
                        break;
                    }
                case "PredefineTasksXml":
                    {
                        xml = new StringReader(TimeeBridge.TimeeValues.PredefineTasksXml);
                        this.context.PredefinedTasks.ReadXml(xml);
                        break;
                    }
                case "Context":
                    {
                        

                        foreach (var location in TimeeBridge.TimeeValues.ContextLocationCollection)
                        {
                            UserConfigurationLocation tmpLocation = new UserConfigurationLocation();

                            tmpLocation.Name = location.Name;
                            if (tmpLocation.Name != null)
                            {
                                if (this.context.Locations.Where(i => i.Name == tmpLocation.Name).Count() == 0)
                                {
                                    tmpLocation.Value = location.Value;
                                    tmpLocation.Order = context.Locations.Count == 0 ? 1 : this.context.Locations.Max(i => i.Order + 1);
                                    tmpLocation.OrderSpecified = true;
                                    this.context.Locations.Add(tmpLocation);
                                }

                            }
                        }


                        foreach (var project in TimeeBridge.TimeeValues.ContextProjectCollection)
                        {
                            UserConfigurationProject tmpProject = new UserConfigurationProject();

                            tmpProject.Name = project.Name;
                            if (tmpProject.Name != null)
                            {
                                if (this.context.Projects.Where(i => i.Name == tmpProject.Name).Count() == 0)
                                {
                                    tmpProject.Value = project.Value;
                                    tmpProject.Order = context.Projects.Count == 0 ? 1 : this.context.Projects.Max(i => i.Order + 1);
                                    tmpProject.OrderSpecified = true;
                                    this.context.Projects.Add(tmpProject);
                                }

                            }
                        }
                        foreach (var subProject in TimeeBridge.TimeeValues.ContextSubprojectCollection)
                        {
                            UserConfigurationSubproject tmpSubproject = new UserConfigurationSubproject();
                            tmpSubproject.Name = subProject.Name;
                            if (tmpSubproject.Name != null)
                            {
                                tmpSubproject.Value = subProject.Value;
                                tmpSubproject.Parent = subProject.Parent;
                                tmpSubproject.Order = context.Subprojects.Count == 0 ? 1 : this.context.Subprojects.Max(i => i.Order + 1);
                                tmpSubproject.OrderSpecified = true;
                                this.context.Subprojects.Add(tmpSubproject);
                            }
                        }
                        foreach (var task in TimeeBridge.TimeeValues.ContextTaskCollection)
                        {
                            UserConfigurationTask tmpTask = new UserConfigurationTask();
                            tmpTask.Name = task.Name;
                            if (tmpTask.Name != null)
                            {
                                tmpTask.Value = task.Value;
                                tmpTask.Parent = task.Parent;
                                tmpTask.Order = context.Tasks.Count == 0 ? 1 : this.context.Tasks.Max(i => i.Order + 1);
                                tmpTask.OrderSpecified = true;
                                this.context.Tasks.Add(tmpTask);
                            }
                            
                        }
                        

                        //tmpTask.Name = TimeeBridge.TimeeValues.ContextTask.Name;
                        //tmpTask.Value = TimeeBridge.TimeeValues.ContextTask.Value;
                        //context.Tasks.Add(tmpTask);

                        Services.TimeeXMLService.Instance.SaveContext(context);
                        Services.TimeeXMLService.Instance.LoadContext();
                        TimeeBridge.TimeeValues.ContextLocationCollection.Clear();
                        TimeeBridge.TimeeValues.ContextProjectCollection.Clear();
                        TimeeBridge.TimeeValues.ContextSubprojectCollection.Clear();
                        TimeeBridge.TimeeValues.ContextTaskCollection.Clear();
                       // TimeeBridge.TimeeValues.Context.Locations.Where(l => l.Name.Length != 0).Select(l => l.Name);
                        break;
                    }
            }
        }
    }
}
