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