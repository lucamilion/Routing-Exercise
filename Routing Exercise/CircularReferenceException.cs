using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing_Exercise
{
    [Serializable]
    public class CircularReferenceException : Exception
    {
        public CircularReferenceException() : base() { }
        public CircularReferenceException(string message) : base(message) { }
        public CircularReferenceException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected CircularReferenceException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
