using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using Timee.Models;

namespace Timee.DAL
{
    public class TimeeXMLService
    {
        private static TimeeXMLService _instance;

        private TimeeXMLService()
        {
            _instance = this;
        }
        public static TimeeXMLService Instance
        {
            get
            {
                return _instance == null ? new TimeeXMLService() : _instance;
            }
        }

        public TimeeContext LoadContext()
        {
            TimeeContext context = new TimeeContext();
            XmlSerializer s = new XmlSerializer(typeof(Models.UserConfiguration));
            XDocument doc =
            XDocument.Parse(Properties.Settings.Default.UserConfiguration);
            var conf = (Models.UserConfiguration)s.Deserialize(doc.CreateReader());
            context.Locations = new BindingList<Models.UserConfigurationLocation>(conf.Location.ToList());
            context.Projects = new BindingList<Models.UserConfigurationProject>(conf.Project.ToList());
            context.Tasks = new BindingList<Models.UserConfigurationTask>(conf.Task.ToList());
            context.Subprojects = new BindingList<Models.UserConfigurationSubproject>(conf.Subproject.ToList());
            return context;
        }

        public void SaveContext(TimeeContext context)
        {
            var conf = new UserConfiguration();
            conf.Location = context.Locations.ToArray();
            conf.Project = context.Projects.ToArray();
            conf.Subproject = context.Subprojects.ToArray();
            conf.Task = context.Tasks.ToArray();

            var xmlSerializer = new XmlSerializer(typeof(Models.UserConfiguration));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, conf);
                Properties.Settings.Default.UserConfiguration = textWriter.ToString();
                Properties.Settings.Default.Save();
            }
        }
    }
}
