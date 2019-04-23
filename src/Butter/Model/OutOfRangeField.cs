namespace Butter.Model
{
    using System;
    using Metadata;

    public class OutOfRangeField<T> :
        Field<T>
    {
        readonly int _index;
        readonly int _count;

        public OutOfRangeField(int index, int count)
        {
            _index = index;
            _count = count;
        }

        public T Value =>
            throw new FieldOutOfRangeException($"The index is out of range (index: {_index}, count: {_count})");
        public string Name { get; }
        public DataType DataType => DataTypes.Convert<T>();
        public Type Type => typeof(T);
    }
}