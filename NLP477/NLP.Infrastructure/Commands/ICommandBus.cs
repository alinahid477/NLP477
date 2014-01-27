using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Commands
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}
