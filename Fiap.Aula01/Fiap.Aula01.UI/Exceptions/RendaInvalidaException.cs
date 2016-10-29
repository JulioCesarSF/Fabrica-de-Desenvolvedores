using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Aula01.UI.Exceptions
{
    [Serializable] //anotação 
    public class RendaInvalidaException : Exception
    {
        public RendaInvalidaException() { }
        public RendaInvalidaException(string message) : base(message) { }
        public RendaInvalidaException(string message, Exception inner) : base(message, inner) { }
        protected RendaInvalidaException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
