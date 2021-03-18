namespace Butter.Internal
{
    using Specification;

    class MapFieldImpl :
        MapField
    {
        public MapFieldImpl(string id, int index, FieldMap<PrimitiveField, PrimitiveField> field, bool isNullable = false)
        {
            Id = id;
            Index = index;
            Key = field != null ? field.Key : SchemaCache.MissingField;
            Value = field != null ? field.Value : SchemaCache.MissingField;
            DataType = SchemaDataType.Map;
            IsNullable = isNullable;
            HasValue = !string.IsNullOrWhiteSpace(id);
        }

        public MapFieldImpl(string id, int index, bool isNullable)
        {
            Id = id;
            Index = index;
            Key = SchemaCache.MissingField;
            Value = SchemaCache.MissingField;
            DataType = SchemaDataType.Map;
            IsNullable = isNullable;
            HasValue = !string.IsNullOrWhiteSpace(id);
        }

        public string Id { get; }
        public int Index { get; }
        public bool IsNullable { get; }
        public SchemaDataType DataType { get; }
        public bool HasValue { get; }
        public PrimitiveField Key { get; }
        public PrimitiveField Value { get; }

        public override string ToString() => $"FIELD [ID = '{Id}', Data Type = {DataType.ToString()}, Nullable = {(IsNullable ? bool.TrueString : bool.FalseString)}]";
    }
}