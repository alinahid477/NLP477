using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Events
{
    public interface IEventSerializer
    {
        IEvent DeserializeEvent(string json, string typeName);
        string SerializeEvent(IEvent @event);
    }
}
