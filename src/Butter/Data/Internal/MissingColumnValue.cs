namespace Butter.Data.Internal
{
    using System;
    using Metadata;

    class MissingColumnValue :
        Value
    {
        public string Data { get; }
        public DataType DataType => DataType.NONE;
        public Type ClrType => typeof(byte[]);
    }
}