using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Domain.Logic
{
    public interface IDownloadLogic
    {
        void DownloadFromExternalSource<TLogicObject>(TLogicObject obj) where TLogicObject : class, IDownloadLogic;
    }
}
