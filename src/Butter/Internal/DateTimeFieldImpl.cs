namespace Butter.Internal
{
    using Specification;

    class DateTimeFieldImpl :
        DateTimeField
    {
        public DateTimeFieldImpl(string id, int index, DateTimeEncoding encoding = DateTimeEncoding.Default, bool isNullable = false)
        {
            Id = id;
            Index = index;
            IsNullable = isNullable;
            Encoding = encoding;
            DataType = SchemaDataType.DateTimeOffset;
            HasValue = !string.IsNullOrWhiteSpace(id);
        }

        public string Id { get; }
        public bool IsNullable { get; }
        public SchemaDataType DataType { get; }
        public bool HasValue { get; }
        public DateTimeEncoding Encoding { get; }
        public int Index { get; }

        public override string ToString() => $"FIELD [ID = '{Id}', Data Type = {DataType.ToString()}, Nullable = {(IsNullable ? bool.TrueString : bool.FalseString)}, Encoding = {Encoding}]";
    }
}