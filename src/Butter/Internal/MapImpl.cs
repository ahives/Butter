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
    using System.Threading;
    using Builders;
    using Specification;

    class MapImpl :
        Map
    {
        Lazy<string> _id;
        Lazy<bool> _nullable;
        Lazy<PrimitiveField> _key;
        Lazy<PrimitiveField> _value;
        FieldMap<PrimitiveField,PrimitiveField> _mapping;

        public Map Id(string id)
        {
            _id = new Lazy<string>(() => id, LazyThreadSafetyMode.PublicationOnly);
            
            return this;
        }

        public Map Map(PrimitiveField key, PrimitiveField value)
        {
            _key = new Lazy<PrimitiveField>(() => key, LazyThreadSafetyMode.PublicationOnly);
            _value = new Lazy<PrimitiveField>(() => value, LazyThreadSafetyMode.PublicationOnly);

            return this;
        }

        public Map Key(PrimitiveField key)
        {
            _key = new Lazy<PrimitiveField>(() => key, LazyThreadSafetyMode.PublicationOnly);
            
            return this;
        }

        public Map Value(PrimitiveField value)
        {
            _value = new Lazy<PrimitiveField>(() => value, LazyThreadSafetyMode.PublicationOnly);

            return this;
        }

        public Map IsNullable()
        {
            _nullable = new Lazy<bool>(() => true, LazyThreadSafetyMode.PublicationOnly);
            
            return this;
        }

        public MapField Build()
        {
            _mapping = new FieldMapImpl(_key.Value, _value.Value);
            
            return new MapFieldImpl(_id.Value, _mapping, _nullable.Value);
        }

        public FieldMap<PrimitiveField, PrimitiveField> Mapping => _mapping;
    }
}