using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Events
{
    public interface IEventLogger
    {
        void LogEvent(IEvent @event);
    }
}
