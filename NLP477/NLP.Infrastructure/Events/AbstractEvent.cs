using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Events
{
    public abstract class AbstractEvent : IEvent
    {
        protected string eventguid;
        protected DateTime dateTime;

        public AbstractEvent()
        {
            this.eventguid = Guid.NewGuid().ToString();
            dateTime = DateTime.Now;
        }
        public string EventGUID
        {
            get { return this.eventguid; }
        }

        public DateTime DateTime
        {
            get { return this.dateTime; }
        }
    }
}
