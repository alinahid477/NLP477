using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.DTO.Exceptions
{
    public abstract class ErrorBase : System.SystemException
    {
        public String ErrorCode { get; set; }
        public String ErrorDescription { get; set; }
        public String ErrorType { get; set; }

        public ErrorBase()
        {
            this.ErrorType = this.GetType().ToString();
        }

        public ErrorBase(String message)
            : base(message)
        {
            this.ErrorType = this.GetType().ToString();
        }

        public ErrorBase(string message, Exception innerException)
            : base(message, innerException)
        {
            this.ErrorType = this.GetType().ToString();
        }
    }
}
