namespace Butter.Builders
{
    using Specification;

    public interface DateTime :
        IFieldBuilder
    {
        DateTime Id(string id);

        DateTime Index(int index);

        DateTime IsNullable();

        DateTime Encoding(DateTimeEncoding encoding);

        DateTimeField Build();
    }
}