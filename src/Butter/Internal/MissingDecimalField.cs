namespace Butter.Internal
{
    using Specification;

    class MissingDecimalField :
        DecimalField
    {
        public string Id => "[Butter].[missing_field]";
        public bool IsNullable => true;
        public SchemaDataType DataType => SchemaDataType.Decimal;
        public bool HasValue => false;
        public int Index => -1;
        public int Scale => 0;
        public int Precision => 0;
    }
}