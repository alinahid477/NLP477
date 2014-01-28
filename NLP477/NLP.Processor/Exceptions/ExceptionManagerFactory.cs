using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Ninject.Activation;
using NLP.Processor.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Processor.Exceptions
{
    public class ExceptionManagerFactory : IExceptionManagerFactory, IProvider
    {
        private IExceptionMangerProfiles exceptionProfiles;
        private ILoggingConfigurator logConfig;

        private ExceptionManager exManager = null;
        private LogWriter logWriter = null;

        public Type Type
        {
            get
            {
                return this.GetType();
            }
        }

        public ExceptionManagerFactory(IExceptionMangerProfiles excpProfiles, ILoggingConfigurator logConfigurator)
        {
            //Get profiles and log config
            this.exceptionProfiles = excpProfiles;
            this.logConfig = logConfigurator;
            //Create log writer
            this.logWriter = new LogWriter(this.logConfig.BuildLoggingConfig());
        }

        public object Create(IContext context)
        {
            return GetExceptionManager();
        }

        public ExceptionManager GetExceptionManager()
        {
            //Check if execption manager exists if not create one.
            if (exManager == null)
            {
                ExceptionPolicyFactory factory = new ExceptionPolicyFactory();
                this.exManager = factory.CreateManager();
                exManager = exceptionProfiles.BuildExceptionManagerConfig(logWriter);
            }
            return this.exManager;
        }
    }
}
