namespace Butter
{
    using System;
    using Internal;
    using Specification;

    public static class SchemaCache
    {
        public static readonly PrimitiveField MissingField = new MissingField();
        public static readonly DecimalField MissingDecimalField = new MissingDecimalField();
        public static readonly MapField MissingMapField = new MissingMapField();
        public static readonly ListField MissingListField = new MissingListField();
        public static readonly StructField MissingStructField = new MissingStructField();
        public static readonly DateTimeField MissingDateTimeField = new MissingDateTimeField();
        public static readonly IReadOnlyFieldList EmptyFieldList = new EmptyFieldList();
        public static readonly PrimitiveField OutOfRangeField = new OutOfRangeField();

        public static T GetMissingField<T>(this Type type)
        {
            switch (type)
            {
                case MapField _:
                    return (T) MissingMapField;

                case ListField _:
                    return (T) MissingListField;

                case StructField _:
                    return (T) MissingStructField;

                case DecimalField _:
                    return (T) MissingDecimalField;

                case DateTimeField _:
                    return (T) MissingDateTimeField;
                
                case PrimitiveField _:
                    return (T) MissingField;

                default:
                    throw new Exception();
            }
        }
    }
}