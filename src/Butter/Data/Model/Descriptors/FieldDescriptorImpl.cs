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
    using System.Threading;
    using Internal;
    using Model;

    class FieldDescriptorImpl :
        FieldDescriptor
    {
        public Field Create(Action<FieldDefinition> criteria)
        {
            var impl = new FieldDefinitionImpl();
            criteria(impl);
            
            return new FieldImpl(impl.FieldId.Value, impl.FieldType.Value);
        }

        public FieldDescriptorType Type => FieldDescriptorType.Primitive;


        class FieldDefinitionImpl :
            FieldDefinition
        {
            string _id;
            FieldType _fieldType;

            public FieldDefinitionImpl()
            {
                FieldId = new Lazy<string>(() => _id, LazyThreadSafetyMode.PublicationOnly);
                FieldType = new Lazy<FieldType>(() => _fieldType, LazyThreadSafetyMode.PublicationOnly);
            }

            public void Id(string name)
            {
                _id = name;
            }

            public void Type(FieldType type)
            {
                _fieldType = type;
            }

            public Lazy<string> FieldId { get; }
            public Lazy<FieldType> FieldType { get; }
        }
    }
}