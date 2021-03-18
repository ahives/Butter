namespace Butter.Validation.Internal
{
    using System;
    using Specification;

    class ValidationContextImpl :
        ValidationContext
    {
        public ValidationContextImpl(PrimitiveField specification, ValidationResult validationResult)
        {
            Specification = specification;
            ValidationResult = validationResult;
            Timestamp = DateTimeOffset.UtcNow;
        }

        public PrimitiveField Specification { get; }
        public ValidationResult ValidationResult { get; }
        public DateTimeOffset Timestamp { get; }
    }
}