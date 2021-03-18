namespace Butter.Internal
{
    using Specification;

    class EmptyFieldList :
        IReadOnlyFieldList
    {
        public bool HasValues => false;
        public int Count => 0;
        public PrimitiveField this[int index] => SchemaCache.MissingField;

        public PrimitiveField this[string id] => SchemaCache.MissingField;

        public bool TryGetValue(int index, out PrimitiveField field)
        {
            field = SchemaCache.MissingField;
            return false;
        }

        public bool TryGetValue(string id, out PrimitiveField field)
        {
            field = SchemaCache.MissingField;
            return false;
        }

        public bool Contains(PrimitiveField field) => false;
        public bool Contains(string id) => false;

        public void Sort()
        {
        }

        public bool Equals(IReadOnlyFieldList other) => false;
    }
}