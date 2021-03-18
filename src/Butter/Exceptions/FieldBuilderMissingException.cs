namespace Butter
{
    using System;
    using System.Runtime.Serialization;

    public class FieldBuilderMissingException :
        Exception
    {
        public FieldBuilderMissingException()
        {
        }

        protected FieldBuilderMissingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public FieldBuilderMissingException(string message)
            : base(message)
        {
        }

        public FieldBuilderMissingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}