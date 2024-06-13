using System.Runtime.Serialization;

namespace Papeleria.LogicaNegocio.Excepciones
{
    [Serializable]
    public class TMovException : Exception
    {
        public TMovException()
        {
        }

        public TMovException(string? message) : base(message)
        {
        }

        public TMovException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TMovException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}