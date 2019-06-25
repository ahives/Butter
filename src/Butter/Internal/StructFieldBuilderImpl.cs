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
    using Specification;

    class StructFieldBuilderImpl :
        StructFieldBuilder
    {
        string _id;
        bool _nullable;
        readonly IFieldList _specifications;

        public StructFieldBuilderImpl()
        {
            _specifications = new FieldList(false);
        }

        public StructFieldBuilder Id(string id)
        {
            _id = id;

            return this;
        }

        public StructFieldBuilder Field<T>(T specification)
            where T : PrimitiveField
        {
            _specifications.Add(specification);

            return this;
        }

        public StructFieldBuilder Field<T>(Func<T, PrimitiveField> builder)
            where T : ISpecificationBuilder
        {
            T specBuilder = Butter.Field.Builder<T>();

            var specification = builder(specBuilder);

            _specifications.Add(specification);

            return this;
        }

        public StructFieldBuilder Fields(IReadOnlyFieldList specifications)
        {
            _specifications.AddRange(specifications.ToList());

            return this;
        }

        public StructFieldBuilder IsNullable()
        {
            _nullable = true;

            return this;
        }

        public StructField Build() => new StructFieldImpl(_id, _specifications, isNullable:_nullable);
    }
}