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
        public string url = null;
        public string Download(string url)
        {
            return null;
        }

        abstract public List<IPlace> Process(string json);
    }
}
