using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Services.External
{
    public class ExternalReader
    {
        public static string DownloadFromURL(string url)
        {
            string s = null;
            s = (new System.Net.WebClient()).DownloadString(url);
            return s;
        }

        public static string DownloadFromFile(string url)
        {
            string s = null;

            return s;
        }
    }
}
