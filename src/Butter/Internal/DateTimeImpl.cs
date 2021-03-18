namespace Butter.Internal
{
    using Builders;
    using Specification;

    class DateTimeImpl :
        DateTime
    {
        string _id;
        bool _nullable;
        DateTimeEncoding _encoding;
        int _index;

        public DateTime Id(string id)
        {
            _id = id;
            
            return this;
        }

        public DateTime Index(int index)
        {
            _index = index;
            
            return this;
        }

        public DateTime IsNullable()
        {
            _nullable = true;
            
            return this;
        }

        public DateTime Encoding(DateTimeEncoding encoding)
        {
            _encoding = encoding;
            
            return this;
        }

        public DateTimeField Build() => new DateTimeFieldImpl(_id, _index, _encoding, _nullable);
    }
}