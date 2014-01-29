﻿using NLP.Domain.Logic;
using NLP.Domain.Places;
using NLP.Infrastructure.Events;
using NLP.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<Park> list = new List<Park>();
            return list;
        }

        public Park GetPark(Guid uniqueId)
        {
            Park park = null;
            return park;
        }

        public Park GetParkByCode(string parkCode)
        {
            Park park = null;
            return park;
        }

        public override void Add(Park entity)
        { 
            
        }

        public void AddBulk(ParkLogic logicalEntity)
        {
            context.Parks.AddRange(logicalEntity.Parks);
            this.uncommittedEvents = logicalEntity.Events.ToList();
            context.SaveChanges();
            this.CommitEvents();
        }

        public override void Update(Park entity)
        { 
            
        }
    }
}
