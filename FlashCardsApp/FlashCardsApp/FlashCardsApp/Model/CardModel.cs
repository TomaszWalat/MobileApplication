using FlashCardsApp.Misc;
using FlashCardsApp.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlashCardsApp.Model
{
    public class CardModel: ModelBase, ICustomObservable<Type>, ICustomObserver<Type>
    {
        private string _question;
        private string _answer;

        private ObservableCollection<StackModel> _stacks;
        private ObservableCollection<CardModel> _allCards;

        private List<ICustomObserver<Type>> _observers;
        private List<ICustomObservable<Type>> _observables;

        public string Question
        {
            set 
            {
                if (_question != value)
                {
                    _question = value;
                    OnPropertyChanged();
                }
            }
            get { return _question; }
        }

        public string Answer
        {
            set 
            {
                if (_answer != value)
                {
                    _answer = value;
                    OnPropertyChanged();
                }
            }
            get { return _answer;  }
        }

        public ObservableCollection<StackModel> Stacks
        {
            get { return _stacks; }
        }

        public CardModel(string question, string answer, ObservableCollection<CardModel> allCards)
        {
            _question = question;
            _answer = answer;
            _allCards = allCards;
            _stacks = new ObservableCollection<StackModel>();
            _observers = new List<ICustomObserver<Type>>();
            _observables = new List<ICustomObservable<Type>>();
        }

        public CardModel(string question, string answer, ObservableCollection<CardModel> allCards, ObservableCollection<StackModel> stacks = null)
        {
            _question = question;
            _answer = answer;
            _allCards = allCards;
            _stacks = stacks;
            _observers = new List<ICustomObserver<Type>>();
            _observables = new List<ICustomObservable<Type>>();
        }

        //public void Add(StackModel s)
        //{
        //    if(s != null)
        //    {
        //        if(!Stacks.Contains(s))
        //        {
        //            Stacks.Add(s);
        //        }
        //    }
        //}

        //public void Remove(StackModel s)
        //{
        //    if(s != null)
        //    {
        //        if(Stacks.Contains(s))
        //        {
        //            for(int i = Stacks.Count - 1; i > -1; i--)
        //            {
        //                if(Stacks[i].Equals(s))
        //                {
        //                    Stacks.RemoveAt(i);
        //                }
        //            }
        //        }
        //    }
        //}

        public void RemoveSelf()
        {
            //for(int i = Stacks.Count - 1; i > -1; i--)
            //{
            //    if(Stacks[i].Cards.Contains(this))
            //    {
            //        Stacks[i].Remove(this);
            //    }
            //}

            for(int i = _allCards.Count; i > 0; i--)
            {
                if (_allCards[i - 1].Equals(this))
                {
                    _allCards.RemoveAt(i-1);
                }
            }

            for(int i = _observers.Count; i > 0; i--)
            {
                _observers[i - 1].ForgetObservable(this);
                Console.WriteLine(_observables[i - 1].ToString());
            }

            for (int i = _observables.Count; i > 0; i--)
            {
                _observables[i - 1].UnsubscribeObject(this);
                Console.WriteLine(_observers[i - 1].ToString());
            }
        }

        public void NewObservable(ICustomObservable<Type> observable)
        {
            if(observable != null)
            {
                if (!_observables.Contains(observable))
                {
                    _observables.Add(observable);
                }

                if (observable.GetType().Name.ToString() == "StackModel")
                {
                    if (!Stacks.Contains((StackModel)observable))
                    {
                        Stacks.Add((StackModel)observable);
                    }
                }
            }
        }

        public void ForgetObservable(ICustomObservable<Type> observable)
        {
            if (observable != null)
            {
                if (_observables.Contains(observable))
                {
                    _observables.Remove(observable);
                }

                if (observable.GetType().Name.ToString() == "StackModel")
                {
                    if (Stacks.Contains((StackModel)observable))
                    {
                        Stacks.Remove((StackModel)observable);
                    }
                }
            }
        }

        public void SubscribeObject(ICustomObserver<Type> observer)
        {
            if (observer != null)
            {
                if (!_observers.Contains(observer))
                {
                    _observers.Add(observer);
                    observer.NewObservable(this);
                }

                //if (observer.GetType().Name.ToString() == "StackModel")
                //{
                //    if (!Stacks.Contains((StackModel)observer))
                //    {
                //        Stacks.Add((StackModel)observer);
                //    }
                //}
            }
        }

        public void UnsubscribeObject(ICustomObserver<Type> observer)
        {
            if (observer != null)
            {
                if (_observers.Contains(observer))
                {
                    //observer.ForgetObservable(this);
                    _observers.Remove(observer);
                    observer.ForgetObservable(this);
                }

                //if (observer.GetType().Name.ToString() == "StackModel")
                //{
                //    if (Stacks.Contains((StackModel)observer))
                //    {
                //        Stacks.Remove((StackModel)observer);
                //    }
                //}
            }
        }
    }
}
