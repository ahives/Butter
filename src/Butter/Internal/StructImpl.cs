namespace Butter.Internal
{
    using System;
    using Builders;
    using Specification;

    class StructImpl :
        Struct
    {
        string _id;
        bool _nullable;
        readonly IFieldList _fields;
        int _index;

        public StructImpl()
        {
            _fields = new FieldList(false);
        }

        public Struct Id(string id)
        {
            _id = id;

            return this;
        }

        public Struct Index(int index)
        {
            _index = index;
            
            return this;
        }

        public Struct Field<T>(T field)
            where T : PrimitiveField
        {
            _fields.Add(field);

            return this;
        }

        public Struct Field<T>(Func<T, PrimitiveField> builder)
            where T : IFieldBuilder
        {
            T specBuilder = Butter.Field.Builder<T>();

            var specification = builder(specBuilder);

            _fields.Add(specification);

            return this;
        }

        public Struct Fields(IReadOnlyFieldList fields)
        {
            _fields.AddRange(fields.ToList());

            return this;
        }

        public Struct IsNullable()
        {
            _nullable = true;

            return this;
        }

        public StructField Build() => new StructFieldImpl(_id, _index, _fields, isNullable:_nullable);
    }
}