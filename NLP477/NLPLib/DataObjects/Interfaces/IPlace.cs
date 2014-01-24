using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.Query.DataObjects.Interfaces
{
    public interface IPlace
    {
        string Name { get; set; }
        string Id { get; }
    }
}
