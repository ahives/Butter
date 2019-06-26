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
    using System.Text;
    using Builders;
    using Internal;
    using Notification;
    using Specification;

    public class Schema :
        ISchema, IEquatable<Schema>, IDisposable
    {
        readonly List<IDisposable> _observers;
        readonly FieldList _fields;

        public IReadOnlyFieldList Fields => _fields;

        internal Schema(IList<PrimitiveField> fields, IList<IObserver<NotificationContext>> observers)
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
            where T : PrimitiveField
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
            where T : PrimitiveField
        {
            var fields = new FieldList();
            
            for (int i = 0; i < _fields.Count; i++)
            {
                T field = _fields[i].Cast<T>();
                if (!criteria(field))
                    continue;
                
                fields.Add(_fields.Remove(i));
                i = 0;
            }

            return fields;
        }

        public string Report()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Schema Summary");
            builder.AppendLine("\tFields");
            
            for (int i = 0; i < _fields.Count; i++)
            {
                builder.AppendLine(_fields[i].ToString());
            }

            return builder.ToString();
        }

        public T Modify<T, TBuilder>(Func<T, bool> criteria, Func<TBuilder, T> builder)
            where T : PrimitiveField
            where TBuilder : IFieldBuilder
        {
            TBuilder b = Field.Builder<TBuilder>();
            T field = builder(b);

            for (int i = 0; i < _fields.Count; i++)
            {
                T current = _fields[i].Cast<T>();

                if (criteria(current))
                    return !_fields.TryReplace(current.Id, field, out PrimitiveField previous)
                        ? typeof(T).GetMissingField<T>()
                        : previous.Cast<T>();
            }

            return typeof(T).GetMissingField<T>();
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