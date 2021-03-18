namespace Butter.Internal
{
    using Builders;
    using Specification;

    class MapImpl :
        Map
    {
        string _id;
        bool _nullable;
        PrimitiveField _key;
        PrimitiveField _value;
        int _index;

        public Map Id(string id)
        {
            _id = id;
            
            return this;
        }

        public Map Index(int index)
        {
            _index = index;

            return this;
        }

        public Map Map(PrimitiveField key, PrimitiveField value)
        {
            _key = key;
            _value = value;

            return this;
        }

        public Map Key(PrimitiveField key)
        {
            _key = key;
            
            return this;
        }

        public Map Value(PrimitiveField value)
        {
            _value = value;

            return this;
        }

        public Map IsNullable()
        {
            _nullable = true;
            
            return this;
        }

        public MapField Build() => new MapFieldImpl(_id, _index, new FieldMapImpl(_key, _value), _nullable);
    }
}