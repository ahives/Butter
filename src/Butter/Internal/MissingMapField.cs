namespace Butter.Internal
{
    using Specification;

    class MissingMapField :
        MapField
    {
        public string Id => "[Butter].[missing_field]";
        public bool IsNullable => true;
        public SchemaDataType DataType => SchemaDataType.Map;
        public bool HasValue => false;
        public PrimitiveField Key => SchemaCache.MissingField;
        public PrimitiveField Value => SchemaCache.MissingField;
        public int Index => -1;
    }
}