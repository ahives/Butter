namespace Butter.Notification
{
    using System;
    using Specification;

    public interface NotificationContext
    {
        PrimitiveField Field { get; }
        
        SchemaActionType Action { get; }
        
        DateTimeOffset Timestamp { get; }
    }
}