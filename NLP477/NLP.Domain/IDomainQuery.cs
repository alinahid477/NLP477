using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Domain.Places;

namespace NLP.Domain
{
    public interface IDomainQuery
    {
        List<Park> GetAllParks();
    }
}
