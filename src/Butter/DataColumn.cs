namespace Butter
{
    using Entities;
    using Entities.Model;
    using Schema;

    public class DataColumn
    {
        public static Column Create(Field field, IEntityList<Value> values)
        {
            if (field == null || values == null)
                return SchemaCache.Empty;
            
            return new ColumnImpl(field, values);
        }

        class ColumnImpl :
            Column
        {
            public ColumnImpl(Field field, IEntityList<Value> values)
            {
                Field = field;
                Values = values;
                HasValues = values != null && values.HasValues;
            }

            public Field Field { get; }
            public IEntityList<Value> Values { get; }
            public bool HasValues { get; }
        }
    }
}