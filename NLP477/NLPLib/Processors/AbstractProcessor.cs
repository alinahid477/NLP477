using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.Query.Processors
{
    abstract public class AbstractProcessor : Interfaces.IProcessor
    {
        protected JsonProcessor.AbstractConsumer consumer = null;
        protected IO.Interfaces.IDataWriter writer = null;
        protected IO.Interfaces.IInputReader reader = null;

        public string JSON { get; set; }

        public AbstractProcessor(IO.Interfaces.IDataWriter writer, IO.Interfaces.IInputReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }
        public void DownloadJSON()
        {
            JSON = consumer.ReadJSON(reader);
        }
        public abstract bool Process();
    }
}
