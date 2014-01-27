using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLP.Infrastructure.Aggregate;
using NLP.Repository.Contexts;
using NLP.Infrastructure.Events;
namespace NLP.Repository
{
    public abstract class AbstractRepository<TEntity> where TEntity : Aggregate
    {
        protected NLPDomainContext context;
        protected IEventBus eventBus;
        protected IList<IEvent> uncommittedEvents;

        public AbstractRepository(IEventBus eventBus, NLPDomainContext _context)
        {
            this.context = _context;
            this.uncommittedEvents = new List<IEvent>();
            this.eventBus = eventBus;
        }

        protected void CommitEvents()
        {
            foreach (IEvent @event in uncommittedEvents)
            {
                eventBus.Publish(@event);
            }
            this.uncommittedEvents.Clear();
        }

        public abstract void Update(TEntity entity);

        public abstract void Add(TEntity entity);
    }
}
