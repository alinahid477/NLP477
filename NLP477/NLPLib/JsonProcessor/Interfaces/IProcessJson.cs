using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPLib.DataObjects.Interfaces;
namespace NLPLib.JsonProcessor.Interfaces
{
    public interface IProcessJson
    {
        List<IPlace> Process(string json);
    }
}
