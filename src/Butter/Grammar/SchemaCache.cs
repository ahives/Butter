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
namespace Butter.Grammar
{
    using System;
    using Internal;

    public static class SchemaCache
    {
        public static readonly FieldSpec MissingFieldSpec = new MissingFieldSpec();
        public static readonly DecimalFieldSpec MissingDecimalFieldSpec = new MissingDecimalFieldSpec();
        public static readonly MapFieldSpec MissingMapFieldSpec = new MissingMapFieldSpec();
        public static readonly ListFieldSpec MissingListFieldSpec = new MissingListFieldSpec();
        public static readonly StructFieldSpec MissingStructFieldSpec = new MissingStructFieldSpec();
        public static readonly IReadOnlyFieldList EmptyFieldList = new EmptyFieldList();
        public static readonly FieldSpec OutOfRangeFieldSpec = new OutOfRangeFieldSpec();

        public static T GetMissingField<T>(this Type type)
        {
            switch (type)
            {
                case MapFieldSpec _:
                    return (T) MissingMapFieldSpec;

                case ListFieldSpec _:
                    return (T) MissingListFieldSpec;

                case StructFieldSpec _:
                    return (T) MissingStructFieldSpec;

                case DecimalFieldSpec _:
                    return (T) MissingDecimalFieldSpec;

                default:
                    throw new Exception();
            }
        }
    }
}