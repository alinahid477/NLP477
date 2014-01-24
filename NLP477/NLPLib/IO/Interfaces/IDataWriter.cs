using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.Query.IO.Interfaces
{
    public interface IDataWriter
    {
        void WriteData(DataObjects.Interfaces.IPlace place);
        void WriteData(List<DataObjects.Interfaces.IPlace> place);
    }
}
