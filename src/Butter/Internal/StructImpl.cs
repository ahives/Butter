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
    using Builders;
    using Specification;

    class StructImpl :
        Struct
    {
        string _id;
        bool _nullable;
        readonly IFieldList _fields;
        int _index;

        public StructImpl()
        {
            _fields = new FieldList(false);
        }

        public Struct Id(string id)
        {
            _id = id;

            return this;
        }

        public Struct Index(int index)
        {
            _index = index;
            
            return this;
        }

        public Struct Field<T>(T field)
            where T : PrimitiveField
        {
            _fields.Add(field);

            return this;
        }

        public Struct Field<T>(Func<T, PrimitiveField> builder)
            where T : IFieldBuilder
        {
            T specBuilder = Butter.Field.Builder<T>();

            var specification = builder(specBuilder);

            _fields.Add(specification);

            return this;
        }

        public Struct Fields(IReadOnlyFieldList fields)
        {
            _fields.AddRange(fields.ToList());

            return this;
        }

        public Struct IsNullable()
        {
            _nullable = true;

            return this;
        }

        public StructField Build() => new StructFieldImpl(_id, _index, _fields, isNullable:_nullable);
    }
}