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
namespace Butter.Builders
{
    using System;
    using Specification;

    public interface Struct :
        IFieldBuilder
    {
        Struct Id(string id);

        Struct Index(int index);

        Struct Field<T>(T field)
            where T : PrimitiveField;

        Struct Field<T>(Func<T, PrimitiveField> builder)
            where T : IFieldBuilder;

        Struct Fields(IReadOnlyFieldList fields);

        Struct IsNullable();

        StructField Build();
    }
}