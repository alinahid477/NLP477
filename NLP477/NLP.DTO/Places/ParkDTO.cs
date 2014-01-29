using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.DTO.Places
{
    public class ParkDTO
    {
        private string _downloadsource = null;
        public string DownloadSource 
        {
            get
            {
                if (_downloadsource == null)
                    return ConfigurationManager.AppSettings["ParksDownloadURL"];
                return _downloadsource;
            }
            set
            {
                _downloadsource = value;
            }
        }

        public string ParkCODE { get; set; }
        public string ParkURL { get; set; }
        public Guid ItemID { get; set; }
        public ParkSEO seo { get; set; }
    }

    public class ParkSEO
    {
        public string meta_title { get; set; }
        public string meta_description { get; set; }
        public string location_keywords { get; set; }
    }
}
