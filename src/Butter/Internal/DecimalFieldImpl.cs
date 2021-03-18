namespace Butter.Internal
{
    using Specification;

    class DecimalFieldImpl :
        DecimalField
    {
        public DecimalFieldImpl(string id, int index, int scale, int precision, bool nullable = false)
        {
            Id = id;
            Index = index;
            IsNullable = nullable;
            DataType = SchemaDataType.Decimal;
            Scale = scale;
            Precision = precision;
            HasValue = !string.IsNullOrWhiteSpace(id);
        }

        public DecimalFieldImpl(string id, int index, bool nullable = false)
        {
            Id = id;
            Index = index;
            IsNullable = nullable;
            DataType = SchemaDataType.Decimal;
            HasValue = !string.IsNullOrWhiteSpace(id);
        }

        public string Id { get; }
        public bool IsNullable { get; }
        public SchemaDataType DataType { get; }
        public bool HasValue { get; }
        public int Index { get; }
        public int Scale { get; }
        public int Precision { get; }

        public override string ToString() => $"FIELD [ID = '{Id}', Data Type = {DataType.ToString()}, Nullable = {(IsNullable ? bool.TrueString : bool.FalseString)}]";
    }
}