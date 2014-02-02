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
using Ninject;

namespace NLP.Processor.Data
{
    public class DomainQuery : IDomainQuery
    {
        [Inject]
        public IEventBus eventBus {private get; set;}
        //private NLPDomainContext context;

        [Inject]
        public NLPDomainContext context { private get; set; }


        public DomainQuery()
        {
        }

        /*public DomainQuery(IEventBus bus, NLPDomainContext _context)
        {
            this.eventBus = bus;
            this.context = _context;
        }*/

        public List<Park> GetAllParks()
        {
            ParkRepository repo = new ParkRepository(eventBus, context);
            return repo.GetAll();
        }
    }
}
