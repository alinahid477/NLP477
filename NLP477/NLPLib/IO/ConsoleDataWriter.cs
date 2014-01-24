using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.Query.IO
{
    public class ConsoleDataWriter : Interfaces.IDataWriter
    {
        public void WriteData(DataObjects.Interfaces.IPlace place)
        {
            Console.WriteLine(place.ToString());
        }

        public void WriteData(List<DataObjects.Interfaces.IPlace> places)
        {
            foreach (DataObjects.Interfaces.IPlace place in places)
            {
                this.WriteData(place);
            }
        }

    }
}
