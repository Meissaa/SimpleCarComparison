using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarComparison.Common.Exceptions
{
    [Serializable]
    public class VerifierException : Exception
    {
        public VerifierException() { }
        public VerifierException(string message) : base(message) { }
        public VerifierException(string message, Exception inner) : base(message, inner) { }
        protected VerifierException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
