using NLP.Domain.Places;
using NLP.Infrastructure.Events;
using NLP.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Repository.AccomodationRepository
{
    public class AccomodationRepository : AbstractRepository<Accomodation>, IAccomodationRepository
    {

        public AccomodationRepository(IEventBus eventBus, NLPDomainContext _context)
            : base(eventBus, _context)
        {
        }

        public List<Accomodation> GetAccomodationsByPark(Guid parkUniqueId)
        { 
            List<Accomodation> list = new List<Accomodation>();
            return list;
        }

        public Accomodation GetAccomodation(Guid uniqueId)
        {
            Accomodation accom = null;
            return accom;
        }

        public override void Add(Accomodation park)
        { 
        
        }

        public override void Update(Accomodation park)
        { 
            
        }
    }
}
