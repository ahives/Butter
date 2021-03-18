namespace Butter.Validation
{
    using System;

    public interface ValidationResult
    {
        string Reason { get; }
        
        DateTimeOffset DateTimestamp { get; }
        
        ValidationType Type { get; }
    }
}