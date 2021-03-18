namespace Butter.Validation.Internal
{
    using System.Collections.Generic;
    using System.Linq;
    using Validation;

    public class ValidationList :
        IValidationList
    {
        readonly List<ValidationResult> _validations;
        int _count;

        public ValidationList()
        {
            _validations = new List<ValidationResult>();
            _count = 0;
        }

        public void Add(ValidationResult validation)
        {
            if (validation == null)
                return;

            if (validation.Type == ValidationType.Error)
                HasErrors = true;
            
            _validations.Add(validation);
            _count = _validations.Count;
        }

        public bool HasErrors { get; private set; }
        public int Count => _count;

        public ValidationResult this[int index]
        {
            get
            {
                TryGetValue(index, out ValidationResult validation);

                return validation;
            }
        }

        public bool TryGetValue(int index, out ValidationResult validation)
        {
            if (index < 0 || _count <= 0)
            {
                validation = ValidationCache.MissingValidationResult;
                return false;
            }

            if (index < _count)
            {
                validation = _validations[index];
                return true;
            }
            
            validation = ValidationCache.MissingValidationResult;
            return false;
        }

        public bool Contains(ValidationResult validation) => validation != null && _validations.Contains(validation, new ValidationComparer());

        public void Clear()
        {
            _validations.Clear();
        }


        class ValidationComparer :
            IEqualityComparer<ValidationResult>
        {
            public bool Equals(ValidationResult x, ValidationResult y)
            {
                if (x == null || y == null)
                    return false;

                return x.Reason == y.Reason;
            }

            public int GetHashCode(ValidationResult obj) => obj.Reason.GetHashCode();
        }
    }
}