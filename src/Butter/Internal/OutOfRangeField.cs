namespace Butter.Internal
{
    using Specification;

    class OutOfRangeField :
        PrimitiveField
    {
        public string Id => "[Butter].[missing_field_spec]";
        public bool IsNullable => true;
        public SchemaDataType DataType => SchemaDataType.None;
        public bool HasValue => false;
        public int Index => -1;
    }
}