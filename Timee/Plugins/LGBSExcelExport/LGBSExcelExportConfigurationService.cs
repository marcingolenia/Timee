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
            XmlSerializer s = new XmlSerializer(typeof(LGBSExcelExportConfiguration));

            XDocument doc =
            XDocument.Load(Path.Combine(Environment.CurrentDirectory, "Plugins",
            "LGBSExcelExport", "LGBSExcelExportConfiguration.xml"));
            return (LGBSExcelExportConfiguration)s.Deserialize(doc.CreateReader());
        }
        public void SaveConfiguration(LGBSExcelExportConfiguration configuration)
        {
            try
            {
            var writer = new XmlSerializer(typeof(LGBSExcelExportConfiguration));
            var file = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Plugins",
            "LGBSExcelExport", "LGBSExcelExportConfiguration.xml"));
            writer.Serialize(file, configuration);
            file.Close();
            }
                        catch(IOException ex)
            {
                throw ex;
            }
        }
    }
}
