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
namespace Butter.Internal
{
    using System;
    using System.Collections.Generic;
    using Notification;
    using Specification;

    class SchemaBuilderImpl :
        ISchemaBuilder
    {
        readonly List<Field> _specifications = new List<Field>();
        readonly List<IObserver<NotificationContext>> _observers = new List<IObserver<NotificationContext>>();

        public ISchemaBuilder Field(Field field)
        {
            _specifications.Add(field);

            return this;
        }

        public ISchemaBuilder Field<T>(Func<T, Field> builder)
            where T : ISpecificationBuilder
        {
            T specBuilder = FieldSpec.Builder<T>();

            var specification = builder(specBuilder);

            _specifications.Add(specification);

            return this;
        }

        public ISchemaBuilder Fields(IReadOnlyFieldList fields)
        {
            _specifications.AddRange(fields.ToList());

            return this;
        }

        public ISchemaBuilder RegisterObserver(IObserver<NotificationContext> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            
            return this;
        }

        public ISchema Build() => new Schema(_specifications, _observers);
    }
}