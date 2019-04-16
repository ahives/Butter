namespace Butter.Metadata
{
    using System.Collections.Generic;

    public interface ColumnMetadata
    {
        DataType Type { get; }
        
        List<DataEncoding> Encodings { get; }
        
        List<string> PathInSchema { get; }
        
        CompressionCodec Codec { get; }
        
        long TotalValues { get; }
        
        long TotalUncompressedSize { get; }
        
        long TotalCompressedSize { get; }
        
        List<KeyValue> KeyValueMetadata { get; }
        
        long DataPageOffset { get; }
        
        long IndexPageOffset { get; }
        
        long DictionaryPageOffset { get; }
    }
}