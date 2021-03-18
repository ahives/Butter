namespace Butter.Specification
{
    public interface MapField :
        PrimitiveField
    {
        PrimitiveField Key { get; }
        
        PrimitiveField Value { get; }
    }
}