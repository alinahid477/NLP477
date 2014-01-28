using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.DTO.Exceptions
{
    public class SystemError : ErrorBase
    {
        public SystemError()
        {

        }

        public SystemError(String message)
            : base(message)
        {

        }

        public SystemError(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
