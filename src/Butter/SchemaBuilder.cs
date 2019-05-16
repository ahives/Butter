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
    using Data;
    using Data.Model;
    using Data.Model.Definition;
    using Data.Model.Internal;

    class SchemaBuilder :
        ISchemaBuilder
    {
        readonly FieldList _fields = new FieldList();

        public ISchemaBuilder Field(string fieldId, FieldType fieldType, bool nullable = false)
        {
            _fields.Add(new FieldImpl(fieldId, fieldType, nullable));
            
            return this;
        }

        public ISchemaBuilder Field(string fieldId, FieldType fieldType, Action<DecimalDefinition> definition, bool nullable = false)
        {
            var impl = new DecimalDefinitionImpl();
            definition(impl);
            
            _fields.Add(new DecimalFieldImpl(fieldId, nullable, fieldType, impl.Scale.Value, impl.Precision.Value));
            
            return this;
        }

        public ISchema Build() => new Schema(_fields);


        class DecimalDefinitionImpl :
            DecimalDefinition
        {
            int _precision;
            int _scale;

            public Lazy<int> Scale { get; }
            public Lazy<int> Precision { get; }

            public DecimalDefinitionImpl()
            {
                Scale = new Lazy<int>(() => _scale, LazyThreadSafetyMode.PublicationOnly);
                Precision = new Lazy<int>(() => _precision, LazyThreadSafetyMode.PublicationOnly);
            }

            public void SetScale(int scale)
            {
                _scale = scale;
            }

            public void SetPrecision(int precision)
            {
                _precision = precision;
            }
        }
    }
}