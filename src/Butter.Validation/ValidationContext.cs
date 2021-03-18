namespace Butter.Validation
{
    using System;
    using Specification;

    public interface ValidationContext
    {
        PrimitiveField Specification { get; }
        
        ValidationResult ValidationResult { get; }
        
        DateTimeOffset Timestamp { get; }
    }
}