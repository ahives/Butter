namespace Butter.Validation
{
    using System;
    using System.Collections.Generic;
    using Notification;
    using NRules;
    using NRules.Diagnostics;
    using NRules.Fluent;
    using NRules.RuleModel;
    using Rules;
    using Serialization.Json;
    using Specification;

    public class SchemaValidator :
        ISchemaValidator
    {
        IDisposable _unsubscribe;
        readonly IFieldList _fields;
        readonly ISession _session;

        public IList<ValidationContext> Validation { get; }

        public SchemaValidator()
        {
            Validation = new List<ValidationContext>();
            _fields = new FieldList();
            
            var repository = new RuleRepository();
            
            repository.Load(x => x.Where(r => r.IsTagged("FieldValidation")));
            repository.Load(x => x.From(typeof(NullFieldRule).Assembly));
            
            var factory = repository.Compile();
            _session = factory.CreateSession();
            
            _session.Events.RuleFiredEvent += OnRuleFiredEventHandler;
        }

        public void Validate()
        {
            _session.Fire();
        }

        void OnRuleFiredEventHandler(object sender, AgendaEventArgs e)
        {
            foreach (IFactMatch fact in e.Facts)
            {
                    Console.WriteLine(e.Rule.Name);
                    Console.WriteLine(fact.Value.GetType());
                    
                foreach (var field in (IEnumerable<PrimitiveField>)fact.Value)
                {
                    Console.WriteLine(field.ToJsonString());
                    if (field == null)
                    {
                        Console.WriteLine($"Field 'null'");
                        Console.WriteLine($"\tRule '{e.Rule.Name}' executed => '{e.Rule.Description}'");
                        continue;
                    }
                    
                    Console.WriteLine($"Field '{field.Id}'");
                    Console.WriteLine($"\tRule '{e.Rule.Name}' executed => '{e.Rule.Description}'");
                }
            }
        }

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
            _session.Insert(value.Field);
            
//            if (value == null)
//            {
//                var result = new ValidationResultImpl("FIELD == NULL.", ValidationType.Error);
//                var context = new ValidationContextImpl(SchemaCache.MissingField, result);
//                
//                Validation.Add(context);
//                
//                return;
//            }
//
//            if (_fields.Contains(value.Field))
//            {
//                var result = new ValidationResultImpl("FIELD ALREADY EXISTS.", ValidationType.Error);
//                var context = new ValidationContextImpl(value.Field, result);
//                
//                Console.WriteLine(result.Reason);
//                Validation.Add(context);
//            }
//            
//            _fields.Add(value.Field);
        }
    }
}