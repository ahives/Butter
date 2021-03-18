namespace Butter.Builders
{
    using System;
    using Specification;

    public interface Struct :
        IFieldBuilder
    {
        Struct Id(string id);

        Struct Index(int index);

        Struct Field<T>(T field)
            where T : PrimitiveField;

        Struct Field<T>(Func<T, PrimitiveField> builder)
            where T : IFieldBuilder;

        Struct Fields(IReadOnlyFieldList fields);

        Struct IsNullable();

        StructField Build();
    }
}