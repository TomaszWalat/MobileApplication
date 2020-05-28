using FlashCardsApp.Misc;
using FlashCardsApp.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlashCardsApp.Model
{
    public class StackModel : ModelBase, ICustomObserver<Type>, ICustomObservable<Type>
    {
        private string _name;
        private string _description;

        private ObservableCollection<CardModel> _cards;
        private ObservableCollection<StackModel> _allStacks;

        private List<ICustomObservable<Type>> _observables;
        private List<ICustomObserver<Type>> _observers;

        public string Name
        {
            set 
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
            get { return _name; }
        }

        public string Description
        {
            set 
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
            get { return _description; }
        }

        public ObservableCollection<CardModel> Cards
        { 
            get { return _cards; }
        }

        public StackModel(string name, ObservableCollection<StackModel> allStacks, string description = "")
        {
            _name = name;
            _description = description;
            _allStacks = allStacks;
            _cards = new ObservableCollection<CardModel>();
            _observers = new List<ICustomObserver<Type>>();
            _observables = new List<ICustomObservable<Type>>();
        }

        public StackModel(string name, ObservableCollection<StackModel> allStacks, ObservableCollection<CardModel> cards, string description = "")
        {
            _name = name;
            _description = description;
            _allStacks = allStacks;
            _cards = cards;
            _observers = new List<ICustomObserver<Type>>();
            _observables = new List<ICustomObservable<Type>>();
        }

        //public void Add(CardModel c)
        //{
        //    if(c != null)
        //    {
        //        if(!Cards.Contains(c))
        //        {
        //            Cards.Add(c);
        //        }
        //    }
        //}

        //public void Remove(CardModel c)
        //{
        //    if(c != null)
        //    {
        //        if(Cards.Contains(c))
        //        {
        //            for(int i = Cards.Count - 1; i > -1; i--)//CardModel card in Cards)
        //            {
        //                if(Cards[i].Equals(c))
        //                {
        //                    Cards.RemoveAt(i);
        //                }
        //            }
        //        }
        //    }
        //}

        public void RemoveSelf()
        {
            //for(int i = Cards.Count - 1; i > -1; i--)
            //{
            //    if(Cards[i].Stacks.Contains(this))
            //    {
            //        Cards[i].Remove(this);
            //    }
            //}
            //Console.WriteLine("0 - This is: " + Name);
            //Console.WriteLine("1 - removing self from AllStacks");
            for (int i = _allStacks.Count; i > 0; i--)
            {
                if (_allStacks[i - 1].Equals(this))
                {
                    _allStacks.RemoveAt(i-1);
                }
            }
            //Console.WriteLine("2 - informing observers to remove me");
            for (int i = _observers.Count; i > 0; i--)
            {
                _observers[i - 1].ForgetObservable(this);
                //Console.WriteLine(_observers[i - 1].ToString());
            }
            //Console.WriteLine("3 - unsubscribing from observables");
            for (int i = _observables.Count; i > 0; i--)
            {
                //Console.WriteLine("observer " + i + ": " + _observables[i - 1].ToString());
                _observables[i - 1].UnsubscribeObject(this);
            }
            //Console.WriteLine("4 - all done removing myself, bye");
        }

        public void NewObservable(ICustomObservable<Type> observable)
        {
            if (observable != null)
            {
                if (!_observables.Contains(observable))
                {
                    _observables.Add(observable);
                }

                if (observable.GetType().Name.ToString() == "CardModel")
                {
                    if (!Cards.Contains((CardModel)observable))
                    {
                        Cards.Add((CardModel)observable);
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

                if (observable.GetType().Name.ToString() == "CardModel")
                {
                    if (Cards.Contains((CardModel)observable))
                    {
                        Cards.Remove((CardModel)observable);
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
            }
            //if (observer.GetType().Name.ToString() == "CardModel")
            //{
            //    if (!Cards.Contains((CardModel)observer))
            //    {
            //        Cards.Add((CardModel)observer);
            //    }
            //}
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
            }
            //if (observer.GetType().Name.ToString() == "CardModel")
            //{
            //    if (Cards.Contains((CardModel)observer))
            //    {
            //        Cards.Remove((CardModel)observer);
            //    }
            //}
        }
    }
}
