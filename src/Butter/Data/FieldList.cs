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
namespace Butter.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class FieldList :
        IFieldList
    {
        readonly List<Field> _fields;
        int _count;

        public bool HasValues => _fields != null && _fields.Any();
        public int Count => _count;

        public FieldList()
        {
            _fields = new List<Field>();
            _count = 0;
        }

        public FieldList(List<Field> fields)
        {
            _fields = fields;
            _count = fields.Count;
        }

        public void Add(Field field)
        {
            if (field == null || _fields.Contains(field, new FieldComparer()))
                return;
            
            _fields.Add(field);
            _count++;
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
                field = SchemaCache.OutOfRangeField;
                return false;
            }

            if (index < _fields.Count)
            {
                field = _fields[index];
                return true;
            }

            field = SchemaCache.OutOfRangeField;
            return false;
        }

        
        class FieldComparer :
            IEqualityComparer<Field>
        {
            public bool Equals(Field x, Field y)
            {
                if (x == null || y == null)
                    return false;

                return x.EqualTo(y);
            }

            public int GetHashCode(Field obj) => obj.Id.GetHashCode();
        }
    }
}