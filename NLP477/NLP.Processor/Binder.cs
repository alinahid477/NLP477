using Ninject.Modules;
using NLP.Infrastructure.Commands;
using NLP.Infrastructure.Events;
using NLP.Repository.Contexts;
using NLP.Repository.ParkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Processor
{
    public class Binder : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ICommandBus>().To<CommandBus>().InSingletonScope(); // verified. singleton
            Kernel.Bind<IEventBus>().To<EventBus>().InSingletonScope(); // verified. singleton
            //Kernel.Bind<ISchedulerService>().To<SchedulerService>().InSingletonScope();
            Kernel.Bind<ICommandSerializer>().To<CommandSerializer>().InSingletonScope(); // verified. singleton
            Kernel.Bind<IEventSerializer>().To<EventSerializer>().InSingletonScope(); // verified. singleton

            //Db Context
            Kernel.Bind<NLPDomainContext>().ToConstructor(x => new NLPDomainContext());

            //Repostiories - all in request scope
            Kernel.Bind<IParkRepository>().To<ParkRepository>();

            Kernel.Bind(x =>
            {
                x.FromThisAssembly().SelectAllClasses().InheritedFromAny(typeof(Handles<>), typeof(Subscribes<>)).BindAllInterfaces().Configure(c => c.InTransientScope());
            });
        }
    }
}
