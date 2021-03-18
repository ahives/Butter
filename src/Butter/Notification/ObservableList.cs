namespace Butter.Notification
{
    using System;
    using System.Collections.Generic;
    using Internal;
    using Specification;

    public abstract class ObservableList
    {
        readonly bool _notifyObservers;
        readonly List<IObserver<NotificationContext>> _observers;

        protected ObservableList(bool notifyObservers)
        {
            _notifyObservers = notifyObservers;
            _observers = new List<IObserver<NotificationContext>>();
        }

        public IDisposable Subscribe(IObserver<NotificationContext> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new UnsubscribeObserver(_observers, observer);
        }

        protected void NotifyObservers(PrimitiveField specification, SchemaActionType schemaActionType)
        {
            if (!_notifyObservers)
                return;
            
            foreach (var observer in _observers)
            {
                observer.OnNext(new NotificationContextImpl(specification, schemaActionType));
            }
        }
        
        
        class UnsubscribeObserver :
            IDisposable
        {
            readonly List<IObserver<NotificationContext>> _observers;
            readonly IObserver<NotificationContext> _observer;

            public UnsubscribeObserver(List<IObserver<NotificationContext>> observers, IObserver<NotificationContext> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}