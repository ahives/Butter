namespace Butter.Validation.Internal
{
    using System;
    using Validation;

    class MissingValidationListImpl :
        IValidationList
    {
        public void Add(ValidationResult validation)
        {
            throw new NotImplementedException();
        }

        public bool HasErrors => false;
        public int Count => 0;

        public ValidationResult this[int index] => ValidationCache.MissingValidationResult;

        public bool TryGetValue(int index, out ValidationResult validation)
        {
            validation = ValidationCache.MissingValidationResult;
            return false;
        }

        public bool Contains(ValidationResult validation) => false;
        
        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}