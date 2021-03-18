namespace Butter.Internal
{
    using Specification;

    class StructFieldImpl :
        StructField
    {
        public StructFieldImpl(string id, int index, IReadOnlyFieldList fields, bool isNullable = false)
        {
            Id = id;
            Index = index;
            IsNullable = isNullable;
            DataType = SchemaDataType.Struct;
            Fields = fields;
            HasValue = !string.IsNullOrWhiteSpace(id);
        }

        public StructFieldImpl(string id, int index, bool isNullable)
        {
            Id = id;
            Index = index;
            IsNullable = isNullable;
            DataType = SchemaDataType.Struct;
            Fields = SchemaCache.EmptyFieldList;
            HasValue = !string.IsNullOrWhiteSpace(id);
        }

        public string Id { get; }
        public bool IsNullable { get; }
        public SchemaDataType DataType { get; }
        public bool HasValue { get; }
        public int Index { get; }
        public IReadOnlyFieldList Fields { get; }

        public override string ToString() => $"FIELD [ID = '{Id}', Data Type = {DataType.ToString()}, Nullable = {(IsNullable ? bool.TrueString : bool.FalseString)}]";
    }
}