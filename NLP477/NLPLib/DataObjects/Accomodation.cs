using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPLib.DataObjects
{
    public class Accomodation : Interfaces.IPlace
    {
        string _name = null;
        public Accomodation(string name)
        {
            _name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
}
