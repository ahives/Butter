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
namespace Butter
{
    using System;
    using Specification;

    public interface ISchema
    {
        /// <summary>
        /// Read-only list of fields.
        /// </summary>
        IReadOnlyFieldList Fields { get; }

        /// <summary>
        /// Removes the first field matching the criteria.
        /// </summary>
        /// <param name="criteria"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Remove<T>(Func<T, bool> criteria)
            where T : SchemaField;

        /// <summary>
        /// Removes all fields found matching the criteria.
        /// </summary>
        /// <param name="criteria"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IReadOnlyFieldList RemoveAll<T>(Func<T, bool> criteria)
            where T : SchemaField;

//        T Modify<T, TBuilder>(Func<T, bool> criteria, Func<TBuilder, T> builder)
//            where T : Field
//            where TBuilder : ISpecificationBuilder;

        string Report();
    }
}