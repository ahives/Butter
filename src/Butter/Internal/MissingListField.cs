namespace Butter.Internal
{
    using Specification;

    class MissingListField :
        ListField
    {
        public string Id => "[Butter].[missing_field]";
        public bool IsNullable => true;
        public SchemaDataType DataType => SchemaDataType.List;
        public bool HasValue => false;
        public int Index => -1;
    }
}