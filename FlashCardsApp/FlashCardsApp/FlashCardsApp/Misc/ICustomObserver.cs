using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardsApp.Misc
{
    public interface ICustomObserver<T>
    {
        void NewObservable(ICustomObservable<T> observable);

        void ForgetObservable(ICustomObservable<T> observable);
    }
}
