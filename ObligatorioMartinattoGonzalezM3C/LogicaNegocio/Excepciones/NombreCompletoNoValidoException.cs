using System.Runtime.Serialization;

namespace Papeleria.LogicaNegocio.Excepciones
{
    [Serializable]
    internal class NombreCompletoNoValidoException : Exception
    {
        public NombreCompletoNoValidoException()
        {
        }

        public NombreCompletoNoValidoException(string? message) : base(message)
        {
        }

        public NombreCompletoNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NombreCompletoNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}