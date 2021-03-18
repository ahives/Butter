namespace Butter
{
    public interface IFieldMap<out TKey, out TValue>
    {
        TKey Key { get; }
        
        TValue Value { get; }
    }
}