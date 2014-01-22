using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.JsonProcessor
{
    public class ParkConsumer : AbstractConsumer
    {
        public ParkConsumer()
            : base(System.Configuration.ConfigurationManager.AppSettings["ParkJsonUrl"])
        { 
            
        }
        public override List<DataObjects.Interfaces.IPlace> Process(string json)
        {
            List<DataObjects.Interfaces.IPlace> list = new List<DataObjects.Park>();
            return list;
        }
    }


    public class AccomodationConsumer : AbstractConsumer
    {
        public AccomodationConsumer()
            : base(System.Configuration.ConfigurationManager.AppSettings["AccomodationJsonUrl"])
        { 
            
        }
        public override List<DataObjects.Accomodation> Process(string json)
        {
            List<DataObjects.Accomodation> list = new List<DataObjects.Accomodation>();
            return list;
        }
    }

    public class RouteConsumer : AbstractConsumer
    {
        public RouteConsumer()
            : base(System.Configuration.ConfigurationManager.AppSettings["RouteJsonUrl"])
        { 
            
        }
        public override List<DataObjects.Route> Process(string json)
        {
            List<DataObjects.Route> list = new List<DataObjects.Route>();
            return list;
        }
    }
}
