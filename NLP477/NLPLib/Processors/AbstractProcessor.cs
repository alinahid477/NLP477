using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.Processors
{
    abstract public class AbstractProcessor : Interfaces.IProcessor
    {
        protected JsonProcessor.AbstractConsumer consumer = null;
        protected IO.Interfaces.IWriteData writer = null;

        public string JSON { get; set; }

        public AbstractProcessor(IO.Interfaces.IWriteData writer)
        {
            this.writer = writer;
        }
        public void DownloadJSON()
        {
            JSON = consumer.Download(consumer.url);
        }
        public abstract bool Process();
    }
}
