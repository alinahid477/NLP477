using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Domain.Places;

namespace NLP.Repository.AccomodationRepository
{
    public interface IAccomodationRepository
    {
        Accomodation GetAccomodation(Guid uniqueId);
        List<Accomodation> GetAccomodationsByPark(Guid parkUniqueId);
        void Add(List<Accomodation> accomodations);
        void Add(Accomodation accomodation);
        void Update(Accomodation accomodation);
    }
}
