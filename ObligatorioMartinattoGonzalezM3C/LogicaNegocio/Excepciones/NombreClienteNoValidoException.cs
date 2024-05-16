using System.Runtime.Serialization;

namespace Papeleria.LogicaNegocio.Excepciones
{
    [Serializable]
    internal class NombreClienteNoValidoException : Exception
    {
        public NombreClienteNoValidoException()
        {
        }

        public NombreClienteNoValidoException(string? message) : base(message)
        {
        }

        public NombreClienteNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NombreClienteNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}