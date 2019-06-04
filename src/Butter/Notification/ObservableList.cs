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
namespace Butter.Notification
{
    using System;
    using System.Collections.Generic;
    using Grammar;
    using Internal;

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

        protected void NotifyObservers(Field specification, SchemaActionType schemaActionType)
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