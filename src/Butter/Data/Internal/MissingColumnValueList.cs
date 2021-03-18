namespace Butter.Data.Internal
{
    class MissingColumnValueList :
        IValueList
    {
        public bool HasValues => false;
        public int Count => 0;

        public Value this[int index] => DataCache.MissingValue;

        public bool TryGetValue(int index, out Value value)
        {
            value = DataCache.MissingValue;
            return false;
        }
        
        public void Add(Value field)
        {
        }
    }
}