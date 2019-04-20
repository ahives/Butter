namespace Butter
{
    public interface FieldList<TValue> :
        IField
    {
        Field<TValue> this[int index] { get; }

        bool TryGetValue(int index, out Field<TValue> field);
    }
}