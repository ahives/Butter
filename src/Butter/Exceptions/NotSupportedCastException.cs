namespace Butter
{
    using System;
    using System.Runtime.Serialization;

    public class NotSupportedCastException :
        Exception
    {
        public NotSupportedCastException()
        {
        }

        protected NotSupportedCastException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public NotSupportedCastException(string message)
            : base(message)
        {
        }

        public NotSupportedCastException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}