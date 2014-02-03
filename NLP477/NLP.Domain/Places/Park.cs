using NLP.Domain.Events;
using NLP.Infrastructure.Aggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Domain.Places
{
    public class Park : Aggregate, IPlace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; private set; }
        public Guid UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Url { get; private set; }
        public string ParkCode { get; private set; }
        public virtual List<Location> Locations { get; private set; }
        public virtual List<Accomodation> Accomodations { get; private set; }

        public Park()
        {
            UniqueId = Guid.Empty;
            this.Accomodations = new List<Accomodation>();
        }

        public Park(Guid uniqueId, string title, string url, string parkCode, string description, List<Location> locations)
        {
            UniqueId = uniqueId;
            Title = title;
            Url = url;
            ParkCode = parkCode;
            Description = description;
            this.Locations = locations;
            this.events.Add(new ParkCreated(this));
        }

        public Park(int id, Guid uniqueId, string title, string url, string parkCode, string description, List<Location> locations)
        {
            ID = id;
            UniqueId = uniqueId;
            Title = title;
            Url = url;
            ParkCode = parkCode;
            Description = description;
            this.Locations = locations;
            this.events.Add(new ParkCreated(this));
        }

        public void AddAccomodation(Accomodation accomodation)
        {
            if (UniqueId == Guid.Empty)
                throw new NullReferenceException("Park object has not been created. Use Create() to create park object");
            this.Accomodations.Add(accomodation);
        }
        public void AddAccomodations(List<Accomodation> accomodations)
        {
            if (UniqueId == Guid.Empty)
                throw new NullReferenceException("Park object has not been created. Use Create() to create park object");
            this.Accomodations.AddRange(accomodations);
            this.events.Add(new AccomodationsCreated(string.Format("Accomodations added : {0}.", accomodations.Count)));
        }

        public void AddAccomodations(List<Accomodation> accomodations, bool isNewRange)
        {
            if (isNewRange)
            {
                this.Accomodations.Clear();
                this.events.Add(new AccomodationsCreated(string.Format("Accomodations in Park {0} cleared for adding accomodations from scratch.", this.Title)));
            }
            this.AddAccomodations(accomodations);
        }

    }
}
