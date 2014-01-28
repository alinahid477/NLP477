using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Processor.Exceptions
{
    public interface IExceptionPolicy<T>
    {
        List<ExceptionPolicyEntry> GetPolicyEntry(LogWriter logWriter);
    }
}
