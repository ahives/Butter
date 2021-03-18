namespace Butter.Internal
{
    using Specification;

    class ListFieldImpl :
        ListField
    {
        public ListFieldImpl(string id, int index)
        {
            Id = id;
            Index = index;
            DataType = SchemaDataType.List;
            HasValue = !string.IsNullOrWhiteSpace(id);
        }

        public string Id { get; }
        public int Index { get; }
        public bool IsNullable { get; }
        public SchemaDataType DataType { get; }
        public bool HasValue { get; }
    }
}