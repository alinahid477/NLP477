using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.Processors
{
    sealed public class ProcessParks : AbstractProcessor
    {
        public ProcessParks(IO.Interfaces.IWriteData writer) : base(writer)
        {   
            consumer = new JsonProcessor.ParkConsumer();
        }

        public override bool Process()
        {
            if (string.IsNullOrEmpty(JSON)) this.DownloadJSON();
            List<DataObjects.Interfaces.IPlace> parks = consumer.Process(JSON);
            if (parks.Count < 1)
            {
                throw new TaskCanceledException("Nothing new found.");
            }
            writer.WriteData(parks);
            return true;
        }
    }
}
