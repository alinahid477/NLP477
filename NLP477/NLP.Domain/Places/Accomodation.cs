using NLP.Infrastructure.Aggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Domain.Places
{
    public class Accomodation : Aggregate, IPlace
    {
        [Key]
        public int ID { get; private set; }
        public Guid UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Url { get; private set; }
    }
}
