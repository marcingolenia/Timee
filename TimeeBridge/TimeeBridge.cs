using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeeBridge
{
    public interface IPlugins
    {
        void Start();
    }
    public interface IMetaData
    {
        string Name { get; }
        string Return { get; }
        string Group { get; }
    }
}
