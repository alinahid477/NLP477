using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Infrastructure.Events;
using NLP.Domain.Places;


namespace NLP.Domain.Events
{

    public class AccomodationCreated: AbstractEvent, IEvent
    {
        public Accomodation Accomodation { get; private set; }
        public AccomodationCreated(Accomodation accomodation)
        {
            this.Accomodation = accomodation;
        }
    }
}
