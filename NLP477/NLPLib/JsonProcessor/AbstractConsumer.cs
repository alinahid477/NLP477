using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPLib.IO.Interfaces;
using NLPLib.JsonProcessor.Interfaces;
using NLPLib.DataObjects.Interfaces;

namespace NLPLib.JsonProcessor
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
