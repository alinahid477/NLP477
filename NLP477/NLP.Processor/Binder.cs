
using NLP.Infrastructure.Commands;
using NLP.Infrastructure.Events;
using NLP.Repository.Contexts;
using NLP.Repository.ParkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Extensions.Conventions;
using NLP.Processor.Loggers;
using NLP.Processor.Exceptions;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using NLP.Domain;
using NLP.Processor.Data;
using NLP.Repository.AccomodationRepository;
using NLP.Infrastructure.Logic;

namespace NLP.Processor
{
    public class Binder : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ICommandBus>().To<CommandBus>().InSingletonScope(); // verified. singleton
            Kernel.Bind<IEventBus>().To<EventBus>().InSingletonScope(); // verified. singleton
            Kernel.Bind<ICommandSerializer>().To<CommandSerializer>().InSingletonScope(); // verified. singleton
            Kernel.Bind<IEventSerializer>().To<EventSerializer>().InSingletonScope(); // verified. singleton

            //Db Context
            Kernel.Bind<NLPDomainContext>().ToConstructor(x => new NLPDomainContext()).InRequestScope();

            // Data Objects
            Kernel.Bind<IDomainQuery>().To<DomainQuery>().InSingletonScope();

            //Configurators          
            Kernel.Bind<IExceptionMangerProfiles>().To<ExceptionManagerProfiles>().InSingletonScope(); // verified. singleton
            Kernel.Bind<ILoggingConfigurator>().To<LoggingConfigurator>().InSingletonScope(); // verified. singleton

            //Exception
            Kernel.Bind<ExceptionManager>().ToProvider<ExceptionManagerFactory>().InSingletonScope(); // verified. singleton.

            // Loggers
            Kernel.Bind<ICommandLogger>().To<CommandLogger>().InSingletonScope(); // verified. ok as singleton
            Kernel.Bind<IEventLogger>().To<EventLogger>().InSingletonScope(); // verified. ok as singleton

            //Repostiories - all in request scope
            Kernel.Bind<IParkRepository>().To<ParkRepository>();
            Kernel.Bind<IAccomodationRepository>().To<AccomodationRepository>();

            

            Kernel.Bind(x =>
            {
                x.FromThisAssembly().SelectAllClasses().InheritedFromAny(typeof(ILogic), typeof(Handles<>), typeof(Subscribes<>)).BindAllInterfaces().Configure(c => c.InTransientScope());
            });
            Kernel.Bind(x =>
            {
                x.FromThisAssembly().SelectAllClasses().InheritedFromAny(typeof(IExceptionPolicy<>)).BindAllInterfaces().Configure(c => c.InTransientScope());
            });
        }
    }
}
