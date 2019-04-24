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
    using Metadata;
    using Model;

    public static class DataField
    {
        /// <summary>
        /// Creates a new instance of a <see cref="Field{TValue}"/> given <see cref="fieldName"/>
        /// </summary>
        /// <param name="fieldName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="EntityCreationException"></exception>
        public static Field<T> Create<T>(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new EntityCreationException("Cannot create a field with a missing name");

            return new FieldImpl<T>(fieldName);
        }

        /// <summary>
        /// Creates a new instance of a <see cref="Field{TValue}"/> given <see cref="fieldName"/> and <see cref="value"/>
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="EntityCreationException"></exception>
        public static Field<T> Create<T>(string fieldName, T value)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new EntityCreationException("Cannot create a field with a missing name");

            return new FieldImpl<T>(fieldName, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        /// <exception cref="EntityCreationException"></exception>
        public static Field Create(string fieldName, DataType dataType)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new EntityCreationException("Cannot create a field with a missing name");

            return new FieldImpl(fieldName, dataType);
        }

        public static Field<T> OutOfRange<T>(int index, int count) => new OutOfRangeField<T>(index, count);

        public static Field OutOfRange(int index, int count) => new OutOfRangeField(index, count);

        public static Field<T> Empty<T>() => TypedFieldCache<T>.EmptyField;

        public static Field Empty() => FieldCache.EmptyField;


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


        class FieldImpl :
            Field
        {
            public FieldImpl(string name, DataType dataType)
            {
                Name = name;
                DataType = dataType;
                Type = ClrType.Convert(dataType);
            }

            public DataType DataType { get; }
            public Type Type { get; }
            public string Name { get; }
        }

        
        static class TypedFieldCache<T>
        {
            public static readonly Field<T> EmptyField = new EmptyField<T>();
        }

        
        static class FieldCache
        {
            public static readonly Field EmptyField = new EmptyField();
        }

    }
}