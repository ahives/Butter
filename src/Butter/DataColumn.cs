namespace Butter
{
    using Data;
    using Data.Model;

    public class DataColumn
    {
        public static Column Create(Field field, IValueList values)
        {
            if (field == null || values == null)
                return SchemaCache.Empty;
            
            return new ColumnImpl(field, values);
        }

        class ColumnImpl :
            Column
        {
            public ColumnImpl(Field field, IValueList values)
            {
                Field = field;
                Values = values;
                HasValues = values != null && values.HasValues;
            }

            public Field Field { get; }
            public IValueList Values { get; }
            public bool HasValues { get; }
        }
    }
}