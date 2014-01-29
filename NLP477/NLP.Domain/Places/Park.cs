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
        public virtual List<Accomodation> Accomodations { get; private set; }

        public void Create(string title, string parkCode, string description)
        {
            Title = title;
            ParkCode = parkCode;
            Description = description;
        }

    }
}
