using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Excepciones
{
    public class AdministradorNoValidoException : Exception
    {
        public AdministradorNoValidoException()
        {
        }

        public AdministradorNoValidoException(string? message) : base(message)
        {
        }

        public AdministradorNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AdministradorNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
