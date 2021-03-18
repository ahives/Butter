namespace Butter.Data
{
    using Specification;

    public class DataColumn
    {
        public static Column Create(PrimitiveField specification, IValueList values)
        {
            if (specification == null || values == null)
                return DataCache.Empty;
            
            return new ColumnImpl(specification, values);
        }

        class ColumnImpl :
            Column
        {
            public ColumnImpl(PrimitiveField specification, IValueList values)
            {
                Specification = specification;
                Values = values;
                HasValues = values != null && values.HasValues;
            }

            public PrimitiveField Specification { get; }
            public IValueList Values { get; }
            public bool HasValues { get; }
        }
    }
}