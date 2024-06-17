using System.Runtime.Serialization;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    [Serializable]
    public class MovException : Exception
    {
        public MovException()
        {
        }

        public MovException(string? message) : base(message)
        {
        }

        public MovException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MovException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}