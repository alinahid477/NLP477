using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Domain.Places;
using NLP.Infrastructure.Events;
using NLP.Repository.Contexts;
using System.Data.Entity;


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
            list = (from accomList in context.Accomodations where accomList.Parks.Where(p=>p.UniqueId == parkUniqueId).ToList().Count > 0 select accomList).ToList();
            return list;
        }

        public Accomodation GetAccomodation(Guid uniqueId)
        {
            return context.Accomodations.Where(entity=>entity.UniqueId == uniqueId).FirstOrDefault();
        }

        public override Accomodation GetByID(int ID)
        {
            return context.Accomodations.Where(entity => entity.ID == ID).FirstOrDefault();
        }

        public override void Add(Accomodation entity)
        {
            List<Park> dbParkList = new List<Park>();
            foreach (Park park in entity.Parks)
            {
                Park dbPark = new Park(park.ID, park.UniqueId, park.Title, park.Url, park.ParkCode, park.Description, park.Locations);
                context.Parks.Attach(dbPark);
                dbParkList.Add(dbPark);
            }
            entity.SetParks(dbParkList);
        }

        public void Add(List<Accomodation> accomodations)
        {
            //EITHER
            /*context.Configuration.LazyLoadingEnabled = false;
            List<Park> parks = context.Parks.Include("Accomodations").ToList();
            foreach (Accomodation accom in accomodations)
            {
                int[] parkIDs = accom.Parks.Select(sel=>sel.ID).ToArray();
                List<Park> relatedParks = parks.Where(sel=>parkIDs.Contains(sel.ID)).ToList();
                accom.SetParks(relatedParks);
            }*/

            //OR
            // This StackOverflow Problem : http://stackoverflow.com/questions/7478570/entity-framework-code-first-adding-to-many-to-many-relationship-by-id 
            //states similar to what I'm facing here.

            
            List<Park> addedToContextParkList = new List<Park>(); // this is to avoid attaching 1 park twice in the context. So we can add that to accomodation but not to context.
                                                                    // attaching one object twice to context causes error.

            foreach(Accomodation accom in accomodations)
            {
                List<Park> dbParkList = new List<Park>();
                foreach (Park park in accom.Parks)
                {
                    Park dbPark = addedToContextParkList.Where(p => p.ID == park.ID).FirstOrDefault();
                    if (dbPark == null)
                    {
                        dbPark = new Park(park.ID, park.UniqueId, park.Title, park.Url, park.ParkCode, park.Description, park.Locations);
                        context.Parks.Attach(dbPark);
                        dbParkList.Add(dbPark);
                        addedToContextParkList.Add(dbPark);
                    }
                    else
                    {
                        dbParkList.Add(dbPark);
                    }
                }
                accom.SetParks(dbParkList);
            }
            
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

        public override void Update(Accomodation entity)
        {
            context.Accomodations.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            this.uncommittedEvents = entity.Events.ToList();
            this.CommitEvents();
        }
    }
}
