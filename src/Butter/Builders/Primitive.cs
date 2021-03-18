namespace Butter.Builders
{
    using Specification;

    public interface Primitive :
        IFieldBuilder
    {
        Primitive Id(string id);

        Primitive Index(int index);

        Primitive DataType(SchemaDataType dataType);

        Primitive IsNullable();

        PrimitiveField Build();
    }
}