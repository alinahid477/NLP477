using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using NLP.DTO.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Processor.Exceptions
{
    public class ProcessorPolicy : IExceptionPolicy<ProcessorPolicy>
    {
        public List<ExceptionPolicyEntry> GetPolicyEntry(LogWriter logWriter)
        {
            List<ExceptionPolicyEntry> domainPolicy = new List<ExceptionPolicyEntry>()
            {
                new ExceptionPolicyEntry(typeof (ErrorBase),
                    PostHandlingAction.NotifyRethrow,
                    new IExceptionHandler[]
                     {
                       new LoggingExceptionHandler("General", 9002, TraceEventType.Error,
                         "Processor Exception", 5, typeof(TextExceptionFormatter), logWriter)
                     }),
                new ExceptionPolicyEntry(typeof (Exception),
                    PostHandlingAction.ThrowNewException,
                    new IExceptionHandler[]
                     {
                       new LoggingExceptionHandler("General", 9002, TraceEventType.Error,
                         "Unhandled Exception", 5, typeof(TextExceptionFormatter), logWriter),
                       new WrapHandler("System Error. Please contact your administrator.",
                         typeof(NLP.DTO.Exceptions.SystemError))
                     })
            };

            return domainPolicy;
        }
    }
}
