using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Processor.Exceptions
{
    public class ExceptionManagerProfiles : IExceptionMangerProfiles
    {
        private IExceptionPolicy<ProcessorPolicy> processorPolicy;

        public ExceptionManagerProfiles(IExceptionPolicy<ProcessorPolicy> procPolicy)
        {
            this.processorPolicy = procPolicy;
        }
        public ExceptionManager BuildExceptionManagerConfig(LogWriter logWriter)
        {
            var policies = new List<ExceptionPolicyDefinition>();

            var procPolicyEntries = this.processorPolicy.GetPolicyEntry(logWriter);

            policies.Add(new ExceptionPolicyDefinition("ProcessorPolicy", procPolicyEntries));

            return new ExceptionManager(policies);
        }
    }
}
