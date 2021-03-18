namespace Butter
{
    using System;
    using Metadata;
    using Specification;

    public static class DataTypeExtensions
    {
        public static DataType Convert(this Type type)
        {
            if (type == typeof(int))
                return DataType.INT32;
            
            if (type == typeof(long))
                return DataType.INT64;
            
            if (type == typeof(bool))
                return DataType.BOOLEAN;
            
            if (type == typeof(float))
                return DataType.FLOAT;
            
            if (type == typeof(double))
                return DataType.DOUBLE;
            
            if (type == typeof(byte[]))
                return DataType.BYTE_ARRAY;
            
            throw new System.NotSupportedException();
        }
    }
}