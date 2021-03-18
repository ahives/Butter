namespace Butter.Data
{
    using Internal;

    public class DataCache
    {
        public static readonly Value MissingValue = new MissingColumnValue();
        public static readonly Column Empty = new EmptyColumn();
        public static readonly IValueList MissingValueList = new MissingColumnValueList();
    }
}