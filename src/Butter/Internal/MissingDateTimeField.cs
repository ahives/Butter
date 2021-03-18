namespace Butter.Internal
{
    using Specification;

    public class MissingDateTimeField :
        DateTimeField
    {
        public string Id => "[Butter].[missing_field]";
        public bool IsNullable => true;
        public SchemaDataType DataType => SchemaDataType.DateTimeOffset;
        public bool HasValue => false;
        public int Index => -1;
        public DateTimeEncoding Encoding => DateTimeEncoding.Default;
    }
}