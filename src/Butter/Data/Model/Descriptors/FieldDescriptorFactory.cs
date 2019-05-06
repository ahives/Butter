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
namespace Butter.Data.Model.Descriptors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;

    class FieldDescriptorFactory :
        IFactory
    {
        readonly IDictionary<string, object> _descriptorCache;

        public FieldDescriptorFactory()
        {
            _descriptorCache = new Dictionary<string, object>();
        }

        public T Get<T>()
            where T : IFieldDescriptor
        {
            Type type = GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface);
            
            if (type == null)
                throw new BuilderMissingException($"Failed to find implementation class for interface {typeof(T)}");

            if (_descriptorCache.ContainsKey(type.FullName))
                return (T)_descriptorCache[type.FullName];

            var descriptor = (T)Activator.CreateInstance(type);

            if (!_descriptorCache.ContainsKey(type.FullName))
                _descriptorCache.Add(type.FullName, descriptor);
            
            return descriptor;
        }
    }
}