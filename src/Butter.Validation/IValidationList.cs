namespace Butter.Validation
{
    public interface IValidationList
    {
        void Add(ValidationResult validation);
        
        int Count { get; }
        
        ValidationResult this[int index] { get; }

        bool TryGetValue(int index, out ValidationResult validation);

        bool Contains(ValidationResult validation);

        void Clear();
    }
}