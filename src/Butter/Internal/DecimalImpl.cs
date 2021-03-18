namespace Butter.Internal
{
    using Builders;
    using Specification;

    class DecimalImpl :
        Decimal
    {
        string _id;
        bool _nullable;
        int _scale;
        int _precision;
        int _index;

        public DecimalImpl()
        {
            _nullable = false;
            _scale = 2;
            _precision = 3;
        }

        public Decimal Id(string id)
        {
            _id = id;
            
            return this;
        }

        public Decimal Index(int index)
        {
            _index = index;
            
            return this;
        }

        public Decimal IsNullable()
        {
            _nullable = true;
            
            return this;
        }

        public Decimal Scale(int scale)
        {
            _scale = scale;

            return this;
        }

        public Decimal Precision(int precision)
        {
            _precision = precision;

            return this;
        }

        public DecimalField Build() => new DecimalFieldImpl(_id, _index, _scale, _precision, _nullable);
    }
}