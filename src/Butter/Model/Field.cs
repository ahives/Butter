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
namespace Butter.Model
{
    using System;
    using Metadata;

    public interface Field<out TValue>
    {
        TValue Value { get; }
        
        string Name { get; }
        
        DataType DataType { get; }
        
        Type Type { get; }
    }

    public static class Field
    {
        /// <summary>
        /// Creates a new instance of a <see cref="Field{TValue}"/> given <see cref="name"/>
        /// </summary>
        /// <param name="name"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="EntityCreationException"></exception>
        public static Field<T> Create<T>(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new EntityCreationException("Cannot create a field with a missing name");

            return new FieldImpl<T>(name);
        }

        /// <summary>
        /// Creates a new instance of a <see cref="Field{TValue}"/> given <see cref="name"/> and <see cref="value"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="EntityCreationException"></exception>
        public static Field<T> Create<T>(string name, T value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new EntityCreationException("Cannot create a field with a missing name");

            return new FieldImpl<T>(name, value);
        }

        
        class FieldImpl<T> :
            Field<T>
        {
            public FieldImpl(string name)
            {
                Name = name;
                DataType = DataTypes.Convert<T>();
                Type = typeof(T);
            }

            public FieldImpl(string name, T value)
            {
                Name = name;
                DataType = DataTypes.Convert<T>();
                Value = value;
                Type = typeof(T);
            }

            public DataType DataType { get; }
            public Type Type { get; }
            public T Value { get; }
            public string Name { get; }
        }
    }
}