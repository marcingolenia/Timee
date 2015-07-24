using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeeBridge
{
    public interface IPlugins
    {
        string ImportXml (string xml);
        void ExportXml(string xml);
    }
    public interface IPluginsMetaData
    {
        string Name { get; }
        string Type { get; }
    }
}
