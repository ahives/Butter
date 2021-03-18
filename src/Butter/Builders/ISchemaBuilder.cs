namespace Butter.Builders
{
    using System;
    using Notification;
    using Specification;

    public interface ISchemaBuilder
    {
        ISchemaBuilder Field(PrimitiveField field);

        ISchemaBuilder Field<T>(Func<T, PrimitiveField> builder)
            where T : IFieldBuilder;

        ISchemaBuilder Fields(IReadOnlyFieldList fields);
        
        ISchemaBuilder RegisterObserver(IObserver<NotificationContext> observer);
        
        ISchema Build();
    }
}