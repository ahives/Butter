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
    using Builders;

    public static class Field
    {
        /// <summary>
        /// Returns a field builder from cache memory.
        /// </summary>
        /// <typeparam name="TBuilder"></typeparam>
        /// <returns></returns>
        /// <exception cref="FieldBuilderMissingException"></exception>
        public static TBuilder Builder<TBuilder>()
            where TBuilder : IFieldBuilder
        {
            Type type = typeof(TBuilder)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => typeof(TBuilder).IsAssignableFrom(x) && !x.IsInterface);
            
            if (type == null)
                throw new FieldBuilderMissingException($"Failed to find implementation for builder '{typeof(TBuilder)}'");

            return (TBuilder)Activator.CreateInstance(type);
        }
    }
}