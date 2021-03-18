namespace Butter.Specification
{
    public interface FieldMap<out TKey, out TValue>
    {
        TKey Key { get; }
        
        TValue Value { get; }
    }
}