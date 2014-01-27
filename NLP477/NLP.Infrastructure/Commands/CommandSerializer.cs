using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Commands
{
    public class CommandSerializer : ICommandSerializer
    {
        private JsonSerializerSettings settings;

        public CommandSerializer()
        {
            var contractResolver = new DefaultContractResolver();
            contractResolver.DefaultMembersSearchFlags |= BindingFlags.NonPublic;
            settings = new JsonSerializerSettings { ContractResolver = contractResolver };
            settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            JsonSerializer serializer = new JsonSerializer();


        }
        public String SerializeCommand(ICommand command)
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
            return JsonConvert.SerializeObject(command);


        }

        public ICommand DeserializeCommand(String json, String typeName)
        {
            return (ICommand)JsonConvert.DeserializeObject(json, Type.GetType(typeName, true), settings);
        }
    }
}
