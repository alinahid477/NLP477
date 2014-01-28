using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NLP.Domain.Places;

namespace NLP.Repository.Contexts
{
    public class NLPDomainContext : DbContext
    {
        public DbSet<Park> Parks { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }
        static NLPDomainContext()
        {
            var _ = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            //var __ = typeof(System.Data.Entity.SqlServerCompact.SqlCeProviderServices);
        }
    }
}
