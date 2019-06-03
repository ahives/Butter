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
    using Grammar;

    class StructFieldSpecBuilderImpl :
        StructFieldSpecBuilder
    {
        string _id;
        FieldSpec _specification;
        readonly IFieldList _specifications;
        bool _nullable;

        public StructFieldSpecBuilderImpl()
        {
            _specifications = new FieldList(false);
        }

        public StructFieldSpecBuilder Id(string id)
        {
            _id = id;

            return this;
        }

        public StructFieldSpecBuilder Field<T>(T specification)
            where T : FieldSpec
        {
            _specifications.Add(specification);

            return this;
        }

        public StructFieldSpecBuilder Field<T>(Func<T, FieldSpec> builder)
            where T : ISpecificationBuilder
        {
            T specBuilder = Butter.Field.Builder<T>();

            var specification = builder(specBuilder);

            _specifications.Add(specification);

            return this;
        }

        public StructFieldSpecBuilder Fields(IReadOnlyFieldList specifications)
        {
            _specifications.AddRange(specifications.ToList());

            return this;
        }

        public StructFieldSpecBuilder IsNullable()
        {
            _nullable = true;

            return this;
        }

        public StructFieldSpec Build() => new StructFieldSpecImpl(_id, _specifications, isNullable:_nullable);
    }
}