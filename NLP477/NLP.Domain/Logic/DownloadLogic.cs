using NLP.Infrastructure.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Domain.Logic
{
    public class DownloadLogic<TObject> : Aggregate where TObject : class, IDownloadLogic 
    {
        public void DownloadFromExternalSource(TObject obj)
        {
            
        }
    }
}
