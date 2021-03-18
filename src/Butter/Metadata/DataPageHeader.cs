namespace Butter.Metadata
{
    public interface DataPageHeader
    {
        int TotalValues { get; }
        
        DataEncoding Encoding { get; }
        
        DataEncoding DefinitionLevelEncoding { get; }
        
        DataEncoding RepetitionLevelEncoding { get; }
    }
}