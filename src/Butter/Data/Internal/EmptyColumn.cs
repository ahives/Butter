namespace Butter.Data.Internal
{
    using Specification;

    class EmptyColumn :
        Column
    {
        public PrimitiveField Specification => SchemaCache.MissingField;
        public IValueList Values => DataCache.MissingValueList;
        public bool HasValues => false;
    }
}