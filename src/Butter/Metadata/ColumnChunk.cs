namespace Butter.Metadata
{
    public interface ColumnChunk
    {
        string FilePath { get; }
        
        long FileOffset { get; }
        
        ColumnMetadata Metadata { get; }
    }
}