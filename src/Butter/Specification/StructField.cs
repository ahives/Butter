namespace Butter.Specification
{
    public interface StructField :
        PrimitiveField
    {
        IReadOnlyFieldList Fields { get; }
    }
}