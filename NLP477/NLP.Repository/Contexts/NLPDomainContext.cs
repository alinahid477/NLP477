using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NLP.Domain.Places;
using System.Data.Entity.Infrastructure;

namespace NLP.Repository.Contexts
{
    public class NLPDomainContext : DbContext
    {
        public DbSet<Park> Parks { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }
        public NLPDomainContext()
            : base("NLPDataContext")
        {
            var _ = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            //var __ = typeof(System.Data.Entity.SqlServerCompact.SqlCeProviderServices);
            //Database.SetInitializer(new NLPDBContextInitializer());
        }

        /*
        private class NLPDBContextInitializer : DropCreateDatabaseIfModelChanges<NLPDomainContext>
        {
            public NLPDBContextInitializer()
            {
#if DEBUG
                Database.SetInitializer<NLPDomainContext>(new DropCreateDatabaseIfModelChanges<NLPDomainContext>());
#else
                Database.SetInitializer<NLPDomainContext>(null);
#endif
                using (var context = new NLPDomainContext())
                {
                    if (!context.Database.Exists())
                    {
                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    }
                    context.Database.Initialize(true);
                }
            }

            protected override void Seed(NLPDomainContext context)
            {
                if (!context.Database.Exists())
                {
                    ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                }
                //context.Patients.Add(new Patient { Name = "Fred Peters" });
                //context.Patients.Add(new Patient { Name = "John Smith" });
                //context.Patients.Add(new Patient { Name = "Karen Fredricks" });
            }
        }
        */
    }

    
}
