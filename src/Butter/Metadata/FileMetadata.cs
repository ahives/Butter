namespace Butter.Metadata
{
    using System.Collections.Generic;

    public interface FileMetadata
    {
        int Version { get; }
        
        List<SchemaElement> Schema { get; }
        
        long TotalRows { get; }
        
        List<RowGroup> RowGroups { get; }
        
        List<KeyValue> KeyValueMetadata { get; }
    }
}