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
    using System.Runtime.Serialization;
    using System.Threading;
    using Metadata;
    using Model;

    public static class DataField
    {
        public static Field Create(Action<FieldDefinitionCriteria> criteria)
        {
            var impl = new FieldDefinitionCriteriaImpl();
            criteria(impl);
            
            return new FieldImpl(impl);
        }

        
        class FieldDefinitionCriteriaImpl :
            FieldDefinitionCriteria, DefinedFieldCriteria
        {
            string _name;
            FieldType _fieldType;

            public FieldDefinitionCriteriaImpl()
            {
                DefinedName = new Lazy<string>(() => _name, LazyThreadSafetyMode.PublicationOnly);
                DefinedFieldType = new Lazy<FieldType>(() => _fieldType, LazyThreadSafetyMode.PublicationOnly);
            }

            public void Name(string name)
            {
                _name = name;
            }

            public void Type(FieldType fieldType)
            {
                _fieldType = fieldType;
            }

            public Lazy<string> DefinedName { get; }
            public Lazy<FieldType> DefinedFieldType { get; }
        }

        public static Field OutOfRange(int index, int count) => new OutOfRangeField(index, count);

        public static Field Missing() => SchemaCache.MissingField;


        class FieldImpl :
            Field
        {
            public FieldImpl(DefinedFieldCriteria criteria)
            {
                Name = criteria.DefinedName.Value;
                FieldType = criteria.DefinedFieldType.Value;
            }

            public string Name { get; }
            public FieldType FieldType { get; }
        }
    }

    interface DefinedFieldCriteria
    {
        Lazy<string> DefinedName { get; }
        
        Lazy<FieldType> DefinedFieldType { get; }
    }

    public interface FieldDefinitionCriteria
    {
        void Name(string name);

        void Type(FieldType fieldType);
    }

    public interface SchemaFactory
    {
        T Factory<T>()
            where T : SchemaEntity;
    }

    class SchemaFactoryImpl : SchemaFactory
    {
        public T Factory<T>()
            where T : SchemaEntity
        {
            Type type = GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface);

            if (type == null)
                throw new SchemaFactoryInitException($"Failed to find implementation class for interface {typeof(T)}");

            var resource = (T)Activator.CreateInstance(type);

            return resource;
        }
    }

    class SchemaFactoryInitException : Exception
    {
        public SchemaFactoryInitException()
        {
        }

        protected SchemaFactoryInitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public SchemaFactoryInitException(string message) : base(message)
        {
        }

        public SchemaFactoryInitException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public interface SchemaEntity
    {
    }

    public static class ButterFactory
    {
        
    }
}