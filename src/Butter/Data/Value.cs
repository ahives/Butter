namespace Butter.Data
{
    using System;
    using Metadata;

    public interface Value
    {
        string Data { get; }
        
        DataType DataType { get; }
        
        Type ClrType { get; }
    }
}