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
    using Grammar;

    class MapFieldBuilderImpl :
        MapFieldBuilder
    {
        Lazy<string> _id;
        Lazy<bool> _nullable;
        Lazy<Field> _key;
        Lazy<Field> _value;
        FieldMap<Field,Field> _mapping;

        public MapFieldBuilder Id(string id)
        {
            _id = new Lazy<string>(() => id, LazyThreadSafetyMode.PublicationOnly);
            
            return this;
        }

        public MapFieldBuilder Map(Field key, Field value)
        {
            _key = new Lazy<Field>(() => key, LazyThreadSafetyMode.PublicationOnly);
            _value = new Lazy<Field>(() => value, LazyThreadSafetyMode.PublicationOnly);

            return this;
        }

        public MapFieldBuilder Key(Field key)
        {
            _key = new Lazy<Field>(() => key, LazyThreadSafetyMode.PublicationOnly);
            
            return this;
        }

        public MapFieldBuilder Value(Field value)
        {
            _value = new Lazy<Field>(() => value, LazyThreadSafetyMode.PublicationOnly);

            return this;
        }

        public MapFieldBuilder IsNullable()
        {
            _nullable = new Lazy<bool>(() => true, LazyThreadSafetyMode.PublicationOnly);
            
            return this;
        }

        public MapField Build()
        {
            _mapping = new FieldMapImpl(_key.Value, _value.Value);
            
            return new MapFieldImpl(_id.Value, _mapping, _nullable.Value);
        }

        public FieldMap<Field, Field> Mapping => _mapping;
    }
}