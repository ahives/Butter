namespace Butter.Validation.Internal
{
    using System;
    using Validation;

    class MissingValidationResultImpl :
        ValidationResult
    {
        public MissingValidationResultImpl()
        {
            DateTimestamp = DateTimeOffset.UtcNow;
        }

        public string Reason => "Missing validation";
        public DateTimeOffset DateTimestamp { get; }
        public ValidationType Type => ValidationType.Error;
    }
}