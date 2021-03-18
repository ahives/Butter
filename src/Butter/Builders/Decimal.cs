namespace Butter.Builders
{
    using Specification;

    public interface Decimal :
        IFieldBuilder
    {
        Decimal Id(string id);

        Decimal Index(int index);

        Decimal IsNullable();

        Decimal Scale(int scale);
        
        Decimal Precision(int precision);

        DecimalField Build();
    }
}