using NLP.Infrastructure.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Domain.Events
{
    public class ParksCreated : AbstractEvent, IEvent
    {
        public string Message { get; set; }
        public ParksCreated(string msg)
        {
            this.Message = msg;
        }
    }
}
