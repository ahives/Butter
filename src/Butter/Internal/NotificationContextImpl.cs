namespace Butter.Internal
{
    using System;
    using Notification;
    using Specification;

    class NotificationContextImpl :
        NotificationContext
    {
        public NotificationContextImpl(PrimitiveField specification, SchemaActionType action)
        {
            Field = specification;
            Action = action;
            Timestamp = DateTimeOffset.UtcNow;
        }

        public PrimitiveField Field { get; }
        public SchemaActionType Action { get; }
        public DateTimeOffset Timestamp { get; }
    }
}