namespace Butter.Internal
{
    using Specification;

    class MissingField :
        PrimitiveField
    {
        public string Id => "[Butter].[missing_field]";
        public bool IsNullable => true;
        public SchemaDataType DataType => SchemaDataType.Primitive;
        public bool HasValue => false;
        public int Index => -1;
    }
}