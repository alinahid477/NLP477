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
    public class AccomodationLogic : Aggregate
    {
        public List<Accomodation> Accomodations = null;
        public void DownloadFromExternalSource(AccomodationDTO dto)
        {
            string downloadedtext = ExternalReader.Download(dto.DownloadSource);
            List<AccomodationDTO> list = JsonConvert.DeserializeObject<List<AccomodationDTO>>(downloadedtext);
            List<Accomodation> accomList = new List<Accomodation>();
            foreach (AccomodationDTO adto in list)
            {
                Accomodation x = new Accomodation();
                x.Create(adto.identity.unique_id, adto.identity.name, adto.accommodation_url, adto.identity.primary_identity_id, adto.seo.meta_description);
                accomList.Add(x);
            }
            this.events.Add(new AccomodationsCreated("Total parks created : " + accomList.Count));
            this.Accomodations = accomList;
        }


    }
}
