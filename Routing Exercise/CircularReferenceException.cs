using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_Exercise
{
    public class CircularReferenceException : Exception
    {
        public CircularReferenceException() : base() { }
        public CircularReferenceException(string message) : base(message) { }
        public CircularReferenceException(string message, Exception inner) : base(message, inner) { }
    }
}
