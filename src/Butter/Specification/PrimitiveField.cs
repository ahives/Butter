namespace Butter.Specification
{
    public interface PrimitiveField
    {
        string Id { get; }
        
        bool IsNullable { get; }
        
        SchemaDataType DataType { get; }
        
        bool HasValue { get; }
        
        int Index { get; }
    }
}