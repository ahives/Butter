namespace Butter.Data
{
    using Specification;

    public interface Column
    {
        PrimitiveField Specification { get; }
        
        IValueList Values { get; }
        
        bool HasValues { get; }
    }
}