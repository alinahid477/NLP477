using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.IO
{
    public abstract class DataWriter : Interfaces.IWriteData
    {
        public abstract void WriteData(DataObjects.Interfaces.IPlace place);
        public abstract void WriteData(List<DataObjects.Interfaces.IPlace> places); 
    }
}
