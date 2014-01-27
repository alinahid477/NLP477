using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Events
{
    public class EventBus : IEventBus
    {
        IKernel ninjectContainer;

        private Dictionary<Type, object> eventHandlers = new Dictionary<Type, object>();
        private IEventLogger eventLogger;

        public EventBus(IKernel kernel, IEventLogger eventLogger)
        {
            this.ninjectContainer = kernel;
            this.eventLogger = eventLogger;
        }


        public void Publish<TEvent>(TEvent @event) where TEvent : class, IEvent
        {

            try
            {

                // see: https://github.com/rmacdonaldsmith/CQRSExample/blob/master/src/Domain/ServiceBus/InMemoryServiceBus.cs

                Type ifaceType = typeof(Subscribes<>);
                Type[] evntTypeArgs = { @event.GetType() };
                Type genericHandlerType = ifaceType.MakeGenericType(evntTypeArgs);


                var subscribers = this.ninjectContainer.GetAll(genericHandlerType);
                foreach (var eventHandler in subscribers)
                {
                    ((dynamic)eventHandler).Handle(@event as dynamic); // i don't understand why this works! (Jon)
                    eventLogger.LogEvent(@event);
                }
            }
            catch (Ninject.ActivationException activationException)
            {
                throw new InvalidOperationException(
                    string.Format("There are no event handlers subscribed to handle events of type '{0}'",
                                  @event.GetType().Name), activationException);
            }
        }
    }
}
