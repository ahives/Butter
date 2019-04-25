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
namespace Butter.Model
{
    using System;
    using Metadata;

    public class OutOfRangeField :
        Field
    {
        public OutOfRangeField(int index, int count)
        {
            Value = new ValueImpl(index, count);
        }

        class ValueImpl : Value
        {
            readonly int _index;
            readonly int _count;

            public ValueImpl(int index, int count)
            {
                _index = index;
                _count = count;
            }

            public string Data => throw new FieldOutOfRangeException($"The index is out of range (index: {_index}, count: {_count})");
            public DataType DataType => DataType.None;
            public Type ClrType => DataType.None.Convert();
        }

        public string Name { get; }
        public Value Value { get; }
    }
}