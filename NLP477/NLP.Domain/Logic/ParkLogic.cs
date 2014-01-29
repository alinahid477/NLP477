﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Domain.Places;
using NLP.DTO.Places;
using NLP.Services.External;
using NLP.Services.Util;
using Newtonsoft.Json;
using NLP.Infrastructure.Aggregate;
using NLP.Domain.Events;

namespace NLP.Domain.Logic
{
    public class ParkLogic : Aggregate
    {
        public List<Park> Parks = null;
        public void DownloadParksFromExternalSource(ParkDTO dto)
        {
            string downloadedtext = null;
            if (Utility.IsJson(dto.DownloadSource))
                downloadedtext = dto.DownloadSource;
            else if (dto.DownloadSource.Contains("http"))
                downloadedtext = ExternalReader.DownloadFromURL(dto.DownloadSource);
            else
                downloadedtext = ExternalReader.DownloadFromFile(dto.DownloadSource);

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
                x.Create(pdto.seo.meta_title, pdto.ParkCODE, pdto.seo.meta_description, llist);
                parkList.Add(x);
            }
            this.events.Add(new ParksCreated("Total parks created : " + parkList.Count));
            this.Parks = parkList;
        }


    }
}
