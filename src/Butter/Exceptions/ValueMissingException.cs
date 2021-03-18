namespace Butter
{
    using System;
    using System.Runtime.Serialization;

    public class ValueMissingException :
        Exception
    {
        public ValueMissingException()
        {
        }

        protected ValueMissingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ValueMissingException(string message)
            : base(message)
        {
        }

        public ValueMissingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}