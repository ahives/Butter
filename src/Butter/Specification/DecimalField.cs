namespace Butter.Specification
{
    public interface DecimalField :
        PrimitiveField
    {
        int Scale { get; }
        
        int Precision { get; }
    }
}