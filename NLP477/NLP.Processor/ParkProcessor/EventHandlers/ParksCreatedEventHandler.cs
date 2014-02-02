using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Domain.Events;
using NLP.Infrastructure.Events;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace NLP.Processor.ParkProcessor.EventHandlers
{
    public class ParksCreatedEventHandler : Subscribes<ParkCreated>
    {
        private ExceptionManager exManager;

        public ParksCreatedEventHandler(ExceptionManager eManager)
        {
            this.exManager = eManager;
        }

        public void Handle(ParkCreated @event)
        {
            exManager.Process(() =>
                {
                    //Send notification.

                }, "ProcessorPolicy");
        }
    }
}
