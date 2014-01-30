using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Infrastructure.Events;


namespace NLP.Domain.Events
{

    public class AccomodationsCreated: AbstractEvent, IEvent
    {
        public string Message { get; set; }
        public AccomodationsCreated(string msg)
        {
            this.Message = msg;
        }
    }
}
