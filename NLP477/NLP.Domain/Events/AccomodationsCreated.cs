using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Infrastructure.Events;
using NLP.Domain.Places;


namespace NLP.Domain.Events
{

    public class AccomodationsCreated: AbstractEvent, IEvent
    {
        public string Message { get; private set; }
        public AccomodationsCreated(string message)
        {
            this.Message = message;
        }
    }
}
