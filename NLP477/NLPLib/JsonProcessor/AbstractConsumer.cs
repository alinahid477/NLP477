using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPLib.Query.IO.Interfaces;
using NLPLib.Query.JsonProcessor.Interfaces;
using NLPLib.Query.DataObjects.Interfaces;

namespace NLPLib.Query.JsonProcessor
{
    public abstract class AbstractConsumer : IProcessJson
    {
        public string url = null;
        public string ReadJSON(IInputReader input)
        {
            return input.ReadInput(url);
        }

        abstract public List<IPlace> Process(string json);
    }
}
