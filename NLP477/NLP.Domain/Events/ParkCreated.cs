using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Infrastructure.Events;
using NLP.Domain.Places;


namespace NLP.Domain.Events
{
    public class ParkCreated : AbstractEvent, IEvent
    {
        public Park Park { get; private set; }
        public ParkCreated(Park park)
        {
            this.Park = park;
        }
    }
}
