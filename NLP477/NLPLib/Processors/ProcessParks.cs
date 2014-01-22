using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.Processors
{
    sealed class ProcessParks : Interfaces.IProcessor
    {
        public void Process(IO.Interfaces.IWriteData writer)
        { 
            JsonProcessor.AbstractConsumer consumer = new JsonProcessor.ParkConsumer();
            List<DataObjects.Interfaces.IPlace> parks = consumer.Process(consumer.JSON);
            writer.WriteData(parks);
        }
    }
}
