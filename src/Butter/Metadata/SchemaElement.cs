namespace Butter.Metadata
{
    public interface SchemaElement
    {
        DataType Type { get; }
        
        int TypeLength { get; }
        
        FieldRepetitionType RepetitionType { get; }
        
        string Name { get; }
        
        int TotalChildren { get; }
        
        ConvertedType ConvertedType { get; }
    }
}