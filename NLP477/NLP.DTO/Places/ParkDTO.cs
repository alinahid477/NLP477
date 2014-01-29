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
        public string ParkName { get; set; }
        public string ParkDesciption { get; set; }

    }
}
