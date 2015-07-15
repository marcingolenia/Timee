using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Timee.Plugins.LGBSExcelExport
{
    class LGBSExcelExportConfigurationService
    {
        private static LGBSExcelExportConfigurationService _instance;

        private LGBSExcelExportConfigurationService()
        {
            _instance = this;
        }
        public static LGBSExcelExportConfigurationService Instance
        {
            get
            {
                return _instance == null ? new LGBSExcelExportConfigurationService() : _instance;
            }
        }

        public LGBSExcelExportConfiguration LoadConfiguration()
        {
            if (Properties.Settings.Default.Properties["LGBSExcelExportConfiguration"] == null)
            {
                System.Configuration.SettingsProperty property =
                new System.Configuration.SettingsProperty("LGBSExcelExportConfiguration");

                //Load xml doc into it
                property.IsReadOnly = false;
                property.PropertyType = typeof(string);
                property.DefaultValue = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Plugins",
                                        "LGBSExcelExport", "LGBSExcelExportConfiguration.xml"));
                property.Provider = Properties.Settings.Default.Providers["LocalFileSettingsProvider"];
                property.Attributes.Add(typeof(System.Configuration.UserScopedSettingAttribute), new System.Configuration.UserScopedSettingAttribute());
                Properties.Settings.Default.Properties.Add(property);
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            XmlSerializer s = new XmlSerializer(typeof(LGBSExcelExportConfiguration));
            XDocument doc =
            XDocument.Parse((string)Properties.Settings.Default["LGBSExcelExportConfiguration"]);
            return (LGBSExcelExportConfiguration)s.Deserialize(doc.CreateReader());

        }
        public void SaveConfiguration(LGBSExcelExportConfiguration configuration)
        {

            var xmlSerializer = new XmlSerializer(typeof(LGBSExcelExportConfiguration));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, configuration);
                Properties.Settings.Default["LGBSExcelExportConfiguration"] = textWriter.ToString();
            }
            Properties.Settings.Default.Save();
        }
    }
}
