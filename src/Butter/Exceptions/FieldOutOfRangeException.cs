namespace Butter
{
    using System;
    using System.Runtime.Serialization;

    public class FieldOutOfRangeException :
        Exception
    {
        public FieldOutOfRangeException()
        {
        }

        protected FieldOutOfRangeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public FieldOutOfRangeException(string message)
            : base(message)
        {
        }

        public FieldOutOfRangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}