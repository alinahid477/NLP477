using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.Query.Processors
{
    sealed public class ProcessParks : AbstractProcessor
    {
        public ProcessParks(IO.Interfaces.IDataWriter writer, IO.Interfaces.IInputReader reader) : base(writer, reader)
        {   
            consumer = new JsonProcessor.ParkConsumer();
        }

        public override bool Process()
        {
            // The AbstractProcessor expects a json string to process. 
            // So we're checking if the JSON exists. If doesnt then download it and store it in the abstract class itself. 
            // Otherwise use the existing json. Thus we can mock this easily making testing possible. 
            // Otherwise it would have created method dependency and was posing as unflexible.
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
