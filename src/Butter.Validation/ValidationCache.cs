namespace Butter.Validation
{
    using Internal;

    static class ValidationCache
    {
        public static readonly ValidationResult MissingValidationResult = new MissingValidationResultImpl();
        public static readonly IValidationList MissingValidationList = new MissingValidationListImpl();
    }
}