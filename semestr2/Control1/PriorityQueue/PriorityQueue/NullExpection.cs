using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class NullExpection : ApplicationException
    {
        public NullExpection(string message) 
            : base(message)
        {
        }
    }
}
