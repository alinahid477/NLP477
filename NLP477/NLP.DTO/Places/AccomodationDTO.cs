using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.DTO.Places
{
    public class AccomodationDTO
    {
        private string _downloadsource = null;
        public string DownloadSource
        {
            get
            {
                if (_downloadsource == null)
                    return ConfigurationManager.AppSettings["AccomodationsDownloadURL"];
                return _downloadsource;
            }
            set
            {
                _downloadsource = value;
            }
        }


        public string accommodation_url { get; set; }
        public AccomodationIndentity identity { get; set; }
        public AccomodationRelationship relationships { get; set; }
        public SEODTO seo { get; set; }
    }

    public class AccomodationIndentity
    {
        public Guid unique_id { get; set; }
        public string name { get; set; }
        public string primary_identity_id { get; set;  }
    }

    public class AccomodationRelationship
    {
        public string[] Parks { get; set; }
    }
}
