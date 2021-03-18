namespace Butter.Specification
{
    public interface DateTimeField :
        PrimitiveField
    {
        DateTimeEncoding Encoding { get; }
    }
}