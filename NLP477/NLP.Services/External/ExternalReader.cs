using NLP.Services.Util;
using System;
using System.Collections.Generic;
using System.IO;
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
            using (StreamReader sr = new StreamReader(url))
            {
                s = sr.ReadToEnd();
                sr.Close();
            }
            return s;
        }


        public static string Download(string source)
        {
            string downloadedtext = null;
            if (Utility.IsJson(source))
                downloadedtext = source;
            else if (source.Contains("http"))
                downloadedtext = ExternalReader.DownloadFromURL(source);
            else
                downloadedtext = ExternalReader.DownloadFromFile(source);

            return downloadedtext;
        }
    }
}
