using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace NLPLib.Query.IO
{
    public class FileDataWriter : Interfaces.IDataWriter, IDisposable
    {
        bool isAppend = false;
        StreamWriter file = null;
        

        public void WriteData(DataObjects.Interfaces.IPlace place)
        {
            if(!isAppend)file = new StreamWriter("output.txt");
            file.WriteLine(place.ToString());
            if(!isAppend)file.Close();
        }

        public void WriteData(List<DataObjects.Interfaces.IPlace> places)
        {
            isAppend = true;
            file = new StreamWriter(places.GetType().Name + "-output.txt", isAppend);
            foreach (DataObjects.Interfaces.IPlace place in places)
            {
                this.WriteData(place);
            }
            file.Close();
        }

        public void Dispose()
        {
            file.Close();
            file.Dispose();
        }
    }
}
