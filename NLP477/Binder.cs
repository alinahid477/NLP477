using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject;
using Ninject.Modules;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;
using TIS.Online.Infrastructure.Command;
using TIS.Online.Processor.Jobs.CommandHandlers;
using TIS.Online.Processor.Commands;
using Ninject.Planning.Bindings;
using System.Reflection;
using TIS.Online.Processor;
using Quartz.Spi;
using TIS.Online.Processor.Scheduling;
using Quartz;
using TIS.Online.Infrastructure.Event;
using TIS.Online.Processor.Jobs;
using TIS.Online.Processor.Interpreters;
using TIS.Online.Domain.Repositories;
using TIS.Online.Processor.Data;
using Ninject.Extensions.Conventions.Syntax;
using TIS.Online.Processor.Agencies;
using TIS.Online.Processor.Logging;
using TIS.Online.Jessica;
using TIS.Online.Jessica.Retry;
using TIS.Online.Jessica.Builder;
using TIS.Online.Processor.Exceptions;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using TIS.Online.Domain.Jobs;
using TIS.Online.Domain;
using TIS.Online.Domain.Repositories.Lookup;
using TIS.Online.Domain.LookupEntities;
using TIS.Online.Processor.LookupEntities;
using TIS.Online.Processor.Services;
using TIS.Online.BinaryStore.Binaries.Documents;
using TIS.Online.BinaryStore;
using TIS.Online.Processor.Users.Data;
using TIS.Online.Processor.TISAdmins.Data;
using TIS.Online.Web.Domain.Repositories;
using TIS.Online.Processor.Jobs.Data;
using TIS.Online.Processor.Notifications;
using TIS.Online.Processor.Scheduling.QueueProcessors.CompleteJobs;
using TIS.Online.Processor.Scheduling.QueueProcessors.FinaliseJobs.Data;
using TIS.Online.Processor.Scheduling.QueueProcessors.FinaliseJobs;
using TIS.Online.Processor.Scheduling.QueueProcessors.VariedJobs.Data;
using TIS.Online.Processor.Scheduling.QueueProcessors.VariedJobs;
using TIS.Online.Processor.Scheduling.PropertyLogger.Data;
using TIS.Online.Processor.Scheduling.PropertyLogger;
using TIS.Online.Processor.Notifications.Data;
using TIS.Online.Processor.Notifications.Builders;
using TIS.Online.Processor.Notifications.Configuration.Data;
using TIS.Online.Processor.Notifications.SMS;
using TIS.Online.Processor.Notifications.Email;

namespace TIS.Online.Processor
{
    public class Binder : NinjectModule
    {
        public override void Load()
        {
            // bind default bindings - ie. Foo to IFoo
            //Kernel.Bind(s => s.FromAssembliesMatching("TIS.Online.*").SelectAllClasses().BindDefaultInterface().Configure(c => c.InSingletonScope()));
            //// bind other bindings which do not match the default pattern.
            //Kernel.Bind<ICommandBus>().To<InProcessCommandBus>().InSingletonScope();
            //Kernel.Bind<IEventBus>().To<InProcessEventBus>().InSingletonScope();
            //Kernel.Bind<ICommandLogger>().To<ADOCommandLogger>().InSingletonScope();
            //Kernel.Bind<IEventLogger>().To<ADOEventLogger>().InSingletonScope();

            //Commands
            Kernel.Bind<ICommandBus>().To<InProcessCommandBus>().InSingletonScope(); // verified. singleton
            Kernel.Bind<IEventBus>().To<InProcessEventBus>().InSingletonScope(); // verified. singleton
            //Kernel.Bind<ISchedulerService>().To<SchedulerService>().InSingletonScope();
            Kernel.Bind<ICommandSerializer>().To<CommandSerializer>().InSingletonScope(); // verified. singleton
            Kernel.Bind<IEventSerializer>().To<EventSerializer>().InSingletonScope(); // verified. singleton

            //Repostiories - all in request scope
            Kernel.Bind<IJobRepository>().To<JobRepository>();
            Kernel.Bind<TIS.Online.Domain.Repositories.IInterpreterRepository>().To<TIS.Online.Processor.Interpreters.InterpreterRepository>().InRequestScope();
            Kernel.Bind<TIS.Online.Domain.Repositories.IAgencyRepository>().To<TIS.Online.Processor.Agencies.AgencyRepository>().InRequestScope();
            Kernel.Bind<TIS.Online.Domain.Repositories.Lookup.ILanguageRepository>().To<TIS.Online.Processor.Data.LanguageRepository>().InRequestScope();
            Kernel.Bind<IAgencyInactiveReasonRepository>().To<AgencyInactiveReasonRepository>().InRequestScope();
            Kernel.Bind<TIS.Online.Domain.Repositories.Lookup.IClientCategoryRepository>().To<TIS.Online.Processor.LookupEntities.ClientCategoryRepository>().InRequestScope();
            Kernel.Bind<TIS.Online.Domain.Repositories.Lookup.IClientSubCategoryRepository>().To<TIS.Online.Processor.LookupEntities.ClientSubCategoryRepository>().InRequestScope();
            Kernel.Bind<IJobCancelReasonRepository>().To<JobCancelReasonRepository>().InRequestScope();
            Kernel.Bind<INAATIAccreditationRepository>().To<NAATIAccreditationRepository>().InRequestScope();
            Kernel.Bind<IInterpreterInactiveReasonRepository>().To<InterpreterInactiveReasonRepository>().InRequestScope();
            Kernel.Bind<IDocumentRepository>().To<DocumentRepository>().InRequestScope();
            Kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            Kernel.Bind<Domain.Repositories.ITISAdminRepository>().To<Processor.TISAdmins.Data.TISAdminRepository>().InRequestScope();
            Kernel.Bind<IAuthenticationUserRepository>().To<AuthenticationUserRepository>().InRequestScope();
            Kernel.Bind<IAssignedJobsRepository>().To<AssignedJobsRepository>().InRequestScope();
            Kernel.Bind<IJobQueryRepository>().To<JobQueryRepository>().InRequestScope();
            Kernel.Bind<IScheduledProcessPropertyRepository>().To<ScheduledProcessPropertyRepository>().InRequestScope();
            Kernel.Bind<IVariedJobRepository>().To<VariedJobRepository>().InRequestScope();
            Kernel.Bind<INotificationRepository>().To<NotificationRepository>().InRequestScope();
            Kernel.Bind<INotificationConfigurationRepository>().To<NotificationConfigurationRepository>().InRequestScope();
            
            
            //Services
            Kernel.Bind<ICommandLogger>().To<ADOCommandLogger>().InSingletonScope(); // verified. ok as singleton
            Kernel.Bind<IEventLogger>().To<ADOEventLogger>().InSingletonScope(); // verified. ok as singleton
            Kernel.Bind<IJessicaService>().To<JessicaService>().InSingletonScope(); // verified. ok as singleton
            Kernel.Bind<IBinaryService>().To<BinaryService>().InRequestScope(); // to discuss with glenn. moved to request scope in line with other repositories
            Kernel.Bind<INotificationService>().To<NotificationService>().InSingletonScope(); // to discuss with glenn
            
            Kernel.Bind<IRetryService>().To<RetryService>().InSingletonScope(); // verified. ok as singleton
            Kernel.Bind<IMessageSender>().To<MessageSender>().InSingletonScope(); // verified. ok as singleton
            Kernel.Bind<IScheduledProcessLoggerService>().To<ScheduledProcessLoggerService>().InTransientScope(); // to discuss with glenn. discussed making transient scope in line with other quartz driven things
            Kernel.Bind<ISMSService>().To<SMSService>().InSingletonScope(); // assuming this just sends (not builds) smses when implemented, ok for singleton
            Kernel.Bind<IEmailService>().To<EmailService>().InSingletonScope(); // assuming that this just sends emails when implemented, ok for singleton.
            

            //Domain Services moved out here as not acutally a "service" like the others.
            // to discuss with glenn. rename to DomainQueries or something
            Kernel.Bind<IDomainServices>().To<DomainServices>().InRequestScope(); // changed from singleton to in request scope to match the context

            //Factories
            Kernel.Bind<IProxyFactory>().To<ProxyFactory>().InSingletonScope(); // verified. singleton.
            Kernel.Bind<IDomainFactory>().To<DomainFactory>().InRequestScope(); // changed from singleton scope to request scope as it has a reference to domain services
            Kernel.Bind<ExceptionManager>().ToProvider<ExceptionManagerFactory>().InSingletonScope(); // verified. singleton.
            Kernel.Bind<INotificationFactory>().To<NotificationFactory>().InSingletonScope(); // removed singleton scope made transient in line with other quartz driven things
            

            //Configurators          
            Kernel.Bind<IExceptionMangerProfiles>().To<ExceptionManagerProfiles>().InSingletonScope(); // verified. singleton
            Kernel.Bind<ILoggingConfigurator>().To<LoggingConfigurator>().InSingletonScope(); // verified. singleton
          
            //Queue processors
            Kernel.Bind<ICompleteJobQueueProcessor>().To<CompleteJobQueueProcessor>(); // removed singleton scope, made transient. injected into quartz jobs which are also transient.
            Kernel.Bind<IFinaliseJobQueueRepository>().To<FinaliseJobQueueRepository>(); // removed singleton scope, made transient. injected into quartz jobs which are also transient.
            Kernel.Bind<IFinaliseJobQueueProcessor>().To<FinaliseJobQueueProcessor>(); // removed singleton scope, made transient. injected into quartz jobs which are also transient.
            Kernel.Bind<IVariedJobQueueProcessor>().To<VariedJobQueueProcessor>(); // removed singleton scope, made transient. injected into quartz jobs which are also transient.
            
            // Quartz Job Manager and start quartz jobs
            Kernel.Get<QuartzJobManager>();
            
            // bind command handlers and event handlers. these need to be bound together as classes which implement both handles<> and subscribes<> were being bound twice leading to errors.
            Kernel.Bind(x =>
            {
                x.FromThisAssembly().SelectAllClasses().InheritedFromAny(typeof(Handles<>),typeof(Subscribes<>)).BindAllInterfaces().Configure(c => c.InTransientScope()); 
            });

            Kernel.Bind(x =>
            {
                x.FromThisAssembly().SelectAllClasses().InheritedFromAny(typeof(IExceptionPolicy<>)).BindAllInterfaces().Configure(c => c.InTransientScope());
            });
            
            
        }

        private  IEnumerable<Type> GetAllTypesImplementingOpenGenericType(Type openGenericType)
        {
            return from x in Assembly.GetExecutingAssembly().GetTypes()
                   from z in x.GetInterfaces()
                   let y = x.BaseType
                   where
                   (y != null && y.IsGenericType &&
                   openGenericType.IsAssignableFrom(y.GetGenericTypeDefinition())) ||
                   (z.IsGenericType &&
                   openGenericType.IsAssignableFrom(z.GetGenericTypeDefinition()))
                   select x;
        }

        private IEnumerable<Type> GetAllTypesImplementingInterface(Type @type)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            return types;
        }
    }


}
