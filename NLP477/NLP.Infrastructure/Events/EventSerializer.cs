using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Events
{
    public class EventSerializer : IEventSerializer
    {
        private JsonSerializerSettings settings;

        public EventSerializer()
        {
            var contractResolver = new DefaultContractResolver();
            contractResolver.DefaultMembersSearchFlags |= BindingFlags.NonPublic;
            settings = new JsonSerializerSettings { ContractResolver = contractResolver, ReferenceLoopHandling = ReferenceLoopHandling.Serialize };
            settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            JsonSerializer serializer = new JsonSerializer();


        }
        public String SerializeEvent(IEvent @event)
        {
            /*
            DataContractJsonSerializer ser = new DataContractJsonSerializer(command.GetType());
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, command);
            ms.Position = 0;
            TextReader reader = new StreamReader(ms);
            String json = reader.ReadToEnd();


            return json;
            */
            return JsonConvert.SerializeObject(@event, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


        }

        public IEvent DeserializeEvent(String json, String typeName)
        {
            return (IEvent)JsonConvert.DeserializeObject(json, Type.GetType(typeName, true), settings);
        }
    }
}
