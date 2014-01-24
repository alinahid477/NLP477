using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.Query.DataObjects
{
    public class Accomodation : Interfaces.IPlace
    {
        string _id = null;
        public string Name { get; set; }
        public string Id { get { return _id; } }

        public Accomodation(string id, string name)
        {
            Name = name;
            _id = id;
        }

        public override string ToString()
        {
            return "Accomodation : " + Name;
        }

    }
}
