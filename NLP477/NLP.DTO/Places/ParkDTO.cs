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
        private string _parkname;
        public string ParkName 
        {
            get
            {
                if (!string.IsNullOrEmpty(_parkname))
                    return _parkname;
                else
                    return seo.meta_title;
            }
            set
            {
                _parkname = value;
            }
        }
        private string _parkdescription;
        public string ParkDescription 
        {
            get 
            {
                if (!string.IsNullOrEmpty(_parkdescription))
                    return _parkdescription;
                else
                    return seo.meta_description;
            }
            set
            {
                _parkdescription = value;
            }
        }
        public ParkSEO seo { get; set; }
    }

    public class ParkSEO
    {
        public string meta_title { get; set; }
        public string meta_description { get; set; }
        public string location_keywords { get; set; }
    }
}
