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
        {
            this.url = System.Configuration.ConfigurationManager.AppSettings["ParkJsonUrl"];
        }
        
        public override List<DataObjects.Interfaces.IPlace> Process(string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException("json string is null.");
            List<DataObjects.Interfaces.IPlace> list = new List<DataObjects.Interfaces.IPlace>();
            return list;
        }
    }


    public class AccomodationConsumer : AbstractConsumer
    {
        public AccomodationConsumer()
        {
            this.url = System.Configuration.ConfigurationManager.AppSettings["AccomodationJsonUrl"];
        }
        public override List<DataObjects.Interfaces.IPlace> Process(string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException("json string is null.");
            List<DataObjects.Interfaces.IPlace> list = new List<DataObjects.Interfaces.IPlace>();
            return list;
        }
    }

    public class RouteConsumer : AbstractConsumer
    {
        public RouteConsumer()
        {
            this.url = System.Configuration.ConfigurationManager.AppSettings["RouteJsonUrl"];
        }
        public override List<DataObjects.Interfaces.IPlace> Process(string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException("json string is null.");
            List<DataObjects.Interfaces.IPlace> list = new List<DataObjects.Interfaces.IPlace>();
            return list;
        }
    }
}
