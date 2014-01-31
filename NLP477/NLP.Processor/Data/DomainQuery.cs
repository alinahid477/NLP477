using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Domain;
using NLP.Domain.Places;
using NLP.Repository.ParkRepository;
using NLP.Infrastructure.Events;
using NLP.Repository.Contexts;

namespace NLP.Processor.Data
{
    public class DomainQuery : IDomainQuery
    {
        private IEventBus eventBus;
        private NLPDomainContext context;

        public DomainQuery(IEventBus bus, NLPDomainContext _context)
        {
            this.eventBus = bus;
            this.context = _context;
        }

        public List<Park> ParksGetAll()
        {
            ParkRepository repo = new ParkRepository(eventBus, context);
            return repo.GetAll();
        }
    }
}
