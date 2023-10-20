using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBCapital
{
    public abstract class Observer
    {
        public abstract void Update(string ticket, string message);
    }
}
