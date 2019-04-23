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
    using System.Collections.Generic;

    public interface FieldList<T>
    {
        Field<T> this[int index] { get; }

        bool TryGetValue(int index, out Field<T> field);
    }

    public static class FieldList
    {
        public static FieldList<T> Create<T>(params Field<T>[] fields)
        {
            if (fields.Length <= 0)
                return Empty<T>();
            
            return new FieldListImpl<T>(fields);
        }

        public static FieldList<T> Empty<T>() => FieldListCache<T>.EmptyFieldList;


        class FieldListImpl<TValue> :
            FieldList<TValue>
        {
            readonly IReadOnlyList<Field<TValue>> _values;

            public FieldListImpl(IReadOnlyList<Field<TValue>> fields)
            {
                _values = fields;
            }

            public Field<TValue> this[int index]
            {
                get
                {
                    TryGetValue(index, out var field);

                    return field;
                }
            }

            public bool TryGetValue(int index, out Field<TValue> field)
            {
                if (index < 0)
                {
                    field = Field.OutOfRange<TValue>(index, _values.Count);
                    return false;
                }

                if (index < _values.Count)
                {
                    field = _values[index];
                    return true;
                }

                field = Field.OutOfRange<TValue>(index, _values.Count);
                return false;
            }
        }

        
        static class FieldListCache<T>
        {
            public static readonly FieldList<T> EmptyFieldList = new EmptyFieldList<T>();
        }
    }
}