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
    using System.Linq;

    public class FieldSpec
    {
        /// <summary>
        /// Returns a field builder from cache memory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="FieldBuilderMissingException"></exception>
        public static T Builder<T>()
            where T : ISpecificationBuilder
        {
            Type type = typeof(T)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface);
            
            if (type == null)
                throw new FieldBuilderMissingException($"Failed to find implementation for builder '{typeof(T)}'");

            return (T)Activator.CreateInstance(type);
        }
    }
}