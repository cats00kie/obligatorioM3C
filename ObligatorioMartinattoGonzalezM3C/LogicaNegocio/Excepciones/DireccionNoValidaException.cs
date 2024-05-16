using System.Runtime.Serialization;

namespace Papeleria.LogicaNegocio.Excepciones
{
    [Serializable]
    internal class DireccionNoValidaException : Exception
    {
        public DireccionNoValidaException()
        {
        }

        public DireccionNoValidaException(string? message) : base(message)
        {
        }

        public DireccionNoValidaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DireccionNoValidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}