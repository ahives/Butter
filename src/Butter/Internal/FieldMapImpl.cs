namespace Butter.Internal
{
    using Specification;

    class FieldMapImpl :
        FieldMap<PrimitiveField, PrimitiveField>
    {
        public FieldMapImpl(PrimitiveField key, PrimitiveField value)
        {
            Key = key;
            Value = value;
        }

        public PrimitiveField Key { get; }
        public PrimitiveField Value { get; }
    }
}