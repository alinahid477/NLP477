using NLP.Infrastructure.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Aggregate
{
    public abstract class Aggregate
    {
        protected IList<IEvent> events = new List<IEvent>();
        public IEnumerable<IEvent> Events { get { return this.events; } }

    }
}
