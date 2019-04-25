namespace Butter
{
    using System;
    using Metadata;

    public static class ClrTypeExtensions
    {
        public static Type Convert(this DataType dataType)
        {
            switch (dataType)
            {
                case DataType.BOOLEAN:
                    return typeof(bool);
                
                case DataType.INT32:
                    return typeof(int);
                
                case DataType.INT64:
                    return typeof(long);
                
                case DataType.FLOAT:
                    return typeof(float);
                
                case DataType.DOUBLE:
                    return typeof(double);
                
                case DataType.BYTE_ARRAY:
                    return typeof(byte[]);
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
            }
        }
    }
}