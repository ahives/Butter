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
    using System.Collections.Generic;
    using Notification;

    public class FieldList :
        ReadOnlyFieldList, IFieldList
    {
        public FieldList(bool notifyObservers = true)
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

                Field field = _fields[i];
                
                _fields.RemoveAt(i);
                _count = _fields.Count;
                
                NotifyObservers(field, SchemaActionType.Delete);
                
                return field;
            }

            return SchemaCache.MissingField;
        }

        public bool TryRemove(int index, out Field item)
        {
            if (index > _count || index < 0)
            {
                item = SchemaCache.MissingField;

                return false;
            }

            if (!TryGetValue(index, out Field field))
            {
                item = SchemaCache.MissingField;

                return false;
            }
            
            item = field;
            
            _fields.RemoveAt(index);
            _count = _fields.Count;
            
            NotifyObservers(field, SchemaActionType.Delete);

            return true;
        }

        public bool TryRemove(string id, out Field item)
        {
            for (int i = 0; i < _fields.Count; i++)
            {
                if (_fields[i].Id != id)
                    continue;
                
                item = _fields[i];

                _fields.RemoveAt(i);
                _count = _fields.Count;
                
                NotifyObservers(item, SchemaActionType.Delete);
            
                return true;
            }
            
            item = SchemaCache.MissingField;

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

        public void AddRange(IList<Field> fields)
        {
            if (fields == null)
                return;
            
            for (int i = 0; i < fields.Count; i++)
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