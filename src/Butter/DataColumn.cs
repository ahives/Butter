namespace Butter
{
    using Entities;
    using Entities.Model;
    using Schema;

    public class DataColumn
    {
        public static Column Create(Field field, ValueList values)
        {
            if (field == null || values == null)
                return SchemaCache.Empty;
            
            return new ColumnImpl(field, values);
        }

        public class ColumnImpl :
            Column
        {
            public ColumnImpl(Field field, ValueList values)
            {
                Field = field;
                Values = values;
                HasValues = values != null && values.HasValues;
            }

            public Field Field { get; }
            public ValueList Values { get; }
            public bool HasValues { get; }
        }
    }
}