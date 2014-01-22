using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.JsonProcessor.Interfaces
{
    public interface IDownloader
    {
        string Download(string url);
    }
}
