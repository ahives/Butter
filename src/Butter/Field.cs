namespace Butter
{
    public interface Field<out TValue> :
        IField
    {
        TValue Value { get; }
    }
}