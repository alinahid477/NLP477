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
        public string DownloadURL 
        {
            get
            {
                return ConfigurationManager.AppSettings["ParksDownloadURL"];
            }
        }


    }
}
