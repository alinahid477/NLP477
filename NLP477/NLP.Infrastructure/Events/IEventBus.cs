using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Events
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : class, IEvent;
    }
}
