using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLP.Domain.Places;
using NLP.DTO.Places;


namespace NLP.Domain.Factories
{
    public interface IPlaceFactory
    {
        List<Park> DownloadFromExternalSource(ParkDTO dto);
        List<Accomodation> DownloadFromExternalSource(AccomodationDTO dto);
    }
}
