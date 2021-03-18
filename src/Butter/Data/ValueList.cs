namespace Butter.Data
{
    public interface ValueList
    {
        bool HasValues { get; }
        
        Value this[int index] { get; }

        bool TryGetValue(int index, out Value value);
    }
}