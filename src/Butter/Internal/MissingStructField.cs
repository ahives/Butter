namespace Butter.Internal
{
    using Specification;

    class MissingStructField :
        StructField
    {
        public MissingStructField()
        {
            Fields = new EmptyFieldList();
        }

        public string Id => "[Butter].[missing_field]";
        public bool IsNullable => true;
        public SchemaDataType DataType => SchemaDataType.Struct;
        public bool HasValue => false;
        public IReadOnlyFieldList Fields { get; }
        public int Index => -1;
    }
}