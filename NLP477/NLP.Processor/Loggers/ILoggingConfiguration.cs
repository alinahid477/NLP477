using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Processor.Loggers
{
    public interface ILoggingConfigurator
    {
        LoggingConfiguration BuildLoggingConfig();
    }
}
