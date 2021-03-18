namespace Butter
{
    using System;
    using System.Runtime.Serialization;

    public class ValueOutOfRangeException :
        Exception
    {
        public ValueOutOfRangeException()
        {
        }

        protected ValueOutOfRangeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ValueOutOfRangeException(string message)
            : base(message)
        {
        }

        public ValueOutOfRangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}