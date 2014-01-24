using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPLib.Query.DataObjects.Interfaces;
namespace NLPLib.Query.JsonProcessor.Interfaces
{
    public interface IProcessJson
    {
        List<IPlace> Process(string json);
    }
}
