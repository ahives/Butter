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
    using System.Collections.Generic;
    using Internal;
    using Notification;
    using Specification;

    public class Schema :
        ISchema, IEquatable<Schema>, IDisposable
    {
        readonly List<IDisposable> _observers;
        readonly FieldList _fields;

        public IReadOnlyFieldList Fields => _fields;

        internal Schema(IList<Field> fields, IList<IObserver<NotificationContext>> observers)
        {
            _observers = new List<IDisposable>();
            
            _fields = new FieldList();
            
            ConnectObservers(observers);
            
            _fields.AddRange(fields);
        }

        /// <summary>
        /// Builds the schema.
        /// </summary>
        /// <returns></returns>
        public static ISchemaBuilder Builder() => new SchemaBuilderImpl();

        public T Remove<T>(Func<T, bool> criteria)
            where T : Field
        {
            for (int i = 0; i < _fields.Count; i++)
            {
                T field = _fields[i].Cast<T>();
                if (!criteria(field))
                    continue;
                
                return _fields.Remove(i).Cast<T>();
            }

            return typeof(T).GetMissingField<T>();
        }

        public IReadOnlyFieldList RemoveAll<T>(Func<T, bool> criteria)
            where T : Field
        {
            var fields = new FieldList();
            
            for (int i = 0; i < _fields.Count; i++)
            {
                T field = _fields[i].Cast<T>();
                if (!criteria(field))
                    continue;
                
                fields.Add(_fields.Remove(i));
            }

            return fields;
        }

        public bool Equals(Schema other)
        {
            if (ReferenceEquals(null, other))
                return false;
            
            if (ReferenceEquals(this, other))
                return true;

            return _fields.Equals(other.Fields);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            
            if (ReferenceEquals(this, obj))
                return true;
            
            if (obj.GetType() != this.GetType())
                return false;
            
            return Equals((Schema) obj);
        }

        public override int GetHashCode() => _fields != null ? _fields.GetHashCode() : 0;

        public void Dispose()
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                _observers[i].Dispose();
            }
        }

        void ConnectObservers(IList<IObserver<NotificationContext>> observers)
        {
            for (int i = 0; i < observers.Count; i++)
            {
                if (observers[i] != null)
                    _observers.Add(_fields.Subscribe(observers[i]));
            }
        }
    }
}