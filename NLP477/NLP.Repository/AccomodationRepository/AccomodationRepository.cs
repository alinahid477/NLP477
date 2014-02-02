using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Domain.Places;
using NLP.Infrastructure.Events;
using NLP.Repository.Contexts;


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

        public override void Add(Accomodation accomodation)
        { 
        
        }

        public void Add(List<Accomodation> accomodations)
        {
            /*context.Configuration.LazyLoadingEnabled = false;
            List<Park> parks = context.Parks.Include("Accomodations").ToList();
            foreach (Accomodation accom in accomodations)
            {
                int[] parkIDs = accom.Parks.Select(sel=>sel.ID).ToArray();
                List<Park> relatedParks = parks.Where(sel=>parkIDs.Contains(sel.ID)).ToList();
                accom.SetParks(relatedParks);
            }*/
            context.Accomodations.AddRange(accomodations);
            List<IEvent> eventList = new List<IEvent>();
            foreach (Accomodation a in accomodations)
            {
                eventList.AddRange(a.Events);
            }
            this.uncommittedEvents = eventList;
            context.SaveChanges();
            this.CommitEvents();
        }

        public override void Update(Accomodation accomodation)
        { 
            
        }

        public override Accomodation GetByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
