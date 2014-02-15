using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using NLP.Domain.Places;
using NLP.Infrastructure.Events;
using NLP.Repository.Contexts;
using EntityFramework.Extensions;
using System.Data.Entity;

namespace NLP.Repository.ParkRepository
{
    public class ParkRepository : AbstractRepository<Park>, IParkRepository
    {

        public ParkRepository(IEventBus eventBus, NLPDomainContext _context)
            : base(eventBus, _context)
        {
        }

        public List<Park> GetAll()
        {
            return context.Parks.Include(p=>p.Accomodations).ToList();
        }

        public Park GetPark(Guid uniqueId)
        {
            Park park = null;
            return park;
        }
        public override Park GetByID(int ID)
        {
            return context.Parks.Where(p => p.ID == ID).FirstOrDefault();
        }
        public Park GetParkByCode(string parkCode)
        {
            Park park = null;
            return park;
        }

        public override void Add(Park entity)
        {
            context.Parks.Add(entity);
            context.SaveChanges();

            this.uncommittedEvents = entity.Events.ToList();
            this.CommitEvents();
        }

        public void Add(List<Park> parks)
        {
            context.Parks.AddRange(parks);
            List<IEvent> eventList = new List<IEvent>();
            foreach (Park p in parks)
            { 
                eventList.AddRange(p.Events);
            }
            this.uncommittedEvents = eventList;
            context.SaveChanges();
            this.CommitEvents();
        }

        public override void Update(Park entity)
        {
            context.Parks.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            this.uncommittedEvents = entity.Events.ToList();
            this.CommitEvents();
        }

        public void Update(List<Park> parks)
        {

            foreach (Park park in parks)
            {
                Park dbPark = this.GetByID(park.ID);
                context.Parks.Attach(dbPark);
                context.Entry(dbPark).State = EntityState.Modified;
                
            }
            
            context.SaveChanges();
            List<IEvent> eventList = new List<IEvent>();
            foreach (Park p in parks)
            {
                eventList.AddRange(p.Events);
            }
            this.uncommittedEvents = eventList;
            this.CommitEvents();
        }
    }
}
