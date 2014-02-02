using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Domain.Places;


namespace NLP.Repository.ParkRepository
{
    public interface IParkRepository
    {
        Park GetPark(Guid uniqueId);
        Park GetParkByCode(string parkCode);
        List<Park> GetAll();
        void Add(Park park);
        void Update(Park park);
        void Add(List<Park> parks);
        void Update(List<Park> parks);
    }
}
