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
    using System.Collections.Generic;
    using Model;

    public static class DataFieldList
    {
        public static FieldList Create(params Field[] fields)
        {
            if (fields.Length <= 0)
                return Empty();
            
            return new FieldListImpl(fields);
        }

        public static FieldList Create(IReadOnlyList<Field> fields)
        {
            if (fields == null || fields.Count == 0)
                return Empty();
            
            return new FieldListImpl(fields);
        }

        public static FieldList Empty() => FieldListCache.EmptyFieldList;


        class FieldListImpl :
            FieldList
        {
            readonly IReadOnlyList<Field> _values;

            public FieldListImpl(IReadOnlyList<Field> fields)
            {
                _values = fields;
            }

            public Field this[int index]
            {
                get
                {
                    TryGetValue(index, out var field);

                    return field;
                }
            }

            public bool TryGetValue(int index, out Field field)
            {
                if (index < 0)
                {
                    field = DataField.OutOfRange(index, _values.Count);
                    return false;
                }

                if (index < _values.Count)
                {
                    field = _values[index];
                    return true;
                }

                field = DataField.OutOfRange(index, _values.Count);
                return false;
            }
        }

        
        static class FieldListCache
        {
            public static readonly FieldList EmptyFieldList = new EmptyFieldList();
        }
    }
}