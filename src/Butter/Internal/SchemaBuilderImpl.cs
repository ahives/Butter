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
    using Grammar;
    using Notification;

    class SchemaBuilderImpl :
        ISchemaBuilder
    {
        readonly List<FieldSpec> _specifications = new List<FieldSpec>();
        readonly List<IObserver<NotificationContext>> _observers = new List<IObserver<NotificationContext>>();

        public ISchemaBuilder Field(FieldSpec specification)
        {
            _specifications.Add(specification);

            return this;
        }

        public ISchemaBuilder Field<T>(Func<T, FieldSpec> builder)
            where T : ISpecificationBuilder
        {
            T specBuilder = Butter.Field.Builder<T>();

            var specification = builder(specBuilder);

            _specifications.Add(specification);

            return this;
        }

        public ISchemaBuilder Fields(IReadOnlyFieldList specifications)
        {
            _specifications.AddRange(specifications.ToList());

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