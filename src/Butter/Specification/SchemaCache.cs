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
namespace Butter.Specification
{
    using System;
    using Internal;

    public static class SchemaCache
    {
        public static readonly Field MissingField = new MissingField();
        public static readonly DecimalField MissingDecimalField = new MissingDecimalField();
        public static readonly MapField MissingMapField = new MissingMapField();
        public static readonly ListField MissingListField = new MissingListField();
        public static readonly StructField MissingStructField = new MissingStructField();
        public static readonly IReadOnlyFieldList EmptyFieldList = new EmptyFieldList();
        public static readonly Field OutOfRangeField = new OutOfRangeField();

        public static T GetMissingField<T>(this Type type)
        {
            switch (type)
            {
                case MapField _:
                    return (T) MissingMapField;

                case ListField _:
                    return (T) MissingListField;

                case StructField _:
                    return (T) MissingStructField;

                case DecimalField _:
                    return (T) MissingDecimalField;
                
                case Field _:
                    return (T) MissingField;

                default:
                    throw new Exception();
            }
        }
    }
}