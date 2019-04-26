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
        /// Creates a new instance of a <see cref="Field"/> 
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
        
        /// <summary>
        /// Creates a new instance of a <see cref="Field"/> 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="dataType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="EntityCreationException"></exception>
        public static Field Create(string fieldName, DataType dataType, string value)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new EntityCreationException("Cannot create a field with a missing name");

            return new FieldImpl(fieldName, dataType, value);
        }

        /// <summary>
        /// Creates a new instance of a <see cref="Field"/> 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="EntityCreationException"></exception>
        public static Field Create<T>(string fieldName, string value)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new EntityCreationException("Cannot create a field with a missing name");

            return new FieldImpl(fieldName, typeof(T), value);
        }

        /// <summary>
        /// Creates a new instance of a <see cref="Field"/> 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="EntityCreationException"></exception>
        public static Field Create<T>(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new EntityCreationException("Cannot create a field with a missing name");

            return new FieldImpl(fieldName, typeof(T));
        }

        /// <summary>
        /// Creates a new instance of a <see cref="Field"/> 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="EntityCreationException"></exception>
        public static Field Create(string fieldName, Value value)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new EntityCreationException("Cannot create a field with a missing name");

            return new FieldImpl(fieldName, value);
        }

        public static Field OutOfRange(int index, int count) => new OutOfRangeField(index, count);

        public static Field Missing() => FieldCache.MissingField;


        class FieldImpl :
            Field
        {
            public FieldImpl(string fieldName, DataType dataType)
            {
                Name = fieldName;
                Value = new ValueImpl(dataType);
            }

            public FieldImpl(string fieldName, Value value)
            {
                Name = fieldName;
                Value = value;
                HasValue = value != null && !string.IsNullOrWhiteSpace(value.Data);
            }

            public FieldImpl(string fieldName, DataType dataType, string value)
            {
                Name = fieldName;
                Value = new ValueImpl(value, dataType);
                HasValue = !string.IsNullOrWhiteSpace(value);
            }

            public FieldImpl(string fieldName, Type clrType, string value)
            {
                Name = fieldName;
                Value = new ValueImpl(value, clrType);
                HasValue = !string.IsNullOrWhiteSpace(value);
            }

            public FieldImpl(string fieldName, Type clrType)
            {
                Name = fieldName;
                Value = new ValueImpl(clrType);
            }

            public string Name { get; }
            public bool HasValue { get; }
            public Value Value { get; }

            
            class ValueImpl :
                Value
            {
                public ValueImpl(DataType dataType)
                {
                    DataType = dataType;
                    ClrType = dataType.Convert();
                }

                public ValueImpl(string data, DataType dataType)
                {
                    Data = data;
                    DataType = dataType;
                    ClrType = dataType.Convert();
                }

                public ValueImpl(string data, Type clrType)
                {
                    Data = data;
                    DataType = clrType.Convert();
                    ClrType = clrType;
                }

                public ValueImpl(Type clrType)
                {
                    DataType = clrType.Convert();
                    ClrType = clrType;
                }

                public string Data { get; }
                public DataType DataType { get; }
                public Type ClrType { get; }
            }
        }

        
        static class FieldCache
        {
            public static readonly Field MissingField = new MissingField();
        }
    }
}