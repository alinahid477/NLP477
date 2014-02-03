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
using Ninject;
using SimMetricsMetricUtilities;
namespace NLP.Domain.Factories
{
    public class PlaceFactory : Aggregate, IPlaceFactory
    {
        //[Inject]
        public IDomainQuery DomainQuery { get; private set; }

        public PlaceFactory(IDomainQuery domainQuery)
        {
            this.DomainQuery = domainQuery;
        }
        //public PlaceFactory() { }

        

        public List<Park> DownloadFromExternalSource(ParkDTO dto)
        {
            string downloadedtext = ExternalReader.Download(dto.DownloadSource);
            List<ParkDTO> list = JsonConvert.DeserializeObject<List<ParkDTO>>(downloadedtext);
            List<Park> parkList = new List<Park>();
            foreach (ParkDTO pdto in list)
            {
                List<Location> llist = new List<Location>();
                foreach (string s in pdto.seo.location_keywords.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    llist.Add(new Location(s.Trim()));
                }
                Park x = new Park(pdto.ItemID, pdto.ParkName, pdto.ParkURL, pdto.ParkCODE, pdto.ParkDescription, llist);
                parkList.Add(x);
            }
            return parkList;
        }

        public List<Accomodation> DownloadFromExternalSource(AccomodationDTO dto)
        {
            
            string downloadedtext = ExternalReader.Download(dto.DownloadSource);
            List<AccomodationDTO> list = JsonConvert.DeserializeObject<List<AccomodationDTO>>(downloadedtext);
            List<Accomodation> accomList = new List<Accomodation>();
            List<Park> parks = DomainQuery.GetAllParks();

            foreach (AccomodationDTO adto in list)
            {
                List<Park> relatedParks = (from park in parks where adto.relationships.Parks.Contains(park.Title) select park).ToList();
                
                if (relatedParks.Count < 1 || relatedParks.Count != adto.relationships.Parks.Length)
                {
                    foreach (string parkName in adto.relationships.Parks)
                    {
                        if (relatedParks.Select(p => p.Title).ToArray().Contains(parkName))
                            continue;
                        foreach (Park park in parks)
                        {
                            Levenstein editDistance = new Levenstein();
                            if (editDistance.GetSimilarity(parkName, park.Title) > 0.7)
                            {
                                relatedParks.Add(park);
                            }
                        }
                    }
                }
                if (relatedParks.Count < 1) continue; 
                Accomodation x = new Accomodation();
                
                x.Create(adto.identity.unique_id, adto.identity.name, adto.accommodation_url, adto.identity.primary_identity_id, adto.seo.meta_description, relatedParks);
                accomList.Add(x);
            }
            return accomList;
        }
    }
}
