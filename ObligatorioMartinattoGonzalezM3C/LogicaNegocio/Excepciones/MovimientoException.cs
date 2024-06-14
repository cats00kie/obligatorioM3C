using System.Runtime.Serialization;

namespace Papeleria.LogicaNegocio.Excepciones
{
    [Serializable]
    internal class MovimientoException : Exception
    {
        public MovimientoException()
        {
        }

        public MovimientoException(string? message) : base(message)
        {
        }

        public MovimientoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MovimientoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}