namespace Butter.Data
{
    public interface IValueList
    {
        void Add(Value value);

        bool HasValues { get; }

        int Count { get; }

        Value this[int index] { get; }

        bool TryGetValue(int index, out Value value);
    }
}