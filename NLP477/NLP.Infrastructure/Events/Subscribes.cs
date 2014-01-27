using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Events
{
    public interface Subscribes<TEvent> where TEvent : class, IEvent
    {
        void Handle(TEvent @event);
    }
}
