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
    using System.Threading;
    using Metadata;
    using Model;

    class FieldBuilderImpl :
        FieldBuilder
    {
        public Field Create(Action<FieldBuilderCriteria> criteria)
        {
            var impl = new FieldBuilderDefinitionResultImpl();
            criteria(impl);
            
            return new FieldImpl(impl);
        }

        
        class FieldBuilderDefinitionResultImpl :
            FieldBuilderCriteria, FieldDefinitionResult
        {
            string _name;
            FieldType _fieldType;

            public FieldBuilderDefinitionResultImpl()
            {
                DefinedName = new Lazy<string>(() => _name, LazyThreadSafetyMode.PublicationOnly);
                DefinedFieldType = new Lazy<FieldType>(() => _fieldType, LazyThreadSafetyMode.PublicationOnly);
            }

            public void Name(string name)
            {
                _name = name;
            }

            public void FieldType(FieldType fieldType)
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
            public FieldImpl(FieldDefinitionResult definitionResult)
            {
                Name = definitionResult.DefinedName.Value;
                FieldType = definitionResult.DefinedFieldType.Value;
            }

            public string Name { get; }
            public FieldType FieldType { get; }
        }
    }

    interface FieldDefinitionResult
    {
        Lazy<string> DefinedName { get; }
        
        Lazy<FieldType> DefinedFieldType { get; }
    }
}