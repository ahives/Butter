namespace Butter
{
    using System;
    using System.Runtime.Serialization;

    public class EntityCreationException :
        Exception
    {
        public EntityCreationException()
        {
        }

        protected EntityCreationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public EntityCreationException(string message) : base(message)
        {
        }

        public EntityCreationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}