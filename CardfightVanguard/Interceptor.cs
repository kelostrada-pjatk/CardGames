using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardfightVanguard
{
    public class Interceptor : Shield
    {
        public Interceptor(string name, string description, int power, int shield) 
            : base(name, description, power, shield)
        {
        }
    }
}
