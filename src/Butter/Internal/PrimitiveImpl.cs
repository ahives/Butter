namespace Butter.Internal
{
    using Builders;
    using Specification;

    class PrimitiveImpl :
        Primitive
    {
        string _id;
        SchemaDataType _dataType;
        bool _nullable;
        int _index;

        public Primitive Id(string id)
        {
            _id = id;
            
            return this;
        }

        public Primitive Index(int index)
        {
            _index = index;
            
            return this;
        }

        public Primitive DataType(SchemaDataType dataType)
        {
            _dataType = dataType;
            
            return this;
        }

        public Primitive IsNullable()
        {
            _nullable = true;
            
            return this;
        }

        public PrimitiveField Build() => new PrimitiveFieldImpl(_id, _index, _dataType, _nullable);
    }
}