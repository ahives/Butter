namespace Butter.Builders
{
    using Specification;

    public interface Map :
        IFieldBuilder
    {
        Map Id(string id);

        Map Index(int index);

        Map Map(PrimitiveField key, PrimitiveField value);

        Map Key(PrimitiveField key);

        Map Value(PrimitiveField value);

        Map IsNullable();

        MapField Build();
    }
}