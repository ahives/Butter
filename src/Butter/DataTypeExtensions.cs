// ***********************************************************************************
// Copyright 2019 Albert L. Hives
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.
// ***********************************************************************************
namespace Butter
{
    using System;
    using Data.Metadata;

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