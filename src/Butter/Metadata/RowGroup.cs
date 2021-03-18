namespace Butter.Metadata
{
    using System.Collections.Generic;

    public interface RowGroup
    {
        List<ColumnChunk> Columns { get; }
        
        long TotalByteSize { get; }
        
        long TotalRows { get; }
    }
}