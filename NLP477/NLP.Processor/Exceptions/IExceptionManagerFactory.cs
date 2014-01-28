using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Processor.Exceptions
{
    public interface IExceptionManagerFactory
    {
        ExceptionManager GetExceptionManager();
    }
}
