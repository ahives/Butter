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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Internal;

    public class FieldList :
        IFieldList, IEquatable<FieldList>
    {
        readonly List<Field> _fields;
        int _count;

        readonly List<IObserver<ValidationContext>> _observers;

        public bool HasValues => _fields != null && _fields.Any();
        public int Count => _count;

        public Field this[int index]
        {
            get
            {
                TryGetValue(index, out var field);

                return field;
            }
        }

        public FieldList()
        {
            _fields = new List<Field>();
            _observers = new List<IObserver<ValidationContext>>();
            _count = 0;
        }

        public void Add(Field field)
        {
            if (field == null)
            {
                NotifyObservers(new ValidationResultImpl("FIELD == NULL.", ValidationType.Error), true);
                return;
            }
            
            if (Contains(field))
                NotifyObservers(field, new ValidationResultImpl("FIELD ALREADY EXISTS.", ValidationType.Error), true);
            
            _fields.Add(field);
            _count = _fields.Count;
        }

        public void AddRange(IList<Field> fields)
        {
            if (fields == null)
            {
                NotifyObservers(new ValidationResultImpl("FIELD == NULL.", ValidationType.Error), true);
                return;
            }
            
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i] == null)
                {
                    NotifyObservers(null, new ValidationResultImpl("FIELD == NULL.", ValidationType.Error), true);
                    continue;
                }
                
                if (Contains(fields[i]))
                    NotifyObservers(fields[i], new ValidationResultImpl("FIELD ALREADY EXISTS.", ValidationType.Error), true);
                
                _fields.Add(fields[i]);
                _count++;
            }
        }

        public void AddRange(params Field[] fields)
        {
            if (fields == null)
            {
                NotifyObservers(new ValidationResultImpl("FIELD == NULL.", ValidationType.Error), true);
                return;
            }
            
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == null)
                {
                    NotifyObservers(null, new ValidationResultImpl("FIELD == NULL.", ValidationType.Error), true);
                    continue;
                }
                
                if (Contains(fields[i]))
                    NotifyObservers(fields[i], new ValidationResultImpl("FIELD ALREADY EXISTS.", ValidationType.Error), true);
                
                _fields.Add(fields[i]);
                _count++;
            }
        }

        public bool TryGetValue(int index, out Field field)
        {
            if (index < 0 || _count <= 0)
            {
                field = SchemaCache.OutOfRangeField;
                return false;
            }

            if (index < _count)
            {
                field = _fields[index];
                return true;
            }

            field = SchemaCache.OutOfRangeField;
            return false;
        }

        public bool TryGetValue(string id, out Field field)
        {
            if (_count <= 0)
            {
                field = SchemaCache.OutOfRangeField;
                return false;
            }

            for (int i = 0; i < _count; i++)
            {
                if (_fields[i].Id != id)
                    continue;
                
                field = _fields[i];
                return true;
            }
            
            field = SchemaCache.OutOfRangeField;
            return false;
        }

        public bool Contains(Field field) => field != null && _fields.Contains(field, new FieldComparer());

        public bool Equals(FieldList other)
        {
            if (ReferenceEquals(null, other))
                return false;
            
            if (ReferenceEquals(this, other))
                return true;

            if (_count != other._count)
                return false;

            for (int i = 0; i < other.Count; i++)
            {
                if (!_fields.Contains(other[i]))
                    return false;
            }

            return true;
        }

        public IDisposable Subscribe(IObserver<ValidationContext> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new Unsubscriber(_observers, observer);
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

        void NotifyObservers(Field field, ValidationResultImpl validationResult, bool hasErrors)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(new ValidationContextImpl(field, validationResult, hasErrors));
            }
        }

        void NotifyObservers(ValidationResult validationResult, bool hasErrors)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(new ValidationContextImpl(null, validationResult, hasErrors));
            }
        }

        
        class Unsubscriber :
            IDisposable
        {
            readonly List<IObserver<ValidationContext>> _observers;
            readonly IObserver<ValidationContext> _observer;

            public Unsubscriber(List<IObserver<ValidationContext>> observers, IObserver<ValidationContext> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }


        class FieldComparer :
            IEqualityComparer<Field>
        {
            public bool Equals(Field x, Field y)
            {
                if (x == null || y == null)
                    return false;

                return x.Id == y.Id;
            }

            public int GetHashCode(Field obj) => obj.Id.GetHashCode();
        }
    }
}