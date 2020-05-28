using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardsApp.Misc
{
    class CustomUnsubscriber : IDisposable
    {
        private List<ICustomObserver<Type>> _observers;
        private ICustomObserver<Type> _observer;

        public CustomUnsubscriber(List<ICustomObserver<Type>> observers, ICustomObserver<Type> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
