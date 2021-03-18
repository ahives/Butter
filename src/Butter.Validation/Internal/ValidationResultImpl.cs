namespace Butter.Validation.Internal
{
    using System;
    using Validation;

    class ValidationResultImpl :
        ValidationResult
    {
        public ValidationResultImpl(string reason, ValidationType type)
        {
            Reason = reason;
            Type = type;
            DateTimestamp = DateTimeOffset.UtcNow;
        }

        public string Reason { get; }
        public DateTimeOffset DateTimestamp { get; }
        public ValidationType Type { get; }
    }
}