using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Commands
{
    public interface ICommandSerializer
    {
        ICommand DeserializeCommand(string json, string typeName);
        string SerializeCommand(ICommand command);
    }
}
