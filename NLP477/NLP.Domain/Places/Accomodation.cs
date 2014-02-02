using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NLP.Infrastructure.Aggregate;
using NLP.Domain.Events;

namespace NLP.Domain.Places
{
    public class Accomodation : Aggregate, IPlace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; private set; }
        public Guid UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Url { get; private set; }
        public string Type { get; private set; }

        public virtual List<Park> Parks { get; private set; }

        public void Create(Guid uniqueId, string title, string url, string type, string description, List<Park> parkList)
        {
            UniqueId = uniqueId;
            Title = title;
            Url = url;
            Type = type;
            Description = description;
            Parks = parkList;

            events.Add(new AccomodationCreated(this));
        }

        public void SetParks(List<Park> parks)
        {
            Parks = parks;
        }
    }
}
