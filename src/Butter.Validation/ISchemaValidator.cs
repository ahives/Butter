namespace Butter.Validation
{
    using System;
    using System.Collections.Generic;
    using Notification;

    public interface ISchemaValidator :
        IObserver<NotificationContext>
    {
        void Subscribe(IObservable<NotificationContext> provider);
        
        IList<ValidationContext> Validation { get; }

        void Validate();
    }
}