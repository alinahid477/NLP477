using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.DataObjects
{
    public class Park : Interfaces.IPlace
    {
        string _id = null;
        public string Name { get; set; }
        public string Id { get { return _id; } }
        public Park(string id, string name)
        {
            _id = id;
            Name = name;
        }

        public override string ToString()
        {
            return "Park : "+Name;
        }

    }
}
