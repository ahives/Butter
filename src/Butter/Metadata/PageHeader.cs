namespace Butter.Metadata
{
    public interface PageHeader
    {
        PageType Type { get; }
        
        int UncompressedPageSize { get; }
        
        int CompressedPageSize { get; }
        
        int CRC { get; }
        
        DataPageHeader DataPageHeader { get; }
        
        IndexPageHeader IndexPageHeader { get; }
        
        DictionaryPageHeader DictionaryPageHeader { get; }
    }
}