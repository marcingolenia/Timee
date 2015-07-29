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
        [ImportMany(typeof(TimeeBridge.IExcell))]
        IEnumerable<Lazy<TimeeBridge.IExcell, TimeeBridge.IMetaData>> _excellPlugins;

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
            ToolStripMenuItem menuExcell = new ToolStripMenuItem("Excell");
            plugins.DropDownItems.Add(menuExcell);

            foreach (Lazy<TimeeBridge.IExcell, TimeeBridge.IMetaData> excellPlugin in _excellPlugins)
            {
                ToolStripMenuItem excell = new ToolStripMenuItem(excellPlugin.Metadata.Name);
                excell.Name = excellPlugin.Metadata.Name;
                excell.Click += new EventHandler(menuPluginClick);

                menuExcell.DropDownItems.Add(excell);
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
            var action = from plugin in _excellPlugins
                         where plugin.Metadata.Name == item.Name
                         select plugin;

            TimeeBridge.TimeeValues.MainTasks = main.timeeDataSet.Tables[0];
            TimeeBridge.TimeeValues.MainTasksXml = main.timeeDataSet.GetXml();
            TimeeBridge.TimeeValues.PredefineTasks = context.PredefinedTasks.Tables[0];
            TimeeBridge.TimeeValues.PredefineTasksXml = context.PredefinedTasks.GetXml();


            action.First().Value.test();
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
            }
        }
    }
}
