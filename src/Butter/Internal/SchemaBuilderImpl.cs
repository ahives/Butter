namespace Butter.Internal
{
    using System;
    using System.Collections.Generic;
    using Builders;
    using Notification;
    using Specification;

    class SchemaBuilderImpl :
        ISchemaBuilder
    {
        readonly List<PrimitiveField> _specifications = new List<PrimitiveField>();
        readonly List<IObserver<NotificationContext>> _observers = new List<IObserver<NotificationContext>>();

        public ISchemaBuilder Field(PrimitiveField field)
        {
            _specifications.Add(field);

            return this;
        }

        public ISchemaBuilder Field<T>(Func<T, PrimitiveField> builder)
            where T : IFieldBuilder
        {
            T specBuilder = Butter.Field.Builder<T>();

            var specification = builder(specBuilder);

            _specifications.Add(specification);

            return this;
        }

        public ISchemaBuilder Fields(IReadOnlyFieldList fields)
        {
            _specifications.AddRange(fields.ToList());

            return this;
        }

        public ISchemaBuilder RegisterObserver(IObserver<NotificationContext> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            
            return this;
        }

        public ISchema Build() => new Schema(_specifications, _observers);
    }
}