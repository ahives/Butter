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
    using Builders;
    using Specification;

    class MapImpl :
        Map
    {
        string _id;
        bool _nullable;
        PrimitiveField _key;
        PrimitiveField _value;
        int _index;

        public Map Id(string id)
        {
            _id = id;
            
            return this;
        }

        public Map Index(int index)
        {
            _index = index;

            return this;
        }

        public Map Map(PrimitiveField key, PrimitiveField value)
        {
            _key = key;
            _value = value;

            return this;
        }

        public Map Key(PrimitiveField key)
        {
            _key = key;
            
            return this;
        }

        public Map Value(PrimitiveField value)
        {
            _value = value;

            return this;
        }

        public Map IsNullable()
        {
            _nullable = true;
            
            return this;
        }

        public MapField Build() => new MapFieldImpl(_id, _index, new FieldMapImpl(_key, _value), _nullable);
    }
}