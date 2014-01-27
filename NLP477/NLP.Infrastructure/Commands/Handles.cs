using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Commands
{
    public interface Handles<T> where T : class, ICommand
    {
        void Handle(T command);
    } 
}
