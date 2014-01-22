using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPLib.JsonProcessor.Interfaces;
using NLPLib.DataObjects.Interfaces;

namespace NLPLib.JsonProcessor
{
    public abstract class AbstractConsumer : IProcessJson, IDownloader 
    {
        public AbstractConsumer(string urlToConsume)
        {
            this.Download(urlToConsume);
        }
        public string JSON { get; set; }
        public string Download(string url)
        {
            JSON = null;
            return JSON;
        }

        abstract public List<IPlace> Process(string json);
    }
}
