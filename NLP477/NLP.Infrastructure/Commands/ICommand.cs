using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Commands
{
    public interface ICommand
    {

        String GUID { get; }
        String Actor { get; set; }
        DateTime DateTime { get; }
        CommandStatus CommandStatus { get; set; }
    }
}
