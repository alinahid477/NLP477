using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        protected String guid;
        protected String actor;
        protected DateTime dateTime;

        public AbstractCommand()
        {

            this.guid = Guid.NewGuid().ToString();
            dateTime = DateTime.Now;
        }
        public string GUID
        {
            get { return this.guid; }
        }

        public String Actor
        {
            get
            {

                return this.actor;
            }
            set
            {
                this.actor = value;
            }
        }

        public DateTime DateTime
        {
            get { return this.dateTime; }
        }

        public CommandStatus CommandStatus { get; set; }
    }
}
