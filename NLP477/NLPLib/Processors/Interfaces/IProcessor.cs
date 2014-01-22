using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.Processors.Interfaces
{
    public interface IProcessor
    {
        void Process(IO.Interfaces.IWriteData writer);
    }
}
