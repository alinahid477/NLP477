using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLP.Domain.Places;
using NLP.Domain.Logic;

namespace NLP.Repository.ParkRepository
{
    public interface IParkRepository
    {
        Park GetPark(Guid uniqueId);
        Park GetParkByCode(string parkCode);
        List<Park> GetAll();
        void Add(Park park);
        void Update(Park park);
        void AddBulk(ParkLogic park);
    }
}
