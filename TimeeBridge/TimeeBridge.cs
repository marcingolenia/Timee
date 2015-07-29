using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeeBridge
{
    public interface IExcell
    {
        DataTable ImportToExcell (DataTable source);
        void ExportFromExcell(string xml);
        void test();
    }
    public interface IContext
    {
        TimeeContext ImportToContext(TimeeContext source);
        void ExportFromContext(TimeeContext source);
    }

    public interface IMetaData
    {
        string Name { get; }
        string Return { get; }
    }
}
