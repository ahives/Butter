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
    using System.Collections.Generic;
    using Grammar;
    using Grammar.Internal;

    public class SchemaValidator :
        ISchemaValidator
    {
        IDisposable _unsubscribe;
        ISchema _schema;
        readonly IFieldList _fields;

        public IList<ValidationContext> Validation { get; }

        public SchemaValidator()
        {
            Validation = new List<ValidationContext>();
            _fields = new FieldList(false);
        }

        public void Subscribe(IObservable<Field> provider)
        {
            if (provider != null)
                _unsubscribe = provider.Subscribe(this);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Field value)
        {
            if (value == null)
            {
                var result = new ValidationResultImpl("FIELD == NULL.", ValidationType.Error);
                var context = new ValidationContextImpl(SchemaCache.MissingField, result);
                
                Validation.Add(context);
                
                Console.WriteLine(result.Reason);
                
                return;
            }

            if (_fields.Contains(value))
            {
                var result = new ValidationResultImpl("FIELD ALREADY EXISTS.", ValidationType.Error);
                var context = new ValidationContextImpl(value, result);
                
                Validation.Add(context);
                
                Console.WriteLine(result.Reason);
            }
            
            _fields.Add(value);
        }
    }
}