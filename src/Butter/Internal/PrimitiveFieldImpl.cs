namespace Butter.Internal
{
    using Specification;

    class PrimitiveFieldImpl :
        PrimitiveField
    {
        public PrimitiveFieldImpl(string id, int index, SchemaDataType dataType = SchemaDataType.Primitive,
            bool isNullable = false)
        {
            Id = id;
            Index = index;
            IsNullable = isNullable;
            DataType = dataType;
            HasValue = !string.IsNullOrWhiteSpace(id);
        }

        public string Id { get; }
        public bool IsNullable { get; }
        public SchemaDataType DataType { get; }
        public bool HasValue { get; }
        public int Index { get; }

        public override string ToString() => $"FIELD [ID = '{Id}', Data Type = {DataType.ToString()}, Nullable = {(IsNullable ? bool.TrueString : bool.FalseString)}]";
    }
}