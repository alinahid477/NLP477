using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Domain.Places;
using NLP.DTO.Places;
using NLP.Services.External;
using Newtonsoft.Json;
using NLP.Infrastructure.Aggregate;
using NLP.Domain.Events;

namespace NLP.Domain.Logic
{
    public class ParkLogic : Aggregate
    {
        public List<Park> Parks = null;
        public void DownloadFromExternalSource(ParkDTO dto)
        {
            string downloadedtext = ExternalReader.Download(dto.DownloadSource);
            List<ParkDTO> list = JsonConvert.DeserializeObject<List<ParkDTO>>(downloadedtext);
            List<Park> parkList = new List<Park>();
            foreach (ParkDTO pdto in list)
            {
                List<Location> llist = new List<Location>();
                foreach(string s in pdto.seo.location_keywords.Split(new string[]{","}, StringSplitOptions.RemoveEmptyEntries) )
                {
                    llist.Add(new Location(s.Trim()));
                }
                Park x = new Park();
                x.Create(pdto.ItemID, pdto.ParkName, pdto.ParkURL, pdto.ParkCODE, pdto.ParkDescription, llist);
                parkList.Add(x);
            }
            this.events.Add(new ParksCreated("Total parks created : " + parkList.Count));
            this.Parks = parkList;
        }


    }
}
