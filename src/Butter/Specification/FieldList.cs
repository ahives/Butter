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
namespace Butter.Specification
{
    using System.Collections.Generic;
    using Notification;

    public class FieldList :
        ReadOnlyFieldList, IFieldList
    {
        public FieldList(bool notifyObservers = false)
            : base(notifyObservers)
        {
        }

        public Field Remove(int index)
        {
            if (index > _count || index < 0)
                return SchemaCache.MissingField;

            if (!TryGetValue(index, out Field field))
                return SchemaCache.MissingField;
                
            NotifyObservers(field, SchemaActionType.Delete);
                
            _fields.RemoveAt(index);
            _count = _fields.Count;

            return field;
        }

        public Field Remove(string id)
        {
            for (int i = 0; i < _fields.Count; i++)
            {
                if (_fields[i].Id != id)
                    continue;

                Field specification = _fields[i];
                
                _fields.RemoveAt(i);
                _count = _fields.Count;
                
                NotifyObservers(specification, SchemaActionType.Delete);
                
                return specification;
            }

            return SchemaCache.MissingField;
        }

        public bool TryRemove(int index, out Field field)
        {
            if (index > _count || index < 0)
            {
                field = SchemaCache.MissingField;

                return false;
            }

            if (!TryGetValue(index, out Field spec))
            {
                field = SchemaCache.MissingField;

                return false;
            }
            
            field = spec;
            
            _fields.RemoveAt(index);
            _count = _fields.Count;
            
            NotifyObservers(spec, SchemaActionType.Delete);

            return true;
        }

        public bool TryRemove(string id, out Field field)
        {
            for (int i = 0; i < _fields.Count; i++)
            {
                if (_fields[i].Id != id)
                    continue;
                
                field = _fields[i];

                _fields.RemoveAt(i);
                _count = _fields.Count;
                
                NotifyObservers(field, SchemaActionType.Delete);
            
                return true;
            }
            
            field = SchemaCache.MissingField;

            return false;
        }

        public void Add(Field field)
        {
            if (field == null)
            {
                NotifyObservers(field, SchemaActionType.None);
                return;
            }
            
            _fields.Add(field);
            _count = _fields.Count;
            
            NotifyObservers(field, SchemaActionType.Add);
        }

        public void AddRange(IList<Field> field)
        {
            if (field == null)
                return;
            
            for (int i = 0; i < field.Count; i++)
            {
                if (field[i] == null)
                {
                    NotifyObservers(field[i], SchemaActionType.None);
                    continue;
                }
                
                _fields.Add(field[i]);
                _count++;
                
                NotifyObservers(field[i], SchemaActionType.Add);
            }
        }

        public void AddRange(params Field[] fields)
        {
            if (fields == null)
                return;
            
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == null)
                {
                    NotifyObservers(fields[i], SchemaActionType.None);
                    continue;
                }
                
                _fields.Add(fields[i]);
                _count++;
                
                NotifyObservers(fields[i], SchemaActionType.Add);
            }
        }

        public bool Equals(IFieldList other)
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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            
            if (ReferenceEquals(this, obj))
                return true;
            
            if (obj.GetType() != this.GetType())
                return false;
            
            return Equals((FieldList) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_fields != null ? _fields.GetHashCode() : 0) * 397) ^ _count;
            }
        }
    }
}