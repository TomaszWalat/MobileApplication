using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardsApp.Misc
{
    public interface ICustomObservable<T>
    {
        void SubscribeObject(ICustomObserver<T> observer);
        void UnsubscribeObject(ICustomObserver<T> observer);
    }
}
