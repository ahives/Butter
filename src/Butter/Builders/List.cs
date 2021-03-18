namespace Butter.Builders
{
    using Specification;

    public interface List
    {
        List Id(string id);

        List Index(int index);

        List IsNullable();

        ListField Build();
    }
}