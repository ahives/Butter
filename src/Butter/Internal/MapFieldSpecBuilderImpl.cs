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

    class MapFieldSpecBuilderImpl :
        MapFieldSpecBuilder
    {
        Lazy<string> _id;
        Lazy<bool> _nullable;
        Lazy<FieldSpec> _key;
        Lazy<FieldSpec> _value;
        FieldMap<FieldSpec,FieldSpec> _mapping;

        public MapFieldSpecBuilder Id(string id)
        {
            _id = new Lazy<string>(() => id, LazyThreadSafetyMode.PublicationOnly);
            
            return this;
        }

        public MapFieldSpecBuilder Map(FieldSpec key, FieldSpec value)
        {
            _key = new Lazy<FieldSpec>(() => key, LazyThreadSafetyMode.PublicationOnly);
            _value = new Lazy<FieldSpec>(() => value, LazyThreadSafetyMode.PublicationOnly);

            return this;
        }

        public MapFieldSpecBuilder Key(FieldSpec key)
        {
            _key = new Lazy<FieldSpec>(() => key, LazyThreadSafetyMode.PublicationOnly);
            
            return this;
        }

        public MapFieldSpecBuilder Value(FieldSpec value)
        {
            _value = new Lazy<FieldSpec>(() => value, LazyThreadSafetyMode.PublicationOnly);

            return this;
        }

        public MapFieldSpecBuilder IsNullable()
        {
            _nullable = new Lazy<bool>(() => true, LazyThreadSafetyMode.PublicationOnly);
            
            return this;
        }

        public MapFieldSpec Build()
        {
            _mapping = new FieldMapImpl(_key.Value, _value.Value);
            
            return new MapFieldSpecImpl(_id.Value, _mapping, _nullable.Value);
        }

        public FieldMap<FieldSpec, FieldSpec> Mapping => _mapping;
    }
}