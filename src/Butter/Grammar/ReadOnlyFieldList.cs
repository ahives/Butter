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
namespace Butter.Grammar
{
    using System.Linq;

    public class ReadOnlyFieldList :
        BaseFieldList, IReadOnlyFieldList
    {
        public bool HasValues => _fields != null && _fields.Any();
        public int Count => _count;

        public Field this[int index]
        {
            get
            {
                TryGetValue(index, out Field field);

                return field;
            }
        }

        public Field this[string id]
        {
            get
            {
                TryGetValue(id, out Field field);

                return field;
            }
        }

        protected ReadOnlyFieldList(bool notifyObservers)
            : base(notifyObservers)
        {
        }

        public bool TryGetValue(int index, out Field specification)
        {
            if (index < 0 || _count <= 0)
            {
                specification = SchemaCache.OutOfRangeField;
                return false;
            }

            if (index < _count)
            {
                specification = _fields[index];
                return true;
            }

            specification = SchemaCache.OutOfRangeField;
            return false;
        }

        public bool TryGetValue(string id, out Field specification)
        {
            if (_count <= 0)
            {
                specification = SchemaCache.OutOfRangeField;
                return false;
            }

            for (int i = 0; i < _count; i++)
            {
                if (_fields[i].Id != id)
                    continue;
                
                specification = _fields[i];
                return true;
            }
            
            specification = SchemaCache.OutOfRangeField;
            return false;
        }

        public bool Contains(Field specification) => specification != null && _fields.Contains(specification, new FieldComparer());

        public bool Equals(IReadOnlyFieldList other)
        {
            if (ReferenceEquals(null, other))
                return false;
            
            if (ReferenceEquals(this, other))
                return true;

            if (_count != other.Count)
                return false;

            for (int i = 0; i < other.Count; i++)
            {
                if (!_fields.Contains(other[i]))
                    return false;
            }

            return true;
        }
    }
}