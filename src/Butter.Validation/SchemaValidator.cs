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
namespace Butter.Validation
{
    using System;
    using System.Collections.Generic;
    using Grammar;
    using Internal;
    using Notification;

    public class SchemaValidator :
        ISchemaValidator
    {
        IDisposable _unsubscribe;
        readonly IFieldList _fields;
//        readonly ISession _session;

        public IList<ValidationContext> Validation { get; }

        public SchemaValidator()
        {
            Validation = new List<ValidationContext>();
            _fields = new FieldList(false);
            
//            var repository = new RuleRepository();
//            
//            repository.Load(x => x.Where(r => r.IsTagged("FieldValidation")));
//            repository.Load(x => x.From(typeof(NullFieldRule).Assembly));
//            
//            var factory = repository.Compile();
//            _session = factory.CreateSession();
//            
//            _session.Events.RuleFiredEvent += OnRuleFiredEventHandler;
        }

        public void Validate()
        {
//            _session.Fire();
        }

//        void OnRuleFiredEventHandler(object sender, AgendaEventArgs e)
//        {
//            foreach (var fact in e.Facts)
//            {
//                foreach (var context in (IEnumerable<NotificationContext>) fact.Value)
//                {
//                    if (context != null)
//                        Console.WriteLine(context.Field.Id);
//                }
//            }
//        }

        public void Subscribe(IObservable<NotificationContext> provider)
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

        public void OnNext(NotificationContext value)
        {
//            _session.Insert(value);
            
            if (value == null)
            {
                var result = new ValidationResultImpl("FIELD == NULL.", ValidationType.Error);
                var context = new ValidationContextImpl(SchemaCache.MissingFieldSpec, result);
                
                Validation.Add(context);
                
                return;
            }

            if (_fields.Contains(value.Specification))
            {
                var result = new ValidationResultImpl("FIELD ALREADY EXISTS.", ValidationType.Error);
                var context = new ValidationContextImpl(value.Specification, result);
                
                Console.WriteLine(result.Reason);
                Validation.Add(context);
            }
            
            _fields.Add(value.Specification);
        }
    }
}